using MySqlConnector;
using Newtonsoft.Json;
using Starting_Project.CommonLayer.Model;
using System.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Starting_Project.RepositoryLayer
{
    public class ProgramRL : IProgramRL
    {
        public readonly IConfiguration _IConfiguration;
        public readonly MySqlConnection _mySqlConnection;

        public ProgramRL(IConfiguration configuration)
        {
            _IConfiguration = configuration;
            _mySqlConnection = new MySqlConnection(_IConfiguration["ConnectionStrings:DBConnectionString"]);
        }
        public async Task<ProgramDetailsResponseModel> AddProgramData(ProgramDetailsRequestModel programDetailsRequest)
        {
            ProgramDetailsResponseModel response = new ProgramDetailsResponseModel();

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

               

                string questionTypesJson = JsonConvert.SerializeObject(programDetailsRequest.questions.Select(q => (int)q.Type));
                string questionsJson = JsonConvert.SerializeObject(programDetailsRequest.questions.Select(q => q.Question));

                using (MySqlCommand cmd = new MySqlCommand("sp_add_program_data", _mySqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@program_title_in", programDetailsRequest.ProgramTitle);
                    cmd.Parameters.AddWithValue("@program_description_in", programDetailsRequest.ProgramDescription);
                    cmd.Parameters.AddWithValue("@emp_first_name_in", programDetailsRequest.FirstName);
                    cmd.Parameters.AddWithValue("@emp_last_name_in", programDetailsRequest.LastName);
                    cmd.Parameters.AddWithValue("@emp_email_in", programDetailsRequest.Email);
                    cmd.Parameters.AddWithValue("@emp_phone_in", programDetailsRequest.Phone);
                    cmd.Parameters.AddWithValue("@emp_nantionality_in", programDetailsRequest.Nationality);
                    cmd.Parameters.AddWithValue("@current_residence_in", programDetailsRequest.Residence);
                    cmd.Parameters.AddWithValue("@id_number_in", programDetailsRequest.IDNumber);
                    cmd.Parameters.AddWithValue("@emp_dob_in", programDetailsRequest.DOB);
                    cmd.Parameters.AddWithValue("@gender_in", programDetailsRequest.Gender);
                    cmd.Parameters.AddWithValue("@question_type_in", questionTypesJson);
                    cmd.Parameters.AddWithValue("@question_in", questionsJson);

                  cmd.Parameters.AddWithValue("@response_msg", "Program details added successfully.").Direction = ParameterDirection.Output;

                    await cmd.ExecuteNonQueryAsync();
                    response.Message = cmd.Parameters["@response_msg"].Value.ToString();

                }

               

            }
            catch(Exception ex) 
            {
              response.Message += ex.ToString();
            }
            finally
            {
               await  _mySqlConnection.CloseAsync();
            }
            return response;
        }



        public async Task<EditProgramDetailsResponseModel> EditEmployeeQuestions(int emp_id, EditProgramDetailsRequestModel programDetailsRequest)
        {
            EditProgramDetailsResponseModel response = new EditProgramDetailsResponseModel();

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                string questionTypesJson = JsonConvert.SerializeObject(programDetailsRequest.questions.Select(q => (int)q.Type));
                string questionsJson = JsonConvert.SerializeObject(programDetailsRequest.questions.Select(q => q.Question));


                using (MySqlCommand cmd = new MySqlCommand("sp_edit_program_data", _mySqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id_in", emp_id);
                    cmd.Parameters.AddWithValue("@question_type_in", questionTypesJson);
                    cmd.Parameters.AddWithValue("@question_in", questionsJson);



                   
                    await cmd.ExecuteNonQueryAsync();
                    response.message = "Program details updated successfully.";
                }

              

            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
            }

            return response;
        }


    }
}
