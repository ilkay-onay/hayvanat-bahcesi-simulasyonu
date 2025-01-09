using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Models;

int gridBoyutu = 500;
int iterasyonSayisi = 1000;

var simulasyon = new Simulasyon(gridBoyutu, iterasyonSayisi);

// hayvanları ekle
simulasyon.HayvanEkle(HayvanTuru.Koyun, 15, Cinsiyet.Erkek);
simulasyon.HayvanEkle(HayvanTuru.Koyun, 15, Cinsiyet.Disi);
simulasyon.HayvanEkle(HayvanTuru.Inek, 5, Cinsiyet.Erkek);
simulasyon.HayvanEkle(HayvanTuru.Inek, 5, Cinsiyet.Disi);
simulasyon.HayvanEkle(HayvanTuru.Tavuk, 10, Cinsiyet.Disi);
simulasyon.HayvanEkle(HayvanTuru.Tavuk, 10, Cinsiyet.Erkek); //horoz, erkek tavuk horozdur.

// etçil hayvanları ekle
simulasyon.HayvanEkle(HayvanTuru.Kurt, 5, Cinsiyet.Disi);
simulasyon.HayvanEkle(HayvanTuru.Kurt, 5, Cinsiyet.Erkek);
simulasyon.HayvanEkle(HayvanTuru.Aslan, 4, Cinsiyet.Erkek);
simulasyon.HayvanEkle(HayvanTuru.Aslan, 4, Cinsiyet.Disi);

// avcıyı ekle
simulasyon.AvciEkle();

// simülasyonu başlat
simulasyon.Calistir();
