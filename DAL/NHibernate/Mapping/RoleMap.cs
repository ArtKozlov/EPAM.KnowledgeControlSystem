using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
           // Table("Role");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Nullable();
            Map(x => x.Description).Nullable();
            HasManyToMany(x => x.Users).Cascade.All().Inverse().Table("UsersRoles");
        }
    }
}
