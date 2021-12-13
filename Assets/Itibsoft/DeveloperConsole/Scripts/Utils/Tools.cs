using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Utils
{
	public static class Tools
	{
		public static bool IsNull(string text)
		{
			return string.IsNullOrWhiteSpace(text);
		}
		public static bool IsNull(object obj)
		{
			return obj == null;
		}

		public static string GetColoredRichText(string text, Color color)
		{
			var colorInvariant = "#" + ColorUtility.ToHtmlStringRGB(color);
			
			return $"<color=\"{colorInvariant}\">{text}</color=\"{colorInvariant}\">";
		}

		public static string GetColoredRichText(string text, TypeColor color)
		{
			var colorInvariant = color.ToString().ToLowerInvariant();
			
			return $"<color=\"{colorInvariant}\">{text}</color=\"{colorInvariant}\">";
		}

		public static bool Contains(string text, string search, bool toLower = false)
		{
			var tempText = toLower ? text.ToLower() : text;

			return tempText.Contains(search);
		}

		public static bool Compare(string text1, string text2)
		{
			return Equals(text1, text2);
		}
	}
}
