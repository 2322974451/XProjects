using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCardCombination
	{

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

		public CardCombinationStatus status;

		public CardsGroup.RowData data;

		public List<int> starPostion;
	}
}
