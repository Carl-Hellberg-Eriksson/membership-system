using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MembershipSystem.Infrastructure.Repository;
public class PersonRepository : GenericRepository<Person, int>, IPersonRepository {
    private readonly DbSet<Person> persons;

    public PersonRepository(DatabaseContext dbContext) : base(dbContext) {
        persons = dbContext.Persons;
    }

    public ICollection<Person> GetByFirstName(string firstName) {
        return persons.Where(p => EF.Functions.Like(p.FirstName, firstName + '%')).ToList();
    }

    public ICollection<Person> GetByLastName(string lastName) {
        return persons.Where(p => EF.Functions.Like(p.LastName, lastName + '%')).ToList();
    }
}
