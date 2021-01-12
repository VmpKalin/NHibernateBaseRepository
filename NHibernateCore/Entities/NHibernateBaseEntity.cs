namespace NHibernateCore.Entities
{
    public class NHibernateBaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
