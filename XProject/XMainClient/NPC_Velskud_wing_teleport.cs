using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200103E RID: 4158
	internal class NPC_Velskud_wing_teleport
	{
		// Token: 0x0600D5A6 RID: 54694 RVA: 0x003247C8 File Offset: 0x003229C8
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !NPC_Velskud_wing_teleport._veiled;
				if (flag)
				{
					NPC_Velskud_wing_teleport._veiled = true;
					NPC_Velskud_wing_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_wing_teleport._startVeil, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_wing_teleport.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(NPC_Velskud_wing_teleport._token);
				NPC_Velskud_wing_teleport.Unveil(skill.Firer);
				NPC_Velskud_wing_teleport._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5A7 RID: 54695 RVA: 0x00324848 File Offset: 0x00322A48
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = NPC_Velskud_wing_teleport._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			NPC_Velskud_wing_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_wing_teleport._veilDuration, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_wing_teleport.Unveil), o);
		}

		// Token: 0x0600D5A8 RID: 54696 RVA: 0x003248A4 File Offset: 0x00322AA4
		private static void Unveil(object o)
		{
			bool flag = NPC_Velskud_wing_teleport._token > 0U;
			if (flag)
			{
				NPC_Velskud_wing_teleport._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = NPC_Velskud_wing_teleport._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006132 RID: 24882
		private static uint _token = 0U;

		// Token: 0x04006133 RID: 24883
		private static bool _veiled = false;

		// Token: 0x04006134 RID: 24884
		private static float _startVeil = 0.267f;

		// Token: 0x04006135 RID: 24885
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006136 RID: 24886
		private static float _veilDuration = 0.267f;

		// Token: 0x04006137 RID: 24887
		private static float _fadeInTime = 0.2f;
	}
}
