using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pagame.Models.Security
{
	public static class UserLogin
	{
		public enum EncryptionHashAlgorithm
		{
			MD5
			,
			MD5Cng
			,
			None
			,
			SHA256
			,
			SHA256Cng
			,
			SHA512
			,
			SHA512Cng
		}
		/// <summary>
		/// Check against DB if password is ok fof userLogin
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="encryptionHashType"></param>
		/// <param name="sqlConnection"></param>
		/// <returns></returns>
		public static bool CheckUserPassword(string username, string password, EncryptionHashAlgorithm encryptionHashType, string sqlConnection)
		{
			var strSql = @"
SELECT 
Password
FROM dbo.[User]
WHERE
Login = @UserLogin";

			var paramsToSP = new SqlParameter[] { new SqlParameter("@UserLogin", username)
			};

			var dbhash = Softcanon.DAL.SqlApiSqlClient.GetStringRecordValue(strSql, paramsToSP, sqlConnection, 60);

			if (encryptionHashType.Equals(EncryptionHashAlgorithm.SHA512))
			{
				return SHA512HashAlgorithm.VerifyHashSHA512(password, dbhash);
			}

			return false;
		}

		/// <summary>
		/// Save a new password to DB for userId
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="password"></param>
		/// <param name="encryptionHashType"></param>
		/// <param name="sqlConnection"></param>
		public static void SaveNewUserPassword(string userId, string password, EncryptionHashAlgorithm encryptionHashType, string sqlConnection)
		{
			var newpass = string.Empty;

			if (encryptionHashType.Equals(EncryptionHashAlgorithm.SHA512))
			{
				newpass = SHA512HashAlgorithm.ComputeHashSHA512(password);
			}


			var strSql = @"
UPDATE dbo.[User] SET 
       Password = @UserPass
 WHERE 
 User_ID = @UserId
";

			var paramsToSP = new SqlParameter[] { new SqlParameter("@UserPass", password)
			, new SqlParameter("@UserId", userId)
			};


			Softcanon.DAL.SqlApiSqlClient.ExecuteSqlString(strSql, paramsToSP, sqlConnection, 60);
		}

		/// <summary>
		/// Return an encrypted string
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="password"></param>
		/// <param name="encryptionHashType"></param>
		/// <param name="sqlConnection"></param>
		/// <returns></returns>
		public static string GetNewUserPassword(string userId, string password, EncryptionHashAlgorithm encryptionHashType, string sqlConnection)
		{
			var newpass = string.Empty;

			if (encryptionHashType.Equals(EncryptionHashAlgorithm.SHA512))
			{
				newpass = SHA512HashAlgorithm.ComputeHashSHA512(password);
			}

			return newpass;
		}


        /// <summary>
        /// Currently only SHA512
        /// </summary>
        /// <param name="password"></param>
        /// <param name="encryptionHashType"></param>
        /// <returns></returns>
        public static string GetNewPasswordFromString(string password, EncryptionHashAlgorithm encryptionHashType)
        {
            var newpass = string.Empty;

            if (encryptionHashType.Equals(EncryptionHashAlgorithm.SHA512))
            {
                newpass = SHA512HashAlgorithm.ComputeHashSHA512(password);
            }

            return newpass;
        }



        /// <summary>
        /// Return SHA512 encoded string
        /// </summary>
        /// <param name="password"></param>
        /// <param name="encryptionHashType"></param>
        /// <returns></returns>
        public static string GetNewPasswordFromString(string password)
        {
            return SHA512HashAlgorithm.ComputeHashSHA512(password);
        }
	}
}
