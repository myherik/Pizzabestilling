namespace Pizzabestilling.Models
{
    public class Bestilling
    {
        public int Id { get; set; }
        public string Pizzatype { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
        public virtual Kunde Kunde { get; set; }
        public override string ToString()
        {
            return $"id:{Id}, pizzatype:{Pizzatype}, tykkelse:{Tykkelse}, antall:{Antall}, kunde:{Kunde}";
        }
    }
}