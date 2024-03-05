namespace Dasar_Pemrograman_6;

class Program
{
    static void Main(string[] args)
    {
        
        //Game TicTacToe

        //Inisialisasi variabel awal
        char pemain = 'X';
        bool gameSelesai = false;
        char[,] papan = new char [3,3];

        init(papan);

        while(!gameSelesai)
        {
            Console.Clear();
            TampilkanPapan(papan);

            try{
                Console.Write("Baris (0-2) : ");
                int baris = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kolom (0-2) : ");
                int kolom = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Baris : "+baris+"Kolom : "+kolom);

                papan[baris,kolom] = pemain;
            
            }catch(Exception ex){
                Console.WriteLine("Error : "+ex.Message);
            }

            //cek menang atau seri
            if(CekMenang(papan,pemain)){
                TampilkanPapan(papan);
                Console.WriteLine(pemain+" adalah pemenangnya, selamat dan terimakasih telah bermain...");
                Console.Read();
                gameSelesai = true;
            }else if(CekSeri(papan)){
                TampilkanPapan(papan);
                Console.WriteLine("Permainan kali ini seri");
                Console.Read();
                gameSelesai = true;
            }
            pemain = GantiPemain(pemain);
        }


   
        static char GantiPemain(char pemain)
        {
            if(pemain =='X'){
                return 'O';
            }else{
                return 'X';
            }
        }

        static bool CekMenang(char[,] papan,char pemain){

            for(int i=0;i<3;i++){
                if(papan[i,0]==pemain && papan[i,1]==pemain && papan[i,2]==pemain) return true;
                if(papan[0,i]==pemain && papan[1,i]==pemain && papan[2,i]==pemain) return true;
            }

            if(papan[0,0]==pemain && papan[1,1]==pemain && papan[2,2]==pemain) return true;
            if(papan[0,2]==pemain && papan[1,1]==pemain && papan[2,0]==pemain) return true;
        
            return false;
        }

        static bool CekSeri(char[,] papan){
            for(int i=0;i<3;i++){
                for(int j=0;j<3;j++){
                    if(papan[i,j]==' ') return false;
                }
            }
            return true;
        }

        static void TampilkanPapan(char[,] papan){

            Console.WriteLine("  | 0 | 1 | 2 | ");
            for(int i=0;i<3;i++){
                Console.Write(i+ " | " );
                for(int j=0;j<3;j++){
                    Console.Write(papan[i,j]);
                    Console.Write( " | " );
                }
                Console.WriteLine();
            }
        }


        static void init(char[,] papan){
                for(int baris=0;baris<3;baris++){
                    for(int kolom=0;kolom<3;kolom++){
                        papan[baris,kolom] = ' ';
                    }
                    Console.WriteLine("");
                }
            }
    
        /*
        int[ , ] matriks = new  int [3 , 3];
        matriks[0,0] = 1;
        matriks[0,1] = 2;
        matriks[0,2] = 3;
        matriks[1,0] = 4;
        matriks[1,1] = 5;
        matriks[1,2] = 6;
        matriks[2,0] = 7;
        matriks[2,1] = 8;
        matriks[2,2] = 9;

        //menampilkan hasil matriks pada console
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                Console.Write(matriks[i,j]+ " ");
            }
            Console.WriteLine("");
        }

        int[,] matriks2 = new int[3,3] { {9, 8, 7},{6, 5, 4},{3, 2, 1}};

        int[,] tambah = PenambahanMatriks(matriks,matriks2);

        //menampilkan hasil matriks pada console
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                Console.Write(tambah[i,j]+ " ");
            }
            Console.WriteLine("");
        }

        

    static int[,] PenambahanMatriks(int[,] matriks1, int[,] matriks2){
            int[,] hasil = new int [3,3];

            //Penambahan Matriks
            for(int x=0;x<3;x++){
                for(int y=0;y<3;y++){
                    hasil [x,y] = matriks1[x,y] + matriks2[x,y];
                } 
            }
            return hasil;
        }*/

    }
}
