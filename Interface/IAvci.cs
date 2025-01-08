// avcının interface'ini tanımlar.
// avcı, diğer hayvanları avlayabilir.
namespace HayvanatBahcesiSimulasyonu.Models
{
    public interface IAvci : IHayvan
    {
        IHayvan? Avla(IGrid grid);
    }
}
