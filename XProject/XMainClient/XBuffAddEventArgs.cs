using System;

namespace XMainClient
{
	// Token: 0x02000F61 RID: 3937
	internal class XBuffAddEventArgs : XEventArgs
	{
		// Token: 0x0600D031 RID: 53297 RVA: 0x003041F1 File Offset: 0x003023F1
		public XBuffAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffAdd;
			this.xBuffDesc.Reset();
			this.xEffectImm = false;
		}

		// Token: 0x0600D032 RID: 53298 RVA: 0x00304216 File Offset: 0x00302416
		public override void Recycle()
		{
			base.Recycle();
			this.xBuffDesc.Reset();
			this.xEffectImm = false;
			XEventPool<XBuffAddEventArgs>.Recycle(this);
		}

		// Token: 0x04005E20 RID: 24096
		public BuffDesc xBuffDesc;

		// Token: 0x04005E21 RID: 24097
		public bool xEffectImm;
	}
}
