using System;

namespace XMainClient
{

	internal class XPrerogativeChangeArgs : XEventArgs
	{

		public XPrerogativeChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_Prerogative;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XPrerogativeChangeArgs>.Recycle(this);
		}

		public uint prerogativeLevel = 0U;
	}
}
