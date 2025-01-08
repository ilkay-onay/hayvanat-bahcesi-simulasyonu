// hayvanların avlanma işlemlerini yönetir.
// etçil hayvanlar ve avcı, diğer hayvanları avlar.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class AvlanmaYoneticisi(HayvanYoneticisi hayvanYoneticisi)
    {
        private readonly HayvanYoneticisi _hayvanYoneticisi = hayvanYoneticisi;

        public void AvlanmaIslemi(int adim)
        {
            var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

            Parallel.ForEach(
                hayvanlar,
                hayvan =>
                {
                    if (hayvan is IEtcil etcil)
                    {
                        var avlanan = etcil.Avla(_hayvanYoneticisi.Grid);
                        if (avlanan != null)
                        {
                            _hayvanYoneticisi.HayvanSil(avlanan); // avlanan hayvanı sil
                            Console.WriteLine($"[adım {adim}] {etcil.Tur}, {avlanan.Tur} avladı.");
                        }
                    }
                    else if (hayvan is IAvci avci)
                    {
                        var avlanan = avci.Avla(_hayvanYoneticisi.Grid);
                        if (avlanan != null)
                        {
                            _hayvanYoneticisi.HayvanSil(avlanan); // avlanan hayvanı sil
                            Console.WriteLine($"[adım {adim}] avcı, {avlanan.Tur} avladı.");
                        }
                    }
                }
            );
        }
    }
}
