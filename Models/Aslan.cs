using System;
using System.Linq;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Aslan : Hayvan, IEtcil
    {
        public override int HareketMenzili => 4;
        public override int AvlanmaMenzili => 5;

        public Aslan(Cinsiyet cinsiyet, int gridBoyutu, Random random)
            : base(HayvanTuru.Aslan, cinsiyet, gridBoyutu, random) { }

        public IHayvan? Avla(IGrid grid)
        {
            var yakinHayvanlar = grid.YakinHayvanlariGetir(this, AvlanmaMenzili);
            var avlanabilirler = yakinHayvanlar.Where(h => h is IAslanSaldırabilir).ToList();

            if (avlanabilirler.Count != 0)
            {
                return avlanabilirler[Random.Shared.Next(avlanabilirler.Count)];
            }
            return null;
        }
    }
}
