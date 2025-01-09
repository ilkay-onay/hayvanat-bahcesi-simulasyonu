// üreme yöneticisi, hayvanların üreme işlemlerini yönetir.

using System.Collections.Concurrent;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Factories;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class UremeYoneticisi(HayvanYoneticisi hayvanYoneticisi, HayvanFabrikasi hayvanFabrikasi)
    {
        private readonly HayvanYoneticisi _hayvanYoneticisi = hayvanYoneticisi;
        private readonly HayvanFabrikasi _hayvanFabrikasi = hayvanFabrikasi;

        public void UremeIslemi()
        {
            var yeniHayvanlar = new ConcurrentBag<IHayvan>();
            var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

            var turGruplari = hayvanlar.Where(h => h.Cinsiyet != Cinsiyet.Yok).GroupBy(h => h.Tur);

            Parallel.ForEach(
                turGruplari,
                grup =>
                {
                    var erkekler = grup.Where(h => h.Cinsiyet == Cinsiyet.Erkek).ToList();
                    var disiler = grup.Where(h => h.Cinsiyet == Cinsiyet.Disi).ToList();

                    foreach (var erkek in erkekler)
                    {
                        foreach (var disi in disiler)
                        {
                            if (erkek.UzaklikHesapla(disi) <= 3.0)
                            {
                                Cinsiyet yeniCinsiyet =
                                    Random.Shared.Next(2) == 0 ? Cinsiyet.Erkek : Cinsiyet.Disi;

                                if (Enum.TryParse(erkek.Tur, out HayvanTuru tur))
                                {
                                    var yeniHayvan = _hayvanFabrikasi.HayvanYarat(
                                        tur,
                                        yeniCinsiyet,
                                        _hayvanYoneticisi.Grid.GridBoyutu,
                                        Random.Shared
                                    );
                                    if (yeniHayvan != null)
                                    {
                                        yeniHayvanlar.Add(yeniHayvan);
                                        string outputTur = yeniHayvan.Tur;
                                        if (
                                            yeniHayvan.Tur == HayvanTuru.Tavuk.ToString()
                                            && yeniHayvan.Cinsiyet == Cinsiyet.Erkek
                                        )
                                        {
                                            outputTur = "Horoz";
                                        }
                                        Console.WriteLine($"yeni {outputTur} doğdu.");
                                    }
                                }
                            }
                        }
                    }
                }
            );
            foreach (var yeniHayvan in yeniHayvanlar)
            {
                _hayvanYoneticisi.HayvanEkle(yeniHayvan);
            }
        }
    }
}
