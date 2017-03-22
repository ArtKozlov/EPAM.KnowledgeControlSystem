using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            //Table("Question");
            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Value).Column("Value").Nullable();
            Map(x => x.TestId).Column("TestId").Nullable();
            HasOne(x => x.Test).Cascade.All();
        }
    }
}
