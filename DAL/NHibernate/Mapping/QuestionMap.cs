using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Value).Nullable();
            References(x => x.Test);
        }
    }
}
