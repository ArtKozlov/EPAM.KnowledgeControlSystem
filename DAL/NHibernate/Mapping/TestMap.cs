using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class TestMap : ClassMap<Test>
    {
        public TestMap()
        {
            //Table("Test");
            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Column("Name").Nullable();
            Map(x => x.Time).Column("Time").Nullable();
            Map(x => x.Description).Column("Description").Nullable();
            Map(x => x.GoodAnswers).Column("GoodAnswers").Nullable();
            Map(x => x.BadAnswers).Column("BadAnswers").Nullable();
            Map(x => x.IsValid).Column("IsValid").Nullable();
            Map(x => x.Creator).Column("Creator").Nullable();
          //  HasMany(x => x.Answers).Cascade.All();
          //  HasMany(x => x.Questions).Cascade.All();
        }
    }
}
