using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop.Pyrshiev
{
    public enum TimeFrame { Year, TwoYears, Long }
    public class Person
    {
        private string name;
        private string surname;
        private DateTime bdate;
        public Person(string _name, string _surname, DateTime _bdate)
        {
            name = _name;
            surname = _surname;
            bdate = _bdate;
        }
        public Person() : this("Default_Name", "Default_Sname", new DateTime(1996, 12, 1))
        { }
        string StdName
        {
            get
            {
                return name;
            }

        }

        string StdSurName
        {
            get
            {
                return surname;
            }

        }

        DateTime StdBDate
        {
            get
            {
                return bdate;
            }

        }
        int intStdBdate
        {
            get
            {
                return Convert.ToInt32(bdate);
            }
            set
            {
                bdate = Convert.ToDateTime(value);
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}\nDate of birth: {2}", name, surname, bdate);
        }
        public string ToShortString()
        {
            return "\n" + "Имя: " + name + "\n" + "Фамилия: " + surname;
        }
    }
    public class Paper
    {
        public string NameP { get; set; }
        Person Author { get; set; }
        DateTime Data { get; set; }
        public Paper(string name, Person author, DateTime data)
        {
            NameP = name;
            Author = author;
            Data = data;
        }
        private Paper() : this("WarandWorld", "Lolstoy", new DateTime(1889, 6, 1))
        { }
        public override string ToString()
        {
            return string.Format("Author  {0} write book {1}. Data = {2}", NameP, Author, Data);
        }
    }
    
    public class ResearchTeam
    {
        private string Theme;
        private string NameOfOrg;
        private int NumberOfRed;
        private TimeFrame Last;
        private List<Paper> _publications = new List<Paper>();
        public ResearchTeam(List<Paper> _publications, string theme, string nameoforg, int numberofred, TimeFrame last)
        {
            Theme = theme;
            NameOfOrg = nameoforg;
            NumberOfRed = numberofred;
            Last = last;
        }
        public ResearchTeam(): this(new Person("Ecology", "Colos", 0123456789, new DateTime(1996, 12, 1), Paper.Spe******t, 1))
            { }
        public string theme
        {
            get
            {
                return Theme;
            }
        }
        public string nameofogr
        {
            get
            {
                return NameOfOrg;
            }
        }
        public int numberofred
        {
            get
            {
                return NumberOfRed;
            }
        }
        public TimeFrame Last
        {
            get
            {
                return last;
            }
        }

        public IReadOnlyList<Paper> Publications
        {
            get
            {
                return _publications.AsReadOnly();
            }
        }
        public double ListPublic
        {
            get
            {
                return null;
            }
        }
        public bool this [TimeFrame rez_prov]
        {
            get
            {
                if (this.Last == rez_prov)
                    return true; 
                return false;
            }           
        }
        }
        public void AddPapers(params Paper[] )
        {
            _publications.AddRange();
        }
        public override string ToString()
        {
            return string.Format("\nTheme: {0}\nNameOfOrg: {1}\nNumberOfRed: {2}\nLast: {3}\nPublications: {4} ", Theme, NameOfOrg, NumberOfRed, Last, _publications);
        }
        public string ToShortString()
        {
            return string.Format("\nTheme: {0}\nNameOfOrg: {1}\nNumberOfRed: {2}\nLast: {3}\n", Theme, NameOfOrg, NumberOfRed, Last);
        }
    }
}
