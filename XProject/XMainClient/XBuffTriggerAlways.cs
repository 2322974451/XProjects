using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000899 RID: 2201
	internal class XBuffTriggerAlways : XBuffTrigger
	{
		// Token: 0x060085EB RID: 34283 RVA: 0x0010C9C5 File Offset: 0x0010ABC5
		public XBuffTriggerAlways(XBuff buff) : base(buff)
		{
			this._timeCb = new XTimerMgr.ElapsedEventHandler(this.OnTimer);
		}

		// Token: 0x060085EC RID: 34284 RVA: 0x0010C9F0 File Offset: 0x0010ABF0
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.OnTimer(null);
		}

		// Token: 0x060085ED RID: 34285 RVA: 0x0010CA04 File Offset: 0x0010AC04
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			base.OnRemove(entity, IsReplaced);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimeToken);
		}

		// Token: 0x060085EE RID: 34286 RVA: 0x0010CA21 File Offset: 0x0010AC21
		public void OnTimer(object o)
		{
			base.Trigger();
			this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._timeCb, o);
		}

		// Token: 0x040029AF RID: 10671
		private uint _TimeToken = 0U;

		// Token: 0x040029B0 RID: 10672
		private XTimerMgr.ElapsedEventHandler _timeCb = null;
	}
}
