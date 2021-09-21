using System;

namespace XMainClient
{
	// Token: 0x02000F90 RID: 3984
	internal class XDesignationInfoChange : XEventArgs
	{
		// Token: 0x0600D0BE RID: 53438 RVA: 0x00304FD0 File Offset: 0x003031D0
		public XDesignationInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_DesignationInfoChange;
		}

		// Token: 0x0600D0BF RID: 53439 RVA: 0x00304FE5 File Offset: 0x003031E5
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XDesignationInfoChange>.Recycle(this);
		}
	}
}
