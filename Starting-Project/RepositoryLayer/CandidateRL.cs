using MySqlConnector;
using Newtonsoft.Json;
using Starting_Project.CommonLayer.Model;
using System.Data;
using System.Text.Json;

namespace Starting_Project.RepositoryLayer
{
    public class CandidateRL : ICandidateRL
    {
        public readonly IConfiguration _IConfiguration;
        public readonly MySqlConnection _mySqlConnection;

        public CandidateRL(IConfiguration configuration)
        {
            _IConfiguration = configuration;
            _mySqlConnection = new MySqlConnection(_IConfiguration["ConnectionStrings:DBConnectionString"]);
        }
        public async Task<CandidateDetailsResponseModel> AddCandidateData(CandidateDetailsRequestModel candidatedetailsRequest)
        {
            CandidateDetailsResponseModel response = new CandidateDetailsResponseModel();

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }



                string multipleChoiceJson = System.Text.Json.JsonSerializer.Serialize(candidatedetailsRequest.MultipleChoice);

                using (MySqlCommand cmd = new MySqlCommand("sp_add_candidate_data", _mySqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@emp_first_name_in", candidatedetailsRequest.FirstName);
                    cmd.Parameters.AddWithValue("@emp_last_name_in", candidatedetailsRequest.LastName);
                    cmd.Parameters.AddWithValue("@emp_email_in", candidatedetailsRequest.Email);
                    cmd.Parameters.AddWithValue("@emp_phone_in", candidatedetailsRequest.Phone);
                    cmd.Parameters.AddWithValue("@emp_nantionality_in", candidatedetailsRequest.Nationality);
                    cmd.Parameters.AddWithValue("@current_residence_in", candidatedetailsRequest.Residence);
                    cmd.Parameters.AddWithValue("@id_number_in", candidatedetailsRequest.IDNumber);
                    cmd.Parameters.AddWithValue("@emp_dob_in", candidatedetailsRequest.DOB);
                    cmd.Parameters.AddWithValue("@gender_in", candidatedetailsRequest.Gender);
                    cmd.Parameters.AddWithValue("@about_yourself_in", candidatedetailsRequest.AboutYourself);
                    cmd.Parameters.AddWithValue("@graduation_year_in", candidatedetailsRequest.GraduationYear);
                    cmd.Parameters.AddWithValue("@multiple_choice_in", multipleChoiceJson);
                    cmd.Parameters.AddWithValue("@rejected_by_uk_in", candidatedetailsRequest.RejectedByUK);
                    cmd.Parameters.AddWithValue("@years_of_exp_in", candidatedetailsRequest.YearsOfExperienece);
                    cmd.Parameters.AddWithValue("@moved_to_uk_in", candidatedetailsRequest.MovedToUKDate);    


                    cmd.Parameters.AddWithValue("@response_msg", "Candidate details added successfully.").Direction = ParameterDirection.Output;

                    await cmd.ExecuteNonQueryAsync();
                    response.Message = cmd.Parameters["@response_msg"].Value.ToString();

                }



            }
            catch (Exception ex)
            {
                response.Message += ex.ToString();
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
            }
            return response;
        }


        public async Task<CandidateQuestionsResponseModel> GetProgramQuestions()
        {
            CandidateQuestionsResponseModel response = new CandidateQuestionsResponseModel();
           // List<string> questionsList = new List<string>();

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand cmd = new MySqlCommand("sp_get_questions", _mySqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string question = reader.GetString(0);
                            response.questions = JsonConvert.DeserializeObject<string[]>(question);// Assuming question is stored as a string in the first column
                           // questionsList.Add(question);
                        }
                    }
                    await cmd.ExecuteNonQueryAsync();
                  
                }

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
            }
            return response;
        }

    }
}
