using Starting_Project.CommonLayer.Model;

namespace Starting_Project.ServiceLayer
{
    public interface ICandidateSL
    {
        public Task<CandidateDetailsResponseModel> AddCandidateData(CandidateDetailsRequestModel candidatedetailsRequest);
        public Task<CandidateQuestionsResponseModel> GetProgramQuestions();
    }
}
