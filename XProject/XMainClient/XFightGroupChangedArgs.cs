using System;

namespace XMainClient
{
	// Token: 0x02000FAE RID: 4014
	internal class XFightGroupChangedArgs : XEventArgs
	{
		// Token: 0x0600D102 RID: 53506 RVA: 0x003055EB File Offset: 0x003037EB
		public XFightGroupChangedArgs()
		{
			this._eDefine = XEventDefine.XEvent_FightGroupChanged;
			this.newFightGroup = 0U;
			this.oldFightGroup = 0U;
		}

		// Token: 0x0600D103 RID: 53507 RVA: 0x0030560E File Offset: 0x0030380E
		public override void Recycle()
		{
			base.Recycle();
			this.newFightGroup = 0U;
			this.oldFightGroup = 0U;
			XEventPool<XFightGroupChangedArgs>.Recycle(this);
		}

		// Token: 0x04005E99 RID: 24217
		public uint newFightGroup;

		// Token: 0x04005E9A RID: 24218
		public uint oldFightGroup;

		// Token: 0x04005E9B RID: 24219
		public XEntity targetEntity;
	}
}
