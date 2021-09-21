using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001557 RID: 5463
	internal class Player_assassin_attack_chakelahuanying_dash
	{
		// Token: 0x0600EA73 RID: 60019 RVA: 0x003443A0 File Offset: 0x003425A0
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Player_assassin_attack_chakelahuanying_dash._veiled;
				if (flag)
				{
					Player_assassin_attack_chakelahuanying_dash._veiled = true;
					bool flag2 = Player_assassin_attack_chakelahuanying_dash._Veil == null;
					if (flag2)
					{
						Player_assassin_attack_chakelahuanying_dash._Veil = new XTimerMgr.ElapsedEventHandler(Player_assassin_attack_chakelahuanying_dash.Veil);
					}
					Player_assassin_attack_chakelahuanying_dash._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_assassin_attack_chakelahuanying_dash._startVeil, Player_assassin_attack_chakelahuanying_dash._Veil, skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Player_assassin_attack_chakelahuanying_dash._token);
				Player_assassin_attack_chakelahuanying_dash.Unveil(skill.Firer);
				Player_assassin_attack_chakelahuanying_dash._veiled = false;
			}
			return true;
		}

		// Token: 0x0600EA74 RID: 60020 RVA: 0x00344438 File Offset: 0x00342638
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Player_assassin_attack_chakelahuanying_dash._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = Player_assassin_attack_chakelahuanying_dash._Unveil == null;
			if (flag)
			{
				Player_assassin_attack_chakelahuanying_dash._Unveil = new XTimerMgr.ElapsedEventHandler(Player_assassin_attack_chakelahuanying_dash.Unveil);
			}
			Player_assassin_attack_chakelahuanying_dash._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_assassin_attack_chakelahuanying_dash._veilDuration, Player_assassin_attack_chakelahuanying_dash._Unveil, o);
		}

		// Token: 0x0600EA75 RID: 60021 RVA: 0x003444A8 File Offset: 0x003426A8
		private static void Unveil(object o)
		{
			bool flag = Player_assassin_attack_chakelahuanying_dash._token > 0U;
			if (flag)
			{
				Player_assassin_attack_chakelahuanying_dash._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Player_assassin_attack_chakelahuanying_dash._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006542 RID: 25922
		private static uint _token = 0U;

		// Token: 0x04006543 RID: 25923
		private static bool _veiled = false;

		// Token: 0x04006544 RID: 25924
		private static float _startVeil = 0.033f;

		// Token: 0x04006545 RID: 25925
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006546 RID: 25926
		private static float _veilDuration = 0.566f;

		// Token: 0x04006547 RID: 25927
		private static float _fadeInTime = 0.1f;

		// Token: 0x04006548 RID: 25928
		private static XTimerMgr.ElapsedEventHandler _Veil;

		// Token: 0x04006549 RID: 25929
		private static XTimerMgr.ElapsedEventHandler _Unveil;
	}
}
