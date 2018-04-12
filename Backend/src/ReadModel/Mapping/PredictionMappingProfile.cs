using AutoMapper;
using Domain.Models;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Predictions.Dtos;

namespace ReadModel.Mapping
{
    public class PredictionMappingProfile : Profile
    {
        public PredictionMappingProfile()
        {
            CreateMap<Prediction, PredictionMinimalInfoReadDto>();
        }
    }
}
