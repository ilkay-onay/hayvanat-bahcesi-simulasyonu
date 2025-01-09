// inek sınıfını tanımlar.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Inek : Hayvan, IAslanSaldırabilir
    {
        public Inek(Cinsiyet cinsiyet, int hareketMenzili, int gridBoyutu, Random random)
            : base("Inek", cinsiyet, hareketMenzili, gridBoyutu, random) { }
    }
}
