using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            //Table("User");
            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Column("Name").Nullable();
            Map(x => x.Email).Column("Email").Nullable();
            Map(x => x.Password).Column("Password").Nullable();
            Map(x => x.Age).Column("Age").Nullable();
           // HasMany(x => x.Roles).Inverse().Cascade.All();
           // HasMany(x => x.TestResults).Inverse().Cascade.All();
        }
    }
}
