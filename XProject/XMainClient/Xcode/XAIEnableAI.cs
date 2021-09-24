using System;

namespace XMainClient
{

	internal class XAIEnableAI : XEventArgs
	{

		public XAIEnableAI()
		{
			this._eDefine = XEventDefine.XEvent_EnableAI;
			this.Enable = true;
			this.Puppet = true;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Enable = true;
			this.Puppet = true;
			XEventPool<XAIEnableAI>.Recycle(this);
		}

		public bool Enable;

		public bool Puppet;
	}
}
