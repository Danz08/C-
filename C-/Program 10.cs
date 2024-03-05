//Safrin Nada Ramdani 2307111849 (TI A)

using System;
using System.Text;
using System.Threading;

namespace Dasar_Pemrograman_10;

class Program
{
    static int width = 50;
    static int height = 30;
    static int windowWidth; 
    static int windowHeight;
    static Random random = new();
    static char[,] scene;
    static int skor = 0;
    static int posisiMobil;
    static int kecepatanMobil;
    static bool mulaiMain;
    static bool lanjutMain = true;
    static bool consoleError = false;
    static int updateJalanRaya = 0;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        try
        {
            Init();
            tampilkanIntro();
            while (lanjutMain)
            {
                InitScene();
                while (mulaiMain)
                {
                    if (Console.WindowHeight < height || Console.WindowWidth < width)
                    {
                        consoleError = true;
                        lanjutMain = false;
                        break;
                    }
                    UserInput();
                    Update();
                    Render();
                    if (mulaiMain)
                    {
                        Thread.Sleep(TimeSpan.FromMilliseconds(33));                        
                    }
                    else
                    {
                        GameOverScreen();
                    }
                }
                Console.Clear();
                if (consoleError)
                {
                    Console.WriteLine("Console/Terminal terlalu kecil.");
                    Console.WriteLine($"Ukuran minimal layar adalah {width} x {height}");
                    Console.WriteLine("Perbesar ukuran layar console untuk dapat bermain.");
                }
            }
            Console.WriteLine("Permainan ditutup.");
        }
        finally
        {
            Console.CursorVisible = true;
        }
    }

    static void Init()
    {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
        if (OperatingSystem.IsWindows())
        {
            if (windowWidth < width && OperatingSystem.IsWindows())
            {
                windowWidth = Console.WindowWidth = width + 1;
            }
            if (windowHeight < height && OperatingSystem.IsWindows())
            {
                windowHeight = Console.WindowHeight = height + 1;
            }
            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
        }
    }

    static void tampilkanIntro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Name : ");
        string? nama = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"selamat datang di permainan mengemudi ({nama})\n");
        Thread.Sleep(1000);
        Console.WriteLine("Kamu harus mengarahkan mobil agar tetap berada dijalan raya!!!\n");
        Thread.Sleep(1500);
        Console.WriteLine("untuk mengarahkan mobil : \n#Tekan A, W, dan D atau \n#panah kiri, panah atas, dan panah kanan\n");
        Thread.Sleep(1500);
        Console.WriteLine("Jangan sampai keluar dari Jalan!!!");
        Console.Write("Tekan [Enter] untuk mulai\n");
        TekanEnterUntukLanjut();
    }

    static void TekanEnterUntukLanjut()
    {
    GetInput:
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                break;
            case ConsoleKey.Escape:
                lanjutMain = false;
                break;
            default:
                goto GetInput;
        }
    }

    static void InitScene()
    {
        const int lebarJalan = 10;
        mulaiMain = true;
        posisiMobil = width / 2;
        kecepatanMobil = 0;
        int batasKiri = (width - lebarJalan) / 2;
        int batasKanan = batasKiri + lebarJalan + 1;
        scene = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j < batasKiri || j > batasKanan)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    scene[i, j] = '.';
                }
                else
                {
                    scene[i, j] = ' ';
                }
            }
        }
    }

    static void Render()
    {
        StringBuilder stringBuilder = new(width * height);
        for (int i = height - 1; i >= 0; i--)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 1 && j == posisiMobil)
                {
                    stringBuilder.Append
                    (
                        !mulaiMain ? 'X' :
                        kecepatanMobil < 0 ? '‹' :
                        kecepatanMobil > 0 ? '›' :
                        '^'
                    );
                }
                else
                {
                    stringBuilder.Append(scene[i, j]);
                }
            }
            if (i > 0)
            {
                stringBuilder.AppendLine();
            }
        }
        Console.SetCursorPosition(0, 0);
        Console.Write(stringBuilder);
    }

    static void UserInput()
    {
        while (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A or ConsoleKey.LeftArrow:
                    kecepatanMobil = -1;
                    break;
                case ConsoleKey.D or ConsoleKey.RightArrow:
                    kecepatanMobil = +1;
                    break;
                case ConsoleKey.W or ConsoleKey.UpArrow or ConsoleKey.S or ConsoleKey.DownArrow:
                    kecepatanMobil = 0;
                    break;
                case ConsoleKey.Escape:
                    mulaiMain = false;
                    lanjutMain = false;
                    break;
                case ConsoleKey.Enter:
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void GameOverScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("permainan selesai");
        Console.WriteLine($"skor: {skor}");
        Console.WriteLine($"main lagi?\n (Y/N)");
    GetInput:
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Y:
                lanjutMain = true;
                skor = 0;
                break;
            case ConsoleKey.N or ConsoleKey.Escape:
                lanjutMain = false;
                break;
            default:
                goto GetInput;
        }
    }

    static void Update()
    {
        for (int i = 0; i < height - 1; i++)
        {
            for (int j = 0; j < width; j++)
            {
                scene[i, j] = scene[i + 1, j];
            }
        }

        int updateJalan =
            random.Next(5) < 4 ? updateJalanRaya :
            random.Next(3) - 1;
        if (updateJalan is -1 && scene[height - 1, 0] is ' ') updateJalan = 1;
        if (updateJalan is 1 && scene[height - 1, width - 1] is ' ') updateJalan = -1;
        switch (updateJalan)
        {
            case -1: // kiri
                for (int i = 0; i < width - 1; i++)
                {
                    scene[height - 1, i] = scene[height - 1, i + 1];
                }
                scene[height - 1, width - 1] = '.';
                break;
            case 1: // kanan
                for (int i = width - 1; i > 0; i--)
                {
                    scene[height - 1, i] = scene[height - 1, i - 1];
                }
                scene[height - 1, 0] = '.';
                break;
        }
        updateJalanRaya = updateJalan;
        posisiMobil += kecepatanMobil;
        if (posisiMobil < 0 || posisiMobil >= width || scene[1, posisiMobil] is not ' ') 
        {
            mulaiMain = false;
        }
        skor++;
    }
}