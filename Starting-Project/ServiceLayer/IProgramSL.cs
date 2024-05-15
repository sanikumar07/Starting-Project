using Starting_Project.CommonLayer.Model;

namespace Starting_Project.ServiceLayer
{
    public interface IProgramSL
    {
        public Task<ProgramDetailsResponseModel> AddProgramData(ProgramDetailsRequestModel programDetailsRequest);
        public Task<EditProgramDetailsResponseModel> EditEmployeeQuestions(int emp_id, EditProgramDetailsRequestModel programDetailsRequest);
    }
}
