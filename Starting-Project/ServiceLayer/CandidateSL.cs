using Starting_Project.CommonLayer.Model;
using Starting_Project.RepositoryLayer;

namespace Starting_Project.ServiceLayer
{
    public class CandidateSL : ICandidateSL
    {
        public readonly ICandidateRL _ICandidateRL;

        public CandidateSL(ICandidateRL candidateRL)
        {
            _ICandidateRL = candidateRL;
        }

        public async Task<CandidateDetailsResponseModel> AddCandidateData(CandidateDetailsRequestModel candidatedetailsRequest)
        {
            return await _ICandidateRL.AddCandidateData(candidatedetailsRequest);
        }
        public async Task<CandidateQuestionsResponseModel> GetProgramQuestions()
        {
            return await _ICandidateRL.GetProgramQuestions();
        }
    }
}
