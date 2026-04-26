using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace jurnalModul8
{
    internal class BankTransferConfig
    {
        public string Lang { get; set; } = "en";
        public TransferData Transfer { get; set; } = new();
        public List<string> Methods { get; set; } = new() { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        public ConfirmationData Confirmation { get; set; } = new();

        private const string FilePath = "bank_transfer_config.json";
        private static readonly JsonSerializerOptions JsonOpts = new() { WriteIndented = true };

        public BankTransferConfig() => Load();

        private void Load()
        {
            if (!File.Exists(FilePath)) { Save(); return; }
            try
            {
                var json = File.ReadAllText(FilePath);
                var dto = JsonSerializer.Deserialize<ConfigDto>(json);
                if (dto != null)
                {
                    Lang = dto.Lang ?? Lang;
                    Transfer.Threshold = dto.Transfer?.Threshold ?? Transfer.Threshold;
                    Transfer.LowFee = dto.Transfer?.LowFee ?? Transfer.LowFee;
                    Transfer.HighFee = dto.Transfer?.HighFee ?? Transfer.HighFee;
                    Methods = dto.Methods ?? Methods;
                    Confirmation.En = dto.Confirmation?.En ?? Confirmation.En;
                    Confirmation.Id = dto.Confirmation?.Id ?? Confirmation.Id;
                }
            }
            catch { }
        }

        public void Save()
        {
            var dto = new ConfigDto { Lang = Lang, Transfer = Transfer, Methods = Methods, Confirmation = Confirmation };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(dto, JsonOpts));
        }
    }

    public class TransferData { public long Threshold { get; set; } = 25000000; public int LowFee { get; set; } = 6500; public int HighFee { get; set; } = 15000; }
    public class ConfirmationData { [JsonPropertyName("en")] public string En { get; set; } = "yes"; [JsonPropertyName("id")] public string Id { get; set; } = "ya"; }

    internal class ConfigDto
    {
        [JsonPropertyName("lang")] public string Lang { get; set; }
        [JsonPropertyName("transfer")] public TransferData Transfer { get; set; }
        [JsonPropertyName("methods")] public List<string> Methods { get; set; }
        [JsonPropertyName("confirmation")] public ConfirmationData Confirmation { get; set; }
    }
}
