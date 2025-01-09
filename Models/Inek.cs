using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Inek : Hayvan, IAslanSaldırabilir
    {
        public override int HareketMenzili => 2;

        public Inek(Cinsiyet cinsiyet, int gridBoyutu, Random random)
            : base(HayvanTuru.Inek, cinsiyet, gridBoyutu, random) { }
    }
}
