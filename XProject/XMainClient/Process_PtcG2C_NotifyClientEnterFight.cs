using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001195 RID: 4501
	internal class Process_PtcG2C_NotifyClientEnterFight
	{
		// Token: 0x0600DB1B RID: 56091 RVA: 0x0032E79C File Offset: 0x0032C99C
		public static void Process(PtcG2C_NotifyClientEnterFight roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.enemyid);
			bool flag = entity != null;
			if (flag)
			{
				entity.IsServerFighting = roPtc.Data.enterfight;
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.AI != null;
				if (flag2)
				{
					XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
					@event.DepracatedPass = true;
					@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
					@event.EventType = 1;
					@event.EventArg = "SpawnMonster";
					uint item = XSingleton<XEventMgr>.singleton.FireEvent(@event, 0.05f);
					XSingleton<XEntityMgr>.singleton.Player.AI.TimerToken.Add(item);
				}
			}
		}
	}
}
