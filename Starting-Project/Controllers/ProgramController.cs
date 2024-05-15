using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starting_Project.CommonLayer.Model;
using Starting_Project.ServiceLayer;

namespace Starting_Project.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        public readonly IProgramSL _IProgramSL;
        public ProgramController(IProgramSL programSL)
        {
            _IProgramSL = programSL;
        }

        [HttpPost("AddProgramData")]
        public async Task<IActionResult> AddProgramData([FromBody]ProgramDetailsRequestModel programDetailsRequest)
        {
            if (string.IsNullOrEmpty(programDetailsRequest.ProgramTitle) && string.IsNullOrEmpty(programDetailsRequest.ProgramDescription))
            {
                return StatusCode(401, "Program Title and description cannot be empty");
            }

            ProgramDetailsResponseModel oResponse = new ProgramDetailsResponseModel();

            oResponse = await _IProgramSL.AddProgramData(programDetailsRequest);


            return Ok(oResponse);
        }

        [HttpPut("EditEmployeeQuestions/{emp_id}")]
        public async Task<IActionResult> EditEmployeeQuestions(int emp_id, [FromBody] EditProgramDetailsRequestModel programDetailsRequest)
        {

                var response = await _IProgramSL.EditEmployeeQuestions(emp_id, programDetailsRequest);

                return Ok(response);
           
        }
    }
}
