// hayvanların interface'ini tanımlar.
// tüm hayvan türleri bu arayüzü uygular.
namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IHayvan
    {
        string Tur { get; }
        string Cinsiyet { get; }
        int X { get; }
        int Y { get; }
        int HareketMenzili { get; }
        int AvlanmaMenzili { get; }

        void HareketEt(IGrid grid, Random random);
        double UzaklikHesapla(IHayvan diger);
    }
}
