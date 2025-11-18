using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise.Extentions
{
	public static class MyExtentions
	{
		public static void TalIsTheBest<T>(this IComparable<T> comparer)
		{
			Console.WriteLine("Tal Simon is the best!");
		}

		public static void YudAlef<T>(this IEnumerable<T> list)
		{
			Console.WriteLine("Yud Alef 7 Metro West is the best course ever!");
		}
    }
}
