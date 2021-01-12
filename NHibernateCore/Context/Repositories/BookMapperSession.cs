using NHibernate;
using NHibernateCore.Entities;
using System;

namespace NHibernateCore.Context
{
    public interface IBookMapperSession : IMapperSession<Book, Guid>
    {

    }

    public class BookMapperSession : MapperSessionBase<Book, Guid>, IBookMapperSession
    {
        public BookMapperSession(ISession session) : base(session)
        {

        }
    }
}
