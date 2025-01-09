// kurt sınıfını tanımlar.
using System;
using System.Linq;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Kurt : Hayvan, IEtcil
    {
        public override int AvlanmaMenzili => 4; // kurtun avlanma menzilini belirtir.

        public Kurt(Cinsiyet cinsiyet, int hareketMenzili, int gridBoyutu, Random random)
            : base("Kurt", cinsiyet, hareketMenzili, gridBoyutu, random) { }

        public IHayvan? Avla(IGrid grid) // kurtun avlanma mantığını uygular.
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
