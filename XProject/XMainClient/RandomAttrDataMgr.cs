using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E2 RID: 2274
	internal class RandomAttrDataMgr : EquipAttrDataMgr
	{
		// Token: 0x060089B8 RID: 35256 RVA: 0x00121AA0 File Offset: 0x0011FCA0
		public RandomAttrDataMgr(RandomAttributes table)
		{
			this.m_randomTab = table;
		}

		// Token: 0x060089B9 RID: 35257 RVA: 0x00121AB8 File Offset: 0x0011FCB8
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

		// Token: 0x04002BB6 RID: 11190
		private RandomAttributes m_randomTab = null;
	}
}
