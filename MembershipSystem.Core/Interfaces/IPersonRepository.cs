using MembershipSystem.Core.DatabaseEntities;

namespace MembershipSystem.Core.Interfaces;
public interface IPersonRepository : IRepository<Person, int> {

    public ICollection<Person> GetByFirstName(string firstName);
    public ICollection<Person> GetByLastName(string firstName);
}
