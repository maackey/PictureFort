using System;

public static class Debug
{
	public static void Log(string message, Exception e = null, bool stacktrace = false)
	{
		string output = message;
		if (e != null) output += " Exception: " + e.Message;
		if (stacktrace) output += "\n--------------------\nStacktrace: " + e.StackTrace;

		Console.WriteLine(output);
	}

	public static void Log(Exception e, bool stacktrace = false)
	{
		Log("", e, stacktrace);
	}
}

public static class util
{
	/// <summary>
	/// encodes a string with pipe separated values
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public static string encode(string input)
	{
		return input.Replace("%", "%25").Replace("|", "%7C");
	}

	/// <summary>
	/// decodes a string with pipe separated values
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public static string decode(string input)
	{
		return input.Replace("%7C", "|").Replace("%25", "%");
	}
}