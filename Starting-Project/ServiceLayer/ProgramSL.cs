using Starting_Project.CommonLayer.Model;
using Starting_Project.RepositoryLayer;

namespace Starting_Project.ServiceLayer
{
    public class ProgramSL : IProgramSL
    {
        public readonly IProgramRL _IProgramRL;
        public ProgramSL(IProgramRL programRL)
        {
            _IProgramRL = programRL;
        }

        public async Task<ProgramDetailsResponseModel> AddProgramData(ProgramDetailsRequestModel programDetailsRequest)
        {
            return await _IProgramRL.AddProgramData(programDetailsRequest);
        }


        public async Task<EditProgramDetailsResponseModel> EditEmployeeQuestions(int emp_id, EditProgramDetailsRequestModel programDetailsRequest)
        {
            return await _IProgramRL.EditEmployeeQuestions(emp_id, programDetailsRequest);
        }

    }
}
