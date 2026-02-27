using System;

namespace TragedyLooperClient
{
    static class Logger
    {
        //Livelli classici del logger
        public enum Grades
        {
            Off,
            Fatal,
            Error,
            Warn,
            Info,
            Debug,
            Trace
        }

        //Normalmente settato ad OFF, se lo si vuole usare va settato esternamente ad un livello diverso compresp tra 0 e 600
        private static Grades grade = Grades.Off;

        public static Grades Grade
        {
            get
            {
                return grade;
            }
            set
            {
                if (value < 0)
                    grade = (Grades)0;
                else if ((int)value > 6)
                    grade = (Grades)6;
                else
                    grade = value;
            }
        }

        //Se il logger non è settato ad 0 e il messaggio ha una priorità minore o uguale al grado allora procede con la stampa su linea senza a capo
        public static void Write(object Text, int grade)
        {
            if (grade < 1)
                grade = 1;
            else if (grade > 6)
                grade = 6;

            if ((int)Grade >= grade)
                Console.Write(Text.ToString());
        }

        //Se il logger non è settato ad 0 e il messaggio ha una priorità minore o uguale al grado allora procede con la stampa su linea con a capo
        public static void WriteLine(object Text, int grade)
        {
            if (grade < 1)
                grade = 1;
            else if (grade > 6)
                grade = 6;

            if ((int)Grade >= grade)
                Console.WriteLine(Text.ToString());
        }
    }
}