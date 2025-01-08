// hayvanların temel özelliklerini ve davranışlarını içerir.
// tüm hayvan türleri bu sınıftan türetilir.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public abstract class Hayvan : IHayvan
    {
        public string Tur { get; } // hayvan türü
        public string Cinsiyet { get; } // hayvan cinsiyeti
        public int X { get; private set; } // x koordinatı
        public int Y { get; private set; } // y koordinatı
        public int HareketMenzili { get; } // hareket menzili
        public virtual int AvlanmaMenzili => 0; // varsayılan avlanma menzili (otçullar için)

        protected Hayvan(
            string tur,
            string cinsiyet,
            int hareketMenzili,
            int gridBoyutu,
            Random random
        )
        {
            Tur = tur;
            Cinsiyet = cinsiyet ?? "Yok";
            HareketMenzili = hareketMenzili;
            KonumBelirle(gridBoyutu, random); // rastgele konum belirle
        }

        private void KonumBelirle(int gridBoyutu, Random random)
        {
            X = random.Next(0, gridBoyutu);
            Y = random.Next(0, gridBoyutu);
        }

        public void HareketEt(IGrid grid, Random random)
        {
            int eskiX = X;
            int eskiY = Y;
            X = Math.Clamp(
                X + random.Next(-HareketMenzili, HareketMenzili + 1),
                0,
                grid.GridBoyutu - 1
            ); // yeni x koordinatı
            Y = Math.Clamp(
                Y + random.Next(-HareketMenzili, HareketMenzili + 1),
                0,
                grid.GridBoyutu - 1
            ); // yeni y koordinatı
            grid.HayvanKonumGuncelle(this, eskiX, eskiY); // konumu güncelle
        }

        public double UzaklikHesapla(IHayvan diger) =>
            Math.Sqrt(Math.Pow(X - diger.X, 2) + Math.Pow(Y - diger.Y, 2)); // iki hayvan arasındaki mesafeyi hesapla
    }
}
