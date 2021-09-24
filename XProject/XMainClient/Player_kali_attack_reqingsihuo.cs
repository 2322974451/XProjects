using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Player_kali_attack_reqingsihuo
	{

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

		private static uint _token = 0U;

		private static bool _veiled = false;

		private static float _startVeil = 1f;

		private static float _fadeOutTime = 0.1f;

		private static float _veilDuration = 3.2f;

		private static float _fadeInTime = 0.1f;

		private static XTimerMgr.ElapsedEventHandler _Veil;

		private static XTimerMgr.ElapsedEventHandler _Unveil;
	}
}
