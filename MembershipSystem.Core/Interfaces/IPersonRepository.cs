using MembershipSystem.Core.DatabaseEntities;

namespace MembershipSystem.Core.Interfaces;
public interface IPersonRepository : IRepository<Person, int> {

    public Task<List<Person>> GetAsync(string firstName, string lastName);
}
