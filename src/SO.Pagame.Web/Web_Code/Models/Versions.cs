using System.Reflection;

namespace Pagame.Models.Versioning
{
	/// <summary>
	/// Return version of the library
	/// </summary>
	public static class DLLVersion
	{

		/// <summary>
		/// Return version of library.
		/// </summary>
		/// <returns></returns>
		public static string GetVersion()
		{
			var asm = Assembly.GetExecutingAssembly();
			var fullVersionSpec = asm.FullName.Split(',')[1];
			var version = fullVersionSpec.Substring(fullVersionSpec.IndexOf('=') + 1);
			return version;
            
		}
	}



}
