// tavuk sınıfını tanımlar.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Tavuk : Hayvan, IKurtSaldırabilir
    {
        public Tavuk(Cinsiyet cinsiyet, int hareketMenzili, int gridBoyutu, Random random)
            : base("Tavuk", cinsiyet, hareketMenzili, gridBoyutu, random) { }
    }
}
