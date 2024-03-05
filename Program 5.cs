namespace Dasar_Pemrograman_5;

class Program
{
    static void Main(string[] args)
    {
        int[] angka ={20, 11, 5, 0, 9, 3, 7, 4, 8, 0};
        Bagi (angka);
    }
    static void Bagi(int[] angka){
        for(int i=0;i<10;i++)
        {
            try
            {
                int pembagian = angka[i] / angka [i + 1];
                Console.WriteLine("Pembagian : " +pembagian);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Runtime Error : Pembagian dengan Nol. "+ e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Runtime Error : Index Array tidak valid. "+  e.Message);
            }
        }               
        InputBagi();
    
    }
    static void InputBagi()
    {
        try
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Masukkan Angka Pertama Anda...");
            double angkaPertama = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Masukkan Angka Kedua Anda...");
            double angkaKedua = Convert.ToDouble(Console.ReadLine());
            double hasil = angkaPertama / angkaKedua;
            Console.WriteLine($"Hasilnya Adalah {hasil}");
        }
        catch(DivideByZeroException e)
        {
            Console.WriteLine("Runtime Error : Pembagian dengan Nol. "+ e.Message);
            InputBagi();
        }
        catch(FormatException e)
        {
            Console.WriteLine("Runtime Error : IndexOutOfRange "+ e.Message);
            InputBagi();
        }
    }
}