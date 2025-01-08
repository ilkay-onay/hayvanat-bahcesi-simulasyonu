// grid yapısının interface'ini tanımlar.
// grid üzerindeki işlemler bu arayüz üzerinden yönetilir.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IGrid
    {
        int GridBoyutu { get; }
        void HayvanEkle(IHayvan hayvan);
        void HayvanSil(IHayvan hayvan);
        List<IHayvan> YakinHayvanlariGetir(IHayvan hayvan, int menzil);
        void HayvanKonumGuncelle(IHayvan hayvan, int eskiX, int eskiY);
    }
}
