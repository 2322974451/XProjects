using System;

namespace XMainClient
{

	internal class XDoodadDeleteArgs : XEventArgs
	{

		public XDoodadDeleteArgs()
		{
			this._eDefine = XEventDefine.XEvent_DoodadDelete;
			this.doo = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.doo = null;
			XEventPool<XDoodadDeleteArgs>.Recycle(this);
		}

		public XLevelDoodad doo;
	}
}
