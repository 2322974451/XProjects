using System;

namespace XMainClient
{

	internal class XBuffAddEventArgs : XEventArgs
	{

		public XBuffAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffAdd;
			this.xBuffDesc.Reset();
			this.xEffectImm = false;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.xBuffDesc.Reset();
			this.xEffectImm = false;
			XEventPool<XBuffAddEventArgs>.Recycle(this);
		}

		public BuffDesc xBuffDesc;

		public bool xEffectImm;
	}
}
