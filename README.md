# Bayatman_2D

**Bayatman_2D**, tamamen eğitim amaçlı geliştirilmiş, **Unity 2D**'ye yeni başlayanlar için tasarlanmış sade ama öğretici bir **platformer deneme projesidir**.

Bu proje bir "tam oyun" olma hedefi yoktur.  
Asıl amacı şudur:  
Unity'nin **component tabanlı çalışma mantığını**, **fizik sistemini**, **çarpışma algılama** mekanizmalarını ve **C# ile basit davranış programlamayı** bizzat kod yazarak vev değer değiştirerek öğrenmektir.

Kısaca: "Unity nasıl çalışır, neden böyle davranır?" sorularına **çalıştırılabilir, dokunulabilir bir cevap** sunar.

------------------------------------------------------------------------

## Proje Hedefleri ve Öğrenme Kazanımları

Bu projeyi tamamladığında veya iyice incelediğinde şu konuları **somut olarak** anlamış olacaksın:

1. GameObject, Component ve Transform ilişkisi  
2. Her GameObject'in neden **zorunlu olarak** bir Transform bileşeni taşıdığı  
3. **Rigidbody2D** ile **Collider2D** arasındaki zorunlu işbirliği  
4. Fiziksel hareketin **FixedUpdate** içinde neden işlenmesi gerektiği  
5. **Update** vs **FixedUpdate** vs **LateUpdate** farkları  
6. Çarpışmaların iki farklı türü:  
   - Fiziksel çarpışma → `OnCollisionEnter2D`  
   - Tetikleyici bölge → `OnTriggerEnter2D`  
7. **SerializeField** ve **public** değişkenlerin Inspector'da görünürlüğü
8. Klavye girdisi alma yöntemleri (`Input.GetKeyDown` vb.)  
9. Hız, zıplama gücü, yerçekimi gibi parametrelerin kolayca ayarlanabilir yapılması  
10. Sorting Layer ve Order in Layer ile 2D görsel katman yönetimi  
11. Basit **debug** teknikleri (`Debug.Log`, `OnDrawGizmos`)  

------------------------------------------------------------------------

## Kullanılan Temel Unity Sistemleri ve Kavramlar (Detaylı)

| Sistem / Kavram                  | Ne İşe Yarar?                                                                 | Bu Projede Nasıl Kullanıldı?                              | Öğrenme İpucu / Sık Yapılan Hata                          |
|----------------------------------|-------------------------------------------------------------------------------|------------------------------------------------------------|------------------------------------------------------------|
| Transform                        | Her nesnenin konum, rotasyon ve ölçeğini tutar                               | Her GameObject'te otomatik gelir                           | Transform olmadan nesne hareket ettirilemez!               |
| Rigidbody2D                      | Fizik simülasyonu (yerçekimi, hız, kuvvet uygulama)                           | Karakter ve bazı nesnelerde Dynamic / Kinematic            | Rigidbody olmadan fizik çalışmaz – en yaygın hata          |
| Collider2D (Box / Circle vb.)    | Çarpışma / tetikleme alanı tanımlar                                          | Karakter, zemin, düşman, toplanabilir objeler             | Collider olmadan çarpışma algılanmaz                       |
| Is Trigger                       | Fizik tepkisi olmadan sadece tetikleme alanı oluşturur                        | Toplanabilir objelerde, tehlike bölgelerinde               | Trigger açıkken fiziksel itme olmaz                        |
| Sprite Renderer                  | 2D sprite'ı ekranda gösterir                                                  | Tüm görsel objelerde                                       | Sorting Layer sırası yanlışsa nesneler yanlış üst üste gelir |
| MonoBehaviour                    | Unity'nin temel script sınıfı                                                 | Tüm davranış scriptleri bu sınıftan türetilir              | —                                                          |
| Update()                         | Her frame çağrılır – giriş, animasyon, mantık için                           | Hareket yönü okuma, input kontrolü                         | Fizik işlemleri buraya yazılmamalı                         |
| FixedUpdate()                    | Sabit zaman aralığında çağrılır – fizik için idealdir                         | Hız uygulama, kuvvet ekleme                                | Fizik kodları genelde buraya yazılır                       |
| OnCollisionEnter2D               | Fiziksel çarpışma anında çalışır                                              | Duvara / düşmana çarpma                                    | Sadece Rigidbody olan nesnelerde tetiklenir                |
| OnTriggerEnter2D                 | Trigger alanına girildiğinde çalışır                                          | Altın toplama, ölüm bölgesi                                | Rigidbody şart değil, ama en az bir collider olmalı        |
| Input.GetAxis("Horizontal")      | Yumuşak yatay input (-1 ile +1 arası)                                         | Karakter yürüme                                            | Smooth input istiyorsan bu kullanılır                      |
| Input.GetKeyDown(KeyCode.Space)  | Tuşa basıldığı frame'de tek seferlik olay                                     | Zıplama                                                    | Sürekli basılı tutmayı istemiyorsan GetKeyDown kullanılır  |
| SerializeField               | Private değişkeni Inspector'da görünür kılar                                  | Hız, zıplama gücü, kontrol hassasiyeti                     | public yerine daha temiz – önerilen yöntem                 |
| [Range(0f, 20f)]                 | Sayısal değer için kaydırıcı oluşturur                                        | JumpForce, moveSpeed gibi değerlerde                       | Yanlış değer girmeyi engeller                              |

------------------------------------------------------------------------

## Projede Mutlaka İncelemen Gereken Yerler

| İncelenecek Yer                  | Neden Önemli?                                                                 | Bakılacak Özel Satırlar / Özellikler                              |
|----------------------------------|-------------------------------------------------------------------------------|--------------------------------------------------------------------|
| PlayerController.cs              | Oyuncunun tüm hareket mantığı burada                                          | FixedUpdate içindeki velocity, AddForce, zıplama kontrolü         |
| Rigidbody2D ayarları             | Gravity Scale, Constraints (Freeze Rotation Z)                                | Dönmemesi için Z rotasyonu dondurulur                              |
| Collider ayarları                | Edit Collider butonu ile şekil düzenleme                                      | Offset, Size, Is Trigger kutusu                                    |

## Kendine sorabileceğin en faydalı sorular:

- Rigidbody2D'yi Kinematic yaparsam ne değişir?  
- Collider'da Is Trigger'ı açarsam fiziksel çarpışma biter mi?  
- FixedUpdate yerine Update'e fizik kodu yazarsam ne olur? (deneyin!)  
- Character'ın Rigidbody'sini kaldırırsam neden hareket etmiyor?

## Bu Projeden Sonra Ne Yapabilirsin?

1. Karaktere çift zıplama ekle  
2. Basit bir puan sistemi ve UI (TextMeshPro) yap  
3. Level geçişi mantığı kur (SceneManager)  
4. Animator ile yürüme/zıplama animasyonu ekle     
5. Projeyi WebGL olarak build alıp arkadaşlarına göster!

## Lisans

MIT License

Bu proje özgürce:

- kullanılabilir  
- değiştirilebilir  
- dağıtılabilirdir
- ticari projelerde bile kullanılabilir
Detaylar → LICENSE dosyası

## Ön gösterim
<img width="1128" height="487" alt="image" src="https://github.com/user-attachments/assets/f461a60d-94ef-4bf6-8047-8f5ae51f03fd" />

<img width="1100" height="482" alt="image" src="https://github.com/user-attachments/assets/2941adcd-1afd-43e5-beb5-b92a1d1dec4b" />




https://github.com/user-attachments/assets/2fe901b3-40e3-4110-9cef-8440a9fb453c


## Haritanın devamı için kurun.Kurumda başarılar😊
Göktuğ Arı


