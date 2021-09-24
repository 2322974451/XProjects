using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RandomAttrDataMgr : EquipAttrDataMgr
	{

		public RandomAttrDataMgr(RandomAttributes table)
		{
			this.m_randomTab = table;
		}

		protected override void SetAttrByItemId(uint itemId)
		{
			bool flag = this.m_randomTab == null;
			if (!flag)
			{
				for (int i = 0; i < this.m_randomTab.Table.Length; i++)
				{
					RandomAttributes.RowData rowData = this.m_randomTab.Table[i];
					bool flag2 = rowData.EquipID == itemId;
					if (flag2)
					{
						bool flag3 = !this.m_attrDic.ContainsKey(rowData.EquipID);
						if (flag3)
						{
							EquipSlotAttrDatas equipSlotAttrDatas = new EquipSlotAttrDatas(rowData.EquipID);
							equipSlotAttrDatas.Add(rowData);
							this.m_attrDic.Add(rowData.EquipID, equipSlotAttrDatas);
						}
						else
						{
							this.m_attrDic[rowData.EquipID].Add(rowData);
						}
					}
				}
			}
		}

		private RandomAttributes m_randomTab = null;
	}
}
