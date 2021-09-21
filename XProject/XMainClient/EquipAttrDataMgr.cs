using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E3 RID: 2275
	internal class EquipAttrDataMgr
	{
		// Token: 0x060089BA RID: 35258 RVA: 0x00121B7C File Offset: 0x0011FD7C
		public EquipSlotAttrDatas GetAttrData(uint itemId)
		{
			EquipSlotAttrDatas equipSlotAttrDatas;
			bool flag = this.m_attrDic.TryGetValue(itemId, out equipSlotAttrDatas);
			EquipSlotAttrDatas result;
			if (flag)
			{
				result = equipSlotAttrDatas;
			}
			else
			{
				this.SetAttrByItemId(itemId);
				bool flag2 = this.m_attrDic.TryGetValue(itemId, out equipSlotAttrDatas);
				if (flag2)
				{
					result = equipSlotAttrDatas;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x060089BB RID: 35259 RVA: 0x00121BC4 File Offset: 0x0011FDC4
		public bool IsHadThisEquip(int itemId)
		{
			bool flag = this.m_attrDic.ContainsKey((uint)itemId);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.SetAttrByItemId((uint)itemId);
				result = this.m_attrDic.ContainsKey((uint)itemId);
			}
			return result;
		}

		// Token: 0x060089BC RID: 35260 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetAttrByItemId(uint itemId)
		{
		}

		// Token: 0x17002AE8 RID: 10984
		// (get) Token: 0x060089BD RID: 35261 RVA: 0x00121C00 File Offset: 0x0011FE00
		public static List<int> MarkList
		{
			get
			{
				bool flag = EquipAttrDataMgr.m_markList == null;
				if (flag)
				{
					EquipAttrDataMgr.m_markList = XSingleton<XGlobalConfig>.singleton.GetIntList("SmeltCorlorRange");
				}
				return EquipAttrDataMgr.m_markList;
			}
		}

		// Token: 0x060089BE RID: 35262 RVA: 0x00121C37 File Offset: 0x0011FE37
		public void DataClear()
		{
			this.m_attrDic.Clear();
		}

		// Token: 0x04002BB7 RID: 11191
		protected static List<int> m_markList;

		// Token: 0x04002BB8 RID: 11192
		protected Dictionary<uint, EquipSlotAttrDatas> m_attrDic = new Dictionary<uint, EquipSlotAttrDatas>();
	}
}
