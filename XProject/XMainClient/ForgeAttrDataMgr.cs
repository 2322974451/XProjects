using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ForgeAttrDataMgr : EquipAttrDataMgr
	{

		public ForgeAttrDataMgr(ForgeAttributes table)
		{
			this.m_forgeTab = table;
		}

		protected override void SetAttrByItemId(uint itemId)
		{
			bool flag = this.m_forgeTab == null;
			if (!flag)
			{
				for (int i = 0; i < this.m_forgeTab.Table.Length; i++)
				{
					ForgeAttributes.RowData rowData = this.m_forgeTab.Table[i];
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

		private ForgeAttributes m_forgeTab = null;
	}
}
