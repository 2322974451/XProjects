using System;

namespace XMainClient
{

	internal class XBattleEndArgs : XEventArgs
	{

		public XBattleEndArgs()
		{
			this._eDefine = XEventDefine.XEvent_BattleEnd;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBattleEndArgs>.Recycle(this);
		}
	}
}
