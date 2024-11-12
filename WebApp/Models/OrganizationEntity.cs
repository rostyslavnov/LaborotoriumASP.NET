using WebApp.Models.Services;

namespace WebApp.Models;

public class OrganizationEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NIP { get; set; }
    public string REGON { get; set; }
    public Adress Adress { get; set; }
    public ISet<ContactEntity> Contacts { get; set; }
    
}

public class Adress
{
    public string City { get; set; }
    public string Street { get; set; }
    
}