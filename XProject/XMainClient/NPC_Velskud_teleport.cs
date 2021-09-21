using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200103D RID: 4157
	internal class NPC_Velskud_teleport
	{
		// Token: 0x0600D5A1 RID: 54689 RVA: 0x00324668 File Offset: 0x00322868
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !NPC_Velskud_teleport._veiled;
				if (flag)
				{
					NPC_Velskud_teleport._veiled = true;
					NPC_Velskud_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_teleport._startVeil, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_teleport.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(NPC_Velskud_teleport._token);
				NPC_Velskud_teleport.Unveil(skill.Firer);
				NPC_Velskud_teleport._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5A2 RID: 54690 RVA: 0x003246E8 File Offset: 0x003228E8
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = NPC_Velskud_teleport._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			NPC_Velskud_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_teleport._veilDuration, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_teleport.Unveil), o);
		}

		// Token: 0x0600D5A3 RID: 54691 RVA: 0x00324744 File Offset: 0x00322944
		private static void Unveil(object o)
		{
			bool flag = NPC_Velskud_teleport._token > 0U;
			if (flag)
			{
				NPC_Velskud_teleport._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = NPC_Velskud_teleport._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0400612C RID: 24876
		private static uint _token = 0U;

		// Token: 0x0400612D RID: 24877
		private static bool _veiled = false;

		// Token: 0x0400612E RID: 24878
		private static float _startVeil = 0.267f;

		// Token: 0x0400612F RID: 24879
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006130 RID: 24880
		private static float _veilDuration = 0.267f;

		// Token: 0x04006131 RID: 24881
		private static float _fadeInTime = 0.2f;
	}
}
