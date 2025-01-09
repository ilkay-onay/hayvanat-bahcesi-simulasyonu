// koyun sınıfını tanımlar.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Koyun : Hayvan, IKurtSaldırabilir, IAslanSaldırabilir
    {
        public Koyun(Cinsiyet cinsiyet, int hareketMenzili, int gridBoyutu, Random random)
            : base("Koyun", cinsiyet, hareketMenzili, gridBoyutu, random) { }
    }
}
