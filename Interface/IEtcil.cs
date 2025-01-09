// etçil interface'i, etçil hayvan davranışlarını tanımlar.

namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IEtcil : IHayvan
    {
        IHayvan? Avla(IGrid grid);
    }
}
