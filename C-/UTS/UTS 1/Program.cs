namespace UTS;

class Program
{
    static void Intro()
    {
        Console.WriteLine("-------------------Adu Dadu-------------------\n");
        Console.ReadLine();
        Console.WriteLine("Pada game ini anda dan komputer anda akan bermain 10 ronde.");
        Console.ReadLine();
        Console.WriteLine("Setiap putaran dadu akan dilempar menghasilkan nilai tertentu.");
        Console.ReadLine();
        Console.WriteLine("Nilai dadu tertinggi akan menjadi pemenang ronde tersebut.");
        Console.ReadLine();
        Console.WriteLine("Siapa yang akan menang? Selamat berjuang.");
        Console.ReadLine();
        Console.Write("..............Mulai Main..............\n");
        Console.ReadLine();
    }

    static int lempar_dadu()
    {
        //Random
        Random rnd = new Random();
        return rnd.Next(1, 7);
    }

    static void Main(string[] args)
    {
        //Deklarasi variabel
        int skor_pemain = 0,
            skor_komputer = 0,
            dadu_pemain,
            dadu_komputer;

        //Intro
        Intro();

        //Loop
        for (int ronde = 1; ronde <= 10; ronde++)
        {
            Console.WriteLine($"Ronde {ronde}");
            Console.Write("Lembar dadu anda...\n");
            dadu_pemain = lempar_dadu();
            Console.WriteLine($"Nilai anda : {dadu_pemain}");
            Console.ReadLine();
            dadu_komputer = lempar_dadu();
            Console.WriteLine($"Nilai komputer : {dadu_komputer}");

            //Perbandingan hasil
            if (dadu_komputer == dadu_pemain)
            {
                Console.WriteLine("Hasil seri pada ronde ini.");
            }
            else if (dadu_komputer > dadu_pemain)
            {
                Console.WriteLine("Komputer memenangkan ronde ini.");
                //Menambahkan skor komputer
                skor_komputer++;
            }
            else
            {
                Console.WriteLine("Anda memenangkan ronde ini.");
                //Menambahkan skor pemain
                skor_pemain++;
            }
            Console.ReadLine();
        }
        //Pengecekan hasil terakhir
        Console.WriteLine("Permainan selesai, silahkan lihat hasil anda.");
        Console.ReadLine();
        Console.WriteLine($"Skor Akhir - Anda : {skor_pemain} | komputer : {skor_komputer}");
        Console.ReadLine();
        if (skor_komputer == skor_pemain)
        {
            Console.WriteLine("Hasil seri");
        }
        else if (skor_komputer > skor_pemain)
        {
            Console.WriteLine("Sayang sekali, Anda kalah! Ternyata komputer lebih handal dari pada anda, coba dilain waktu");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Selamat, Anda menang! Hebat sekali anda bisa mengalahkan komputer.");
            Console.ReadLine();
        }
        Console.WriteLine("Terima kasih sudah bermain...");

    }
}
