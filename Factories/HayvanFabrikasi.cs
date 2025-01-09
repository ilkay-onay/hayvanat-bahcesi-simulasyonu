// hayvan fabrikası, hayvan nesnelerini oluşturur.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Models;

namespace HayvanatBahcesiSimulasyonu.Factories
{
    public class HayvanFabrikasi
    {
        public IHayvan HayvanYarat(HayvanTuru tur, Cinsiyet cinsiyet, int gridBoyutu, Random random)
        {
            switch (tur)
            {
                case HayvanTuru.Koyun:
                    return new Koyun(cinsiyet, gridBoyutu, random);
                case HayvanTuru.Inek:
                    return new Inek(cinsiyet, gridBoyutu, random);
                case HayvanTuru.Kurt:
                    return new Kurt(cinsiyet, gridBoyutu, random);
                case HayvanTuru.Aslan:
                    return new Aslan(cinsiyet, gridBoyutu, random);
                case HayvanTuru.Tavuk:
                    return new Tavuk(cinsiyet, gridBoyutu, random);
                case HayvanTuru.Avci:
                    return new Avci(gridBoyutu, random);
                default:
                    throw new ArgumentException($"bilinmeyen hayvan türü: {tur}");
            }
        }
    }
}
