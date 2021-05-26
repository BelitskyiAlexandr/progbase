using System;

namespace airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class AirplaneRepository
    {
        private AirPlane[] _planes;     //комірки
        private int _size;              //розмір

        //створюєш пустий массив з літаками
        public AirplaneRepository()
        {
            _planes = new AirPlane[16];
            _size = 0;
        }

        //просто метод для розширення масива
        private void Expand()
        {
            int oldCapacity = this._planes.Length;
            AirPlane[] oldArray = this._planes;
            this._planes = new AirPlane[oldCapacity * 2];
            System.Array.Copy(oldArray, this._planes, oldCapacity);
        }
        public AirPlane AddPlane()
        {
            // розмір масива = розміру нашого списку [x][x] -> [x][x][ ][ ]
            //                                      size = 2    size = 2
            //                                    length = 2    length = 4
            if(_size == _planes.Length)
            {
                Expand();
            }
            AirPlane tmpA = new AirPlane(null, null, 0, 0, 0, 0, 0, 0); //коряво, але ладно, якщо тобі так простіше
            Console.Write("Початковий пункт:  ");
            tmpA.startCity = Console.ReadLine();
            Console.Write("Кінцевий пункт:  ");
            tmpA.finishCity = Console.ReadLine();
            Console.Write("Дата відправлення ->");
            Console.Write("\tДень:"); tmpA.Sday = int.Parse(Console.ReadLine());
            Console.Write("\tМісяць"); tmpA.Smonth = int.Parse(Console.ReadLine());
            Console.Write("\tРік:"); tmpA.Syear = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Дата прибуття ->");
            Console.Write("\tДень:"); tmpA.Fday = int.Parse(Console.ReadLine());
            Console.Write("\tМісяць"); tmpA.Fmonth = int.Parse(Console.ReadLine());
            Console.Write("\tРік:"); tmpA.Fyear = int.Parse(Console.ReadLine());
            
            //робиться запис в кінець(якщо сортуєш масив, то додаєш і сортуєш) і додається в масив літаків 
            _planes[_size] = new AirPlane(tmpA.startCity, tmpA.finishCity, tmpA.Sday, tmpA.Smonth, tmpA.Syear, tmpA.Fday, tmpA.Fmonth, tmpA.Fyear);
            //збільшуєш розмір
            _size++;

            //повертаєш запис, а не масив незрозуміло чого
            return _planes[_size - 1];
        }
    }
    class AirPlane
    {
        protected string StartCity = null;
        protected string FinishCity = null;
        protected Date StartDate;
        protected Date FinishDate;



        public string startCity
        {
            set
            {
                StartCity = value;
            }
            get
            {
                return StartCity;
            }
        }
        public string finishCity
        {
            set
            {
                FinishCity = value;
            }
            get
            {
                return FinishCity;
            }
        }
        public int Sday
        {
            set
            {
                StartDate.Day = value;
            }
            get
            {
                return StartDate.Day;
            }
        }
        public int Fday
        {
            set
            {
                FinishDate.Day = value;
            }
            get
            {
                return FinishDate.Day;
            }
        }
        public int Smonth
        {
            set
            {
                StartDate.Month = value;
            }
            get
            {
                return StartDate.Month;
            }
        }
        public int Fmonth
        {
            set
            {
                FinishDate.Month = value;
            }
            get
            {
                return FinishDate.Month;
            }
        }
        public int Syear
        {
            set
            {
                StartDate.Year = value;
            }
            get
            {
                return StartDate.Year;
            }
        }
        public int Fyear
        {
            set
            {
                FinishDate.Year = value;
            }
            get
            {
                return FinishDate.Year;
            }
        }
        public AirPlane(string startCity, string finishCity, int StartDay, int StartMonth, int StartYear, int FinishDay, int FinishMonth, int FinishYear)
        {
            StartCity = startCity;
            FinishCity = finishCity;
            StartDate = new Date(StartDay, StartMonth, StartYear);
            FinishDate = new Date(FinishDay, FinishMonth, FinishYear);
        }
    }

    class Date
    {
        Random rnd = new Random();

        protected int day;
        protected int month;
        protected int year;
        protected int hours;
        protected int minutes;

        public Date(int Day, int Month, int Year)
        {
            day = Day;
            month = Month;
            year = Year;
            hours = rnd.Next() % 24;
            minutes = rnd.Next() % 60;
        }
        public int Day
        {
            set
            {
                if (value > 1)
                    Day = 1;
                else if (value > 31)
                    Day = 31;
                else
                    Day = value;
            }
            get
            {
                return Day;
            }
        }

        public int Month
        {
            set
            {
                if (value < 1)
                    Month = 1;
                else if (value > 12)
                    Month = 12;
                else
                    Month = value;
            }
            get
            {
                return Month;
            }
        }

        public int Year
        {
            set
            {
                if (value < 1900)
                    Year = 1900;
                else if (value > 2100)
                    Year = 2100;
                else
                    Year = value;
            }
            get
            {
                return Year;
            }

        }

    }
}
