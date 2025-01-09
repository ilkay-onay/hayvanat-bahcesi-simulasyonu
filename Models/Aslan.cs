// aslan sınıfını tanımlar.
using System;
using System.Linq;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Aslan : Hayvan, IEtcil
    {
        public override int AvlanmaMenzili => 5; // aslanın avlanma menzilini belirtir.

        public Aslan(Cinsiyet cinsiyet, int hareketMenzili, int gridBoyutu, Random random)
            : base("Aslan", cinsiyet, hareketMenzili, gridBoyutu, random) { }

        public IHayvan? Avla(IGrid grid) // aslanın avlanma mantığını uygular.
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
