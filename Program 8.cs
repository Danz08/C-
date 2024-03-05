//Safrin Nada Ramdani_2307111849_TI A

using System;

namespace Dasar_Pemrograman_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Manusia mns = new Manusia();
            mns.Nama = "Syafa 'Atul Uzhma";
            mns.Umur = 13;
            Console.WriteLine(mns.PrintKeterangan());
            
            Mahasiswa mhs = new Mahasiswa();
            mhs.Umur = 18;
            mhs.Nama = "Safrin Nada Ramdani";
            mhs.Nilai = 95;
            mhs.Alamat = "Desa Semukut, Kec. Pulau Merbau, Kab. Kepulauan Meranti";
            Console.WriteLine(mhs.PrintKeterangan());
            
            Dosen dsn = new Dosen();
            dsn.Umur = 40;
            dsn.Nama = "Rahmat Rizal Andhi, S.T., M.T.";
            dsn.Gaji = 10000000;
            dsn.Keahlian = "Mobile App & Game Development";
            Console.WriteLine(dsn.PrintKeterangan(dsn.Keahlian));
        }
    }

    class Manusia
    {
        public int Umur { get; set; }
        
        public string? Nama { get; set; }

        public virtual string PrintKeterangan()
        {
            return $"Nama           : {Nama}                ||  Umur : {Umur}  ||";
        } 

    }

    class Mahasiswa : Manusia
    {
        public int Nilai { get; set; }

        public string? Alamat { get; set; }

        public override string PrintKeterangan()
        {
            return $"Nama Mahasiswa : {Nama}              ||  Umur : {Umur}  ||  Nilai              : {Nilai}";
        }

        public virtual string PrintKeterangan(string Alamat)
        {
            return $"Nama Mahasiswa : {Nama}              ||  Umur : {Umur}  ||  Alamat             : {Alamat}";

        }

    }

    class Dosen : Manusia
    {
        public int Gaji { get; set; }

        public string? Keahlian { get; set; }

        public override string PrintKeterangan()
        {
            return $"Nama Dosen     : {Nama}   ||  Umur : {Umur}  ||  Gaji               : {Gaji}";
        }

        public virtual string PrintKeterangan(string Keahlian)
        {
            return $"Nama Dosen     : {Nama}   ||  Umur : {Umur}  ||  Bidang Keahlian    : {Keahlian}";
        }
    }
}