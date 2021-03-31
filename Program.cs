using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DisBook("rana's grade book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            var state = book.GetStatistic();
            Console.WriteLine($"the avarage is { state.Avarage:N2} !");
            Console.WriteLine($"the highest is { state.High } ");
            Console.WriteLine($"the avarage is { state.Low } ");
            Console.WriteLine($"the letter is { state.Letter } ");

            var books = new Dictionary<string,Book>();
            books.Add("First", d\mohamed taha);
            books.Add("Second", d\taha rafagh);


            string filePath=hk;

            cv_reader resder= new cv_reader(filePath) ;
           Dictionary<string , list<Country>> countries = reader.ReadAllCountry();

            foreach (Country country in countries.Take(20).where(x=> !x.Name.Contains(' , ')))
            {
                Console.WriteLine($"{country.Population.PadLeft(15) }: {country.Name}");
            }

             foreach (Country country in countries.OrderBy(x=>x.Name)
            {
                Console.WriteLine($"{country.Population.PadLeft(15) }: {country.Name}");
            }

        }

        private static void EnterGrades(IBook book)
        {
            
            while (true)
            {

                Console.WriteLine("enter a grade or 'q' for quit :");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender ,EventArgs e)
        {
          
            Console.WriteLine("Agrade Added");
        }


        class  Country ()
        {
            public string Name {get;}
            public string Code { get;}
            public string Region { get; }
            public int Population { get; }

            public Country (string name , string code , string region , int population){

                this.Name = name;
                this.Code = code;
                this.Region =region;
                this.Population=population;
            }


        }

        class cv_reader()
        {
            string _cvreader {get;}
             public Country(string cvreaderfilepath){
                 this._cvreader = cvreaderfilepath ;
             }


             public Dictionary <string ,List<Country> > ReadAllCountries(){
                 var countries =new Dictionary<string, List<Country>> ();
                 using (StreamReader sr = new StreamReader(_cvreader))
                 {
                     sr.ReadLine();
                       string csvLine ;
                     while((csvLine = sr.ReadLine()) != null)
                     {
                       
                         countries.Add(ReadCountryFromCsvLine(csvLine));
                         
                     }
                 }
                 return countries ;
             }

             public Country [] ReadeFirstNcountry(int ncountry){
                 Country countries =new Country(ncountry);
                 using (StreamReader sr = new StreamReader(_cvreader))
                 {
                     sr.ReadLine();
                     for (int i = 0; i < ncountry; i++)
                     {
                         string csvLine = sr.ReadLine();
                         countries[i]= ReadCountryFromCsvLine(csvLine);
                         
                     }
                 }
                 return countries ;
             }

             public Country ReadCountryFromCsvLine(csvLine){

                 string [] parts = csvLine.Split(new char[] {','});
                 string name =parts[0];
                 string code =parts[1];
                 string region =parts[2];
                 int population int.Parse(parts[3]);

                 return new Country(name , code , region , population);

             }


        }


    }
}
