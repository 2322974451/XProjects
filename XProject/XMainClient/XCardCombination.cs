using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000976 RID: 2422
	internal class XCardCombination
	{
		// Token: 0x060091F2 RID: 37362 RVA: 0x0014FFB4 File Offset: 0x0014E1B4
		public void InitStarPostion(CardsGroup.RowData cdata)
		{
			SeqListRef<uint> starFireCondition = cdata.StarFireCondition;
			this.starPostion = new List<int>();
			bool flag = starFireCondition.count == 0;
			if (!flag)
			{
				int num = 0;
				uint num2 = starFireCondition[num, 0];
				for (int i = 0; i < 100; i++)
				{
					bool flag2 = (long)num + (long)((ulong)num2) >= (long)((ulong)starFireCondition.count);
					if (flag2)
					{
						return;
					}
					this.starPostion.Add(num);
					num += (int)(num2 + 1U);
					bool flag3 = num >= (int)starFireCondition.count;
					if (flag3)
					{
						return;
					}
					num2 = starFireCondition[num, 0];
				}
				XSingleton<XDebug>.singleton.AddErrorLog("TeamId:" + cdata.TeamId + " StarFireCondition Error", null, null, null, null, null);
			}
		}

		// Token: 0x040030A2 RID: 12450
		public CardCombinationStatus status;

		// Token: 0x040030A3 RID: 12451
		public CardsGroup.RowData data;

		// Token: 0x040030A4 RID: 12452
		public List<int> starPostion;
	}
}
