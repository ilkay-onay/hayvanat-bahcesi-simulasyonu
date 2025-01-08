// simülasyonun ana mantığını içerir.
// hayvan ekleme, avcı ekleme ve simülasyon adımlarının yönetimi burada yapılır.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Simulasyon
    {
        private readonly HayvanYoneticisi _hayvanYoneticisi;
        private readonly UremeYoneticisi _uremeYoneticisi;
        private readonly AvlanmaYoneticisi _avlanmaYoneticisi;
        private readonly int _iterasyonSayisi;

        public Simulasyon(int gridBoyutu, int iterasyonSayisi)
        {
            var grid = new Grid(gridBoyutu);
            _hayvanYoneticisi = new HayvanYoneticisi(grid);
            _uremeYoneticisi = new UremeYoneticisi(_hayvanYoneticisi);
            _avlanmaYoneticisi = new AvlanmaYoneticisi(_hayvanYoneticisi);
            _iterasyonSayisi = iterasyonSayisi;
        }

        public void HayvanEkle(
            string tur,
            int adet,
            string cinsiyet,
            int hareketMenzili,
            List<string>? avlar = null
        )
        {
            for (int i = 0; i < adet; i++)
            {
                IHayvan hayvan =
                    avlar == null
                        ? new Otcul(
                            tur,
                            cinsiyet,
                            hareketMenzili,
                            _hayvanYoneticisi.Grid.GridBoyutu,
                            Random.Shared
                        )
                        : new Etcil(
                            tur,
                            cinsiyet,
                            hareketMenzili,
                            avlar,
                            _hayvanYoneticisi.Grid.GridBoyutu,
                            Random.Shared
                        );

                _hayvanYoneticisi.HayvanEkle(hayvan); // hayvanı yöneticiye ekle
            }
        }

        public void AvciEkle()
        {
            var avci = new Avci(_hayvanYoneticisi.Grid.GridBoyutu, Random.Shared);
            _hayvanYoneticisi.HayvanEkle(avci); // avcıyı grid'e ekle
        }

        public void Calistir()
        {
            for (int adim = 1; adim <= _iterasyonSayisi; adim++)
            {
                var hayvanlar = _hayvanYoneticisi.TumHayvanlariGetir();

                // hayvanların hareket etmesi (paralel)
                Parallel.ForEach(
                    hayvanlar,
                    hayvan =>
                    {
                        hayvan.HareketEt(_hayvanYoneticisi.Grid, Random.Shared);
                    }
                );

                // avlanma işlemi (paralel)
                _avlanmaYoneticisi.AvlanmaIslemi(adim);

                // üreme işlemi (paralel)
                _uremeYoneticisi.UremeIslemi();
            }

            SonuclariYazdir(); // sonuçları konsola yazdır
        }

        private void SonuclariYazdir()
        {
            Console.WriteLine("son hayvan sayıları:");
            foreach (var grup in _hayvanYoneticisi.TumHayvanlariGetir().GroupBy(h => h.Tur))
            {
                Console.WriteLine($"{grup.Key}: {grup.Count()}"); // tür bazında hayvan sayılarını yazdır
            }
        }
    }
}
