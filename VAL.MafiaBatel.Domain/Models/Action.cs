namespace VAL.MafiaBatel.Domain.Models
{
    public class Action(string actionDescription)
    {
        public Guid ActionId { get; set; } = Guid.NewGuid();
        public string ActionDescription { get; private set; } = actionDescription;
    }
}
