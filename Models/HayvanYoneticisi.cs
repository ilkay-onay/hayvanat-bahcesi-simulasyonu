using System.Collections.Concurrent;

namespace HayvanatBahcesiSimulasyonu.Models
{
    public class HayvanYoneticisi(IGrid grid)
    {
        private readonly ConcurrentDictionary<Guid, IHayvan> _hayvanlar = new();
        private readonly ConcurrentDictionary<IHayvan, Guid> _hayvanIdleri = new();
        private readonly IGrid _grid = grid;

        public IGrid Grid => _grid; // grid özelliği

        public void HayvanEkle(IHayvan hayvan)
        {
            var hayvanId = Guid.NewGuid();
            _hayvanlar.TryAdd(hayvanId, hayvan);
            _hayvanIdleri.TryAdd(hayvan, hayvanId);
            _grid.HayvanEkle(hayvan); // hayvanı grid'e ekle
        }

        public void HayvanSil(IHayvan hayvan)
        {
            if (_hayvanIdleri.TryRemove(hayvan, out var hayvanId))
            {
                _hayvanlar.TryRemove(hayvanId, out _);
                _grid.HayvanSil(hayvan); // hayvanı grid'den kaldır
            }
        }

        public List<IHayvan> TumHayvanlariGetir() => [.. _hayvanlar.Values]; // tüm hayvanları döndür
    }
}
