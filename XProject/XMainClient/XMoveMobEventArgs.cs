using System;

namespace XMainClient
{

	internal class XMoveMobEventArgs : XEventArgs
	{

		public XMoveMobEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Move_Mob;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XMoveMobEventArgs>.Recycle(this);
		}
	}
}
