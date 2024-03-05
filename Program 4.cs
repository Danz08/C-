using System.Collections;

namespace Dasar_Pemrograman_4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Array : ");
        //Array
        string[] namaMahasiswa = new string[5];
        namaMahasiswa[0] = "Dani";
        namaMahasiswa[1] = "Ferry";
        namaMahasiswa[2] = "Arif";
        namaMahasiswa[3] = "Ichwan";
        namaMahasiswa[4] = "Werd";

        for (int i = 0; i < namaMahasiswa.Length; i++)
        {
            Console.WriteLine("Nama Mahasiswa : " + namaMahasiswa[i]);
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Mahasiswa Semester 2 : ");

        namaMahasiswa[1] = "Dea";
        namaMahasiswa[2] = "Ridwan Honda";
        namaMahasiswa[4] = "Alfan";

        for (int i = 0; i < namaMahasiswa.Length; i++)
        {
            Console.WriteLine("Nama Mahasiswa : " + namaMahasiswa[i]);
        }

        //ArrayList
        Console.WriteLine("ArrayList : ");
        ArrayList namaMahasiswaList = new ArrayList();
        namaMahasiswaList.Add("Dani");
        namaMahasiswaList.Add("Ferry");
        namaMahasiswaList.Add("Arif");
        namaMahasiswaList.Add("Ichwan");
        namaMahasiswaList.Add("Werd");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Nama Mahasiswa : " + namaMahasiswaList[i]);
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Mahasiswa Semester 2 : ");

        namaMahasiswaList.Remove("Ferry");
        namaMahasiswaList.Remove("Arif");
        namaMahasiswaList.Remove("Werd");

        namaMahasiswaList.Add("Dea");
        namaMahasiswaList.Add("Ridwan Honda");
        namaMahasiswaList.Add("Alfan");

        foreach (string name in namaMahasiswaList)
        {
            Console.WriteLine("Nama Mahasiswa : " + name);
        }
    }
}

//for(int i=0;i<namaMahasiswa.Length;i++){
// Console.WriteLine("Nama Mahasiswa : "+namaMahasiswa[i]);
