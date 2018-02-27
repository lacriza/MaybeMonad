using System;

namespace MonadaMaybe
{

	public static class Maybe
	{

		public static TResult With<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
			where TInput : class
			where TResult : class
		{
			if (obj == null) return null;
			return evaluator(obj);
		}

		public static TResult Return<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator, TResult failureValue)
			where TInput : class
		{
			if (obj == null) return failureValue;
			return evaluator(obj);
		}

		public static bool ReturnSuccess<TInput>(this TInput obj)
			where TInput : class
		{
			return obj != null;
		}

		public static TInput If<TInput>(this TInput obj, Predicate<TInput> evaluator)
			where TInput : class
		{
			if (obj == null) return null;
			return evaluator(obj) ? obj : null;
		}

		public static TInput Do<TInput>(this TInput obj, Action<TInput> action)
			where TInput : class
		{
			if (obj == null) return null;
			action(obj);
			return obj;
		}

	}

	public class Person
	{
		public PaymentCredantials PaymentCredantials { get; set; }
	}

	public class PaymentCredantials
	{

		public string cardType { get; set; }
		public DateTime dateEnd { get; set; }
		public string cardNumbe { get; set; }
		public int CVV { get; set; }
	}

	public class App
	{
		public App() { }

		public bool HasValidCardType(Person person)
		{
			return person
				.With(p => p.PaymentCredantials)
				.With(c => c.cardType)
				.If(c => c.Length > 4)
				.Do(Console.WriteLine)
				.ReturnSuccess();
		}

	}
}
