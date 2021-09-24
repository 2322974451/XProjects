using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XDocComponent : XComponent
	{

		public override void InitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.GetBuffer(ref this._eventMap, 4);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_OnReconnected, new XComponent.XEventHandler(this.Reconnect));
		}

		protected bool Reconnect(XEventArgs args)
		{
			XReconnectedEventArgs arg = args as XReconnectedEventArgs;
			this.OnReconnected(arg);
			return true;
		}

		public virtual void OnEnterSceneFinally()
		{
		}

		public virtual void OnSceneStarted()
		{
		}

		public virtual void OnGamePause(bool pause)
		{
		}

		protected abstract void OnReconnected(XReconnectedEventArgs arg);
	}
}
