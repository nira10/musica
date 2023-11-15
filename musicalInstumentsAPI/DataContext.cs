using musicalInstumentsAPI.Entities;

namespace musicalInstumentsAPI
{
    public class DataContext
    {

        public int index { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<MusicalInstrumen> MusicaLInstrumentList { get; set; }
        public List<Provider> ProviderList { get; set; }

        public DataContext()
        {
            CustomersList = new List<Customers>();
            MusicaLInstrumentList = new List<MusicalInstrumen>();
            ProviderList = new List<Provider>();
           index=0;
        }
    }
}
