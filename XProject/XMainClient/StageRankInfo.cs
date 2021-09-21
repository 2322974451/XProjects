using System;

namespace XMainClient
{
	// Token: 0x02000DCF RID: 3535
	internal class StageRankInfo
	{
		// Token: 0x170033D1 RID: 13265
		// (get) Token: 0x0600C09A RID: 49306 RVA: 0x0028C88C File Offset: 0x0028AA8C
		public int Rank
		{
			get
			{
				switch (this._rank)
				{
				case 0:
					return 0;
				case 1:
				case 2:
				case 4:
					return 1;
				case 7:
					return 3;
				}
				return 2;
			}
		}

		// Token: 0x170033D2 RID: 13266
		// (get) Token: 0x0600C09B RID: 49307 RVA: 0x0028C8DC File Offset: 0x0028AADC
		// (set) Token: 0x0600C09C RID: 49308 RVA: 0x0028C8F4 File Offset: 0x0028AAF4
		public int RankValue
		{
			get
			{
				return this._rank;
			}
			set
			{
				this._rank = value;
			}
		}

		// Token: 0x0400506D RID: 20589
		private int _rank;
	}
}
