using System;

namespace XMainClient
{

	internal class XArmorBrokenArgs : XEventArgs
	{

		public XArmorBrokenArgs()
		{
			this._eDefine = XEventDefine.XEvent_ArmorBroken;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XArmorBrokenArgs>.Recycle(this);
		}

		public XEntity Self;
	}
}
