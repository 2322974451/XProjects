using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FashionStorageHairColor : FashionStorageTabBase, IFashionStorageSelect
	{

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

		public override string GetName()
		{
			return this.m_hairName;
		}

		public override int GetID()
		{
			return (int)this.m_hairData.HairID;
		}

		private FashionHair.RowData m_hairData;

		private string m_hairName;
	}
}
