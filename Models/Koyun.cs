using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Koyun : Hayvan, IKurtSaldırabilir, IAslanSaldırabilir
    {
        public override int HareketMenzili => 2;

        public Koyun(Cinsiyet cinsiyet, int gridBoyutu, Random random)
            : base(HayvanTuru.Koyun, cinsiyet, gridBoyutu, random) { }
    }
}
