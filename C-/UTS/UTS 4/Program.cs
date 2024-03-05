using System;

namespace UTS4
{
    class Program
    {
        static void IntroGame()
        {
            Console.Clear();
            Console.WriteLine("Petualang!!!");
            Console.WriteLine("Petualang!!!");
            Console.WriteLine("Apakah kau mendengarku???");
            Console.WriteLine("Cepat!!! Kami butuh bantuanmu");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            IntroGame();
            Random rnd = new Random();
            int Pertarungan = rnd.Next(3, 6);

            Stats User = new Stats();
            Console.Clear();
            Console.WriteLine("Siapa namamu petualang?  ");
            string? name = Console.ReadLine();
            Console.WriteLine("");

            User.name = name;
            
            Console.WriteLine("Masukkan Rolemu : ");
            Console.WriteLine("1. Seorang Novice");
            Console.WriteLine("2. Seorang Mage");
            Console.WriteLine("");

            int pilihan = 0;
            while (pilihan != 1 && pilihan != 2)
            {
                Console.Write("(1 atau 2)");
                if (int.TryParse(Console.ReadLine(), out pilihan) && (pilihan == 1 || pilihan == 2))
                {
                    string masukkanPilihan = (pilihan == 1) ? "Novice" : "Mage";
                    Console.WriteLine("");
                    Console.WriteLine($"{name} adalah seorang {masukkanPilihan}");

                    User.classUser = masukkanPilihan;
                }
                else
                {
                    Console.WriteLine("Pilihlah Rolemu!!!");
                }
            }
            
            
            User.exp = 0;
            User.KekuatanSerangan = 50;
            User.nyawa = 120;

            Stats Musuh1 = new Stats();
            Musuh1.name = "Zagan";
            Musuh1.KekuatanSerangan = 50;
            Musuh1.nyawa = 40;
            Musuh1.adalahBoss = false;

            Stats Musuh2 = new Stats();
            Musuh2.name = "Andras";
            Musuh2.KekuatanSerangan = 60;
            Musuh2.nyawa = 50;
            Musuh2.adalahBoss = false;

            Stats Boss = new Stats();
            Boss.name = "Lord Mammon";
            Boss.KekuatanSerangan = 3 * User.KekuatanSerangan;
            Boss.nyawa = 1000;
            Boss.adalahBoss = true;
            Boss.PowerSpecial = 100000000;

            Console.WriteLine($"Tolong, Selamatkan Dunia Kami  {name}! Kami berharap padamu!!!");
            Console.WriteLine("===============================================================");
            while (Pertarungan > 0 && User.nyawa > 0)
            {
                switch (Pertarungan)
                {
                    case 3:
                        User.Attack(Musuh1);
                        Pertarungan--;
                        break;
                    case 2:
                        User.Attack(Musuh2);
                        Pertarungan--;
                        break;
                    case 1:
                        User.Attack(Boss);
                        Pertarungan--;
                        break;
                }
            }
        }
    }

    class Stats
    {
        static Random random = new Random();
        static int lvl = 1;
        public int output = 1;
        public string? name;
        public string? classUser;
        public int nyawa;
        public int KekuatanSerangan;
        public int PowerSpecial;
        public bool adalahBoss;
        public int exp;
        public int penambahanLevel = 30;
        public int pilihanMu;
        int playerSkillUses = 2;
        static int seranganDitahan = 0;

        

        public void Attack(Stats target)
        {
            int expDiperoleh = random.Next(10, 40);
            bool berhasilLari = false;

            while (target.nyawa > 0 && nyawa > 0)
            {
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"{target.name} Sedang menyerang...");
                Console.WriteLine("==================================");
                Console.WriteLine($"status {name} : ");
                Console.WriteLine("------------------------");
                Console.WriteLine($"HP : {nyawa} || EXP : {exp} || Class {classUser}");
                Console.WriteLine($"{target.name} status : ");
                Console.WriteLine("------------------------");
                Console.WriteLine($"HP : {target.nyawa} || Serangan {target.KekuatanSerangan}");
                Console.WriteLine("");
                Console.WriteLine("Cepat, waktu kita tidak banyak lagi!!!");
                Console.WriteLine(" 1) Gunakan Tongkat Sihir");
                Console.WriteLine(" 2) Gunakan Serangan Spesial");
                Console.WriteLine(" 3) Tahan Serangan Musuh");
                Console.WriteLine(" 4) Lari");
                try
                {
                    int pilihanMu = int.Parse(Console.ReadLine());
                    switch (pilihanMu)
                    {
                        case 1:
                            exp += expDiperoleh;
                            seranganPedang(target);
                            seranganMusuh(target);
                            break;
                        case 2:
                            exp += expDiperoleh;
                            SpecialAttack(target);
                            seranganMusuh(target);
                            break;
                        case 3:
                            exp += expDiperoleh;
                            bertahan(target);
                            Console.WriteLine($"Serangan {target.name} ditahan!!!");
                            seranganMusuh(target);
                            seranganDitahan = -60;
                            break;
                        case 4:
                            target.nyawa = 0;
                            Console.WriteLine($"{name} Melarikan diri!!!");
                            return;
                        default:
                            Console.WriteLine("Pilihan Tersedia.");
                            break;
                    }

                    if (target.nyawa <= 0)
                    {
                        if (target.adalahBoss)
                        {
                            Console.WriteLine("Selamat, Anda telah mengalahkan Lord Mammon");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Pilhan Tidak Tersedia.");
                }
            }

            if (nyawa <= 0 && !berhasilLari)
            {
                Console.WriteLine("Kamu Telah Mati");
                return;
            }
            if ((target.nyawa <= 0))
            {
                Console.WriteLine("Selamat petualang, anda memenangkan pertarungan kali ini.");
                levelUp(exp, penambahanLevel);
                penambahanSerangan(penambahanLevel);
                healEnemy(target);
            }
            
            
        }
        public void bertahan(Stats target)
        {
            seranganDitahan += 60;
        }
        public void seranganMusuh(Stats target)
        {
            Random rnd = new Random();
            if (adalahBoss)
            {
                int i = rnd.Next(1, 101);
                if (i > 5)
                {
                    int Serangan = (int)(target.KekuatanSerangan + (rnd.Next(1, 10)) - seranganDitahan);
                    nyawa -= Serangan;
                    Console.WriteLine($"{target.name} Menyerangmu, nyawamu menurun {Serangan}");
                }
                else
                {
                    int serangan = target.PowerSpecial - seranganDitahan;
                    nyawa -= serangan;
                    Console.WriteLine($"{target.name} Terlalu Kuat, tidak bisa menahan!!!");
                }
            }
            else
            {
                int Serangan = (int)(target.KekuatanSerangan + (rnd.Next(1, 10)) - seranganDitahan);
                nyawa -= Serangan;
                Console.WriteLine($"{target.name} Menyerangmu, nyawamu menurun {Serangan}");
            }
        }
        private void seranganPedang(Stats target)
        {
            int serangan = KekuatanSerangan;
            target.nyawa -= serangan;
            Console.WriteLine($"Kamu Melukai {target.name} untuk {serangan} damage");
        }
        private void SpecialAttack(Stats target)
        {

            if (classUser == "Novice" && playerSkillUses > 0)
            {
                playerSkillUses--;
                nyawa += 40 * lvl;
                Console.WriteLine($"Kau memakai ability 'Istirahat'! HP sembuh {nyawa}.");
            }
            else if (classUser == "Mage" && playerSkillUses > 0)
            {
                playerSkillUses--;
                int serangan = random.Next(30, 51) * lvl;
                target.nyawa -= serangan;
                Console.WriteLine($"Kamu memakai ability 'Fire Bolt'! Kamu melukai {serangan} damage.");
            }
            else
            {
                Console.WriteLine("Kau sudah habis memakai abilitymu.");
            }
        }

        public int levelUp(int exp, int penambahanLevel)
        {
            if (exp >= penambahanLevel)
            {
                penambahanLevel += 20;
                exp = 0;
                output++;
            }
            return output;
        }

        public void penambahanSerangan(int penambahanLevel)
        {
            int lvlSebelumnya = 1;
            lvl = levelUp(exp, penambahanLevel);
            if (lvl > lvlSebelumnya)
            {
                KekuatanSerangan *= 2;
                playerSkillUses += 5;
                lvlSebelumnya++;
                Console.WriteLine($"Level : {lvl}.");
                nyawa += 200;
                penambahanLevel = 0;
            }
        }
        private void healEnemy(Stats target)
        {
            target.nyawa += 60;
        }
    }
}