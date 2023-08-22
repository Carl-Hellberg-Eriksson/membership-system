using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Core.DomainEntities;
public class Person {
    public int Id { get; set; }
    [MaxLength(255)]
    public string FirstName { get; set; }
    [MaxLength(255)]
    public string LastName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    [MaxLength(255)]
    public string? EmailAddress { get; set; }
    [MaxLength(255)]
    public string? PhoneNumber { get; set; }
    [MaxLength(255)]
    public string? AddressRow1 { get; set; }
    [MaxLength(255)]
    public string? AddressRow2 { get; set; }
    [MaxLength(255)]
    public string? AddressRow3 { get; set; }
    [MaxLength(255)]
    public string? AddressRow4 { get; set; }
    public DateTimeOffset? MembershipExpirationDate { get; set; }
}
