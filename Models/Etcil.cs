// etçil hayvanların özelliklerini ve avlanma davranışlarını içerir.
// etçil hayvanlar bu sınıftan türetilir.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Etcil(
        string tur,
        string cinsiyet,
        int hareketMenzili,
        List<string> avlar,
        int gridBoyutu,
        Random random
    ) : Hayvan(tur, cinsiyet, hareketMenzili, gridBoyutu, random), IEtcil
    {
        public List<string> Avlar { get; } = avlar;
        public override int AvlanmaMenzili { get; } =
            tur == "Kurt" ? 4
            : tur == "Aslan" ? 5
            : hareketMenzili; // türüne göre avlanma menzili belirle

        public IHayvan? Avla(IGrid grid)
        {
            var yakinHayvanlar = grid.YakinHayvanlariGetir(this, AvlanmaMenzili);
            var avlanabilirler = yakinHayvanlar
                .Where(h => Avlar.Contains(h.Tur)) // avlanabilir hayvanları filtrele
                .ToList();

            if (avlanabilirler.Count != 0)
            {
                return avlanabilirler[Random.Shared.Next(avlanabilirler.Count)]; // rastgele bir av seç
            }

            return null; // av bulunamadı
        }
    }
}
