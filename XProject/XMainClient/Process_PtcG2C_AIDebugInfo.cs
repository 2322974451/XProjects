using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011FD RID: 4605
	internal class Process_PtcG2C_AIDebugInfo
	{
		// Token: 0x0600DCB9 RID: 56505 RVA: 0x00330BC0 File Offset: 0x0032EDC0
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
