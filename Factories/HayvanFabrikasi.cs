// hayvan nesnelerini oluşturmak için fabrika sınıfı.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Models;

namespace HayvanatBahcesiSimulasyonu.Factories
{
    public class HayvanFabrikasi
    {
        public IHayvan HayvanYarat(
            HayvanTuru tur,
            Cinsiyet cinsiyet,
            int hareketMenzili,
            int gridBoyutu,
            Random random
        )
        {
            switch (tur)
            {
                case HayvanTuru.Koyun:
                    return new Koyun(cinsiyet, hareketMenzili, gridBoyutu, random);
                case HayvanTuru.Inek:
                    return new Inek(cinsiyet, hareketMenzili, gridBoyutu, random);
                case HayvanTuru.Kurt:
                    return new Kurt(cinsiyet, hareketMenzili, gridBoyutu, random);
                case HayvanTuru.Aslan:
                    return new Aslan(cinsiyet, hareketMenzili, gridBoyutu, random);
                case HayvanTuru.Tavuk:
                    return new Tavuk(cinsiyet, hareketMenzili, gridBoyutu, random);
                default:
                    throw new ArgumentException($"bilinmeyen hayvan türü: {tur}");
            }
        }
    }
}
