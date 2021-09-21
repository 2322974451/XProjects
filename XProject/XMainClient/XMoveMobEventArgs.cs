using System;

namespace XMainClient
{
	// Token: 0x02000F68 RID: 3944
	internal class XMoveMobEventArgs : XEventArgs
	{
		// Token: 0x0600D040 RID: 53312 RVA: 0x003043CB File Offset: 0x003025CB
		public XMoveMobEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Move_Mob;
		}

		// Token: 0x0600D041 RID: 53313 RVA: 0x003043E0 File Offset: 0x003025E0
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XMoveMobEventArgs>.Recycle(this);
		}
	}
}
