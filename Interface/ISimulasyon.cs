// simülasyonun interface'ini tanımlar.
// simülasyonun temel işlemleri bu arayüz üzerinden yönetilir.
namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface ISimulasyon
    {
        void HayvanEkle(
            string tur,
            int adet,
            string cinsiyet,
            int hareketMenzili,
            List<string>? avlar = null
        );
        void AvciEkle();
        void Calistir();
    }
}
