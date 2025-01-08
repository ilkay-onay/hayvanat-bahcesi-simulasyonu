// etçil hayvanların interface'ini tanımlar.
// etçil hayvanlar, belirli hayvan türlerini avlayabilir.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IEtcil : IHayvan
    {
        List<string> Avlar { get; }
        IHayvan? Avla(IGrid grid);
    }
}
