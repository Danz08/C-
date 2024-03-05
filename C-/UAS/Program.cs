//Safrin Nada Ramdani_2307111849

using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading;

namespace UAS_Safrin_Nada_Ramdani;

class Program
{
    static void Main(string[] args)
    {

    string[] Tank =
    {
    null!,
    // Atas
	@" _^_ " + "\n" +
	@"|___|" + "\n" +
	@"[ooo]" + "\n",
	// Bawah
	@" ___ " + "\n" +
	@"|_O_|" + "\n" +
	@"[ooo]" + "\n",
	// Kiri
	@"  __ " + "\n" +
	@"=|__|" + "\n" +
	@"[ooo]" + "\n",
	// Kanan
	@" __  " + "\n" +
	@"|__|=" + "\n" +
	@"[ooo]" + "\n",
    };

    string[] TankShooting =
    {
    null!,
    // Atas
	@" _█_ " + "\n" +
	@"|___|" + "\n" +
	@"[ooo]" + "\n",
	// Bawah
	@" ___ " + "\n" +
	@"|_█_|" + "\n" +
	@"[ooo]" + "\n",
	// Kiri
	@"  __ " + "\n" +
	@"█|__|" + "\n" +
	@"[ooo]" + "\n",
	// Kanan
	@" __  " + "\n" +
	@"|__|█" + "\n" +
	@"[ooo]" + "\n",
    };

    string [] TankExploding =
    {
    // Ka...
	@" ___ " + "\n" +
	@"|___|" + "\n" +
	@"[ooo]" + "\n",
	// Boom
	@"█████" + "\n" +
	@"█████" + "\n" +
	@"█████" + "\n",
	// Dead
	@"     " + "\n" +
	@"     " + "\n" +
	@"     " + "\n",
    };

    char[] Bullet = //karakter peluru tank
    {
        default,
        '^', // Up
	    'v', // Down
	    '<', // Left
	    '>', // Right
    };

    string Map =
    
    @"╔═════════════════════════════════════════════════════════════════════════╗" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║     ═════                                                     ═════     ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                    ║                                    ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"║                                                                         ║" + "\n" +
	@"╚═════════════════════════════════════════════════════════════════════════╝" + "\n";
        //deklarasikan dan inisialisasi variabel
        //2 buat list : tank dan tanks, player(objek tank) dan nilai random
        var Tanks = new List<Tank>();
        var AllTanks = new List<Tank>();
        var Player = new Tank() { X = 08, Y = 05, IsPlayer = true};

        //Tambahkan player dan 3 tank lain (AI) kedalam list tanks
        Tanks.Add(Player);
        Tanks.Add(new Tank() { X = 08, Y = 21, });
        Tanks.Add(new Tank() { X = 66, Y = 05, });
        Tanks.Add(new Tank() { X = 66, Y = 21, });
        AllTanks.AddRange(Tanks);

        //set width dan height console window supaya game leluasa untuk dimainkan
        Console.CursorVisible = false;
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = Math.Max(Console.WindowWidth, 90);
            Console.WindowHeight = Math.Max(Console.WindowHeight, 35);//besar sistem termasuk tulisan dengan terminalnya
        }
        //clear console
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        //render map game
        Render(Map);
        Console.WriteLine();
        //tuliskan intro "gunakan WASD untuk bergerak dan tombol panah untuk menembak"
        Console.WriteLine("Halo Player, Disini kamu akan bermain Battle Tank");
        Console.WriteLine("gunakan WASD untuk bergerak dan tombol panah untuk menembak");

        //Render
        static void Render(string @string, bool renderSpace = false)
        {
            int x = Console.CursorLeft;//render dimulai dari kiri atas
            int y = Console.CursorTop;
            foreach (char c in @string)
                if (c is '\n') Console.SetCursorPosition(x, ++y);
                else if (c is not ' ' || renderSpace) Console.Write(c);
                else Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
        }

        //gameplay
        while (Tanks.Contains(Player) && Tanks.Count > 1)
        {
            foreach (var tank in Tanks)
            {
                //buat logika arah tembakan pemain/tank
                if (tank.IsShooting)
                {
                    tank.Bullet = new Bullet()
                    {
                        X = tank.Arah switch
                        {
                            Arah.Left => tank.X - 3, //atur peluru sesuai dengan arah  moncong tank
                            Arah.Right => tank.X + 3,
                            _ => tank.X,
                        },
                        Y = tank.Arah switch
                        {
                            Arah.Up => tank.Y - 2, //atur peluru sesuai dengan arah  moncong tank
                            Arah.Down => tank.Y + 2,
                            _ => tank.Y,
                        },
                        Arah = tank.Arah,
                    };
                    tank.IsShooting = false;
                    continue;
                }
                //buat logika untuk menampilkan animasi ledakan tank
                if (tank.IsExploding)
                {
                    tank.ExplodingFrame++;
                    Console.SetCursorPosition(tank.X - 2, tank.Y - 1);
                    Render(tank.ExplodingFrame > 9 //menampilkan animasi ledakan sampai nilai nya 9 sebelum tank meledak
                        ? TankExploding[2]//menghilangkan animasi tank
                        : TankExploding[tank.ExplodingFrame % 2], true);//membuat pergantian animasi exploding  0 dan 1
                    continue;
                }
                //tank lain atau terkena tembakan tank lain (bullet)

                bool CheckGerakan(Tank gerakTank, int X, int Y)
                {
                    //buat pendeteksi tabrakan tank dengan tank lain atau dengan batas dinding
                    foreach (var tank in Tanks)
                    {
                        if (tank == gerakTank)
                        {
                            continue;
                        }
                        if (Math.Abs(tank.X - X) <= 4 && Math.Abs(tank.Y - Y) <= 2)//tabrakan tank
                        {
                            return false;
                        }
                    }
                    if (X < 3 || X > 71 || Y < 2 || Y > 25) //tabrakan dinding
                    {
                        return false;
                    }
                    if (3 < X && X < 13 && 11 < Y && Y < 15) //tabrakan hambatan kiri
                    {
                        return false;
                    }
                    if (34 < X && X < 40 && 2 < Y && Y < 8) //tabrakan hambatan atas
                    {
                        return false;
                    }
                    if (34 < X && X < 40 && 19 < Y && Y < 25) // tabrakan hambatan bawah
                    {
                        return false;
                    }
                    if (61 < X && X < 71 && 11 < Y && Y < 15)// tabrakan hambatan kanan
                    {
                        return false;
                    }
                    return true;
                }

                void TryGerakan(Arah arah)
                {
                    //metode untuk gerakan pemain/tank (atas, bawah, kiri, kanan)
                    switch (arah)
                    {
                        case Arah.Up:
                            if (CheckGerakan(tank, tank.X, tank.Y - 1))
                            {
                                Console.SetCursorPosition(tank.X - 2, tank.Y + 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X - 1, tank.Y + 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X, tank.Y + 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 1, tank.Y + 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 2, tank.Y + 1);
                                Console.Write(' ');
                                tank.Y--;
                            }
                            break;
                        case Arah.Down:
                            if (CheckGerakan(tank, tank.X, tank.Y + 1))
                            {
                                Console.SetCursorPosition(tank.X - 2, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X - 1, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 1, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 2, tank.Y - 1);
                                Console.Write(' ');
                                tank.Y++;
                            }
                            break;
                        case Arah.Left:
                            if (CheckGerakan(tank, tank.X - 1, tank.Y))
                            {
                                Console.SetCursorPosition(tank.X + 2, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 2, tank.Y);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X + 2, tank.Y + 1);
                                Console.Write(' ');
                                tank.X--;
                            }
                            break;
                        case Arah.Right:
                            if (CheckGerakan(tank, tank.X + 1, tank.Y))
                            {
                                Console.SetCursorPosition(tank.X - 2, tank.Y - 1);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X - 2, tank.Y);
                                Console.Write(' ');
                                Console.SetCursorPosition(tank.X - 2, tank.Y + 1);
                                Console.Write(' ');
                                tank.X++;
                            }
                            break;
                    }
                }

                if (tank.IsPlayer)
                {
                    //implementasi player input (keyboard) untuk gerak dan menembak
                    Arah? gerakan = null;
                    Arah? tembakan = null;

                    while (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            //GERAKAN
                            case ConsoleKey.W: gerakan = gerakan.HasValue ? Arah.Null : Arah.Up; break;
                            case ConsoleKey.S: gerakan = gerakan.HasValue ? Arah.Null : Arah.Down; break;
                            case ConsoleKey.A: gerakan = gerakan.HasValue ? Arah.Null : Arah.Left; break;
                            case ConsoleKey.D: gerakan = gerakan.HasValue ? Arah.Null : Arah.Right; break;

                            //TEMBAKAN
                            case ConsoleKey.UpArrow: tembakan = tembakan.HasValue ? Arah.Null : Arah.Up; break;
                            case ConsoleKey.DownArrow: tembakan = tembakan.HasValue ? Arah.Null : Arah.Down; break;
                            case ConsoleKey.LeftArrow: tembakan = tembakan.HasValue ? Arah.Null : Arah.Left; break;
                            case ConsoleKey.RightArrow: tembakan = tembakan.HasValue ? Arah.Null : Arah.Right; break;

                            //keluar dari game
                            case ConsoleKey.Escape:
                                Console.Clear();
                                Console.Write("Permainan telah selesai.");
                                return;
                        }
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                        }
                    }

                    tank.IsShooting = tembakan.HasValue && tembakan.Value is not Arah.Null && tank.Bullet is null;
                    if (tank.IsShooting)
                    {
                        tank.Arah = tembakan ?? tank.Arah;
                    }
                    if (gerakan.HasValue)
                        TryGerakan(gerakan.Value);

                }
                else
                {
                    //implementasi gerakan dan tembakan dari AI (musuh)
                    int randomIndex = Random.Shared.Next(0, 6);//membuat tank ai gerak nya menjadi random
                    if (randomIndex < 4)
                        TryGerakan((Arah)randomIndex + 1);

                    if (tank.Bullet is null)
                    {
                        Arah shoot = Math.Abs(tank.X - Player.X) > Math.Abs(tank.Y - Player.Y)//jika nilai x ai besar dari nilai y ai maka ai akan menembak horizontal dan sebaliknya
                            ? (tank.X < Player.X ? Arah.Right : Arah.Left)//jika nilai x ai kecil dari nilai x player maka peluru ai nembak kekanan dan sebaliknya 
                            : (tank.Y > Player.Y ? Arah.Up : Arah.Down);//jika nilai y ai kecil dari nilai y player maka peluru ai nembak kebawah dan sebaliknya 
                        tank.Arah = shoot;//arah tank ai berdsarkan nilai dari shoot ai
                        tank.IsShooting = true;
                    }
                }

                //render tank, bullet dan map ke console
                Console.SetCursorPosition(tank.X - 2, tank.Y - 1);
                Render(tank.IsExploding
                    ? TankExploding[tank.ExplodingFrame % 2]
                    : tank.IsShooting
                        ? TankShooting[(int)tank.Arah]
                        : Tank[(int)tank.Arah],//menampilkan keempat tank
                    true);
            }

            bool BulletCollisionCheck(Bullet bullet, out Tank collisionTank)
            {
                collisionTank = null!;
                foreach (var tank in Tanks)
                {
                    if (Math.Abs(bullet.X - tank.X) < 3 && Math.Abs(bullet.Y - tank.Y) < 2)
                    {
                        collisionTank = tank;
                        return true;
                    }
                }
                if (bullet.X is 0 || bullet.X is 74 || bullet.Y is 0 || bullet.Y is 27)
                {
                    return true;
                }
                if (5 < bullet.X && bullet.X < 11 && bullet.Y is 13)
                {
                    return true;//tabrakan dengan blok kiri
                }
                if (bullet.X is 37 && 3 < bullet.Y && bullet.Y < 7)
                {
                    return true;//tabrakan dengan blok atas
                }
                if (bullet.X is 37 && 20 < bullet.Y && bullet.Y < 24)
                {
                    return true;//tabrakan dengan blok bawah
                }
                if (63 < bullet.X && bullet.X < 69 && bullet.Y is 13)
                {
                    return true;//tabrakan dengan blok kanan
                }
                return false;
            }

            foreach (var tank in AllTanks)
            {
                if (tank.Bullet is not null)
                {
                    //implementasi logika gerak bullet dan collison bullet
                    var bullet = tank.Bullet;
                    Console.SetCursorPosition(bullet.X, bullet.Y);
                    Console.Write(' ');
                    switch (bullet.Arah)//arah gerakan peluru
                    {
                        case Arah.Up: bullet.Y--; break;
                        case Arah.Down: bullet.Y++; break;
                        case Arah.Left: bullet.X--; break;
                        case Arah.Right: bullet.X++; break;
                    }
                    Console.SetCursorPosition(bullet.X, bullet.Y);
                    bool collision = BulletCollisionCheck(bullet, out Tank CollisionTank);
                    Console.Write(collision
                        ? '█' //animasi ketika peluru mengenai tank ai
                        : Bullet[(int)bullet.Arah]);
                    if (collision)
                    {
                        if (CollisionTank is not null && --CollisionTank.Health <= 0)//menampilkan animasi ledakan tank jika peluru mengenai tank dan dara tank habis
                        {
                            CollisionTank.ExplodingFrame = 1;//menampilakn animasi ledakan peluru jika dara tank tidak habis
                        }
                        tank.Bullet = null!; //menghilangkan peluru setelah peluru 
                    }
                }
            }

            //Hapus tank yang sudah meledak dari list
            for (int i = 0; i < Tanks.Count; i++)
            {
                if (Tanks[i].ExplodingFrame > 10)
                {
                    Tanks.RemoveAt(i);
                    i--;
                }
            }

            //render map
            //beri delay agar animasi pada gameplay smooth
            Console.SetCursorPosition(0, 0);
            Render(Map);
            Thread.Sleep(TimeSpan.FromMilliseconds(20));
        }
        //tampilkan win/lose condition dari game
        Console.SetCursorPosition(0, 33);
        Console.Write(Tanks.Contains(Player)
            ? "Selamat, Kamu Menang."
            : "Kamu Telah Kalah");
        Console.ReadLine();

    }

    //buat metode render untuk menampilkan teks dan sprite pada console app
    //buat sprite untuk tank, animasi tembak, animasi explode, bullet dan map
}

//buat enum untuk arah
enum Arah
{
    Null = 0,
    Up = 1,
    Down = 2,
    Left = 3,
    Right = 4,
}
//buat kelas tank dengan properti dan methodnya
class Tank
{
    public bool IsPlayer;
    public int Health = 4;
    public int X;
    public int Y;
    public Arah Arah = Arah.Down;
    public Bullet Bullet;
    public bool IsShooting;
    public int ExplodingFrame;
    public bool IsExploding => ExplodingFrame > 0;
}
//buat kelas bullet
class Bullet
{
    public int X;
    public int Y;
    public Arah Arah;
}