using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;

namespace MembershipSystem.Infrastructure.Services;
public class PersonService : IPersonService {

    private readonly IUnitOfWork db;
    public PersonService(IUnitOfWork db) {
        this.db = db;
    }

    public async Task AddPersonAsync(Person person) {
        await db.Persons.AddAsync(person);
        await db.SaveChangesAsync();
    }

    public async Task UpdatePersonAsync(Person person) {
        await db.Persons.UpdateAsync(person);
        await db.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(Person person) {
        await db.Persons.DeleteAsync(person);
        await db.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(int id) {
        await db.Persons.DeleteAsync(id);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Person>> GetAllPersonsAsync() {
        return await db.Persons.GetAllAsync();
    }
    public async Task<IEnumerable<Person>> GetPersonsAsync(string firstName, string lastName) {
        return await db.Persons.GetAsync(firstName, lastName);
    }

    public async Task<Person> GetPersonByIdAsync(int id) {
        var person = await db.Persons.GetByIdAsync(id);
        if (person == null) {
            throw new Exception($"Person with id {id} does not exist.");
        }
        return person;
    }
}
