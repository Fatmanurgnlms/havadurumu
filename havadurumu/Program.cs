using System;

public class HavaDurumuBilgisi
{
    public string Şehir { get; set; }
    public string Açıklama { get; set; }
    public string Sıcaklık { get; set; }
    public string Nem { get; set; }
    public string Rüzgar { get; set; }
}

class Program
{
    public static object Newtonsoft { get; private set; }

    static void Main()
    {
        HavaDurumunuAl("istanbul");
        HavaDurumunuAl("izmir");
        HavaDurumunuAl("ankara");
    }

    static void HavaDurumunuAl(string şehir)
    {
        using (System.Net.Http.HttpClient istemci = new System.Net.Http.HttpClient())
        {
            try
            {
                // API'den veriyi al
                string apiUrl = $"https://goweather.herokuapp.com/weather/{şehir}";
                var yanıt = istemci.GetStringAsync(apiUrl).Result;

                // JSON verisini HavaDurumuBilgisi sınıfına dönüştür
                var havaDurumuBilgisi = Newtonsoft.Json.JsonConvert.DeserializeObject<HavaDurumuBilgisi>(yanıt);

                // Hava durumu bilgilerini ekrana yazdır
                Console.WriteLine($"Şehir: {havaDurumuBilgisi.Şehir}");
                Console.WriteLine($"Açıklama: {havaDurumuBilgisi.Açıklama}");
                Console.WriteLine($"Sıcaklık: {havaDurumuBilgisi.Sıcaklık}");
                Console.WriteLine($"Nem: {havaDurumuBilgisi.Nem}");
                Console.WriteLine($"Rüzgar: {havaDurumuBilgisi.Rüzgar}");
                Console.WriteLine();
            }
            catch (Exception hata)
            {
                Console.WriteLine($"Hata oluştu: {hata.Message}");
            }
        }
    }
}
