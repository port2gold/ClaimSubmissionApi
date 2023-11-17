namespace ClaimSubmissionApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsRegisteredUser(string email);
    }
}
