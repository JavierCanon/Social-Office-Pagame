using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Pagame.Models.Security
{
	public static class SHA512HashAlgorithm
	{
		public static string ComputeHashSHA512(string input)
		{
			var sha = SHA512.Create();
			var hashData = sha.ComputeHash(Encoding.Unicode.GetBytes(input));
			return Convert.ToBase64String(hashData);
		}

		public static bool VerifyHashSHA512(string input, string hashValue)
		{
			var sha = SHA512.Create();
			var hashData = sha.ComputeHash(Encoding.Unicode.GetBytes(input));
			return Convert.ToBase64String(hashData) == hashValue;
		}
	}
}
