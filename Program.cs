// grid boyutu, iterasyon sayısı ve hayvanların eklenmesi burada yapılır.
using HayvanatBahcesiSimulasyonu.Enums;
using HayvanatBahcesiSimulasyonu.Models;

int gridBoyutu = 500; // grid boyutu (500x500)
int iterasyonSayisi = 1000; // simülasyonun kaç adım çalışacağı

var simulasyon = new Simulasyon(gridBoyutu, iterasyonSayisi);

// hayvanları ekle
            simulasyon.HayvanEkle(Koyun, 15, Cinsiyet.Erkek, 2);
            simulasyon.HayvanEkle(Koyun, 15, Cinsiyet.Disi, 2);
            simulasyon.HayvanEkle(Inek, 5, Cinsiyet.Erkek, 2);
            simulasyon.HayvanEkle(Inek, 5, Cinsiyet.Disi, 2);
            simulasyon.HayvanEkle(Tavuk, 10, Cinsiyet.Disi, 1);
            simulasyon.HayvanEkle(Tavuk, 10, Cinsiyet.Erkek, 1); //horoz

// etçil hayvanları ekle
            simulasyon.HayvanEkle(Kurt, 5, Cinsiyet.Disi, 3);
            simulasyon.HayvanEkle(Kurt, 5, Cinsiyet.Erkek, 3);
            simulasyon.HayvanEkle(Aslan, 4, Cinsiyet.Erkek, 4);
            simulasyon.HayvanEkle(Aslan, 4, Cinsiyet.Disi, 4);
// avcıyı ekle
simulasyon.AvciEkle();

// simülasyonu başlat
simulasyon.Calistir();
