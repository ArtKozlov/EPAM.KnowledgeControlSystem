using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class TestResultMap : ClassMap<TestResult>
    {
        public TestResultMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.DateComplete).Nullable();
            Map(x => x.GoodAnswers).Nullable();
            Map(x => x.BadAnswers).Nullable();
            References(x => x.User).Not.Nullable();
        }
    }
}
