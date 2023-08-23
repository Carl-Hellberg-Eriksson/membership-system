namespace MembershipSystem.Core.Interfaces;
public interface IUnitOfWork : IDisposable {
    IPersonRepository Persons { get; }
    Task<int> SaveChangesAsync();
}
