using MembershipSystem.Core.Interfaces;

namespace MembershipSystem.Infrastructure.Repository;
public class UnitOfWork : IUnitOfWork {
    private readonly DatabaseContext context;

    public UnitOfWork(DatabaseContext context) {
        this.context = context;
        Persons = new PersonRepository(this.context.Persons);
    }

    public IPersonRepository Persons { get; private set; }

    public Task<int> SaveChangesAsync() {
        return context.SaveChangesAsync();
    }

    public void Dispose() {
        context.Dispose();
    }
}
