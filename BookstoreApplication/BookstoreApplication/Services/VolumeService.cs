using System.Text.Json;
using BookstoreApplication.DTOs;
using BookstoreApplication.Connections;
using Microsoft.EntityFrameworkCore.Query.Internal;
using BookstoreApplication.Models;
using AutoMapper;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class VolumeService : IVolumeService
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        private readonly IComicVineConnection _comicVineConnection;
        private readonly IConfiguration _config;

        public VolumeService(IComicVineConnection comicVineConnection, IConfiguration configuration, IMapper mapper, IIssueRepository issueRepository)
        {
            _comicVineConnection = comicVineConnection;
            _config = configuration;
            _mapper = mapper;
            _issueRepository = issueRepository;
        }

        public async Task<List<VolumeDTO>> SearchVolumesByName(string filter)
        {
            var url = $"{_config["ComicVineBaseUrl"]}/volumes" +
              $"?api_key={_config["ComicVineAPIKey"]}" +
              $"&format=json" +
              $"&filter=name:{Uri.EscapeDataString(filter)}";

            var json = await _comicVineConnection.Get(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<VolumeDTO>>(json, options);
        }

        public async Task<List<IssueDTO>> GetIssuesByVolume(int volumeId)
        {
            var url = $"{_config["ComicVineBaseUrl"]}/issues" +
              $"?api_key={_config["ComicVineAPIKey"]}" +
              $"&format=json" +
              $"&filter=volume:{volumeId}";

            var json = await _comicVineConnection.Get(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<IssueDTO>>(json, options);
        }
        public async Task<Issue> SaveIssue(SaveIssueDTO dto)
        {
            var issue = _mapper.Map<Issue>(dto);
            issue.CoverDate = DateTime.SpecifyKind(issue.CoverDate, DateTimeKind.Utc);
            return await _issueRepository.AddAsync(issue);
        }
    }
}
