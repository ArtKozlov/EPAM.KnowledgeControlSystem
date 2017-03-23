using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class TestMap : ClassMap<Test>
    {
        public TestMap()
        {
            //Table("Test");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.Time).Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.GoodAnswers).Nullable();
            Map(x => x.BadAnswers).Nullable();
            Map(x => x.IsValid).Nullable();
            Map(x => x.Creator).Nullable();
            HasMany(x => x.Answers).KeyColumn("AnswerId").Inverse();
            HasMany(x => x.Questions).KeyColumn("QuestionId").Inverse();
        }
    }
}
