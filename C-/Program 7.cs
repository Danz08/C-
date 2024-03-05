//Safrin Nada Ramdani_2307111849
//TI A

namespace Mahasiswa_2;

class Program
{



    static void Main(string[] args)
    {

        Console.WriteLine("Masukkan Nama Mahasiswa : ");
        string? nama = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Masukkan NIM Mahasiswa : ");
        string? nim = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Masukkan Nilai Mahasiswa : ");
        if (double.TryParse(Console.ReadLine(), out double nilaiAngka))
        {
            if (nilaiAngka > 100)
            {
                Console.WriteLine("Nilai yang anda masukkan tidak valid");
            }
            else
            {
                Mahasiswa mhs1 = new Mahasiswa(nama, nim, nilaiAngka);

                mhs1.absen = true;
                mhs1.nilaiAngka = nilaiAngka;
                mhs1.Pengenalan();
                mhs1.hitungNilai();
            }
        }
        else
        {
            Console.WriteLine("Tidak ada nilai yang dimasukkan");
        }
    }
}


class Mahasiswa
{
    public string nama;
    public string nim;
    public bool absen;
    public double nilaiAngka;
    public string nilaiHuruf;


    public Mahasiswa(string Nama, string NIM, double Nilai)
    {
        Console.Clear();
        nama = Nama;
        nim = NIM;
        nilaiAngka = Nilai;
    }

    public void Pengenalan()
    {
        Console.WriteLine($"Nama : {nama}\nNim  : {nim}");
    }

    public void hitungNilai()
    {
        if (nilaiAngka >= 90) nilaiHuruf = "A";
        else if (nilaiAngka >= 85 && nilaiAngka < 90) nilaiHuruf = "A-";
        else if (nilaiAngka >= 80 && nilaiAngka < 85) nilaiHuruf = "B";
        else if (nilaiAngka >= 75 && nilaiAngka < 80) nilaiHuruf = "B-";
        else if (nilaiAngka >= 70 && nilaiAngka < 75) nilaiHuruf = "C";
        else if (nilaiAngka >= 65 && nilaiAngka < 70) nilaiHuruf = "D";
        else if (nilaiAngka < 60) nilaiHuruf = "E";
        else nilaiHuruf = "E";

        if (!absen || nilaiHuruf == "E")
        {
            Console.WriteLine($"Maaf, Mahasiswa  dengan Nama : {nama}, NIM : {nim} Jumlah nilai : {nilaiAngka} ({nilaiHuruf}) dinyatakan tidak lulus");
        }
        else
        {
            Console.WriteLine($"Selamat, Mahasiswa dengan nama : {nama}, NIM : {nim} Jumlah nilai {nilaiAngka} ({nilaiHuruf}) dinyatakan Lulus");
        }
    }
}