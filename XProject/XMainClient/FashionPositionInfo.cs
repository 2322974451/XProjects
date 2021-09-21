using System;

namespace XMainClient
{
	// Token: 0x02000B2A RID: 2858
	public struct FashionPositionInfo
	{
		// Token: 0x0600A775 RID: 42869 RVA: 0x001D9DFB File Offset: 0x001D7FFB
		public FashionPositionInfo(int id)
		{
			this.fasionID = id;
			this.itemID = id;
			this.fashionName = "";
			this.fashionDir = "";
			this.presentID = 0U;
			this.replace = false;
		}

		// Token: 0x0600A776 RID: 42870 RVA: 0x001D9E30 File Offset: 0x001D8030
		public void Reset()
		{
			this.fasionID = 0;
			this.itemID = 0;
			this.fashionName = "";
			this.fashionDir = "";
			this.presentID = 0U;
			this.replace = false;
		}

		// Token: 0x0600A777 RID: 42871 RVA: 0x001D9E68 File Offset: 0x001D8068
		public bool Equals(ref FashionPositionInfo fpi)
		{
			return this.fasionID == fpi.fasionID && this.fashionName == fpi.fashionName && this.presentID == fpi.presentID && this.itemID == fpi.itemID;
		}

		// Token: 0x04003DE6 RID: 15846
		public int fasionID;

		// Token: 0x04003DE7 RID: 15847
		public int itemID;

		// Token: 0x04003DE8 RID: 15848
		public string fashionName;

		// Token: 0x04003DE9 RID: 15849
		public string fashionDir;

		// Token: 0x04003DEA RID: 15850
		public uint presentID;

		// Token: 0x04003DEB RID: 15851
		public bool replace;
	}
}
