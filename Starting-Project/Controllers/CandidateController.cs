using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starting_Project.CommonLayer.Model;
using Starting_Project.RepositoryLayer;
using Starting_Project.ServiceLayer;

namespace Starting_Project.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public readonly ICandidateSL _ICandidateSL;
        public CandidateController(ICandidateSL candidateSL)
        {
            _ICandidateSL = candidateSL;
        }

        [HttpPost("AddCandidateData")]
        public async Task<IActionResult> AddCandidateData([FromBody] CandidateDetailsRequestModel candidateDetailsRequest)
        {

            CandidateDetailsResponseModel oResponse = new CandidateDetailsResponseModel();

            oResponse = await _ICandidateSL.AddCandidateData(candidateDetailsRequest);


            return Ok(oResponse);
        }


        [HttpGet("GetProgramQuestions")]
        public async Task<CandidateQuestionsResponseModel> GetProgramQuestions()
        {
            CandidateQuestionsResponseModel OData = new CandidateQuestionsResponseModel();
           return OData = await _ICandidateSL.GetProgramQuestions();
            
        }
    }
}
