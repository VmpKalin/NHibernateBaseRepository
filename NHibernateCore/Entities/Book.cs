using System;

namespace NHibernateCore.Entities
{
    public class Book : NHibernateBaseEntity<Guid>
    {
        public virtual string Title { get; set; }
    }
}
