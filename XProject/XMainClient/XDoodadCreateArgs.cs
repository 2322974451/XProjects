using System;

namespace XMainClient
{
	// Token: 0x02000F6F RID: 3951
	internal class XDoodadCreateArgs : XEventArgs
	{
		// Token: 0x0600D070 RID: 53360 RVA: 0x00304744 File Offset: 0x00302944
		public XDoodadCreateArgs()
		{
			this._eDefine = XEventDefine.XEvent_DoodadCreate;
			this.doo = null;
		}

		// Token: 0x0600D071 RID: 53361 RVA: 0x00304760 File Offset: 0x00302960
		public override void Recycle()
		{
			base.Recycle();
			this.doo = null;
			XEventPool<XDoodadCreateArgs>.Recycle(this);
		}

		// Token: 0x04005E41 RID: 24129
		public XLevelDoodad doo;
	}
}
