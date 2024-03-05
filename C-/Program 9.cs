using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dasar_Pemrograman_9;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]

class Program
{
    static int kiri = 0;
    static int kanan = 1;
    static int atas = 2;
    static int bawah = 3;

    //pemain 1
    static int skorPemain1 = 0;
    static int arahPemain1 = kanan;
    static int kolomPemain1 = 0;
    static int barisPemain1 = 0;

    //pemain 2
    static int skorPemain2 = 0;
    static int arahPemain2 = kiri;
    static int kolomPemain2 = 40;
    static int barisPemain2 = 5;

    //Posisi Teks ketika menang supaya tetap berada di satu tempat
    static int posisiTeksX;
    static int posisiTeksY;

    static bool[,]? isUsed;
    
    static void Main(string[] args)
    {
        AturLayarPermainan();
        
        LayarAwal();

        isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
        
        while(true)
        {
            
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                UbahGerakanPemain(key);
            }

            GerakanPemain();

            bool pemain1Kalah = CekKalah(barisPemain1, kolomPemain1);
            bool pemain2Kalah = CekKalah(barisPemain2, kolomPemain2);

            if(pemain1Kalah && pemain2Kalah)
            {
                skorPemain1++;
                skorPemain2++;
                Console.WriteLine("");
                if (posisiTeksY >= 0 && posisiTeksY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(posisiTeksX, posisiTeksY);
                }
                Console.WriteLine("Permainan dinyatakan seri!!!");
                Console.WriteLine($"Skor Sementara : {skorPemain1} - {skorPemain2}");
                ResetGame();
            }
            else if(pemain1Kalah)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                skorPemain2++;
                Console.WriteLine("");
                if (posisiTeksY >= 0 && posisiTeksY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(posisiTeksX, posisiTeksY);
                }
                Console.WriteLine("Pemain 2 Menang");
                Console.WriteLine($"Skor Sementara : {skorPemain1} - {skorPemain2}");
                ResetGame();
            }
            else if(pemain2Kalah)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                skorPemain1++;
                Console.WriteLine("");
                if (posisiTeksY >= 0 && posisiTeksY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(posisiTeksX, posisiTeksY);
                }
                Console.WriteLine("Pemain 1 Menang");
                Console.WriteLine($"Skor Sementara : {skorPemain1} - {skorPemain2}");
                ResetGame();
            }
            if(skorPemain1 == 5 || skorPemain2 == 5)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Permainan telah Usai.");
                Console.WriteLine("ketik y untuk Memulai Ulang, ketik n untuk berhenti.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char e = keyInfo.KeyChar;
                if (e == 'y')
                {
                    skorPemain1 = 0;
                    skorPemain2 = 0;
                    Console.Clear();
                }
                else if (e == 'n')
                {
                    Console.Clear();
                    Console.WriteLine("Terimakasih Telah Bermain");
                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Anda Tidak Memasukkan inputnya...");
                    Environment.Exit(0);
                }
            }
            

            isUsed[kolomPemain1, barisPemain1] = true;
            isUsed[kolomPemain2, barisPemain2] = true;

            WriteInPosition(kolomPemain1, barisPemain1, '»' ,ConsoleColor.Blue);
            WriteInPosition(kolomPemain2, barisPemain2, '«' ,ConsoleColor.Magenta);

            Thread.Sleep(50);
        }
    }

    static void WriteInPosition(int kolom, int baris, char x, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(kolom, baris);
        Console.Write(x);
    }
    

    static void ResetGame()
    {
        isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
        AturLayarPermainan();
        arahPemain1 = kanan;
        arahPemain2 = kiri;
        Console.ReadKey();
        Console.Clear();
        GerakanPemain();
    }

    static bool CekKalah(int baris, int kolom)
    {
        if (baris < 0)
        {
            return true;
        }
        if (kolom < 0)
        {
            return true;
        }
        if (baris >= Console.WindowHeight)
        {
            return true;
        }
        if (kolom >= Console.WindowWidth)
        {
            return true;
        }
        if (isUsed[kolom, baris])
        {
            return true;
        }
        return false;
    }

    static void GerakanPemain()
    {
        //pemain 1
        if (arahPemain1 == kanan)
        {
            kolomPemain1++;
        }
        if (arahPemain1 == kiri)
        {
            kolomPemain1--;
        }
        if (arahPemain1 == atas)
        {
            barisPemain1--;
        }
        if (arahPemain1 == bawah)
        {
            barisPemain1++;
        }

        //pemain 2
        if (arahPemain2 == kanan)
        {
            kolomPemain2++;
        }
        if (arahPemain2 == kiri)
        {
            kolomPemain2--;
        }
        if (arahPemain2 == atas)
        {
            barisPemain2--;
        }
        if (arahPemain2 == bawah)
        {
            barisPemain2++;
        }
    }

    static void UbahGerakanPemain(ConsoleKeyInfo key)
    {
        //pemain 1
        if (key.Key == ConsoleKey.W && arahPemain1 != bawah)
        {
            arahPemain1 = atas;
        }

        if (key.Key == ConsoleKey.A && arahPemain1 != kanan)
        {
            arahPemain1 = kiri;
        }
        
        if (key.Key == ConsoleKey.S && arahPemain1 != atas)
        {
            arahPemain1 = bawah;
        }
        
        if (key.Key == ConsoleKey.D && arahPemain1 != kiri)
        {
            arahPemain1 = kanan;
        }

        //pemain 2
        if (key.Key == ConsoleKey.UpArrow && arahPemain2 != bawah)
        {
            arahPemain2 = atas;
        }
        if (key.Key == ConsoleKey.LeftArrow && arahPemain2 != kanan)
        {
            arahPemain2 = kiri;
        }
        
        if (key.Key == ConsoleKey.DownArrow && arahPemain2 != atas)
        {
            arahPemain2 = bawah;
        }
        
        if (key.Key == ConsoleKey.RightArrow && arahPemain2 != kiri)
        {
            arahPemain2 = kanan;
        }
    }

    static void LayarAwal()
    {
        Console.Clear();
        string? heading = "Welcome to Game TRON";
        Console.CursorLeft = Console.BufferWidth / 2 - heading.Length / 4;
        Console.WriteLine(heading);
        Thread.Sleep(1000);
        Console.CursorLeft = Console.BufferWidth / 7 - heading.Length / 4;
        Console.WriteLine("Game Tron adalah sebuah permainan, dimana 2 orang pemain akan bertarung satu sama lain");
        Thread.Sleep(500);
        Console.CursorLeft = Console.BufferWidth / 12 - heading.Length / 4;
        Console.WriteLine("Aturannya yaitu jangan menabrak musuh dan keluar dari rintangan serta tidak diperbolehkan menabrak diri sendiri ");
        Thread.Sleep(500);
        Console.CursorLeft = Console.BufferWidth / 2 - heading.Length / 4;
        Console.WriteLine("Selamat bermain, Gamers!!!");
        Thread.Sleep(1500);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("kontrol untuk pemain : 1 ");
        Console.WriteLine("W => Atas");
        Console.WriteLine("A => Kiri");
        Console.WriteLine("S => Bawah");
        Console.WriteLine("D => Kanan");

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("kontrol untuk pemain : 2 ");
        Console.WriteLine("Panah Atas => Atas");
        Console.WriteLine("Panah Kiri => Kiri");
        Console.WriteLine("Panah Bawah => Bawah");
        Console.WriteLine("Panah Kanan => Kanan");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("ENTER untuk melanjutkan");
        Console.ReadLine();
        Console.Clear();
    }

    static void AturLayarPermainan()
    {
        
        Console.WindowHeight = 30;
        Console.WindowWidth = 100;
        
        Console.BufferHeight = 30;
        Console.BufferWidth = 100;

        kolomPemain1 = 0;
        barisPemain1 = Console.WindowHeight / 2;

        kolomPemain2 = Console.WindowWidth - 1;
        barisPemain2 = Console.WindowHeight / 2;

        posisiTeksX = 0;
        posisiTeksY = 0;
    }
}
