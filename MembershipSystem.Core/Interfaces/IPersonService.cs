using MembershipSystem.Core.DatabaseEntities;

namespace MembershipSystem.Core.Interfaces;
public interface IPersonService {
    Task AddPersonAsync(Person person);
    Task UpdatePersonAsync(Person person);
    Task DeletePersonAsync(Person person);
    Task DeletePersonAsync(int id);
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<IEnumerable<Person>> GetPersonsAsync(string firstName, string lastName);
    Task<Person> GetPersonByIdAsync(int id);
}
