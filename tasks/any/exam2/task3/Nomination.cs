
    public class Nomination
    {
        public int year;

        public int ceremony;

        public string award;

        public string name;

        public string film;

        public Nomination()
        { }

        public Nomination(int year, int ceremony, string award, string name, string film)
        {
            this.year = year;
            this.ceremony = ceremony;
            this.award = award;
            this.name = name;
            this.film = film;
        }
    }