using System;

namespace XMainClient
{
	// Token: 0x02000985 RID: 2437
	internal class XItemRequired : XDataBase
	{
		// Token: 0x17002CA2 RID: 11426
		// (get) Token: 0x06009291 RID: 37521 RVA: 0x001533A8 File Offset: 0x001515A8
		public bool bEnough
		{
			get
			{
				return this.requiredCount <= this.ownedCount;
			}
		}

		// Token: 0x06009292 RID: 37522 RVA: 0x001533CB File Offset: 0x001515CB
		public override void Init()
		{
			base.Init();
			this.itemID = 0;
			this.requiredCount = 0UL;
			this.ownedCount = 0UL;
		}

		// Token: 0x06009293 RID: 37523 RVA: 0x001533EC File Offset: 0x001515EC
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XItemRequired>.Recycle(this);
		}

		// Token: 0x04003123 RID: 12579
		public int itemID;

		// Token: 0x04003124 RID: 12580
		public ulong requiredCount;

		// Token: 0x04003125 RID: 12581
		public ulong ownedCount;
	}
}
