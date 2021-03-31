using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook

{
    public delegate void GradeAddedDelegat(object sender ,EventArgs args);
    public class NameObject
        {
            public NameObject(string name)
            {
                    Name =name ;

            }
            public string Name {get; set;}
        }
       
       
        public interface IBook{
            void AddGrade(double grade );
            statistic GetStatistic();
            string Name{get;}
            event GradeAddedDelegat GradeAdded;
        }
        public abstract class Book : NameObject , IBook
        
        {
            public Book(string name ) :base( name)
            {

            }

        public abstract event GradeAddedDelegat GradeAdded;

        public abstract void AddGrade(double grade);

        public  abstract statistic GetStatistic();
    }

    public class DisBook : Book
    {
        public DisBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegat GradeAdded;

        public override void AddGrade(double grade)
        {
          using(var writer = File.AppendText($"{Name}.txt")) 
          {
            writer.WriteLine(grade);
            if(GradeAdded != null){
                GradeAdded(this , new EventArgs ());
            }
            //writer.Close();
            //Dispose()function is same close()function
          } 
           
        }

        public override statistic GetStatistic()
        {
            var result   = new statistic() ;

                using (var reader =File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                        
                    }
                }

            return result;

        }
    }
    public class InMemoryBook : Book 
    {
    
            public InMemoryBook(string name) : base(name)
            {
                 grades = new List<double>();
                 Name =name;
            }
           
        
        private List<double> grades;
        

        public void AddLetterGrade(char letter){
            switch(letter){
                case 'A' :
                AddGrade(90);
                break;
                case 'B' :
                AddGrade(80);
                break;
                case 'C' :
                AddGrade(70);
                break;
                case 'D' :
                AddGrade(60);
                break;
                default :
                AddGrade(0);
                break;
            }
        }
        public  override void AddGrade(double grade){
           if(grade <= 100 && grade >=0 )
           {
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this , new EventArgs());
            }
           }
           else 
           {
               throw new ArgumentException($"Invalid{nameof(grade)}");
           }
        }

            public  override event GradeAddedDelegat GradeAdded;
        public override statistic GetStatistic()
        {
            
            var result=new statistic();
             result.Avarage=0.00;
             result.High =double.MinValue;
             result.Low = double.MaxValue;

            for (var index=0 ; index <grades.Count; index++)
            {
                
                result.Avarage += grades[index] ;
                
            }
            result.Avarage /= grades.Count;

            
            return result;

           
        }
    }
}