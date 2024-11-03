namespace ERP.MVC.Domain.Entities.Base
{
    public class EntityBase
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
