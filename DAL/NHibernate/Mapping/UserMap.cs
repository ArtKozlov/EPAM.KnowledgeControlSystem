using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.Email).Nullable();
            Map(x => x.Password).Nullable();
            Map(x => x.Age).Nullable();
            HasManyToMany(x => x.Roles).Table("UsersRoles").ParentKeyColumn("user_fk")
                .ChildKeyColumn("role_fk").Inverse().Cascade.All();
            HasMany(x => x.TestResults).Cascade.All().AsBag();
        }
    }
}
