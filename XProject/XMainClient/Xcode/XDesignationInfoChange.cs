using System;

namespace XMainClient
{

	internal class XDesignationInfoChange : XEventArgs
	{

		public XDesignationInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_DesignationInfoChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XDesignationInfoChange>.Recycle(this);
		}
	}
}
