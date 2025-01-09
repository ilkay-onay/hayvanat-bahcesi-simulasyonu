// hayvan sınıfı, hayvanların temel özelliklerini ve davranışlarını tanımlar.

using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public abstract class Hayvan : IHayvan
    {
        public HayvanTuru Tur { get; protected set; }
        public Cinsiyet Cinsiyet { get; protected set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public abstract int HareketMenzili { get; }
        public virtual int AvlanmaMenzili => 0;
        string IHayvan.Tur => Tur.ToString();

        protected Hayvan(HayvanTuru tur, Cinsiyet cinsiyet, int gridBoyutu, Random random)
        {
            Tur = tur;
            Cinsiyet = cinsiyet;
            KonumBelirle(gridBoyutu, random);
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
            );
            Y = Math.Clamp(
                Y + random.Next(-HareketMenzili, HareketMenzili + 1),
                0,
                grid.GridBoyutu - 1
            );
            grid.HayvanKonumGuncelle(this, eskiX, eskiY);
        }

        public double UzaklikHesapla(IHayvan diger) =>
            Math.Sqrt(Math.Pow(X - diger.X, 2) + Math.Pow(Y - diger.Y, 2));
    }
}
