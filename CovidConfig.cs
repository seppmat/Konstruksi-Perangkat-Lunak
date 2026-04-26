using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tpModul8
{
    public class CovidConfig
    {
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDeman { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string FilePath = "covid_config.json";
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public CovidConfig()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string json = File.ReadAllText(FilePath);
                    var data = JsonSerializer.Deserialize<ConfigDto>(json);

                    if (data != null)
                    {
                        SatuanSuhu = data.SatuanSuhu ?? SatuanSuhu;
                        BatasHariDeman = data.BatasHariDeman != 0 ? data.BatasHariDeman : BatasHariDeman;
                        PesanDitolak = data.PesanDitolak ?? PesanDitolak;
                        PesanDiterima = data.PesanDiterima ?? PesanDiterima;
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
            var data = new ConfigDto
            {
                SatuanSuhu = SatuanSuhu,
                BatasHariDeman = BatasHariDeman,
                PesanDitolak = PesanDitolak,
                PesanDiterima = PesanDiterima
            };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(data, JsonOptions));
        }
    }

    internal class ConfigDto
    {
        [JsonPropertyName("satuan_suhu")]
        public string SatuanSuhu { get; set; }

        [JsonPropertyName("batas_hari_deman")]
        public int BatasHariDeman { get; set; }

        [JsonPropertyName("pesan_ditolak")]
        public string PesanDitolak { get; set; }

        [JsonPropertyName("pesan_diterima")]
        public string PesanDiterima { get; set; }
    }
}