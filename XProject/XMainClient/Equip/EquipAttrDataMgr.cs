using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipAttrDataMgr
	{

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

		protected virtual void SetAttrByItemId(uint itemId)
		{
		}

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

		public void DataClear()
		{
			this.m_attrDic.Clear();
		}

		protected static List<int> m_markList;

		protected Dictionary<uint, EquipSlotAttrDatas> m_attrDic = new Dictionary<uint, EquipSlotAttrDatas>();
	}
}
