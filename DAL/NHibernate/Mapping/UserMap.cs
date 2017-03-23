using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            //Table("User");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.Email).Nullable();
            Map(x => x.Password).Nullable();
            Map(x => x.Age).Nullable();
            HasManyToMany(x => x.Roles).Cascade.All().Table("UsersRoles");
            HasMany(x => x.TestResults).KeyColumn("TestResultId").Inverse();
        }
    }
}
