using System;
using System.Runtime.InteropServices;

public class DLLBridge {
	[DllImport("WindowsUnityDll")]
	public static extern IntPtr ReturnString();

	[DllImport("WindowsUnityDll")]
	public static extern int AddTwoInts(int alpha, int beta);

	[DllImport("WindowsUnityDll")]
	public static extern float hitRate(int total, int hit);

	[DllImport("WindowsUnityDll")]
	public static extern int point(char color);
}