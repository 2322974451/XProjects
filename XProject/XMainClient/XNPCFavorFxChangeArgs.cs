using System;

namespace XMainClient
{

	internal class XNPCFavorFxChangeArgs : XEventArgs
	{

		public XNPCFavorFxChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_NpcFavorFxChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XNPCFavorFxChangeArgs>.Recycle(this);
		}
	}
}
