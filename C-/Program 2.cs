namespace dasar_pemrograman_2;

class Program
{

    static void Intro()
    {
        //Deklarasi Variabel
        string introGame1;
        string introGame2;
        Console.WriteLine("Masukkan nama anda : ");
        string nama = Console.ReadLine();
        Console.WriteLine($"Halo {nama}, Welcome to the my game bro, ENJOY");
        Console.ReadLine();

        //Inisialisasi Variabel
        introGame1 = $"{nama}, Anda adalah agen rahasia yang ditugaskan meretas sebuah server.";
        introGame2 = "Password server terdiri dari 3 angka yang tidak diketahui.";
        Console.ReadLine();

        //Print intro to console
        Console.WriteLine(introGame1);
        Console.WriteLine(introGame2);
    }


    static void Main(string[] args)
    {
        //RNG
        Random rng = new Random();

        //angka rahasia
        int angkaPertama = rng.Next(1, 4);
        int angkaKedua = rng.Next(1, 4);
        int angkaKetiga = rng.Next(1, 4);

        //tebakan pemain 
        int tebakanPertama, tebakanKedua, tebakanKetiga, hasilTambah, hasilKali;

        //kondisi
        bool tebakanBerhasil, permainanSelesai;

        //perhitungan aritmatika
        hasilTambah = angkaPertama + angkaKedua + angkaKetiga;
        hasilKali = angkaPertama + angkaKedua + angkaKetiga;

        //Tampilkan variabel pada layar 
        Intro();
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Hasil penjumlahan dari password adalah " + hasilTambah);
        Console.WriteLine("Hasil perkalian dari password adalah " + hasilKali);
        Console.ReadLine();
        Console.WriteLine("Masukkan Password server : ");

        //Loop
        int kesempatan = 1;
        while (kesempatan <= 5)
        {
            Console.WriteLine("Kesempatan: " + kesempatan);
            kesempatan++;

            //INPUT USER DAN IF ELSE
            Console.Write("Input angka pertama : ");
            tebakanPertama = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input angka kedua : ");
            tebakanKedua = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input angka ketiga : ");
            tebakanKetiga = Convert.ToInt32(Console.ReadLine());
            if (tebakanPertama == angkaPertama && tebakanKedua == angkaKedua && tebakanKetiga == angkaKetiga)
            {
                Console.WriteLine("Selamat, tebakan anda benar. \nServer berhasil diretas!!!");
                kesempatan = 6;
            }
            else
            {
                Console.WriteLine("Sayang sekali, tebakan anda salah. ***ALARM BERBUNYI***");
                Console.WriteLine($"Kode yang benar adalah {angkaPertama}, {angkaKedua}, {angkaKetiga}");
            }
        }
    }
    //Console.WriteLine("Kode yang benar adalah {0},{1},{2}",angkaPertama,angkaKedua,angkaKetiga);
    //Console.WriteLine($"Hasil penjumlahan dari password adalah {hasilTambah}");
    // Console.WriteLine("Hasil penjumlahan dari password adalah {0}", hasilTambah);
}




