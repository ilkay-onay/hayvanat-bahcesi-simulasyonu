// avlanma yöneticisi, hayvanların avlanma işlemlerini yönetir.

using HayvanatBahcesiSimulasyonu.Enums;

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
                            string avlananTur = avlanan.Tur;
                            if (
                                avlanan.Tur == HayvanTuru.Tavuk.ToString()
                                && avlanan.Cinsiyet == Cinsiyet.Erkek
                            )
                            {
                                avlananTur = "Horoz";
                            }
                            _hayvanYoneticisi.HayvanSil(avlanan);
                            Console.WriteLine($"[adım {adim}] {etcil.Tur}, {avlananTur} avladı.");
                        }
                    }
                    else if (hayvan is IAvci avci)
                    {
                        var avlanan = avci.Avla(_hayvanYoneticisi.Grid);
                        if (avlanan != null)
                        {
                            string avlananTur = avlanan.Tur;
                            if (
                                avlanan.Tur == HayvanTuru.Tavuk.ToString()
                                && avlanan.Cinsiyet == Cinsiyet.Erkek
                            )
                            {
                                avlananTur = "Horoz";
                            }
                            _hayvanYoneticisi.HayvanSil(avlanan);
                            Console.WriteLine($"[adım {adim}] avcı, {avlananTur} avladı.");
                        }
                    }
                }
            );
        }
    }
}
