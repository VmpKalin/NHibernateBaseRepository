using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace NHibernateCore.Entities.Mapping
{
    public class StudentMap : ClassMapping<Student>
    {
        public StudentMap()
        {
            Table("Student");

            Id(x => x.Id, x =>
            {
                 x.Generator(Generators.Identity);
                 x.Type(NHibernateUtil.Int32);
                 x.Column("Id");
            });

            Property(x => x.FirstName, x =>
            {
                x.Type(NHibernateUtil.StringClob);
            });

            Property(x => x.LastName, x =>
            {
                x.Type(NHibernateUtil.StringClob);
            });
        }
    }
}
