using Starting_Project.CommonLayer.Model;

namespace Starting_Project.RepositoryLayer
{
    public interface IProgramRL
    {
        public Task<ProgramDetailsResponseModel> AddProgramData(ProgramDetailsRequestModel programDetailsRequest);
        public Task<EditProgramDetailsResponseModel> EditEmployeeQuestions(int emp_id, EditProgramDetailsRequestModel programDetailsRequest);
    }
}
