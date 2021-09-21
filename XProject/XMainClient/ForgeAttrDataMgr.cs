using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E1 RID: 2273
	internal class ForgeAttrDataMgr : EquipAttrDataMgr
	{
		// Token: 0x060089B6 RID: 35254 RVA: 0x001219C4 File Offset: 0x0011FBC4
		public ForgeAttrDataMgr(ForgeAttributes table)
		{
			this.m_forgeTab = table;
		}

		// Token: 0x060089B7 RID: 35255 RVA: 0x001219DC File Offset: 0x0011FBDC
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

		// Token: 0x04002BB5 RID: 11189
		private ForgeAttributes m_forgeTab = null;
	}
}
