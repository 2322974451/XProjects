using System;

namespace XMainClient
{

	internal class XDoodadCreateArgs : XEventArgs
	{

		public XDoodadCreateArgs()
		{
			this._eDefine = XEventDefine.XEvent_DoodadCreate;
			this.doo = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.doo = null;
			XEventPool<XDoodadCreateArgs>.Recycle(this);
		}

		public XLevelDoodad doo;
	}
}
