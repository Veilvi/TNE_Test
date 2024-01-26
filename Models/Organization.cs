namespace Models;
 /*Организация*/
public class Organization:EntityBase
{
 public string Name { get; set; }                                  // Наименование 
 public string Address { get; set; }                               // Адрес
 // Links
 public List<ChildOrganization> ChildOrganizations { get; set; }   // Дочерние организации
}