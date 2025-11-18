using LinqExercise.Data;
using LinqExercise.Extentions;
using LinqExercise.Models;
using System.Linq;
namespace LinqExercise
{
    public class Program
    {
        

        //-----------------------------------------------------------

        public static List<int> FilterList(List<int> lst, Func<int, bool> condition)
        {
            List<int> result = new List<int>();
            foreach (var item in lst)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //-----------------------------------------------------------

        static void Main(string[] args)
        {

            Func<int, bool> IsEven = (x) => x % 2 == 0;
            Console.WriteLine(IsEven(5));
            Console.WriteLine(IsEven(4));

            //-------------------------------------------------------

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evens = FilterList(numbers, IsEven);
            List<int> fiveOrMore = FilterList(numbers, x => x >= 5);

            //-------------------------------------------------------

        #region שימוש בFUNC במקום פונקציה רגילה
        Func<List<int>, Predicate<int>, List<int>> FilterFunc = (lst, condition) =>
            {
                {
                    List<int> result = new List<int>();
                    foreach (var item in lst)
                    {
                        if (condition(item))
                        {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            };

            //--------------------------------------------------

            #endregion

            #region שימוש בEXTENSIONS
            //example of using extension methods

            #endregion

            #region שימוש בLINQ
            List<Student> students = new List<Student>()
            {
                new Student() { Name = "Alice", Age = 20, grade = 90, ClassName = "Math" },
                new Student() { Name = "Bob", Age = 22, grade = 85, ClassName = "Science" },
                new Student() { Name = "Charlie", Age = 21, grade = 95, ClassName = "Math" },
                new Student() { Name = "David", Age = 23, grade = 80, ClassName = "History" },
                new Student() { Name = "Eve", Age = 20, grade = 88, ClassName = "Science" },
                new Student() { Name = "Frank", Age = 24, grade = 92, ClassName = "Math" },
                };

            #region דוגמאות LINQ

            //-------------------------------------------------------
            //---Linq Methods---
            //Max:
            // finds the highest grade of all the students
            var maxGrade = students.Max(student => student.grade);

            //Average:
            // finds the average age of all the students
            double averageAge = students.Average(student => student.Age);

            //FirstOrDefault:
            // finds the first student with the name "Charlie"
            Student student = students.FirstOrDefault(student => student.Name == "Charlie");

            //SingleOrDefault:
            // finds if theres a student with the name "Alice"
            student = students.SingleOrDefault(student => student.Name == "Alice");

            //where:
            // finds all the students in the "Math" class and returns them in a list
            List<Student> mathStudentsList = students.Where(student => student.ClassName == "Math").ToList();

            //where Query:
            var ls = from studentInList in students
                     where studentInList.ClassName == "Math"
                     select studentInList;

            //OrderBy:
            // sorts the students by their grades in ascending order
            List<Student> sortedByGrade = students.OrderBy(student => student.grade).ToList();

            //Any:
            // checks if there is any student with a grade above 90
            bool hasStudentAbove90 = students.Any(student => student.grade > 90);
            hasStudentAbove90 = students.All(student => student.grade > 50);

            //Select:


            #endregion
            #endregion

            #region Test Monkey Exercise
            //השלמת תרגיל הקופים מהחומר הנלמד
            MonkeyList monkeys = new MonkeyList(); // יצירת אובייקט של רשימת הקופים

            try
            {
                // 1. הדפסת נתוני קוף לפי שם
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. הדפסת נתוני קוף לפי שם");
                Monkey monkeyByName = monkeys.SearchMonkeyByName("Baboon");
                Console.WriteLine(monkeyByName);

                // 2. הדפסת כל הקופים לפי מיקום
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("2. הדפסת כל הקופים לפי מיקום");
                List<Monkey> monkeysByLocation = monkeys.GetAllMonkeysPerLocation("Africa & Asia");
                monkeysByLocation.ForEach(m => Console.WriteLine(m.Name));

                // 3. בדיקה אם יש קוף במיקום מסוים
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("3. בדיקה אם יש קוף במיקום מסוים");
                bool isMonkeyInLocation = monkeys.IsThereMonkeyInThatLocation("Japan");
                Console.WriteLine(isMonkeyInLocation);

                // 4. מיון לפי מיקום ושם
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("4. מיון לפי מיקום ושם");
                List<Monkey> sortedMonkeys = monkeys.SortByLocattionAndName();
                sortedMonkeys.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 5. חיפוש קוף לפי שם (שימוש ב-LINQ)
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("5. חיפוש קוף לפי שם (שימוש ב-LINQ)");
                Monkey monkeyByNameQuery = monkeys.SearchMonkeyByNameQuery("Capuchin Monkey");
                Console.WriteLine(monkeyByNameQuery);

                // 6. הדפסת כל הקופים לפי מיקום (שימוש ב-LINQ)
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("6. הדפסת כל הקופים לפי מיקום (שימוש ב-LINQ)");
                var monkeysByLocationQuery = monkeys.GetAllMonkeysPerLocationQuery("Central & South America");
                monkeysByLocationQuery.ForEach(m => Console.WriteLine(m.Name));

                // 7. מיון לפי מיקום ושם (שימוש ב-LINQ)
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("7. מיון לפי מיקום ושם (שימוש ב-LINQ)");
                var sortedMonkeysQuery = monkeys.SortByLocattionAndNameQuery();
                sortedMonkeysQuery.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 8. הדפסת מספר הקופים לפי מיקום
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("8. הדפסת מספר הקופים לפי מיקום");
                monkeys.PrintNumberOfMonkeysPerLocation();

                // 9. הדפסת מספר הקופים לפי מיקום (שימוש ב-LINQ)
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("9. הדפסת מספר הקופים לפי מיקום (שימוש ב-LINQ)");
                monkeys.PrintNumberOfMonkeysPerLocationQuery();

                // 10. קבלת כל הקופים לפי שם
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("10. קבלת כל הקופים לפי שם");
                var monkeysByNameArray = monkeys.GetAllMonkeysByName("Golden Lion Tamarin");
                foreach (var monkey in monkeysByNameArray)
                {
                    Console.WriteLine(monkey.Name);
                }

                // 11. יצירת מילון של קופים
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("11. יצירת מילון של קופים");
                var monkeyDictionary = monkeys.CreateDictionaryFromMonkeyList();
                foreach (var kvp in monkeyDictionary)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}");
                }

                // 12. בדיקה אם קוף קיים לפי שם (שימוש במילון)
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("12. בדיקה אם קוף קיים לפי שם (שימוש במילון)");
                bool doesMonkeyExist = monkeys.MonkeExistByName("Mandrill");
                Console.WriteLine(doesMonkeyExist);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("TBD");
            }
			#endregion
		}
	}
}

