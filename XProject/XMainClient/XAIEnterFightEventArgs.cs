using System;

namespace XMainClient
{
	// Token: 0x02000F56 RID: 3926
	internal class XAIEnterFightEventArgs : XEventArgs
	{
		// Token: 0x0600D013 RID: 53267 RVA: 0x00303DED File Offset: 0x00301FED
		public XAIEnterFightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIEnterFight;
		}

		// Token: 0x0600D014 RID: 53268 RVA: 0x00303E06 File Offset: 0x00302006
		public override void Recycle()
		{
			this.Target = null;
			base.Recycle();
			XEventPool<XAIEnterFightEventArgs>.Recycle(this);
		}

		// Token: 0x04005E01 RID: 24065
		public XEntity Target = null;
	}
}
