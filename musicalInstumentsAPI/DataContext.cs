using The_piano_house.Entities;

namespace The_piano_house
{
    public class DataContext
    {

        public int index { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<MusicaLInstrument> MusicaLInstrumentList { get; set; }
        public List<Provider> ProviderList { get; set; }

        public DataContext()
        {
            CustomersList = new List<Customers>();
            MusicaLInstrumentList = new List<MusicaLInstrument>();
            ProviderList = new List<Provider>();
           index=0;
        }
    }
}
