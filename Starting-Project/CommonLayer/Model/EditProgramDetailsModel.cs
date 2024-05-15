namespace Starting_Project.CommonLayer.Model
{
    public class EditProgramDetailsRequestModel
    {
        public List<EditQuestionsList> questions { get; set; }
    }

    public class EditProgramDetailsResponseModel
    {
        public string message { get; set; }
    }

    public class EditQuestionsList
    {

        public EditQuestionType Type { get; set; }
        public string Question { get; set; }
    }
    public enum EditQuestionType
    {
        Paragraph = 1,
        YesNo = 2,
        Dropdown = 3,
        MultipleChoice = 4,
        Date = 5,
        Number = 6
    }
}
