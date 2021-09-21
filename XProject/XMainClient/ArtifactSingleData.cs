using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008EF RID: 2287
	internal class ArtifactSingleData : IComparable
	{
		// Token: 0x17002B08 RID: 11016
		// (get) Token: 0x06008A4E RID: 35406 RVA: 0x00124DD4 File Offset: 0x00122FD4
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

		// Token: 0x06008A4F RID: 35407 RVA: 0x00124EF4 File Offset: 0x001230F4
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

		// Token: 0x04002C05 RID: 11269
		public bool Redpoint = false;

		// Token: 0x04002C06 RID: 11270
		public ArtifactListTable.RowData ItemData = null;

		// Token: 0x04002C07 RID: 11271
		public ItemComposeTable.RowData ItemComposeData = null;
	}
}
