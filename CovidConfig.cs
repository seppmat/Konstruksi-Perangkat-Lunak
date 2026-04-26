using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tpModul8
{
    internal class CovidConfig
    {
        [JsonPropertyName("satuan_suhu")]
        public string SatuanSuhu { get; set; } = "celcius";

        [JsonPropertyName("batas_hari_deman")]
        public int BatasHariDeman { get; set; } = 14;

        [JsonPropertyName("pesan_ditolak")]
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";

        [JsonPropertyName("pesan_diterima")]
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string FilePath = "covid_config.json";

        public CovidConfig()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string json = File.ReadAllText(FilePath);
                    var loaded = JsonSerializer.Deserialize<CovidConfig>(json);
                    if (loaded != null)
                    {
                        SatuanSuhu = loaded.SatuanSuhu;
                        BatasHariDeman = loaded.BatasHariDeman;
                        PesanDitolak = loaded.PesanDitolak;
                        PesanDiterima = loaded.PesanDiterima;
                    }
                }
                catch { }
            }
            else { Save(); }
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu.Equals("celcius", StringComparison.OrdinalIgnoreCase) ? "fahrenheit" : "celcius";
            Save();
        }

        private void Save()
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(this, opts));
        }
    }
}
