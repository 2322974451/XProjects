using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008DA RID: 2266
	internal class FashionStorageHairColor : FashionStorageTabBase, IFashionStorageSelect
	{
		// Token: 0x0600897A RID: 35194 RVA: 0x00120FE8 File Offset: 0x0011F1E8
		public FashionStorageHairColor(FashionHair.RowData hairData)
		{
			this.m_hairData = hairData;
			this.m_fashionList = new uint[this.m_hairData.UnLookColorID.Length + 1];
			int i = 0;
			int num = this.m_fashionList.Length;
			while (i < num)
			{
				bool flag = i == 0;
				if (flag)
				{
					this.m_fashionList[i] = this.m_hairData.DefaultColorID;
				}
				else
				{
					this.m_fashionList[i] = this.m_hairData.UnLookColorID[i - 1];
				}
				i++;
			}
			this.GetItems().Add(hairData.DefaultColorID);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_hairData.HairID);
			bool flag2 = itemConf != null && itemConf.ItemName != null && itemConf.ItemName.Length != 0;
			if (flag2)
			{
				this.m_hairName = itemConf.ItemName[0];
			}
		}

		// Token: 0x0600897B RID: 35195 RVA: 0x001210C0 File Offset: 0x0011F2C0
		public override string GetName()
		{
			return this.m_hairName;
		}

		// Token: 0x0600897C RID: 35196 RVA: 0x001210D8 File Offset: 0x0011F2D8
		public override int GetID()
		{
			return (int)this.m_hairData.HairID;
		}

		// Token: 0x04002B9E RID: 11166
		private FashionHair.RowData m_hairData;

		// Token: 0x04002B9F RID: 11167
		private string m_hairName;
	}
}
