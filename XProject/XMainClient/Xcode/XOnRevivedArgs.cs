using System;

namespace XMainClient
{

	internal class XOnRevivedArgs : XEventArgs
	{

		public XOnRevivedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnRevived;
			this.entity = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.entity = null;
			XEventPool<XOnRevivedArgs>.Recycle(this);
		}

		public XEntity entity;
	}
}
