using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x02001781 RID: 6017
	internal class XDramaOperateButton : XDataBase
	{
		// Token: 0x0600F85D RID: 63581 RVA: 0x0038C0F2 File Offset: 0x0038A2F2
		public override void Init()
		{
			base.Init();
			this.Name = null;
			this.ClickEvent = null;
			this.TargetTime = 0f;
			this.TimeNote = null;
			this.StateEnable = true;
		}

		// Token: 0x0600F85E RID: 63582 RVA: 0x0038C123 File Offset: 0x0038A323
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XDramaOperateButton>.Recycle(this);
		}

		// Token: 0x04006C60 RID: 27744
		public string Name;

		// Token: 0x04006C61 RID: 27745
		public ButtonClickEventHandler ClickEvent;

		// Token: 0x04006C62 RID: 27746
		public float TargetTime;

		// Token: 0x04006C63 RID: 27747
		public string TimeNote;

		// Token: 0x04006C64 RID: 27748
		public bool StateEnable = true;

		// Token: 0x04006C65 RID: 27749
		public ulong RID;
	}
}
