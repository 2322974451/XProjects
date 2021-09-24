using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Player_assassin_attack_chakelahuanying_dash
	{

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

		private static uint _token = 0U;

		private static bool _veiled = false;

		private static float _startVeil = 0.033f;

		private static float _fadeOutTime = 0.1f;

		private static float _veilDuration = 0.566f;

		private static float _fadeInTime = 0.1f;

		private static XTimerMgr.ElapsedEventHandler _Veil;

		private static XTimerMgr.ElapsedEventHandler _Unveil;
	}
}
