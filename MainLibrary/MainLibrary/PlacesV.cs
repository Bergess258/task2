﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class PlacesV : IComparable
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public PlacesV()
        {
            Name = "";
        }
        public PlacesV(string name)
        {
            Name = name;
        }
        public int CompareTo(object obj)
        {
            if (obj.ToString() == this.ToString()) return 0;
            if (obj.ToString().Length > this.ToString().Length) return 1;
            return -1;
        }
        public PlacesV BasePlace
        {
            get { return new PlacesV(Name); }
        }
        public static PlacesV RandAdd(Random rand)
        {
            string Name = "";
            int c = rand.Next(4);
            if (c == 0)
            {
                Region temp;
                Name = Region.RandomName(rand);
                temp = new Region(Name, rand.Next(0, 10000000), rand.Next(0, 20));
                return temp;
            }
            else
            if (c == 1)
            {
                City temp;
                Name = City.RandomCity(rand);
                temp = new City(Name, rand.Next(0, 900000));
                return temp;
            }
            else
            if (c == 2)
            {
                Megapolis temp;
                Name = Megapolis.RandomMegapolis(rand);
                temp = new Megapolis(Name, rand.Next(0, 20));
                return temp;
            }
            else
            {
                Adres temp;
                Name = Adres.RandomAdres(rand);
                temp = new Adres(Name);
                return temp;
            }
        }
        public override string ToString()
        {
            return name;
        }
    }
    public class Region : PlacesV //Кол-во мужчин во всех регионах
    {
        int numberMans = 0;
        int numberCities = 0;
        public int NumberCities
        {
            get { return numberCities; }
            set { numberCities = value; }
        }
        public int NumberMans
        {
            get { return numberMans; }
            set
            {
                if (value < 0) Console.WriteLine("Мужчин не может быть меньше 0");
                else numberMans = value;
            }
        }
        public Region() : base()
        {

        }
        public Region(string name) : base(name)
        {

        }
        public Region(string name, int mans) : base(name)
        {
            NumberMans = mans;
        }
        public Region(string name, int mans, int cit) : base(name)
        {
            NumberMans = mans;
            numberCities = cit;
        }
        public override string ToString()
        {
            return Name + " Область";
        }
        public static string RandomName(Random rand)
        {
            string Region;
            string[] s = new string[] { "Магаданская", "Адыгейская", "Башкортостанская", "Алтайская", "Дагестанская", "Татарстанская", "Чувашская" };
            int temp = rand.Next(s.Length);
            Region = s[temp];
            return Region;
        }
    }

    public class City : PlacesV // кол-во горожан во всех регионах 
    {
        int citizens = 0;
        public int Citizens
        {
            get { return citizens; }
            set
            {
                if (value < 0) Console.WriteLine("Горожан не может быть меньше 0");
                else citizens = value;
            }
        }
        public City() : base()
        {

        }
        public City(string name) : base(name)
        {
        }
        public City(string name, int Countcitizens) : base(name)
        {
            Citizens = Countcitizens;
        }
        public override string ToString()
        {
            return "Город " + Name;
        }
        public static string RandomCity(Random rand)
        {
            string Name;
            string[] s = new string[] { "Пермь", "Кунгур", "Ижевск", "Боготол", "Саратов", "Чернушка", "Волгоград" };
            int temp = rand.Next(s.Length);
            Name = s[temp];
            return Name;
        }
    }

    public class Megapolis : PlacesV
    {
        private int countFabriks;
        public int CounFabriks
        {
            get { return countFabriks; }
            set { countFabriks = value; }
        }
        public Megapolis() : base()
        {

        }
        public Megapolis(string name) : base(name)
        {

        }
        public Megapolis(string name, int t) : base(name)
        {
            countFabriks = t;
        }
        public override string ToString()
        {
            return "Мегаполис " + Name;
        }
        public static string RandomMegapolis(Random rand)
        {
            string Name;
            string[] s = new string[] { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеренбург", "Нижнiй новгород", "Казань", "Самара" };
            int temp = rand.Next(s.Length);
            Name = s[temp];
            return Name;
        }
    }

    public class Adres : PlacesV
    {
        int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public Adres() : base()
        {

        }
        public Adres(string name) : base(name)
        {

        }
        public Adres(string name, int index1) : base(name)
        {
            index = index1;
        }
        public override string ToString()
        {
            return "Адрес: " + Name;
        }
        public static string RandomAdres(Random rand)
        {
            string[] Streets = new string[] { "улица Павловская", "улица Бахаревская", "улица Гамовская", "улица Запрудская", "улица Ключевая", "улица Красавинская", "улица Липогорская", "улица Набережная", "улица Толбухина", "улица Янаульская" };
            string adres = "";
            adres += Streets[rand.Next(0, Streets.Length)] + " ";
            adres += rand.Next(0, 500);
            return adres;
        }
    }
}
