namespace musicalInstumentsAPI.Entities
{
    public class MusicalInstrumen
    {
        public int code { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public int costPrice { get; set; }
        public int purchasePrice { get; set; }
        public int stockpile { get; set; }
        public int providerCode { get; set; }
    }
}
