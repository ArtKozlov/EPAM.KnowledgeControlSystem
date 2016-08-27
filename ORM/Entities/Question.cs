
namespace ORM.Entities
{
    public class Question
    {

        public int Id { get; set; }
        
        public string Value { get; set; }

        public int? TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
