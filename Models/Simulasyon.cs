// simülasyon sınıfı, simülasyonun ana akışını yönetir.

using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Factories;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Simulasyon
    {
        private readonly HayvanYoneticisi _hayvanYoneticisi;
        private readonly UremeYoneticisi _uremeYoneticisi;
        private readonly AvlanmaYoneticisi _avlanmaYoneticisi;
        private readonly int _iterasyonSayisi;
        private readonly HayvanFabrikasi _hayvanFabrikasi = new();

        public Simulasyon(int gridBoyutu, int iterasyonSayisi)
        {
            var grid = new Grid(gridBoyutu);
            _hayvanYoneticisi = new HayvanYoneticisi(grid);
            _uremeYoneticisi = new UremeYoneticisi(_hayvanYoneticisi, _hayvanFabrikasi);
            _avlanmaYoneticisi = new AvlanmaYoneticisi(_hayvanYoneticisi);
            _iterasyonSayisi = iterasyonSayisi;
        }

        public void HayvanEkle(HayvanTuru tur, int adet, Cinsiyet cinsiyet)
        {
            for (int i = 0; i < adet; i++)
            {
                var hayvan = _hayvanFabrikasi.HayvanYarat(
                    tur,
                    cinsiyet,
                    _hayvanYoneticisi.Grid.GridBoyutu,
                    Random.Shared
                );
                _hayvanYoneticisi.HayvanEkle(hayvan);
            }
        }

        public void AvciEkle()
        {
            var avci = new Avci(_hayvanYoneticisi.Grid.GridBoyutu, Random.Shared);
            _hayvanYoneticisi.HayvanEkle(avci);
        }

        public void Calistir()
        {
            for (int adim = 1; adim <= _iterasyonSayisi; adim++)
            {
                var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

                Parallel.ForEach(
                    hayvanlar,
                    hayvan =>
                    {
                        hayvan.HareketEt(_hayvanYoneticisi.Grid, Random.Shared);
                    }
                );

                _avlanmaYoneticisi.AvlanmaIslemi(adim);

                _uremeYoneticisi.UremeIslemi();
            }

            SonuclariYazdir();
        }

        private void SonuclariYazdir()
        {
            Console.WriteLine("Son hayvan sayıları:");
            var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

            var tavuklar = hayvanlar.Where(h => h.Tur == HayvanTuru.Tavuk.ToString()).ToList();
            var disiTavukSayisi = tavuklar.Count(t => t.Cinsiyet == Cinsiyet.Disi);
            var erkekTavukSayisi = tavuklar.Count(t => t.Cinsiyet == Cinsiyet.Erkek);

            foreach (
                var grup in hayvanlar
                    .Where(h => h.Tur != HayvanTuru.Tavuk.ToString())
                    .GroupBy(h => h.Tur)
            )
            {
                Console.WriteLine($"{grup.Key}: {grup.Count()}");
            }

            Console.WriteLine($"Tavuk: {disiTavukSayisi}");
            Console.WriteLine($"Horoz: {erkekTavukSayisi}");
        }
    }
}
