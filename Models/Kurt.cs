using System;
using System.Linq;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Kurt : Hayvan, IEtcil
    {
        public override int HareketMenzili => 3;
        public override int AvlanmaMenzili => 4;

        public Kurt(Cinsiyet cinsiyet, int gridBoyutu, Random random)
            : base(HayvanTuru.Kurt, cinsiyet, gridBoyutu, random) { }

        public IHayvan? Avla(IGrid grid)
        {
            var yakinHayvanlar = grid.YakinHayvanlariGetir(this, AvlanmaMenzili);
            var avlanabilirler = yakinHayvanlar.Where(h => h is IKurtSaldırabilir).ToList();

            if (avlanabilirler.Count != 0)
            {
                return avlanabilirler[Random.Shared.Next(avlanabilirler.Count)];
            }
            return null;
        }
    }
}
