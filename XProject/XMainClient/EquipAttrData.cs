using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipAttrData
	{

		public uint Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		public uint AttrId
		{
			get
			{
				return this.m_attrId;
			}
		}

		public bool IsCanSmelt
		{
			get
			{
				return this.m_isCanSmelt;
			}
		}

		public uint Prob
		{
			get
			{
				return this.m_prob;
			}
		}

		public EquipAttrRange RangValue
		{
			get
			{
				return this.m_rang;
			}
		}

		public EquipAttrData(RandomAttributes.RowData row)
		{
			this.m_slot = (uint)row.Slot;
			this.m_attrId = (uint)row.AttrID;
			this.m_prob = (uint)row.Prob;
			this.m_isCanSmelt = (row.CanSmelt == 1);
			this.m_rang = new EquipAttrRange(row.Range);
		}

		public EquipAttrData(ForgeAttributes.RowData row)
		{
			this.m_slot = (uint)row.Slot;
			this.m_attrId = (uint)row.AttrID;
			this.m_prob = (uint)row.Prob;
			this.m_isCanSmelt = (row.CanSmelt == 1);
			this.m_rang = new EquipAttrRange(row.Range);
		}

		public double GetPercentValue(uint attrValue)
		{
			float num = (this.m_rang.D_value == 0f) ? 1f : this.m_rang.D_value;
			bool flag = attrValue < this.m_rang.Max;
			double num2;
			if (flag)
			{
				num2 = (double)((attrValue - this.m_rang.Min) * 100f / num);
			}
			else
			{
				num2 = 100.0;
			}
			return num2 / 100.0;
		}

		public string GetColor(uint attrValue)
		{
			float num = (this.m_rang.D_value == 0f) ? 1f : this.m_rang.D_value;
			bool flag = attrValue != this.m_rang.Max;
			float num2;
			if (flag)
			{
				num2 = (attrValue - this.m_rang.Min) * 100f / num;
			}
			else
			{
				num2 = 100f;
			}
			int quality = EquipAttrDataMgr.MarkList.Count - 1;
			for (int i = 0; i < EquipAttrDataMgr.MarkList.Count; i++)
			{
				bool flag2 = num2 < (float)EquipAttrDataMgr.MarkList[i];
				if (flag2)
				{
					quality = i;
					break;
				}
			}
			return XSingleton<UiUtility>.singleton.GetItemQualityRGB(quality);
		}

		private uint m_slot = 0U;

		private uint m_attrId = 0U;

		private uint m_prob = 0U;

		private bool m_isCanSmelt = false;

		private EquipAttrRange m_rang;
	}
}
