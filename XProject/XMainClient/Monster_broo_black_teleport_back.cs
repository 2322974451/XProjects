using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200103F RID: 4159
	internal class Monster_broo_black_teleport_back
	{
		// Token: 0x0600D5AB RID: 54699 RVA: 0x00324928 File Offset: 0x00322B28
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Monster_broo_black_teleport_back._veiled;
				if (flag)
				{
					Monster_broo_black_teleport_back._veiled = true;
					Monster_broo_black_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_black_teleport_back._startVeil, new XTimerMgr.ElapsedEventHandler(Monster_broo_black_teleport_back.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Monster_broo_black_teleport_back._token);
				Monster_broo_black_teleport_back.Unveil(skill.Firer);
				Monster_broo_black_teleport_back._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5AC RID: 54700 RVA: 0x003249A8 File Offset: 0x00322BA8
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Monster_broo_black_teleport_back._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			Monster_broo_black_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_black_teleport_back._veilDuration, new XTimerMgr.ElapsedEventHandler(Monster_broo_black_teleport_back.Unveil), o);
		}

		// Token: 0x0600D5AD RID: 54701 RVA: 0x00324A04 File Offset: 0x00322C04
		private static void Unveil(object o)
		{
			bool flag = Monster_broo_black_teleport_back._token > 0U;
			if (flag)
			{
				Monster_broo_black_teleport_back._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Monster_broo_black_teleport_back._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006138 RID: 24888
		private static uint _token = 0U;

		// Token: 0x04006139 RID: 24889
		private static bool _veiled = false;

		// Token: 0x0400613A RID: 24890
		private static float _startVeil = 0.267f;

		// Token: 0x0400613B RID: 24891
		private static float _fadeOutTime = 0.1f;

		// Token: 0x0400613C RID: 24892
		private static float _veilDuration = 0.3f;

		// Token: 0x0400613D RID: 24893
		private static float _fadeInTime = 0.2f;
	}
}
