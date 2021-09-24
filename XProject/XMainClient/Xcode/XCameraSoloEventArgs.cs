using System;

namespace XMainClient
{

	internal class XCameraSoloEventArgs : XEventArgs
	{

		public XCameraSoloEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraSolo;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			XEventPool<XCameraSoloEventArgs>.Recycle(this);
		}

		public XEntity Target = null;
	}
}
