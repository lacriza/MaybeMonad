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
}
