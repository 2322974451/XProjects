using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E6 RID: 2278
	internal class EquipAttrData
	{
		// Token: 0x17002AEC RID: 10988
		// (get) Token: 0x060089D2 RID: 35282 RVA: 0x001222C0 File Offset: 0x001204C0
		public uint Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		// Token: 0x17002AED RID: 10989
		// (get) Token: 0x060089D3 RID: 35283 RVA: 0x001222D8 File Offset: 0x001204D8
		public uint AttrId
		{
			get
			{
				return this.m_attrId;
			}
		}

		// Token: 0x17002AEE RID: 10990
		// (get) Token: 0x060089D4 RID: 35284 RVA: 0x001222F0 File Offset: 0x001204F0
		public bool IsCanSmelt
		{
			get
			{
				return this.m_isCanSmelt;
			}
		}

		// Token: 0x17002AEF RID: 10991
		// (get) Token: 0x060089D5 RID: 35285 RVA: 0x00122308 File Offset: 0x00120508
		public uint Prob
		{
			get
			{
				return this.m_prob;
			}
		}

		// Token: 0x17002AF0 RID: 10992
		// (get) Token: 0x060089D6 RID: 35286 RVA: 0x00122320 File Offset: 0x00120520
		public EquipAttrRange RangValue
		{
			get
			{
				return this.m_rang;
			}
		}

		// Token: 0x060089D7 RID: 35287 RVA: 0x00122338 File Offset: 0x00120538
		public EquipAttrData(RandomAttributes.RowData row)
		{
			this.m_slot = (uint)row.Slot;
			this.m_attrId = (uint)row.AttrID;
			this.m_prob = (uint)row.Prob;
			this.m_isCanSmelt = (row.CanSmelt == 1);
			this.m_rang = new EquipAttrRange(row.Range);
		}

		// Token: 0x060089D8 RID: 35288 RVA: 0x001223B0 File Offset: 0x001205B0
		public EquipAttrData(ForgeAttributes.RowData row)
		{
			this.m_slot = (uint)row.Slot;
			this.m_attrId = (uint)row.AttrID;
			this.m_prob = (uint)row.Prob;
			this.m_isCanSmelt = (row.CanSmelt == 1);
			this.m_rang = new EquipAttrRange(row.Range);
		}

		// Token: 0x060089D9 RID: 35289 RVA: 0x00122428 File Offset: 0x00120628
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

		// Token: 0x060089DA RID: 35290 RVA: 0x001224B0 File Offset: 0x001206B0
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

		// Token: 0x04002BBD RID: 11197
		private uint m_slot = 0U;

		// Token: 0x04002BBE RID: 11198
		private uint m_attrId = 0U;

		// Token: 0x04002BBF RID: 11199
		private uint m_prob = 0U;

		// Token: 0x04002BC0 RID: 11200
		private bool m_isCanSmelt = false;

		// Token: 0x04002BC1 RID: 11201
		private EquipAttrRange m_rang;
	}
}
