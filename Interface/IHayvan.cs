// hayvan interface'i, hayvan davranışlarını tanımlar.
using HayvanatBahcesiSimulasyonu.Enums;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IHayvan
    {
        string Tur { get; }
        Cinsiyet Cinsiyet { get; }
        int X { get; }
        int Y { get; }
        int HareketMenzili { get; }
        int AvlanmaMenzili { get; }

        void HareketEt(IGrid grid, Random random);
        double UzaklikHesapla(IHayvan diger);
    }
}
