using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001042 RID: 4162
	internal class Monster_broo_white_boss_teleport_foward
	{
		// Token: 0x0600D5BA RID: 54714 RVA: 0x00324D48 File Offset: 0x00322F48
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Monster_broo_white_boss_teleport_foward._veiled;
				if (flag)
				{
					Monster_broo_white_boss_teleport_foward._veiled = true;
					Monster_broo_white_boss_teleport_foward._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_boss_teleport_foward._startVeil, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_boss_teleport_foward.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Monster_broo_white_boss_teleport_foward._token);
				Monster_broo_white_boss_teleport_foward.Unveil(skill.Firer);
				Monster_broo_white_boss_teleport_foward._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5BB RID: 54715 RVA: 0x00324DC8 File Offset: 0x00322FC8
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Monster_broo_white_boss_teleport_foward._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			Monster_broo_white_boss_teleport_foward._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_boss_teleport_foward._veilDuration, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_boss_teleport_foward.Unveil), o);
		}

		// Token: 0x0600D5BC RID: 54716 RVA: 0x00324E24 File Offset: 0x00323024
		private static void Unveil(object o)
		{
			bool flag = Monster_broo_white_boss_teleport_foward._token > 0U;
			if (flag)
			{
				Monster_broo_white_boss_teleport_foward._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Monster_broo_white_boss_teleport_foward._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0400614A RID: 24906
		private static uint _token = 0U;

		// Token: 0x0400614B RID: 24907
		private static bool _veiled = false;

		// Token: 0x0400614C RID: 24908
		private static float _startVeil = 0.267f;

		// Token: 0x0400614D RID: 24909
		private static float _fadeOutTime = 0.1f;

		// Token: 0x0400614E RID: 24910
		private static float _veilDuration = 0.3f;

		// Token: 0x0400614F RID: 24911
		private static float _fadeInTime = 0.2f;
	}
}
