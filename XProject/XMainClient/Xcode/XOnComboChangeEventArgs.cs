using System;

namespace XMainClient
{

	internal class XOnComboChangeEventArgs : XEventArgs
	{

		public XOnComboChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ComboChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.ComboCount = 0U;
			XEventPool<XOnComboChangeEventArgs>.Recycle(this);
		}

		public uint ComboCount = 0U;
	}
}
