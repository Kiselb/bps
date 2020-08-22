using System;

namespace AM_Lib
{
	/// <summary>
	/// Summary description for KAccount.
	/// </summary>
	public class KAccount
	{
		public KAccount()
		{
		}

		public static bool Verify(string CodeBIK, string AccountNumber)
		{
			char[] AccountArray = new char[20];
			int[] Weights = new int[23] {7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1};
			int Sum = 0;
			AccountArray[0] = CodeBIK[6];
			AccountArray[0] = CodeBIK[7];
			AccountArray[0] = CodeBIK[8];
			AccountNumber.ToCharArray().CopyTo(AccountArray, 3);
			for(int counter = 0; counter < 23; counter ++)
			{
				AccountArray[counter] -= '0';
				Sum += (AccountArray[counter] * Weights[counter]) % 10;
			}
			if(Sum % 10 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
