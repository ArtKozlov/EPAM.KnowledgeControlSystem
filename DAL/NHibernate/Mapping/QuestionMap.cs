using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            //Table("Question");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Value).Nullable();
            Map(x => x.TestId).Nullable();
            References(x => x.Test).Column("TestId");
        }
    }
}
