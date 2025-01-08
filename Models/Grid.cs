// hayvanların konumlandığı grid yapısını ve grid üzerindeki işlemleri içerir.
// hayvan ekleme, silme ve konum güncelleme gibi işlemler burada yapılır.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Grid(int gridBoyutu) : IGrid
    {
        private readonly IHayvan?[,] _hucreler = new IHayvan?[gridBoyutu, gridBoyutu]; // grid hücrelerini tutan 2d dizi
        public int GridBoyutu { get; } = gridBoyutu;

        public void HayvanEkle(IHayvan hayvan)
        {
            _hucreler[hayvan.X, hayvan.Y] = hayvan; // hayvanı grid'e ekle
        }

        public void HayvanSil(IHayvan hayvan)
        {
            _hucreler[hayvan.X, hayvan.Y] = null; // hayvanı grid'den kaldır
        }

        public List<IHayvan> YakinHayvanlariGetir(IHayvan hayvan, int menzil)
        {
            var yakinHayvanlar = new List<IHayvan>();
            // belirtilen menzil içindeki hayvanları bul
            for (
                int x = Math.Max(0, hayvan.X - menzil);
                x <= Math.Min(GridBoyutu - 1, hayvan.X + menzil);
                x++
            )
            {
                for (
                    int y = Math.Max(0, hayvan.Y - menzil);
                    y <= Math.Min(GridBoyutu - 1, hayvan.Y + menzil);
                    y++
                )
                {
                    var yakinHayvan = _hucreler[x, y];
                    if (yakinHayvan != null && yakinHayvan != hayvan)
                    {
                        yakinHayvanlar.Add(yakinHayvan);
                    }
                }
            }
            return yakinHayvanlar;
        }

        public void HayvanKonumGuncelle(IHayvan hayvan, int eskiX, int eskiY)
        {
            _hucreler[eskiX, eskiY] = null; // eski konumu boşalt
            _hucreler[hayvan.X, hayvan.Y] = hayvan; // yeni konuma taşı
        }
    }
}
