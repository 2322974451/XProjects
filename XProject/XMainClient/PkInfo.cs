using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x020009BB RID: 2491
	public class PkInfo
	{
		// Token: 0x17002D6D RID: 11629
		// (get) Token: 0x060096E7 RID: 38631 RVA: 0x0016D998 File Offset: 0x0016BB98
		public uint percent
		{
			get
			{
				bool flag = this.win + this.lose == 0U;
				uint result;
				if (flag)
				{
					result = 100U;
				}
				else
				{
					bool flag2 = this.win == 0U;
					if (flag2)
					{
						result = 0U;
					}
					else
					{
						result = Math.Max(1U, 100U * this.win / (this.win + this.lose));
					}
				}
				return result;
			}
		}

		// Token: 0x04003371 RID: 13169
		public RoleSmallInfo brief;

		// Token: 0x04003372 RID: 13170
		public uint win;

		// Token: 0x04003373 RID: 13171
		public uint lose;

		// Token: 0x04003374 RID: 13172
		public uint point;

		// Token: 0x04003375 RID: 13173
		public List<uint> records;
	}
}
