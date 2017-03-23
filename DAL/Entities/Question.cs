namespace DAL.Entities
{
    public class Question
    {

        public virtual int Id { get; set; }
        
        public virtual string Value { get; set; }

        public virtual int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
