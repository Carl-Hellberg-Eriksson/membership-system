using MembershipSystem.Core.Interfaces;

namespace MembershipSystem.Infrastructure.Repository;
public class UnitOfWork : IUnitOfWork {
    private readonly DatabaseContext _context;
    public UnitOfWork(DatabaseContext context) {
        _context = context;
        Persons = new PersonRepository(_context);
    }
    public IPersonRepository Persons { get; private set; }

    public Task<int> SaveChangesAsync() {
        return _context.SaveChangesAsync();
    }

    public void Dispose() {
        _context.Dispose();
    }
}
