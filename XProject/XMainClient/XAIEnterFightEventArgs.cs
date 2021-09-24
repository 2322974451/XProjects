using System;

namespace XMainClient
{

	internal class XAIEnterFightEventArgs : XEventArgs
	{

		public XAIEnterFightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIEnterFight;
		}

		public override void Recycle()
		{
			this.Target = null;
			base.Recycle();
			XEventPool<XAIEnterFightEventArgs>.Recycle(this);
		}

		public XEntity Target = null;
	}
}
