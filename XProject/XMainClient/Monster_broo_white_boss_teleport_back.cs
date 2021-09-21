using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001041 RID: 4161
	internal class Monster_broo_white_boss_teleport_back
	{
		// Token: 0x0600D5B5 RID: 54709 RVA: 0x00324BE8 File Offset: 0x00322DE8
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Monster_broo_white_boss_teleport_back._veiled;
				if (flag)
				{
					Monster_broo_white_boss_teleport_back._veiled = true;
					Monster_broo_white_boss_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_boss_teleport_back._startVeil, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_boss_teleport_back.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Monster_broo_white_boss_teleport_back._token);
				Monster_broo_white_boss_teleport_back.Unveil(skill.Firer);
				Monster_broo_white_boss_teleport_back._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D5B6 RID: 54710 RVA: 0x00324C68 File Offset: 0x00322E68
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Monster_broo_white_boss_teleport_back._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			Monster_broo_white_boss_teleport_back._token = XSingleton<XTimerMgr>.singleton.SetTimer(Monster_broo_white_boss_teleport_back._veilDuration, new XTimerMgr.ElapsedEventHandler(Monster_broo_white_boss_teleport_back.Unveil), o);
		}

		// Token: 0x0600D5B7 RID: 54711 RVA: 0x00324CC4 File Offset: 0x00322EC4
		private static void Unveil(object o)
		{
			bool flag = Monster_broo_white_boss_teleport_back._token > 0U;
			if (flag)
			{
				Monster_broo_white_boss_teleport_back._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Monster_broo_white_boss_teleport_back._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006144 RID: 24900
		private static uint _token = 0U;

		// Token: 0x04006145 RID: 24901
		private static bool _veiled = false;

		// Token: 0x04006146 RID: 24902
		private static float _startVeil = 0.267f;

		// Token: 0x04006147 RID: 24903
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006148 RID: 24904
		private static float _veilDuration = 0.3f;

		// Token: 0x04006149 RID: 24905
		private static float _fadeInTime = 0.2f;
	}
}
