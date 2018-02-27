using MonadaMaybe.ObjModels;
using System;

namespace MonadaMaybe
{
	public class CredentialsChecker
	{

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
