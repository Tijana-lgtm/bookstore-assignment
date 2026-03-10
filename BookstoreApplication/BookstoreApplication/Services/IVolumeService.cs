using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IVolumeService
    {
        Task<List<VolumeDTO>> SearchVolumesByName(string filter);
        Task<List<IssueDTO>> GetIssuesByVolume(int volumeId);
        Task<Issue> SaveIssue(SaveIssueDTO dto);
    }
}
