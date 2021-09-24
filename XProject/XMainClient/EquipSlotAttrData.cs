using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSlotAttrData
	{

		public uint Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		public List<EquipAttrData> AttrDataList
		{
			get
			{
				return this.m_attrDataList;
			}
		}

		public EquipSlotAttrData(uint slot)
		{
			this.m_slot = slot;
			this.m_attrDataList = new List<EquipAttrData>();
		}

		public void Add(RandomAttributes.RowData row)
		{
			EquipAttrData equipAttrData = new EquipAttrData(row);
			int index;
			bool flag = this.FindIndex((uint)row.AttrID, out index);
			if (flag)
			{
				this.m_attrDataList[index] = equipAttrData;
			}
			else
			{
				this.m_attrDataList.Add(equipAttrData);
			}
		}

		public void Add(ForgeAttributes.RowData row)
		{
			EquipAttrData equipAttrData = new EquipAttrData(row);
			int index;
			bool flag = this.FindIndex((uint)row.AttrID, out index);
			if (flag)
			{
				this.m_attrDataList[index] = equipAttrData;
			}
			else
			{
				this.m_attrDataList.Add(equipAttrData);
			}
		}

		public EquipAttrData GetAttrData(uint attrId)
		{
			for (int i = 0; i < this.m_attrDataList.Count; i++)
			{
				bool flag = this.m_attrDataList[i].AttrId == attrId;
				if (flag)
				{
					return this.m_attrDataList[i];
				}
			}
			return null;
		}

		private bool FindIndex(uint attrId, out int index)
		{
			for (int i = 0; i < this.m_attrDataList.Count; i++)
			{
				bool flag = this.m_attrDataList[i].AttrId == attrId;
				if (flag)
				{
					index = i;
					return true;
				}
			}
			index = 0;
			return false;
		}

		private uint m_slot = 0U;

		private List<EquipAttrData> m_attrDataList;
	}
}
