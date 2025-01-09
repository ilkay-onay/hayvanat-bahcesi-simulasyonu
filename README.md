# Hayvanat Bahçesi Simülasyonu

## Proje Açıklaması

Bu proje, 500x500 birimlik bir alanda yaşayan çeşitli hayvan türlerinin davranışlarını simüle eden bir konsol uygulamasıdır. Simülasyon, hayvanların hareketlerini, avlanma davranışlarını ve üreme mekanizmalarını modellemektedir. Proje, belirli sayıda hayvan türünün başlangıç popülasyonuyla başlar ve 1000 adım boyunca simülasyonu çalıştırır. Sonuç olarak, her hayvan türünün kalan sayısı konsola yazdırılır.

---

## Kullanılan Teknolojiler ve Yapılar

### 1. **Teknolojiler**
   - **.NET 8.0:** Proje, .NET 8.0 platformu üzerinde geliştirilmiştir.
   - **C# Programlama Dili:** Proje, C# dilinin modern özellikleri kullanılarak yazılmıştır.
   - **Visual Studio Code:** Geliştirme ortamı olarak Visual Studio Code kullanılmıştır.

### 2. **Algoritmalar ve Veri Yapıları**
   - **Grid Tabanlı Konum Yönetimi:** Hayvanların konumları, 2 boyutlu bir dizi (`IHayvan?[,]`) üzerinde yönetilir. Grid üzerinde hayvanların yakınlarını bulmak için optimize bir arama algoritması kullanılmıştır. Bu algoritma, hayvanın bulunduğu konumdan belirli bir menzil içindeki hücreleri tarar ve sadece ilgili hücreleri kontrol eder.
   - **Paralel İşleme:** Projede, simülasyon adımlarının hızlandırılması için paralel programlama kullanılmıştır. Simülasyon adımları, `Parallel.ForEach` kullanılarak paralel şekilde işlenir. Özellikle, hayvanların hareket etmesi, avlanma ve üreme işlemleri paralel olarak işlenir. Race conditionlarını engellemek için `ConcurrentDictionary` gibi thread-safe yapılar kullanılmıştır.
   
### 3. **Kod Analizi**
   - **Zaman Karmaşıklığı (Time Complexity):**
     - **Hareket İşlemi:** O(n), burada n hayvan sayısıdır.
     - **Avlanma İşlemi:**  Avlanma işlemi, `YakinHayvanlariGetir` metodu ile yakın hayvanları bulmayı içerir. Bu metot, en kötü durumda gridin tamamını tarayabilir, bu da O(gridBoyutu^2) zaman karmaşıklığına yol açar. Avlanma işleminin karmaşıklığı bu nedenle  **O(n \* gridBoyutu^2)**  olarak ifade edilebilir, burada n avcı hayvan sayısıdır.
     - **Üreme İşlemi:** Üreme işlemi, olası tüm eşleşmeleri kontrol ettiğinden, en kötü durumda  **O(k^2)**  karmaşıklığına sahiptir, burada k aynı türden hayvan sayısıdır.
   - **Bellek Karmaşıklığı (Space Complexity):**
     - **Grid Yapısı:** O(gridBoyutu^2), çünkü 2 boyutlu bir dizi kullanılır.
     - **Hayvan Listesi:** O(n), burada n hayvan sayısıdır.

---

## Nasıl Çalıştırılır?

1. **Gereksinimler:**
   - .NET 8.0 SDK yüklü olmalıdır.
   - Visual Studio Code veya başka bir .NET destekli IDE kullanılabilir.

2. **Projeyi Derleme ve Çalıştırma:**
   - Terminalde proje dizinine gidin:
     ```bash
     cd /path/to/project
     ```
   - Projeyi derleyin:
     ```bash
     dotnet build
     ```
   - Projeyi çalıştırın:
     ```bash
     dotnet run
     ```

3. **Sonuçlar:**
   - Simülasyon tamamlandığında, konsolda her hayvan türünün kalan sayısı görüntülenecektir.

---

## Proje Yapısı

Proje, aşağıdaki ana bileşenlerden oluşmaktadır:

### 1. **Hayvan Sınıfları**
   - **`Hayvan` (Base Class):** Tüm hayvan türlerinin temel özelliklerini ve davranışlarını içerir. Bu sınıf, hayvanların türü, cinsiyeti, konumu ve hareket menzili gibi özellikleri tanımlar.
   - **`Koyun`:** Koyunların özelliklerini içerir ve `IKurtSaldırabilir`, `IAslanSaldırabilir` arayüzlerini uygular.
   - **`Inek`:** İneklerin özelliklerini içerir ve `IAslanSaldırabilir` arayüzünü uygular.
   -  **`Tavuk`:** Tavukların özelliklerini içerir ve `IKurtSaldırabilir` arayüzünü uygular.
   - **`Kurt`:** Kurtların özelliklerini ve avlanma davranışlarını içerir. `IEtcil` arayüzünü uygular.
   - **`Aslan`:** Aslanların özelliklerini ve avlanma davranışlarını içerir. `IEtcil` arayüzünü uygular.
   - **`Avci`:** Avcının özelliklerini ve avlanma davranışlarını içerir. `IAvci` arayüzünü uygular.

### 2. **Grid Yapısı**
   - **`Grid`:** Hayvanların konumlandığı 500x500 birimlik alanı temsil eder. Bu sınıf, hayvanların eklenmesi, silinmesi ve konumlarının güncellenmesi gibi işlemleri yönetir.
   - **`YakinHayvanlariGetir`:** Belirli bir menzil içindeki yakın hayvanları bulur.

### 3. **Simülasyon Yönetimi**
   - **`Simulasyon`:** Simülasyonun ana mantığını yönetir. Hayvanların eklenmesi, avcının eklenmesi ve simülasyon adımlarının yürütülmesi bu sınıfta gerçekleştirilir.
   - **`Calistir`:** Simülasyonu başlatır ve her adımda hayvanların hareket etmesi, avlanma ve üreme işlemlerini yönetir.

### 4. **Yönetici Sınıfları**
   - **`HayvanYoneticisi`:** Hayvanların eklenmesi, silinmesi ve listelenmesi gibi işlemleri yönetir.
   - **`UremeYoneticisi`:** Hayvanların üreme işlemlerini yönetir. Aynı türden farklı cinsiyetteki hayvanlar birbirine yakınlaştığında yeni bir hayvan oluşturulur.
   - **`AvlanmaYoneticisi`:** Etçil hayvanların ve avcının avlanma işlemlerini yönetir.

### 5. **Fabrika Sınıfı**
   - **`HayvanFabrikasi`:**  `HayvanTuru` enum değerine göre uygun hayvan nesnesini oluşturur.

### 6. **Arayüzler (Interfaces)**
   - **`IHayvan`:** Tüm hayvan türleri için ortak özellikleri ve davranışları tanımlar.
   - **`IEtcil`:** Etçil hayvanların avlanma davranışlarını tanımlar.
    - **`IAvci`:** Avcının avlanma davranışlarını tanımlar.
   - **`IGrid`:** Grid yapısının işlevlerini tanımlar.
   - **`ISimulasyon`:** Simülasyonun temel işlemlerini tanımlar.
    - **`IKurtSaldırabilir`:** Kurtların avlayabileceği hayvanların işaretlenmesi için kullanılır.
    - **`IAslanSaldırabilir`:** Aslanların avlayabileceği hayvanların işaretlenmesi için kullanılır.

---


## Proje İşleyişi

### 1. **Başlangıç Popülasyonu**
   - Simülasyon başladığında, aşağıdaki hayvanlar rastgele konumlara yerleştirilir:
     - 30 koyun (15 erkek, 15 dişi)
     - 10 inek (5 erkek, 5 dişi)
     - 10 tavuk
     - 10 kurt (5 erkek, 5 dişi)
     - 10 horoz
     - 8 aslan (4 erkek, 4 dişi)
     - 1 avcı

### 2. **Hareket Mekanizması**
   - Her adımda, hayvanlar belirli bir menzil içinde rastgele hareket eder:
     - Koyun: 2 birim
     - İnek: 2 birim
     - Tavuk: 1 birim
     - Horoz: 1 birim
     - Kurt: 3 birim
     - Aslan: 4 birim
     - Avcı: 1 birim
   - Hayvanlar, alanın dışına çıkamaz.

### 3. **Avlanma Mekanizması**
    * **Kurt:** Kendisine 4 birim yakınındaki `IKurtSaldırabilir` arayüzünü implemente eden hayvanları (koyun, tavuk, horoz) avlayabilir.
    * **Aslan:** Kendisine 5 birim yakınındaki `IAslanSaldırabilir` arayüzünü implemente eden hayvanları (inek, koyun) avlayabilir.
    * **Avcı:** Kendisine 8 birim yakınındaki herhangi bir hayvanı avlayabilir.

### 4. **Üreme Mekanizması**
   - Aynı türden farklı cinsiyetteki hayvanlar birbirine 3.0 birim yakınlaştığında, rastgele cinsiyette yeni bir hayvan oluşturulur.

### 5. **Simülasyon Sonu**
   - 1000 adım sonunda, her hayvan türünün kalan sayısı konsola yazdırılır. Tavuklar kendi içerisinde cinsiyetlerine göre (tavuk ve horoz) ayrılır ve yazdırılır.

---

## Örnek İşleyiş

### Senaryo:
- **Grid Boyutu:** 10x10 (küçük bir alan örneği)
- **Hayvanlar:**
  - 2 Koyun (1 Erkek, 1 Dişi)
  - 1 Kurt (Erkek)
  - 1 Avcı
- **Adım Sayısı:** 5 (basit bir örnek için)

### Adım Adım İşleyiş:

#### **Adım 1: Başlangıç**
- Hayvanlar rastgele konumlara yerleştirilir:
  - Koyun (Erkek): (2, 3)
  - Koyun (Dişi): (4, 5)
  - Kurt: (1, 1)
  - Avcı: (5, 5)

#### **Adım 2: Hareket**
- Her hayvan, belirli bir menzil içinde rastgele hareket eder:
  - Koyun (Erkek): (2, 3) → (3, 4)
  - Koyun (Dişi): (4, 5) → (5, 6)
  - Kurt: (1, 1) → (2, 2)
  - Avcı: (5, 5) → (6, 5)

#### **Adım 3: Avlanma**
- **Kurt:** Kendisine 4 birim yakınındaki `IKurtSaldırabilir` hayvanları kontrol eder.
  - Koyun (Dişi) (5, 6) kurtun menzilinde (2, 2) değil, avlanmaz.
- **Avcı:** Kendisine 8 birim yakınındaki hayvanları kontrol eder.
  - Koyun (Dişi) (5, 6) avcının menzilinde (6, 5). Avcı, Koyun (Dişi)'yi avlar.
  - **Çıktı:** `[adım 3] avcı, Koyun avladı.`

#### **Adım 4: Üreme**
- **Koyun (Erkek) ve Koyun (Dişi):**
  - Koyun (Erkek) (3, 4) ve Koyun (Dişi) (5, 6) birbirine 3 birimden uzakta, üreme gerçekleşmez.

#### **Adım 5: Hareket**
- Hayvanlar tekrar hareket eder:
  - Koyun (Erkek): (3, 4) → (4, 5)
  - Kurt: (2, 2) → (3, 3)
  - Avcı: (6, 5) → (7, 5)

#### **Adım 6: Avlanma**
- **Kurt:** Kendisine 4 birim yakınındaki `IKurtSaldırabilir` hayvanları kontrol eder.
  - Koyun (Erkek) (4, 5) kurtun menzilinde (3, 3). Kurt, Koyun (Erkek)'i avlar.
  - **Çıktı:** `[adım 6] Kurt, Koyun avladı.`
- **Avcı:** Yakınında avlanacak hayvan kalmadı.

#### **Adım 7: Üreme**
- **Kurt ve Avcı:** Üreme için uygun değil.

#### **Adım 8: Sonuç**
- Simülasyon sonunda kalan hayvanlar:
```plaintext
[adım 3] avcı, Koyun avladı.
[adım 6] Kurt, Koyun avladı.
son hayvan sayıları:
Koyun: 0
Kurt: 1
Avcı: 1