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