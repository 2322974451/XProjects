using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008DC RID: 2268
	internal class FashionStorageEquipCollection : FashionStorageTabBase
	{
		// Token: 0x0600898B RID: 35211 RVA: 0x001210F8 File Offset: 0x0011F2F8
		public FashionStorageEquipCollection(int suitID)
		{
			this.m_equipSuit = XCharacterEquipDocument.SuitManager.GetSuitBySuitId(suitID);
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			bool flag = this.m_doc.TryGetFashionChaim((uint)suitID, out this.m_charm);
			if (flag)
			{
				this.m_fashionList = this.m_charm.SuitParam;
				this.m_attributeCharms = new List<AttributeCharm>();
				this.InsertAttributeCharm(1, this.m_charm.Effect1);
				this.InsertAttributeCharm(2, this.m_charm.Effect2);
				this.InsertAttributeCharm(3, this.m_charm.Effect3);
				this.InsertAttributeCharm(4, this.m_charm.Effect4);
				this.InsertAttributeCharm(5, this.m_charm.Effect5);
				this.InsertAttributeCharm(6, this.m_charm.Effect6);
				this.InsertAttributeCharm(7, this.m_charm.Effect7);
			}
		}

		// Token: 0x17002ADE RID: 10974
		// (get) Token: 0x0600898C RID: 35212 RVA: 0x001211F8 File Offset: 0x0011F3F8
		public override bool Active
		{
			get
			{
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || this.m_charm == null;
				return !flag && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this.m_charm.Level;
			}
		}

		// Token: 0x0600898D RID: 35213 RVA: 0x0012124C File Offset: 0x0011F44C
		private void InsertAttributeCharm(int index, SeqListRef<uint> list)
		{
			bool flag = list.count == 0;
			if (!flag)
			{
				int i = 0;
				int count = (int)list.count;
				while (i < count)
				{
					AttributeCharm attributeCharm = new AttributeCharm();
					attributeCharm.index = index;
					attributeCharm.key = list[i, 0];
					attributeCharm.value = list[i, 1];
					attributeCharm.active = false;
					this.m_attributeCharms.Add(attributeCharm);
					i++;
				}
			}
		}

		// Token: 0x0600898E RID: 35214 RVA: 0x001212C4 File Offset: 0x0011F4C4
		public override void Refresh()
		{
			this.m_redPoint = false;
			int i = 0;
			int count = this.m_attributeCharms.Count;
			while (i < count)
			{
				AttributeCharm attributeCharm = this.m_attributeCharms[i];
				bool flag = (long)attributeCharm.index <= (long)((ulong)this.m_activateCount);
				if (flag)
				{
					attributeCharm.active = true;
				}
				else
				{
					attributeCharm.active = false;
					bool flag2 = !this.m_redPoint;
					if (flag2)
					{
						this.m_redPoint = (attributeCharm.index <= this.GetCount());
					}
				}
				i++;
			}
		}

		// Token: 0x17002ADF RID: 10975
		// (get) Token: 0x0600898F RID: 35215 RVA: 0x00121358 File Offset: 0x0011F558
		public override bool ActivateAll
		{
			get
			{
				return (long)this.GetFashionList().Length == (long)((ulong)this.m_activateCount);
			}
		}

		// Token: 0x06008990 RID: 35216 RVA: 0x0012137C File Offset: 0x0011F57C
		public override List<AttributeCharm> GetAttributeCharm()
		{
			return this.m_attributeCharms;
		}

		// Token: 0x06008991 RID: 35217 RVA: 0x00121394 File Offset: 0x0011F594
		public override int GetID()
		{
			bool flag = this.m_equipSuit != null;
			int result;
			if (flag)
			{
				result = this.m_equipSuit.SuitID;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06008992 RID: 35218 RVA: 0x001213C4 File Offset: 0x0011F5C4
		public override int GetCount()
		{
			return this.GetItems().Count;
		}

		// Token: 0x17002AE0 RID: 10976
		// (get) Token: 0x06008993 RID: 35219 RVA: 0x001213E4 File Offset: 0x0011F5E4
		public override bool RedPoint
		{
			get
			{
				return this.m_redPoint;
			}
		}

		// Token: 0x06008994 RID: 35220 RVA: 0x001213FC File Offset: 0x0011F5FC
		public override void SetCount(uint count)
		{
			this.m_activateCount = count;
		}

		// Token: 0x06008995 RID: 35221 RVA: 0x00121408 File Offset: 0x0011F608
		public override string GetName()
		{
			bool flag = this.GetItems().Count == this.GetFashionList().Length;
			string result;
			if (flag)
			{
				result = this.m_equipSuit.SuitName;
			}
			else
			{
				result = string.Format("{0}({1}/{2})", this.m_equipSuit.SuitName, this.GetItems().Count, this.GetFashionList().Length);
			}
			return result;
		}

		// Token: 0x04002BA0 RID: 11168
		private XFashionStorageDocument m_doc;

		// Token: 0x04002BA1 RID: 11169
		private EquipSuitTable.RowData m_equipSuit;

		// Token: 0x04002BA2 RID: 11170
		private List<AttributeCharm> m_attributeCharms;

		// Token: 0x04002BA3 RID: 11171
		private FashionCharm.RowData m_charm;

		// Token: 0x04002BA4 RID: 11172
		private bool m_redPoint = false;

		// Token: 0x04002BA5 RID: 11173
		private uint m_activateCount = 0U;
	}
}
