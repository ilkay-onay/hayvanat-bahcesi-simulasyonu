// grid boyutu, iterasyon sayısı ve hayvanların eklenmesi burada yapılır.
using HayvanatBahcesiSimulasyonu.Models;

int gridBoyutu = 500; // grid boyutu (500x500)
int iterasyonSayisi = 1000; // simülasyonun kaç adım çalışacağı

var simulasyon = new Simulasyon(gridBoyutu, iterasyonSayisi);

// hayvanları ekle
simulasyon.HayvanEkle("Koyun", 15, "Erkek", 2);
simulasyon.HayvanEkle("Koyun", 15, "Dişi", 2);
simulasyon.HayvanEkle("İnek", 5, "Erkek", 2);
simulasyon.HayvanEkle("İnek", 5, "Dişi", 2);
simulasyon.HayvanEkle("Tavuk", 10, "Yok", 1);
simulasyon.HayvanEkle("Horoz", 10, "Yok", 1);

// etçil hayvanları ekle
simulasyon.HayvanEkle("Kurt", 5, "Erkek", 3, ["Koyun", "Tavuk", "Horoz"]);
simulasyon.HayvanEkle("Kurt", 5, "Dişi", 3, ["Koyun", "Tavuk", "Horoz"]);
simulasyon.HayvanEkle("Aslan", 4, "Erkek", 4, ["İnek", "Koyun"]);
simulasyon.HayvanEkle("Aslan", 4, "Dişi", 4, ["İnek", "Koyun"]);

// avcıyı ekle
simulasyon.AvciEkle();

// simülasyonu başlat
simulasyon.Calistir();
