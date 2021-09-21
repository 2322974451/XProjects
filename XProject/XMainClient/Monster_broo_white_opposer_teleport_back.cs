using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001040 RID: 4160
	internal class Monster_broo_white_opposer_teleport_back
	{
		// Token: 0x0600D5B0 RID: 54704 RVA: 0x00324A88 File Offset: 0x00322C88
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Monster_broo_white_opposer_teleport_back._veiled;
				if (flag)
				{
					Monster_broo_white_opposer_teleport_back._veiled = true;
					Monster_broo_white_opposer_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_opposer_teleport_back._startVeil, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_opposer_teleport_back.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Monster_broo_white_opposer_teleport_back._token);
				Monster_broo_white_opposer_teleport_back.Unveil(skill.Firer);
				Monster_broo_white_opposer_teleport_back._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5B1 RID: 54705 RVA: 0x00324B08 File Offset: 0x00322D08
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Monster_broo_white_opposer_teleport_back._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			Monster_broo_white_opposer_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_opposer_teleport_back._veilDuration, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_opposer_teleport_back.Unveil), o);
		}

		// Token: 0x0600D5B2 RID: 54706 RVA: 0x00324B64 File Offset: 0x00322D64
		private static void Unveil(object o)
		{
			bool flag = Monster_broo_white_opposer_teleport_back._token > 0U;
			if (flag)
			{
				Monster_broo_white_opposer_teleport_back._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Monster_broo_white_opposer_teleport_back._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0400613E RID: 24894
		private static uint _token = 0U;

		// Token: 0x0400613F RID: 24895
		private static bool _veiled = false;

		// Token: 0x04006140 RID: 24896
		private static float _startVeil = 0.267f;

		// Token: 0x04006141 RID: 24897
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006142 RID: 24898
		private static float _veilDuration = 0.3f;

		// Token: 0x04006143 RID: 24899
		private static float _fadeInTime = 0.2f;
	}
}
