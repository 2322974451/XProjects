using System;

namespace XMainClient
{
	// Token: 0x02000F4C RID: 3916
	internal class XCameraSoloEventArgs : XEventArgs
	{
		// Token: 0x0600CFFB RID: 53243 RVA: 0x00303BAE File Offset: 0x00301DAE
		public XCameraSoloEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraSolo;
		}

		// Token: 0x0600CFFC RID: 53244 RVA: 0x00303BC7 File Offset: 0x00301DC7
		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			XEventPool<XCameraSoloEventArgs>.Recycle(this);
		}

		// Token: 0x04005DF2 RID: 24050
		public XEntity Target = null;
	}
}
