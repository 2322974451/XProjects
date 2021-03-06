using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class EquipSuitItemData : IComparable
	{

		public int CompareValue
		{
			get
			{
				bool flag = this.itemComposeData == null;
				int result;
				if (flag)
				{
					result = int.MinValue;
				}
				else
				{
					int num = (int)XBagDocument.BagDoc.GetItemCount(this.itemComposeData.SrcItem1[0]) - this.itemComposeData.SrcItem1[1];
					bool flag2 = num < 0;
					if (flag2)
					{
						result = num;
					}
					else
					{
						int num2 = (int)XBagDocument.BagDoc.GetItemCount(this.itemComposeData.SrcItem2[0]) - this.itemComposeData.SrcItem2[1];
						bool flag3 = num2 < 0;
						if (flag3)
						{
							result = num2;
						}
						else
						{
							int num3 = (int)XBagDocument.BagDoc.GetItemCount(this.itemComposeData.SrcItem3[0]) - this.itemComposeData.SrcItem3[1];
							bool flag4 = num3 < 0;
							if (flag4)
							{
								result = num3;
							}
							else
							{
								int num4 = (int)XBagDocument.BagDoc.GetItemCount(XEquipCreateDocument.CoinId) - this.itemComposeData.Coin;
								bool flag5 = num4 < 0;
								if (flag5)
								{
									result = num4;
								}
								else
								{
									result = num + num2 + num3 + num4;
								}
							}
						}
					}
				}
				return result;
			}
		}

		public int CompareTo(object _other)
		{
			EquipSuitItemData equipSuitItemData = _other as EquipSuitItemData;
			bool flag = this.itemComposeData != null && equipSuitItemData.itemComposeData != null;
			if (flag)
			{
				bool flag2 = this.itemComposeData.Level != equipSuitItemData.itemComposeData.Level;
				if (flag2)
				{
					return this.itemComposeData.Level - equipSuitItemData.itemComposeData.Level;
				}
			}
			int compareValue = this.CompareValue;
			int compareValue2 = equipSuitItemData.CompareValue;
			bool flag3 = compareValue >= 0;
			if (flag3)
			{
				bool flag4 = compareValue2 < 0;
				if (flag4)
				{
					return -1;
				}
			}
			else
			{
				bool flag5 = compareValue2 >= 0;
				if (flag5)
				{
					return 1;
				}
			}
			int[] equipPosOrderArray = XSingleton<XEquipCreateStaticData>.singleton.EquipPosOrderArray;
			bool flag6 = equipPosOrderArray[(int)this.itemData.EquipPos] == equipPosOrderArray[(int)equipSuitItemData.itemData.EquipPos];
			int result;
			if (flag6)
			{
				bool flag7 = compareValue == compareValue2;
				if (flag7)
				{
					result = this.itemComposeData.Coin - equipSuitItemData.itemComposeData.Coin;
				}
				else
				{
					result = compareValue2 - compareValue;
				}
			}
			else
			{
				result = equipPosOrderArray[(int)this.itemData.EquipPos] - equipPosOrderArray[(int)equipSuitItemData.itemData.EquipPos];
			}
			return result;
		}

		public bool redpoint;

		public EquipList.RowData itemData;

		public ItemComposeTable.RowData itemComposeData;
	}
}
