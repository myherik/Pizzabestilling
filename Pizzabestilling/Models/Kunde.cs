namespace Pizzabestilling.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Telefon { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, navn:{Navn}, adresse:{Adresse}, telefon:{Telefon}";
        }
    }
}