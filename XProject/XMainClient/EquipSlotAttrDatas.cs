using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E4 RID: 2276
	internal class EquipSlotAttrDatas
	{
		// Token: 0x17002AE9 RID: 10985
		// (get) Token: 0x060089C0 RID: 35264 RVA: 0x00121C5C File Offset: 0x0011FE5C
		public uint EquipId
		{
			get
			{
				return this.m_equipId;
			}
		}

		// Token: 0x060089C1 RID: 35265 RVA: 0x00121C74 File Offset: 0x0011FE74
		public EquipSlotAttrDatas(uint equipId)
		{
			this.m_equipId = equipId;
			this.m_slotDataList = new List<EquipSlotAttrData>();
		}

		// Token: 0x060089C2 RID: 35266 RVA: 0x00121C98 File Offset: 0x0011FE98
		public void Add(RandomAttributes.RowData row)
		{
			for (int i = 0; i < this.m_slotDataList.Count; i++)
			{
				bool flag = this.m_slotDataList[i].Slot == (uint)row.Slot;
				if (flag)
				{
					this.m_slotDataList[i].Add(row);
					return;
				}
			}
			EquipSlotAttrData equipSlotAttrData = new EquipSlotAttrData((uint)row.Slot);
			equipSlotAttrData.Add(row);
			this.m_slotDataList.Add(equipSlotAttrData);
		}

		// Token: 0x060089C3 RID: 35267 RVA: 0x00121D18 File Offset: 0x0011FF18
		public void Add(ForgeAttributes.RowData row)
		{
			for (int i = 0; i < this.m_slotDataList.Count; i++)
			{
				bool flag = this.m_slotDataList[i].Slot == (uint)row.Slot;
				if (flag)
				{
					this.m_slotDataList[i].Add(row);
					return;
				}
			}
			EquipSlotAttrData equipSlotAttrData = new EquipSlotAttrData((uint)row.Slot);
			equipSlotAttrData.Add(row);
			this.m_slotDataList.Add(equipSlotAttrData);
		}

		// Token: 0x060089C4 RID: 35268 RVA: 0x00121D98 File Offset: 0x0011FF98
		public EquipAttrData GetAttrData(int slot, XItemChangeAttr attr)
		{
			return this.GetAttrData(slot, attr.AttrID);
		}

		// Token: 0x060089C5 RID: 35269 RVA: 0x00121DB8 File Offset: 0x0011FFB8
		public EquipAttrData GetAttrData(int slot, uint attrid)
		{
			for (int i = 0; i < this.m_slotDataList.Count; i++)
			{
				bool flag = (ulong)this.m_slotDataList[i].Slot == (ulong)((long)slot);
				if (flag)
				{
					return this.m_slotDataList[i].GetAttrData(attrid);
				}
			}
			return null;
		}

		// Token: 0x060089C6 RID: 35270 RVA: 0x00121E18 File Offset: 0x00120018
		public double GetPercentValue(int slot, XItemChangeAttr attr)
		{
			EquipAttrData attrData = this.GetAttrData(slot, attr);
			bool flag = attrData == null;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				result = attrData.GetPercentValue(attr.AttrValue);
			}
			return result;
		}

		// Token: 0x060089C7 RID: 35271 RVA: 0x00121E54 File Offset: 0x00120054
		public string GetColor(int slot, XItemChangeAttr attr)
		{
			EquipAttrData attrData = this.GetAttrData(slot, attr);
			bool flag = attrData == null;
			string result;
			if (flag)
			{
				result = XSingleton<UiUtility>.singleton.GetItemQualityRGB(0);
			}
			else
			{
				result = attrData.GetColor(attr.AttrValue);
			}
			return result;
		}

		// Token: 0x060089C8 RID: 35272 RVA: 0x00121E94 File Offset: 0x00120094
		public EquipSlotAttrData GetAttrData(int slot)
		{
			for (int i = 0; i < this.m_slotDataList.Count; i++)
			{
				bool flag = (ulong)this.m_slotDataList[i].Slot == (ulong)((long)slot);
				if (flag)
				{
					return this.m_slotDataList[i];
				}
			}
			return null;
		}

		// Token: 0x060089C9 RID: 35273 RVA: 0x00121EF0 File Offset: 0x001200F0
		public static uint GetMinPPT(EquipSlotAttrDatas data, XAttributes attributes, bool isForge)
		{
			uint num = 0U;
			bool flag = !isForge;
			if (flag)
			{
				for (int i = 0; i < data.m_slotDataList.Count; i++)
				{
					uint num2 = uint.MaxValue;
					EquipSlotAttrData equipSlotAttrData = data.m_slotDataList[i];
					for (int j = 0; j < equipSlotAttrData.AttrDataList.Count; j++)
					{
						EquipAttrData equipAttrData = equipSlotAttrData.AttrDataList[j];
						bool flag2 = equipAttrData.RangValue.Prob == 0U;
						if (!flag2)
						{
							num2 = Math.Min(num2, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(equipAttrData.AttrId, (double)equipAttrData.RangValue.Min, attributes, -1));
						}
					}
					bool flag3 = num2 == uint.MaxValue;
					if (flag3)
					{
						num2 = 0U;
					}
					num += num2;
				}
			}
			else
			{
				bool flag4 = data.m_slotDataList.Count == 0;
				if (flag4)
				{
				}
				num = uint.MaxValue;
				EquipSlotAttrData equipSlotAttrData2 = data.m_slotDataList[0];
				for (int k = 0; k < equipSlotAttrData2.AttrDataList.Count; k++)
				{
					EquipAttrData equipAttrData2 = equipSlotAttrData2.AttrDataList[k];
					bool flag5 = equipAttrData2.RangValue.Prob == 0U;
					if (!flag5)
					{
						num = Math.Min(num, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(equipAttrData2.AttrId, (double)equipAttrData2.RangValue.Min, attributes, -1));
					}
				}
				bool flag6 = num == uint.MaxValue;
				if (flag6)
				{
					num = 0U;
				}
			}
			return num;
		}

		// Token: 0x060089CA RID: 35274 RVA: 0x00122078 File Offset: 0x00120278
		public static uint GetMaxPPT(EquipSlotAttrDatas data, XAttributes attributes)
		{
			uint num = 0U;
			for (int i = 0; i < data.m_slotDataList.Count; i++)
			{
				uint num2 = 0U;
				EquipSlotAttrData equipSlotAttrData = data.m_slotDataList[i];
				for (int j = 0; j < equipSlotAttrData.AttrDataList.Count; j++)
				{
					EquipAttrData equipAttrData = equipSlotAttrData.AttrDataList[j];
					bool flag = equipAttrData.RangValue.Prob == 0U;
					if (!flag)
					{
						num2 = Math.Max(num2, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(equipAttrData.AttrId, (double)equipAttrData.RangValue.Max, attributes, -1));
					}
				}
				num += num2;
			}
			return num;
		}

		// Token: 0x04002BB9 RID: 11193
		private uint m_equipId = 0U;

		// Token: 0x04002BBA RID: 11194
		private List<EquipSlotAttrData> m_slotDataList;
	}
}
