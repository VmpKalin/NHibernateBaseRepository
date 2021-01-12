namespace NHibernateCore.Entities
{
    public class Student : NHibernateBaseEntity<int>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
