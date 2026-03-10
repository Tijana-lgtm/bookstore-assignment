using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public interface IIssueRepository
    {
        Task<Issue> AddAsync(Issue issue);
    }
}
