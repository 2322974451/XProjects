using System;

namespace XMainClient
{

	internal class XTitleInfoChange : XEventArgs
	{

		public XTitleInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_TitleChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XTitleInfoChange>.Recycle(this);
		}
	}
}
