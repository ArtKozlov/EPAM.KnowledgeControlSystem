using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.Description).Nullable();
            HasManyToMany(x => x.Users).ParentKeyColumn("role_fk")
                .ChildKeyColumn("user_fk").Table("UsersRoles").Inverse().Cascade.All();
        }
    }
}
