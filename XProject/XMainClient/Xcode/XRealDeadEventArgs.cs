using System;

namespace XMainClient
{

	internal class XRealDeadEventArgs : XActionArgs
	{

		public XRealDeadEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_RealDead;
			this.Killer = null;
			this.TheDead = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Killer = null;
			this.TheDead = null;
			XEventPool<XRealDeadEventArgs>.Recycle(this);
		}

		public XEntity Killer;

		public XEntity TheDead;
	}
}
