using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class TestResultMap : ClassMap<TestResult>
    {
        public TestResultMap()
        {
            //Table("TestResult");
            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Column("Name").Nullable();
            Map(x => x.DateComplete).Column("DateComplete").Nullable();
            Map(x => x.GoodAnswers).Column("GoodAnswers").Nullable();
            Map(x => x.BadAnswers).Column("BadAnswers").Nullable();
            Map(x => x.UserId).Column("UserId").Nullable();
          //  HasOne(x => x.User).Cascade.All();
        }
    }
}
