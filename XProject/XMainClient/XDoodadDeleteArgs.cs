using System;

namespace XMainClient
{
	// Token: 0x02000F70 RID: 3952
	internal class XDoodadDeleteArgs : XEventArgs
	{
		// Token: 0x0600D072 RID: 53362 RVA: 0x00304778 File Offset: 0x00302978
		public XDoodadDeleteArgs()
		{
			this._eDefine = XEventDefine.XEvent_DoodadDelete;
			this.doo = null;
		}

		// Token: 0x0600D073 RID: 53363 RVA: 0x00304794 File Offset: 0x00302994
		public override void Recycle()
		{
			base.Recycle();
			this.doo = null;
			XEventPool<XDoodadDeleteArgs>.Recycle(this);
		}

		// Token: 0x04005E42 RID: 24130
		public XLevelDoodad doo;
	}
}
