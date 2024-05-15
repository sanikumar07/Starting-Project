using System.ComponentModel;

namespace Starting_Project.CommonLayer.Model
{
    public class ProgramDetailsRequestModel
    {
     
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string Nationality {  get; set; }
        public string Residence { get; set; }
        public int IDNumber {  get; set; }
        public string DOB { get; set; }
        public int Gender { get; set; }

        public List<QuestionsList> questions { get; set; }
    }

    public class ProgramDetailsResponseModel
    {
        public string Message { get; set; }
    }

    public class QuestionsList
    {
     
        public QuestionType Type { get; set; }
        public string Question { get; set; }
    }
    public enum QuestionType
    {
        Paragraph = 1,
        YesNo = 2,
        Dropdown = 3,
        MultipleChoice = 4,
        Date = 5,
        Number = 6
    }




}
