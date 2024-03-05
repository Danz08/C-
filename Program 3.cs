namespace dasar_pemrograman_2;

class Program
{
    static void Main(string[] args)
    {
        //Deklarasi Variabel
        String introGame1;
        String introGame2;
        
        //angka rahasia
        int angkaPertama = 1; 
        int angkaKedua = 2; 
        int angkaKetiga = 3;

        //tebakan pemain 
        int tebakanPertama, tebakanKedua, tebakanKetiga, hasilTambah, hasilKali;

        //kondisi
        bool tebakanBerhasil, permainanSelesai;

        //perhitungan aritmatika
        hasilTambah = angkaPertama + angkaKedua + angkaKetiga;
        hasilKali = angkaPertama + angkaKedua + angkaKetiga;

        //Inisialisasi Variabel
        introGame1 = "Anda adalah agen rahasia yang ditugaskan meretas sebuah server.";
        introGame2 = "Password server terdiri dari 3 angka yang tidak diketahui.";


        //Tampilkan variabel pada layar 
        Console.WriteLine(introGame1);
        Console.WriteLine(introGame2);
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Hasil penjumlahan dari password adalah "+hasilTambah);
        Console.WriteLine("Hasil perkalian dari password adalah "+hasilKali);
        Console.WriteLine("Masukkan Password server : ");
        Console.Write("Angka pertama adalah");
        tebakanPertama = Convert.ToInt32(Console.ReadLine());
        Console.Write("Angka kedua adalah");
        tebakanKedua = Convert.ToInt32(Console.ReadLine());
        Console.Write("Angka Ketiga adalah");
        tebakanKetiga = Convert.ToInt32(Console.ReadLine());
        if(tebakanPertama == angkaPertama){
            Console.WriteLine("Selamat, tebakan anda benar. \nServer berhasil diretas!!!");
        }
        else{
            Console.WriteLine("Sayang sekali, tebakan anda salah. ***ALARM BERBUNYI***");
        }
        //Console.WriteLine($"Hasil penjumlahan dari password adalah {hasilTambah}");
       // Console.WriteLine("Hasil penjumlahan dari password adalah {0}", hasilTambah);

    }
}
