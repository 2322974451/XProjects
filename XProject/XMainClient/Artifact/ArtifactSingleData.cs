using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactSingleData : IComparable
	{

		public int CompareValue
		{
			get
			{
				bool flag = this.ItemComposeData == null;
				int result;
				if (flag)
				{
					result = int.MinValue;
				}
				else
				{
					int num = (int)XBagDocument.BagDoc.GetItemCount(this.ItemComposeData.SrcItem1[0]) - this.ItemComposeData.SrcItem1[1];
					bool flag2 = num < 0;
					if (flag2)
					{
						result = num;
					}
					else
					{
						int num2 = (int)XBagDocument.BagDoc.GetItemCount(this.ItemComposeData.SrcItem2[0]) - this.ItemComposeData.SrcItem2[1];
						bool flag3 = num2 < 0;
						if (flag3)
						{
							result = num2;
						}
						else
						{
							int num3 = (int)XBagDocument.BagDoc.GetItemCount(this.ItemComposeData.SrcItem3[0]) - this.ItemComposeData.SrcItem3[1];
							bool flag4 = num3 < 0;
							if (flag4)
							{
								result = num3;
							}
							else
							{
								int num4 = (int)XBagDocument.BagDoc.GetItemCount(XEquipCreateDocument.CoinId) - this.ItemComposeData.Coin;
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
			ArtifactSingleData artifactSingleData = _other as ArtifactSingleData;
			bool flag = this.ItemComposeData != null && artifactSingleData.ItemComposeData != null;
			if (flag)
			{
				bool flag2 = this.ItemComposeData.Level != artifactSingleData.ItemComposeData.Level;
				if (flag2)
				{
					return this.ItemComposeData.Level - artifactSingleData.ItemComposeData.Level;
				}
			}
			bool flag3 = this.CompareValue >= artifactSingleData.CompareValue;
			int result;
			if (flag3)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public bool Redpoint = false;

		public ArtifactListTable.RowData ItemData = null;

		public ItemComposeTable.RowData ItemComposeData = null;
	}
}
