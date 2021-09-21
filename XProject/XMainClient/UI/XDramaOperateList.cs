using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x02001782 RID: 6018
	internal class XDramaOperateList : XDataBase
	{
		// Token: 0x0600F860 RID: 63584 RVA: 0x0038C144 File Offset: 0x0038A344
		public override void Init()
		{
			base.Init();
			this.Name = null;
			this.ClickEvent = null;
			this.TargetTime = 0f;
			this.TimeNote = null;
			this.RID = 0UL;
		}

		// Token: 0x0600F861 RID: 63585 RVA: 0x0038C176 File Offset: 0x0038A376
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XDramaOperateList>.Recycle(this);
		}

		// Token: 0x04006C66 RID: 27750
		public string Name;

		// Token: 0x04006C67 RID: 27751
		public SpriteClickEventHandler ClickEvent;

		// Token: 0x04006C68 RID: 27752
		public float TargetTime;

		// Token: 0x04006C69 RID: 27753
		public string TimeNote;

		// Token: 0x04006C6A RID: 27754
		public ulong RID;
	}
}
