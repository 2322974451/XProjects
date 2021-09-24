using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSlotAttrDatas
	{

		public uint EquipId
		{
			get
			{
				return this.m_equipId;
			}
		}

		public EquipSlotAttrDatas(uint equipId)
		{
			this.m_equipId = equipId;
			this.m_slotDataList = new List<EquipSlotAttrData>();
		}

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

		public EquipAttrData GetAttrData(int slot, XItemChangeAttr attr)
		{
			return this.GetAttrData(slot, attr.AttrID);
		}

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

		private uint m_equipId = 0U;

		private List<EquipSlotAttrData> m_slotDataList;
	}
}
