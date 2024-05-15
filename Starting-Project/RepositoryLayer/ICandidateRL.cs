﻿using Starting_Project.CommonLayer.Model;

namespace Starting_Project.RepositoryLayer
{
    public interface ICandidateRL
    {
       public Task<CandidateDetailsResponseModel> AddCandidateData(CandidateDetailsRequestModel candidatedetailsRequest);
        public Task<CandidateQuestionsResponseModel> GetProgramQuestions();
    }
}
