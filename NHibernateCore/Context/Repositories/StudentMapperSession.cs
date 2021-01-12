using NHibernate;
using NHibernateCore.Entities;

namespace NHibernateCore.Context
{
    public interface IStudentMapperSession : IMapperSession<Student, int>
    {

    }

    public class StudentMapperSession : MapperSessionBase<Student, int>, IStudentMapperSession
    {
        public StudentMapperSession(ISession session) : base(session)
        {

        }
    }
}
