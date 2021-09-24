using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAttackEventArgs : XEventArgs
	{

		public XAttackEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Attack;
		}

		public override void Recycle()
		{
			this.Identify = 0U;
			this.Target = null;
			this.Slot = -1;
			this.Demonstration = false;
			this.AffectCamera = XSingleton<XScene>.singleton.GameCamera;
			this.TimeScale = 1f;
			this.SyncSequence = 0U;
			base.Recycle();
			base.Token = (XSingleton<XCommon>.singleton.UniqueToken ^ (long)DateTime.Now.Millisecond);
			XEventPool<XAttackEventArgs>.Recycle(this);
		}

		public uint Identify;

		public XEntity Target = null;

		public int Slot = -1;

		public uint SyncSequence = 0U;

		public bool Demonstration = false;

		public XCameraEx AffectCamera = XSingleton<XScene>.singleton.GameCamera;

		public float TimeScale = 1f;
	}
}
