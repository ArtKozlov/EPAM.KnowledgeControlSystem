using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.NHibernate.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            //Table("Role");
            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name).Column("Name").Nullable();
            Map(x => x.Description).Column("Description").Nullable();
          //  HasMany(x => x.Users).Inverse().Cascade.All();
        }
    }
}
