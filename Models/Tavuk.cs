using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Tavuk : Hayvan, IKurtSaldırabilir
    {
        public override int HareketMenzili => 1;

        public Tavuk(Cinsiyet cinsiyet, int gridBoyutu, Random random)
            : base(HayvanTuru.Tavuk, cinsiyet, gridBoyutu, random) { }
    }
}
