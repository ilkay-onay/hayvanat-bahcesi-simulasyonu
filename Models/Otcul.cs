// otçul hayvanların özelliklerini içerir.
// otçul hayvanlar bu sınıftan türetilir.
namespace HayvanatBahcesiSimulasyonu.Models
{
    public class Otcul(
        string tur,
        string cinsiyet,
        int hareketMenzili,
        int gridBoyutu,
        Random random
    ) : Hayvan(tur, cinsiyet, hareketMenzili, gridBoyutu, random), IOtcul { }
}
