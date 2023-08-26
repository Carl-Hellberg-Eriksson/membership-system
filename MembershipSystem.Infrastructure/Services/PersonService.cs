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

    public async Task<IEnumerable<Person>> GetAllPersonsAsync() {
        return await db.Persons.GetAllAsync();
    }
}
