// avcının özelliklerini ve avlanma davranışlarını içerir.
// avcı, diğer hayvanları avlayabilir.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Avci(int gridBoyutu, Random random)
        : Hayvan("Avcı", "Yok", 1, gridBoyutu, random),
            IAvci
    {
        public override int AvlanmaMenzili => 8; // avcının avlanma menzili

        public IHayvan? Avla(IGrid grid)
        {
            var yakinHayvanlar = grid.YakinHayvanlariGetir(this, AvlanmaMenzili);
            var avlanabilirler = yakinHayvanlar
                .Where(h => h != this) // kendini avlama
                .ToList();

            if (avlanabilirler.Count != 0)
            {
                return avlanabilirler[Random.Shared.Next(avlanabilirler.Count)]; // rastgele bir av seç
            }

            return null; // av bulunamadı
        }
    }
}
