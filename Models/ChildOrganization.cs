namespace Models;
/*Дочерняя организация*/
public class ChildOrganization:EntityBase
{
    public string Name { get; set; }    // Название
    public string Address { get; set; } // Адрес
    // Links
    public Organization ParentOrganization { get; set; } // Организация учредитель
    public List<ObjectOfConsumption> ObjectsOfConsumption { get; set; }
}