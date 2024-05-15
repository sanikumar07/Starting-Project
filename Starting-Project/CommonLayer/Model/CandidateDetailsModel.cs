namespace Starting_Project.CommonLayer.Model
{
    public class CandidateDetailsRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public int IDNumber { get; set; }
        public string DOB { get; set; }
        public int Gender { get; set; }
        public string AboutYourself { get; set; }
        public int GraduationYear { get; set; }
        public List<int> MultipleChoice { get; set; }
        public bool RejectedByUK { get; set; }
        public double YearsOfExperienece { get; set; }
        public string MovedToUKDate { get; set; }
    }
    public class CandidateDetailsResponseModel
    {
        public string Message { get; set; }
    }
    
    public class CandidateQuestionsResponseModel
    {
        public string[] questions { get; set; }
    }
   
}
