namespace Arboretum.Web.Models
{
    public class Card
    {
        public int Number { get; set; }
        public Suit TreeType { get; set; }

        public bool IsValid()
        {
            return Number > 0 && Number <= 8;
        }
    }
}