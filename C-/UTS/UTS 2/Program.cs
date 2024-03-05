using System;

enum ProdiFakultasTeknik
{
    Informatika,
    Elektro,
    Mesin,
    Kimia,
    Arsitektur,
    Sipil,
    Lingkungan,
    kertasdanPulp
}

class Program
{
    static void Main(string[] args)
    {
        string[] prodiFakultasTeknik = Enum.GetNames(typeof(ProdiFakultasTeknik));
        Random random = new Random();
        string kataRahasia = prodiFakultasTeknik[random.Next(prodiFakultasTeknik.Length)].ToLower();
        int kesempatan = 10;
        char[] hurufVocal = { 'a', 'i', 'u', 'e', 'o' };
        char[] hurufTebakan = new char[kataRahasia.Length];
        for (int i = 0; i < kataRahasia.Length; i++)
        {
            hurufTebakan[i] = '_';
        }

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Welcome to Permainan Tebak Kata.....");
        Console.WriteLine("Disini kamu akan menebak kata yang masih rahasia...");
        Console.WriteLine("Ketika kamu menebak huruf-huruf tersebut dengan benar, kamu akan menang...");
        Console.WriteLine("Tapi jika kamu menebaknya dengan salah, maka kesempatanmu akan berkurang....");
        Console.WriteLine($"Kamu memiliki kesempatan sebanyak {kesempatan} untuk menebak....");
        Console.ReadLine();
        Console.WriteLine("Are You Ready??? Ayo Mulai");
        Console.WriteLine();
        Console.WriteLine("       Tekan (ENTER)      ");
        Console.ReadLine();
        Console.WriteLine("Tebak kata rahasia: " + string.Join(" ", hurufTebakan));

        while (kesempatan > 0)
        {
            try
            {
                Console.WriteLine("Masukkan huruf tebakanmu (a-z) : ");
                char tebakan = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!char.IsLetter(tebakan))
                {
                    Console.WriteLine("Anda harus memasukkan huruf.");
                    continue;
                }

                bool hurufBenar = false;

                for (int i = 0; i < kataRahasia.Length; i++)
                {
                    if (kataRahasia[i] == tebakan)
                    {
                        hurufTebakan[i] = tebakan;
                        hurufBenar = true;
                    }
                }

                if (Array.Exists(hurufVocal, v => v == tebakan))
                {   kesempatan--;
                    if (!hurufBenar)
                    {
                        kesempatan--;
                        kesempatan++;
                    }
                }
                if (!hurufBenar){
                    kesempatan--;
                }

                TampilkanHangman(11- kesempatan);

                Console.WriteLine("Kesempatan tersisa: " + kesempatan);
                Console.WriteLine("Tebak kata rahasia: " + string.Join(" ", hurufTebakan));

                if (string.Join("", hurufTebakan) == kataRahasia)
                {
                    Console.WriteLine("Selamat, anda berhasil menebak kata rahasia");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Tebak kata rahasia: " + e.Message);
            }

            if (kesempatan == 0)
            {
                Console.WriteLine("Anda kalah! kata rahasia adalah: " + kataRahasia);
            }
        }
    }

    private static void TampilkanHangman(int kesempatan)
    {
        Console.WriteLine(kesempatan);
        switch (kesempatan)
        {
            case 1:
                Console.WriteLine("------------");
                Console.WriteLine("   | /");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 2:
                Console.WriteLine("------------");
                Console.WriteLine("   | /");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 3:
                Console.WriteLine("------------");
                Console.WriteLine("   | /");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 4:
                Console.WriteLine("------------");
                Console.WriteLine("   | /");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 5:
                Console.WriteLine("------------");
                Console.WriteLine("   | /");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 6:
                Console.WriteLine("------------");
                Console.WriteLine("   | /    |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 7:
                Console.WriteLine("------------");
                Console.WriteLine("   | /    |");
                Console.WriteLine("   |     (_)");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 8:
                Console.WriteLine("------------");
                Console.WriteLine("   | /    |");
                Console.WriteLine("   |     (_)");
                Console.WriteLine("   |     /|\\");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 9:
                Console.WriteLine("------------");
                Console.WriteLine("   | /    |");
                Console.WriteLine("   |     (_)");
                Console.WriteLine("   |     /|\\");
                Console.WriteLine("   |      |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
            case 10:
                Console.WriteLine("------------");
                Console.WriteLine("   | /    |");
                Console.WriteLine("   |     (_)");
                Console.WriteLine("   |     /|\\");
                Console.WriteLine("   |      |");
                Console.WriteLine("   |     / \\");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("-----");
                break;
        }
    }
}