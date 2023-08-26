using MembershipSystem.Core.DatabaseEntities;

namespace MembershipSystem.Core.Interfaces;
public interface IPersonService {
    Task AddPersonAsync(Person person);

    Task<IEnumerable<Person>> GetAllPersonsAsync();
}
