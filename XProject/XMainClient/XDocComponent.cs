using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D41 RID: 3393
	internal abstract class XDocComponent : XComponent
	{
		// Token: 0x0600BBFF RID: 48127 RVA: 0x0026BC4E File Offset: 0x00269E4E
		public override void InitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.GetBuffer(ref this._eventMap, 4);
		}

		// Token: 0x0600BC00 RID: 48128 RVA: 0x0026BC63 File Offset: 0x00269E63
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_OnReconnected, new XComponent.XEventHandler(this.Reconnect));
		}

		// Token: 0x0600BC01 RID: 48129 RVA: 0x0026BC7C File Offset: 0x00269E7C
		protected bool Reconnect(XEventArgs args)
		{
			XReconnectedEventArgs arg = args as XReconnectedEventArgs;
			this.OnReconnected(arg);
			return true;
		}

		// Token: 0x0600BC02 RID: 48130 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnEnterSceneFinally()
		{
		}

		// Token: 0x0600BC03 RID: 48131 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnSceneStarted()
		{
		}

		// Token: 0x0600BC04 RID: 48132 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnGamePause(bool pause)
		{
		}

		// Token: 0x0600BC05 RID: 48133
		protected abstract void OnReconnected(XReconnectedEventArgs arg);
	}
}
