using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class NPC_Velskud_teleport
	{

		public static bool Disappear(XSkill skill)
		{
			bool casting = skill.Casting;
			if (casting)
			{
				bool flag = !NPC_Velskud_teleport._veiled;
				if (flag)
				{
					NPC_Velskud_teleport._veiled = true;
					NPC_Velskud_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_teleport._startVeil, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_teleport.Veil), skill.Firer);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(NPC_Velskud_teleport._token);
				NPC_Velskud_teleport.Unveil(skill.Firer);
				NPC_Velskud_teleport._veiled = false;
			}
			return true;
		}

		private static void Veil(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = NPC_Velskud_teleport._fadeOutTime;
			@event.Firer = (o as XEntity);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			NPC_Velskud_teleport._token = XSingleton<XTimerMgr>.singleton.SetTimer(NPC_Velskud_teleport._veilDuration, new XTimerMgr.ElapsedEventHandler(NPC_Velskud_teleport.Unveil), o);
		}

		private static void Unveil(object o)
		{
			bool flag = NPC_Velskud_teleport._token > 0U;
			if (flag)
			{
				NPC_Velskud_teleport._token = 0U;
				XFadeInEventArgs @event = XEventPool<XFadeInEventArgs>.GetEvent();
				@event.In = NPC_Velskud_teleport._fadeInTime;
				@event.Firer = (o as XEntity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		private static uint _token = 0U;

		private static bool _veiled = false;

		private static float _startVeil = 0.267f;

		private static float _fadeOutTime = 0.1f;

		private static float _veilDuration = 0.267f;

		private static float _fadeInTime = 0.2f;
	}
}
