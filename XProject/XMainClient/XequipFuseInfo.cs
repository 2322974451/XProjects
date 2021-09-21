using System;

namespace XMainClient
{
	// Token: 0x02000DE8 RID: 3560
	internal struct XequipFuseInfo
	{
		// Token: 0x170033E1 RID: 13281
		// (get) Token: 0x0600C0ED RID: 49389 RVA: 0x0028DD64 File Offset: 0x0028BF64
		// (set) Token: 0x0600C0EE RID: 49390 RVA: 0x0028DD6C File Offset: 0x0028BF6C
		public uint BreakNum { get; set; }

		// Token: 0x170033E2 RID: 13282
		// (get) Token: 0x0600C0EF RID: 49391 RVA: 0x0028DD75 File Offset: 0x0028BF75
		// (set) Token: 0x0600C0F0 RID: 49392 RVA: 0x0028DD7D File Offset: 0x0028BF7D
		public uint FuseExp { get; set; }

		// Token: 0x0600C0F1 RID: 49393 RVA: 0x0028DD86 File Offset: 0x0028BF86
		public void Init()
		{
			this.BreakNum = 0U;
			this.FuseExp = 0U;
		}
	}
}
