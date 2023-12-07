using System;
using System.Threading.Tasks;
using HavaDurumu.Model;


class Program
{
    static async Task Main()
    {
        Console.WriteLine("Hava Durumu Uygulamasına Hoş Geldiniz!");
        Console.WriteLine("---------------------------------------");

        string[] sehirler = { "istanbul", "ankara", "izmir", "antalya", "bursa" };

        foreach (var sehir in sehirler)
        {
            await HavaDurumuBilgisiniAl(sehir);
        }

        Console.ReadLine(); 
    }

    static async Task HavaDurumuBilgisiniAl(string sehir)
    {
        int tekrarDenemeSayisi = 3; 
        int beklemeSuresiMilisaniye = 1000; 

        for (int i = 0; i < tekrarDenemeSayisi; i++)
        {
            try
            {
                await HavaDurumuBilgisiniGetir(sehir);
                return;
            }
            catch
            {
                Console.WriteLine($"Hata: {sehir} için hava durumu bilgisi alınamıyor. Tekrar deneme: {i + 1}/{tekrarDenemeSayisi}");
                await Task.Delay(beklemeSuresiMilisaniye);
            }
        }

        Console.WriteLine($"Üzgünüz, {sehir} için hava durumu bilgisi alınamıyor. Lütfen daha sonra tekrar deneyin.");
    }

    static async Task HavaDurumuBilgisiniGetir(string sehir)
    {
        using (System.Net.Http.HttpClient istemci = new System.Net.Http.HttpClient())
        {
            
            string apiAdresi = $"https://goweather.herokuapp.com/weather/{sehir}";
            var cevap = await istemci.GetStringAsync(apiAdresi);

            
            var havaDurumuBilgisi = Newtonsoft.Json.JsonConvert.DeserializeObject<HavaDurumuBilgisi>(cevap);

            Console.WriteLine($"Şehir: {havaDurumuBilgisi.Sehir}");
            Console.WriteLine($"Açıklama: {havaDurumuBilgisi.Aciklama}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Sıcaklık: {havaDurumuBilgisi.Sicaklik}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Nem: {havaDurumuBilgisi.Nem}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rüzgar: {havaDurumuBilgisi.Ruzgar}");
            Console.ResetColor();

            Console.WriteLine();
        }
    }
}
