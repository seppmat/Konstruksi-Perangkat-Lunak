using jurnalModul8;
using System;

class Program
{
    static void Main()
    {
        var cfg = new BankTransferConfig();
        bool isEn = cfg.Lang.Equals("en", StringComparison.OrdinalIgnoreCase);

        Console.Write(isEn ? "Please insert the amount of money to transfer: " : "Masukkan jumlah uang yang akan di-transfer: ");
        decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

        decimal fee = amount <= cfg.Transfer.Threshold ? cfg.Transfer.LowFee : cfg.Transfer.HighFee;
        decimal total = amount + fee;

        Console.WriteLine(isEn ? $"Transfer fee = {fee}" : $"Biaya transfer = {fee}");
        Console.WriteLine(isEn ? $"Total amount = {total}" : $"Total biaya = {total}");

        Console.WriteLine(isEn ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < cfg.Methods.Count; i++) Console.WriteLine($"{i + 1}. {cfg.Methods[i]}");

        string key = isEn ? cfg.Confirmation.En : cfg.Confirmation.Id;
        Console.Write(isEn ? $"Please type \"{key}\" to confirm the transaction: " : $"Ketik \"{key}\" untuk mengkonfirmasi transaksi: ");
        string resp = Console.ReadLine()?.Trim();

        Console.WriteLine(resp?.Equals(key, StringComparison.OrdinalIgnoreCase) == true
            ? (isEn ? "The transfer is completed" : "Proses transfer berhasil")
            : (isEn ? "Transfer is cancelled" : "Transfer dibatalkan"));
    }
}