using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E5 RID: 2277
	internal class EquipSlotAttrData
	{
		// Token: 0x17002AEA RID: 10986
		// (get) Token: 0x060089CB RID: 35275 RVA: 0x00122138 File Offset: 0x00120338
		public uint Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		// Token: 0x17002AEB RID: 10987
		// (get) Token: 0x060089CC RID: 35276 RVA: 0x00122150 File Offset: 0x00120350
		public List<EquipAttrData> AttrDataList
		{
			get
			{
				return this.m_attrDataList;
			}
		}

		// Token: 0x060089CD RID: 35277 RVA: 0x00122168 File Offset: 0x00120368
		public EquipSlotAttrData(uint slot)
		{
			this.m_slot = slot;
			this.m_attrDataList = new List<EquipAttrData>();
		}

		// Token: 0x060089CE RID: 35278 RVA: 0x0012218C File Offset: 0x0012038C
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

		// Token: 0x060089CF RID: 35279 RVA: 0x001221D0 File Offset: 0x001203D0
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

		// Token: 0x060089D0 RID: 35280 RVA: 0x00122214 File Offset: 0x00120414
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

		// Token: 0x060089D1 RID: 35281 RVA: 0x0012226C File Offset: 0x0012046C
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

		// Token: 0x04002BBB RID: 11195
		private uint m_slot = 0U;

		// Token: 0x04002BBC RID: 11196
		private List<EquipAttrData> m_attrDataList;
	}
}
