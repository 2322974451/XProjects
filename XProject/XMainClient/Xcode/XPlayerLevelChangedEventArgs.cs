using System;

namespace XMainClient
{

	internal class XPlayerLevelChangedEventArgs : XEventArgs
	{

		public XPlayerLevelChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_PlayerLevelChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.level = 0U;
			this.PreLevel = 0U;
			XEventPool<XPlayerLevelChangedEventArgs>.Recycle(this);
		}

		public uint level = 0U;

		public uint PreLevel = 0U;
	}
}
