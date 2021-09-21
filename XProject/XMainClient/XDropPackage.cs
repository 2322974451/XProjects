using System;

namespace XMainClient
{
	// Token: 0x02000E08 RID: 3592
	internal class XDropPackage
	{
		// Token: 0x0600C1AB RID: 49579 RVA: 0x00296D48 File Offset: 0x00294F48
		public void Reset()
		{
			this.money = 0U;
			this.weapon_count = 0U;
			this.armor_count = 0U;
		}

		// Token: 0x0400523D RID: 21053
		public uint money;

		// Token: 0x0400523E RID: 21054
		public uint weapon_count;

		// Token: 0x0400523F RID: 21055
		public uint armor_count;
	}
}
