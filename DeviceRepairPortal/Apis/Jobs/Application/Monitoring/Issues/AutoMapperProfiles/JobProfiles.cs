using Application.Monitoring.Issues.Dtos;
using AutoMapper;
using Domain.Entities;

public class IssuesProfiles : Profile
{
    public IssuesProfiles()
    {
        CreateMap<Issue, IssueDto>();
    }
}
