using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MembershipSystem.Infrastructure.Repository;
public class PersonRepository : GenericRepository<Person, int>, IPersonRepository {
    private readonly DbSet<Person> persons;

    public PersonRepository(DatabaseContext dbContext) : base(dbContext) {
        persons = dbContext.Persons;
    }

    public Task<List<Person>> GetAsync(string firstName, string lastName) {
        return persons.Where(p =>
            EF.Functions.Like(p.FirstName, firstName + '%') &&
            EF.Functions.Like(p.LastName, lastName + '%')
            ).ToListAsync();
    }
}
