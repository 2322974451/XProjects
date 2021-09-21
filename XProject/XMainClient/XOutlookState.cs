using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000B29 RID: 2857
	internal class XOutlookState
	{
		// Token: 0x17003009 RID: 12297
		// (get) Token: 0x0600A772 RID: 42866 RVA: 0x001D9DB8 File Offset: 0x001D7FB8
		public bool bMounted
		{
			get
			{
				return this.type == OutLookStateType.OutLook_RidePet || this.type == OutLookStateType.OutLook_RidePetCopilot;
			}
		}

		// Token: 0x1700300A RID: 12298
		// (get) Token: 0x0600A773 RID: 42867 RVA: 0x001D9DE0 File Offset: 0x001D7FE0
		public bool bDancing
		{
			get
			{
				return this.type == OutLookStateType.OutLook_Dance;
			}
		}

		// Token: 0x04003DE3 RID: 15843
		public OutLookStateType type;

		// Token: 0x04003DE4 RID: 15844
		public uint param;

		// Token: 0x04003DE5 RID: 15845
		public ulong paramother;
	}
}
