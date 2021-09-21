using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001057 RID: 4183
	internal class Player_sorceress_dash
	{
		// Token: 0x0600D613 RID: 54803 RVA: 0x003257A8 File Offset: 0x003239A8
		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !Player_sorceress_dash._veiled;
				if (flag)
				{
					Player_sorceress_dash._veiled = true;
					bool flag2 = Player_sorceress_dash._Veil == null;
					if (flag2)
					{
						Player_sorceress_dash._Veil = new XTimerMgr.ElapsedEventHandler(Player_sorceress_dash.Veil);
					}
					Player_sorceress_dash._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_sorceress_dash._startVeil, Player_sorceress_dash._Veil, skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(Player_sorceress_dash._token);
				Player_sorceress_dash.Unveil(skill.Firer);
				Player_sorceress_dash._veiled = false;
			}
			return true;
		}

		// Token: 0x0600D614 RID: 54804 RVA: 0x00325840 File Offset: 0x00323A40
		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = Player_sorceress_dash._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = Player_sorceress_dash._Unveil == null;
			if (flag)
			{
				Player_sorceress_dash._Unveil = new XTimerMgr.ElapsedEventHandler(Player_sorceress_dash.Unveil);
			}
			Player_sorceress_dash._token = XSingleton<XTimerMgr>.singleton.SetTimer(Player_sorceress_dash._veilDuration, Player_sorceress_dash._Unveil, o);
		}

		// Token: 0x0600D615 RID: 54805 RVA: 0x003258B0 File Offset: 0x00323AB0
		private static void Unveil(object o)
		{
			bool flag = Player_sorceress_dash._token > 0U;
			if (flag)
			{
				Player_sorceress_dash._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = Player_sorceress_dash._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x04006161 RID: 24929
		private static uint _token = 0U;

		// Token: 0x04006162 RID: 24930
		private static bool _veiled = false;

		// Token: 0x04006163 RID: 24931
		private static float _startVeil = 0.067f;

		// Token: 0x04006164 RID: 24932
		private static float _fadeOutTime = 0.1f;

		// Token: 0x04006165 RID: 24933
		private static float _veilDuration = 0.233f;

		// Token: 0x04006166 RID: 24934
		private static float _fadeInTime = 0.2f;

		// Token: 0x04006167 RID: 24935
		private static XTimerMgr.ElapsedEventHandler _Veil;

		// Token: 0x04006168 RID: 24936
		private static XTimerMgr.ElapsedEventHandler _Unveil;
	}
}
