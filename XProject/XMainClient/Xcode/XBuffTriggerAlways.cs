using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTriggerAlways : XBuffTrigger
	{

		public XBuffTriggerAlways(XBuff buff) : base(buff)
		{
			this._timeCb = new XTimerMgr.ElapsedEventHandler(this.OnTimer);
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.OnTimer(null);
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			base.OnRemove(entity, IsReplaced);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimeToken);
		}

		public void OnTimer(object o)
		{
			base.Trigger();
			this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._timeCb, o);
		}

		private uint _TimeToken = 0U;

		private XTimerMgr.ElapsedEventHandler _timeCb = null;
	}
}
