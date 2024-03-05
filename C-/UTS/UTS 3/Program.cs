namespace uts_3_daspro;

class Program
{
    static void Main(string[] args)
    {
        try
        {
        
        int areaTikus = 5;
        char tikus = 'T';
        char kosong = '~';
        char tikusHit = 'X';
        char salah = 'O';
        char tikusMati = 'x';
        int jumlahTikus = 3;

        Console.WriteLine(""); 
        Console.WriteLine("             Welcome To Game Tangkap Tikus Tanah");
        Console.WriteLine("");
        Console.WriteLine("Digame kali ini kamu akan menebak dimanakah tikus tanah tersebut berada...");
        Console.WriteLine("");
        Console.WriteLine("                         Tekan ENTER             ");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Silahkan menebak angka pilihan kamu...");
        Console.WriteLine("");
        
        char[,]area =  updateArea(areaTikus, kosong, tikus, jumlahTikus);

         
        petaTikus(area, kosong, tikus, tikusMati);

        int tikusHidup = jumlahTikus;

         while (tikusHidup > 0)
         {
            int[] koordinatTebak  = ambilKoordinat(areaTikus);
            char areaSekarang = verifikasiTebakan(koordinatTebak, area, tikus, kosong, tikusHit, salah, tikusMati);

            if (areaSekarang == tikusHit)                   
                {
                    tikusHidup--;
                }
                area = updateArea (area, koordinatTebak, areaSekarang);
                Console.WriteLine("tikus tersisa : "+tikusHidup);
                petaTikus(area, kosong, tikus, tikusMati);
            }
            Console.WriteLine("Selamat, kamu telah menebak semua tikus tanah...");
            Console.WriteLine("Game Selesai, Terimakasih telah bermain...");
        }
          catch(System.FormatException)
            {
                Console.WriteLine("Game Selesai. Kamu tidak menebak angka!!!");
            }
            catch(System.Exception)
            {
                Console.WriteLine("Kamu menebak selain angka 1-5!!!");
            }

    
    }
    

         private static void petaTikus(char[,] area, char kosong, char tikus, char tikusMati)
         {

            Console.Write("  ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + 1 + " ");
            }
            Console.WriteLine();
            for (int baris = 0; baris < 5; baris++)
            {
                Console.Write(baris + 1 + " ");
                for(int kolom = 0; kolom < 5; kolom++)
                {
                    char position = area[baris, kolom];
                    if(position == tikus)
                    {
                        Console.Write(kosong + " ");
                    }
                    else
                    {
                        Console.Write(position + " ");
                    }
                }
                Console.WriteLine();
            }
        }

         private static char verifikasiTebakan(int[] lokasiMenebak, char [,] area, char tikus, char kosong, char tikusHit, char salah, char tikusMati)
         {

            int baris = lokasiMenebak[0];
            int kolom = lokasiMenebak[1];
            char target = area[baris, kolom];
            
            if(target == tikus)
            {
                Console.WriteLine("Keren!!!, kamu berhasil menangkap tikus tanah!");
                Console.WriteLine("");
                target = tikusHit;
            }
            else if(target == kosong)
            {
                Console.WriteLine("Tebakanmu meleset, ayo terus menebak!!!");
                Console.WriteLine("");
                target = salah;
            }
            else if(target == tikusHit)
            {
                Console.WriteLine("tempat ini sudah kosong!!!");
                Console.WriteLine("");
                target = tikusMati;
            }
            else
            {
                Console.WriteLine("Disini tidak ada tikus tanah!!!");
                Console.WriteLine("");
            }
            return target;
        }

         private static char [,] updateArea( char[,] area, int [] koordinatTebakan, char updateTampilanArea)
    {
         int baris = koordinatTebakan[0];
            int kolom = koordinatTebakan [1];
            area[baris, kolom] = updateTampilanArea;
            return area;
    }     

    #pragma warning disable
    private static int[] ambilKoordinat(int areaTikus)
    {
        int baris;
        int kolom;

        do
        {
            Console.WriteLine(" ");
            Console.Write("Baris 1-5 : ");
            baris = Convert.ToInt32(Console.ReadLine());
            if (baris < 1 || baris > areaTikus || baris > 5)
            {
                Console.WriteLine("Game selesai!!!");
                return null;
            }
        }
        while (baris < 1 || baris > areaTikus || baris > 5);

        do
        {
            Console.Write("Kolom 1-5 : ");
            kolom = Convert.ToInt32(Console.ReadLine());
            if (kolom < 1 || kolom > areaTikus || kolom > 5)
            {
                Console.WriteLine("Game selesai!!!");
                return null;
            }
        }
        while (kolom < 1 || kolom > areaTikus || kolom > 5);
        Console.Clear();
        return new[] { baris - 1, kolom - 1 };
    }

        private static char[,] updateArea(int areaTikus,char kosong, char tikus, int jumlahTikus)
        {
            char[,] area = new char[areaTikus, areaTikus];
            for (int baris = 0; baris < areaTikus ; baris++)
            {
                for (int kolom = 0; kolom < areaTikus ; kolom++)
                {
                    area[baris, kolom] = kosong;
                }
            }
            return letakanTikus(area, jumlahTikus, kosong, tikus);
        }

        private static char[,] letakanTikus(char[,] area, int jumlahTikus, char kosong, char tikus)
        {
            int letakTikus= 0;
            int areaTikus = 5;

            while(letakTikus< jumlahTikus)
            {
                int[] lokasiTikus = generateTikusCoordinate(areaTikus);
                char positionOK= area[lokasiTikus[0], lokasiTikus[1]];

                if(positionOK == kosong)
                {
                    area[lokasiTikus[0], lokasiTikus[1]] = tikus;
                    letakTikus++;
                }
                
            }
            return area;
            
        }

        private static int[] generateTikusCoordinate(int areaTikus)
        {
            Random rnd = new Random();
            int[] coordinates = new int[2];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates [i] = rnd.Next(areaTikus);
            }
            return coordinates;
    }
}

