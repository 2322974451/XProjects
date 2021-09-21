using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200166D RID: 5741
	internal class Player_kali_attack_reqingsihuo
	{
		// Token: 0x0600EF00 RID: 61184 RVA: 0x0034A8A4 File Offset: 0x00348AA4
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Player_kali_attack_reqingsihuo._veiled;
				if (flag)
				{
					Player_kali_attack_reqingsihuo._veiled = true;
					bool flag2 = Player_kali_attack_reqingsihuo._Veil == null;
					if (flag2)
					{
						Player_kali_attack_reqingsihuo._Veil = new XTimerMgr.ElapsedEventHandler(Player_kali_attack_reqingsihuo.Veil);
					}
					Player_kali_attack_reqingsihuo._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_kali_attack_reqingsihuo._startVeil, Player_kali_attack_reqingsihuo._Veil, skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Player_kali_attack_reqingsihuo._token);
				Player_kali_attack_reqingsihuo.Unveil(skill.Firer);
				Player_kali_attack_reqingsihuo._veiled = false;
			}
			return true;
		}

		// Token: 0x0600EF01 RID: 61185 RVA: 0x0034A93C File Offset: 0x00348B3C
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Player_kali_attack_reqingsihuo._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = Player_kali_attack_reqingsihuo._Unveil == null;
			if (flag)
			{
				Player_kali_attack_reqingsihuo._Unveil = new XTimerMgr.ElapsedEventHandler(Player_kali_attack_reqingsihuo.Unveil);
			}
			Player_kali_attack_reqingsihuo._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_kali_attack_reqingsihuo._veilDuration, Player_kali_attack_reqingsihuo._Unveil, o);
		}

		// Token: 0x0600EF02 RID: 61186 RVA: 0x0034A9AC File Offset: 0x00348BAC
		private static void Unveil(object o)
		{
			bool flag = Player_kali_attack_reqingsihuo._token > 0U;
			if (flag)
			{
				Player_kali_attack_reqingsihuo._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Player_kali_attack_reqingsihuo._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006630 RID: 26160
		private static uint _token = 0U;

		// Token: 0x04006631 RID: 26161
		private static bool _veiled = false;

		// Token: 0x04006632 RID: 26162
		private static float _startVeil = 1f;

		// Token: 0x04006633 RID: 26163
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006634 RID: 26164
		private static float _veilDuration = 3.2f;

		// Token: 0x04006635 RID: 26165
		private static float _fadeInTime = 0.1f;

		// Token: 0x04006636 RID: 26166
		private static XTimerMgr.ElapsedEventHandler _Veil;

		// Token: 0x04006637 RID: 26167
		private static XTimerMgr.ElapsedEventHandler _Unveil;
	}
}
