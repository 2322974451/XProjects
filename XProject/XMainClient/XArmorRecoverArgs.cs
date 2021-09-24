using System;

namespace XMainClient
{

	internal class XArmorRecoverArgs : XEventArgs
	{

		public XArmorRecoverArgs()
		{
			this._eDefine = XEventDefine.XEvent_ArmorRecover;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XArmorRecoverArgs>.Recycle(this);
		}

		public XEntity Self;
	}
}
