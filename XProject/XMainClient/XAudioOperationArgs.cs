using System;

namespace XMainClient
{
	// Token: 0x02000FA0 RID: 4000
	internal class XAudioOperationArgs : XEventArgs
	{
		// Token: 0x0600D0E6 RID: 53478 RVA: 0x00305322 File Offset: 0x00303522
		public XAudioOperationArgs()
		{
			this._eDefine = XEventDefine.XEvent_AudioOperation;
		}

		// Token: 0x0600D0E7 RID: 53479 RVA: 0x0030533E File Offset: 0x0030353E
		public override void Recycle()
		{
			base.Recycle();
			this.IsAudioOn = true;
			XEventPool<XAudioOperationArgs>.Recycle(this);
		}

		// Token: 0x04005E89 RID: 24201
		public bool IsAudioOn = true;
	}
}
