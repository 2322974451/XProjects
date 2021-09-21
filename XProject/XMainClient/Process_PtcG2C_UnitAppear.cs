using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001002 RID: 4098
	internal class Process_PtcG2C_UnitAppear
	{
		// Token: 0x0600D4B1 RID: 54449 RVA: 0x00321B38 File Offset: 0x0031FD38
		public static void Process(PtcG2C_UnitAppear roPtc)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				bool flag2 = Process_PtcG2C_UnitAppear.processImmediate;
				if (flag2)
				{
					for (int i = 0; i < roPtc.Data.units.Count; i++)
					{
						XSingleton<XEntityMgr>.singleton.CreateEntityByUnitAppearance(roPtc.Data.units[i]);
					}
				}
				else
				{
					Protocol.ManualReturn();
					bool flag3 = Process_PtcG2C_UnitAppear.processCb == null;
					if (flag3)
					{
						Process_PtcG2C_UnitAppear.processCb = new XTimerMgr.ElapsedEventHandler(Process_PtcG2C_UnitAppear.DelayProcess);
					}
					bool flag4 = Process_PtcG2C_UnitAppear.currentPtc != null;
					if (flag4)
					{
						Process_PtcG2C_UnitAppear.delayQueue.Enqueue(roPtc);
					}
					else
					{
						Process_PtcG2C_UnitAppear.currentPtc = roPtc;
						Process_PtcG2C_UnitAppear.currentProcessCount = 0;
					}
					XSingleton<XTimerMgr>.singleton.SetTimer(0.01f, Process_PtcG2C_UnitAppear.processCb, null);
				}
			}
		}

		// Token: 0x0600D4B2 RID: 54450 RVA: 0x00321C0C File Offset: 0x0031FE0C
		private static void DelayProcess(object o)
		{
			bool flag = Process_PtcG2C_UnitAppear.currentPtc != null;
			if (flag)
			{
				bool flag2 = Process_PtcG2C_UnitAppear.currentProcessCount < Process_PtcG2C_UnitAppear.currentPtc.Data.units.Count;
				if (flag2)
				{
					UnitAppearance unit = Process_PtcG2C_UnitAppear.currentPtc.Data.units[Process_PtcG2C_UnitAppear.currentProcessCount];
					XSingleton<XEntityMgr>.singleton.CreateEntityByUnitAppearance(unit);
					Process_PtcG2C_UnitAppear.currentProcessCount++;
					bool flag3 = Process_PtcG2C_UnitAppear.currentProcessCount < Process_PtcG2C_UnitAppear.currentPtc.Data.units.Count;
					if (flag3)
					{
						XSingleton<XTimerMgr>.singleton.SetTimer(0.01f, Process_PtcG2C_UnitAppear.processCb, null);
					}
					else
					{
						bool flag4 = Process_PtcG2C_UnitAppear.delayQueue.Count > 0;
						if (flag4)
						{
							Process_PtcG2C_UnitAppear.currentPtc = Process_PtcG2C_UnitAppear.delayQueue.Dequeue();
							Process_PtcG2C_UnitAppear.currentProcessCount = 0;
							XSingleton<XTimerMgr>.singleton.SetTimer(0.01f, Process_PtcG2C_UnitAppear.processCb, null);
						}
						else
						{
							bool flag5 = Process_PtcG2C_UnitAppear.currentPtc != null;
							if (flag5)
							{
								Protocol.ReturnProtocolThread(Process_PtcG2C_UnitAppear.currentPtc);
								Process_PtcG2C_UnitAppear.currentPtc = null;
							}
						}
					}
				}
			}
		}

		// Token: 0x040060FA RID: 24826
		private static Queue<PtcG2C_UnitAppear> delayQueue = new Queue<PtcG2C_UnitAppear>();

		// Token: 0x040060FB RID: 24827
		private static XTimerMgr.ElapsedEventHandler processCb = null;

		// Token: 0x040060FC RID: 24828
		private static PtcG2C_UnitAppear currentPtc = null;

		// Token: 0x040060FD RID: 24829
		private static int currentProcessCount = 0;

		// Token: 0x040060FE RID: 24830
		private static bool processImmediate = true;
	}
}
