using System;

namespace XMainClient
{
	// Token: 0x02000A52 RID: 2642
	public class EquipFuseData
	{
		// Token: 0x17002EF7 RID: 12023
		// (get) Token: 0x0600A062 RID: 41058 RVA: 0x001AD3CF File Offset: 0x001AB5CF
		// (set) Token: 0x0600A063 RID: 41059 RVA: 0x001AD3D7 File Offset: 0x001AB5D7
		public uint AttrId { get; set; }

		// Token: 0x17002EF8 RID: 12024
		// (get) Token: 0x0600A064 RID: 41060 RVA: 0x001AD3E0 File Offset: 0x001AB5E0
		// (set) Token: 0x0600A065 RID: 41061 RVA: 0x001AD3E8 File Offset: 0x001AB5E8
		public uint BeforeBaseAttrNum { get; set; }

		// Token: 0x17002EF9 RID: 12025
		// (get) Token: 0x0600A066 RID: 41062 RVA: 0x001AD3F1 File Offset: 0x001AB5F1
		// (set) Token: 0x0600A067 RID: 41063 RVA: 0x001AD3F9 File Offset: 0x001AB5F9
		public uint BeforeAddNum { get; set; }

		// Token: 0x17002EFA RID: 12026
		// (get) Token: 0x0600A068 RID: 41064 RVA: 0x001AD402 File Offset: 0x001AB602
		// (set) Token: 0x0600A069 RID: 41065 RVA: 0x001AD40A File Offset: 0x001AB60A
		public uint AfterAddNum { get; set; }

		// Token: 0x17002EFB RID: 12027
		// (get) Token: 0x0600A06A RID: 41066 RVA: 0x001AD413 File Offset: 0x001AB613
		// (set) Token: 0x0600A06B RID: 41067 RVA: 0x001AD41B File Offset: 0x001AB61B
		public bool IsExtra { get; set; }

		// Token: 0x17002EFC RID: 12028
		// (get) Token: 0x0600A06C RID: 41068 RVA: 0x001AD424 File Offset: 0x001AB624
		public uint UpNum
		{
			get
			{
				return (this.AfterAddNum > this.BeforeAddNum) ? (this.AfterAddNum - this.BeforeAddNum) : 0U;
			}
		}

		// Token: 0x0600A06D RID: 41069 RVA: 0x001AD454 File Offset: 0x001AB654
		public void Init()
		{
			this.AttrId = 0U;
			this.BeforeAddNum = 0U;
			this.AfterAddNum = 0U;
			this.IsExtra = false;
		}
	}
}
