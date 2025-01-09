// avcı sınıfı, avcı davranışlarını uygular.

using System;
using System.Linq;
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Interface;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Avci : Hayvan, IAvci
    {
        public override int HareketMenzili => 1;
        public override int AvlanmaMenzili => 8;

        public Avci(int gridBoyutu, Random random)
            : base(HayvanTuru.Avci, Cinsiyet.Yok, gridBoyutu, random) { }

        public IHayvan? Avla(IGrid grid)
        {
            var yakinHayvanlar = grid.YakinHayvanlariGetir(this, AvlanmaMenzili);
            // avcı kendisi ve diğer avcılar haricindeki tüm hayvanları avlayabilir
            var avlanabilirler = yakinHayvanlar.Where(h => !(h is IAvci) && h != this).ToList();
            if (avlanabilirler.Count != 0)
            {
                return avlanabilirler[Random.Shared.Next(avlanabilirler.Count)];
            }

            return null;
        }
    }
}
