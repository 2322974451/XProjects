using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_AIDebugInfo
	{

		public static void Process(PtcG2C_AIDebugInfo roPtc)
		{
			string[] array = roPtc.Data.msg.Split(new char[]
			{
				'\n'
			});
			XSingleton<XDebug>.singleton.AddLog("<color=cyan>--------START--------</color>", null, null, null, null, null, XDebugColor.XDebug_None);
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i].Length == 0;
				if (!flag)
				{
					XSingleton<XDebug>.singleton.AddGreenLog(array[i], null, null, null, null, null);
				}
			}
			XSingleton<XDebug>.singleton.AddLog("<color=cyan>--------END--------</color>", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
