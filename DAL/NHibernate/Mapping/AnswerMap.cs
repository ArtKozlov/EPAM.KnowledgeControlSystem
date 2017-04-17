using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class AnswerMap : ClassMap<Answer>
    {
        public AnswerMap()
        {
            //Table("Answer");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Value).Nullable();
            References(x => x.Test).Not.Nullable();
        }
    }
}
