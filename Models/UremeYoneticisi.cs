// hayvanların üreme işlemlerini yönetir.
// yakın hayvanlar arasında üreme gerçekleştirilir.
using System.Collections.Concurrent;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class UremeYoneticisi(HayvanYoneticisi hayvanYoneticisi)
    {
        private readonly HayvanYoneticisi _hayvanYoneticisi = hayvanYoneticisi;

        public void UremeIslemi()
        {
            var yeniHayvanlar = new ConcurrentBag<IHayvan>();
            var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

            var turGruplari = hayvanlar
                .Where(h => h.Cinsiyet != "Yok") // cinsiyeti olan hayvanları filtrele
                .GroupBy(h => h.Tur); // türlerine göre grupla

            Parallel.ForEach(
                turGruplari,
                grup =>
                {
                    var erkekler = grup.Where(h => h.Cinsiyet == "Erkek").ToList();
                    var disiler = grup.Where(h => h.Cinsiyet == "Dişi").ToList();

                    foreach (var erkek in erkekler)
                    {
                        foreach (var disi in disiler)
                        {
                            if (erkek.UzaklikHesapla(disi) <= 3.0) // yakınsa üreme
                            {
                                var yeniCinsiyet = Random.Shared.Next(2) == 0 ? "Erkek" : "Dişi";
                                var yeniHayvan = new Otcul(
                                    erkek.Tur,
                                    yeniCinsiyet,
                                    erkek.HareketMenzili,
                                    _hayvanYoneticisi.Grid.GridBoyutu,
                                    Random.Shared
                                );
                                yeniHayvanlar.Add(yeniHayvan);
                                Console.WriteLine($"yeni {erkek.Tur} doğdu.");
                            }
                        }
                    }
                }
            );

            foreach (var yeniHayvan in yeniHayvanlar)
            {
                _hayvanYoneticisi.HayvanEkle(yeniHayvan); // yeni hayvanları ekle
            }
        }
    }
}
