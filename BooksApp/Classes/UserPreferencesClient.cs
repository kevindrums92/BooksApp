using System;
using Foundation;

namespace BooksApp
{
    /// <summary>
    /// Clase para administrar los user preferences
    /// </summary>
	public class UserPreferencesClient
	{
		public UserPreferencesClient ()
		{
		}

		#region IUserPreferences implementation

		public static void StoreIntValue (string key, int value)
		{
			NSUserDefaults.StandardUserDefaults.SetInt (value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}

        public static void StoreStringValue (string key, string value)
		{
			NSUserDefaults.StandardUserDefaults.SetString (value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}

        public static void StoreBoolValue(string key, bool value)
		{
			NSUserDefaults.StandardUserDefaults.SetBool(value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

        public static int GetStoredIntValue (string key)
		{
			string storeStr = NSUserDefaults.StandardUserDefaults.IntForKey (key).ToString ();
			int storeInt = Int32.Parse (storeStr);
			return storeInt;
		}

        public static string GetStoredStringValue (string key)
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey (key);
		}

        public static bool GetStoreBoolValue (string key) {
			return NSUserDefaults.StandardUserDefaults.BoolForKey (key);
		}

		#endregion
	}
}

