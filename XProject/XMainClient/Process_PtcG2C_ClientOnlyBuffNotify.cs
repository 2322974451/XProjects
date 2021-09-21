using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200119B RID: 4507
	internal class Process_PtcG2C_ClientOnlyBuffNotify
	{
		// Token: 0x0600DB32 RID: 56114 RVA: 0x0032EA9C File Offset: 0x0032CC9C
		public static void Process(PtcG2C_ClientOnlyBuffNotify roPtc)
		{
			XRole xrole = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.roleid) as XRole;
			bool flag = !XEntity.ValideEntity(xrole);
			if (!flag)
			{
				for (int i = 0; i < roPtc.Data.buffs.Count; i++)
				{
					XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
					Buff buff = roPtc.Data.buffs[i];
					@event.xBuffDesc.BuffID = buff.buffID;
					@event.xBuffDesc.BuffLevel = buff.buffLevel;
					@event.Firer = xrole;
					@event.xBuffDesc.CasterID = roPtc.Data.casterid;
					bool skillIDSpecified = buff.skillIDSpecified;
					if (skillIDSpecified)
					{
						@event.xBuffDesc.SkillID = buff.skillID;
					}
					bool effecttimeSpecified = buff.effecttimeSpecified;
					if (effecttimeSpecified)
					{
						@event.xBuffDesc.EffectTime = buff.effecttime;
					}
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}
	}
}
