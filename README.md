# Hava Durumu Uygulaması

Bu hava durumu uygulaması, belirli şehirlerin güncel hava durumu bilgilerini gösteren bir konsol uygulamasıdır. Uygulama, OpenWeatherMap API'sini kullanarak hava durumu verilerini alır.
Uygulama çalıştırıldığında, belirtilen şehirlerin hava durumu bilgileri ekrana yazdırılacaktır.

## Proje Yapısı

- **HavaDurumu.Model/HavaDurumuBilgisi.cs**: Hava durumu bilgilerini içeren model sınıfı.
- **Program.cs**: Ana uygulama dosyası. Hava durumu bilgilerini almak ve ekrana yazdırmak için gerekli kodları içerir.

## Kullanılan Teknolojiler

- C# Programming Language
- .NET Core
- Newtonsoft.Json: JSON verilerini deserialize etmek için kullanılan kütüphane.

## Hava Durumu Bilgisi Alma

Hava durumu bilgilerini almak için OpenWeatherMap API'si kullanılmaktadır. Hava durumu bilgileri, belirli bir şehir için `https://goweather.herokuapp.com/weather/{sehir}` adresinden alınmaktadır.

## Hata Durumları

Eğer hava durumu bilgileri alınırken bir hata oluşursa, uygulama belirli bir süre boyunca tekrar deneme yapacaktır. Eğer belirli bir sayıda deneme sonucunda hala başarılı olunamazsa, hata mesajı ekrana yazdırılacaktır.(API çalışmadığı durumlarda)
