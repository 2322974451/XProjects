using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008DE RID: 2270
	internal class FashionStorageFashionCollection : FashionStorageTabBase
	{
		// Token: 0x06008997 RID: 35223 RVA: 0x00121474 File Offset: 0x0011F674
		public FashionStorageFashionCollection(int suitID)
		{
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			this.m_fashionSuit = specificDocument.GetSuitData(suitID);
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

		// Token: 0x17002AE1 RID: 10977
		// (get) Token: 0x06008998 RID: 35224 RVA: 0x0012157C File Offset: 0x0011F77C
		public override bool Active
		{
			get
			{
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || this.m_charm == null;
				return !flag && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this.m_charm.Level;
			}
		}

		// Token: 0x17002AE2 RID: 10978
		// (get) Token: 0x06008999 RID: 35225 RVA: 0x001215D0 File Offset: 0x0011F7D0
		public override bool ActivateAll
		{
			get
			{
				return (long)this.GetFashionList().Length == (long)((ulong)this.m_activateCount);
			}
		}

		// Token: 0x0600899A RID: 35226 RVA: 0x001215F4 File Offset: 0x0011F7F4
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

		// Token: 0x0600899B RID: 35227 RVA: 0x0012166C File Offset: 0x0011F86C
		public override List<AttributeCharm> GetAttributeCharm()
		{
			return this.m_attributeCharms;
		}

		// Token: 0x0600899C RID: 35228 RVA: 0x00121684 File Offset: 0x0011F884
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

		// Token: 0x17002AE3 RID: 10979
		// (get) Token: 0x0600899D RID: 35229 RVA: 0x00121718 File Offset: 0x0011F918
		public override bool RedPoint
		{
			get
			{
				return this.m_redPoint;
			}
		}

		// Token: 0x0600899E RID: 35230 RVA: 0x00121730 File Offset: 0x0011F930
		public override int GetCount()
		{
			return this.GetItems().Count;
		}

		// Token: 0x0600899F RID: 35231 RVA: 0x00121750 File Offset: 0x0011F950
		public override int GetID()
		{
			return this.m_fashionSuit.SuitID;
		}

		// Token: 0x060089A0 RID: 35232 RVA: 0x0012176D File Offset: 0x0011F96D
		public override void SetCount(uint count)
		{
			this.m_activateCount = count;
		}

		// Token: 0x060089A1 RID: 35233 RVA: 0x00121778 File Offset: 0x0011F978
		public override string GetName()
		{
			bool flag = this.GetItems().Count == this.GetFashionList().Length;
			string result;
			if (flag)
			{
				result = this.m_fashionSuit.SuitName;
			}
			else
			{
				result = string.Format("{0}({1}/{2})", this.m_fashionSuit.SuitName, this.GetItems().Count, this.GetFashionList().Length);
			}
			return result;
		}

		// Token: 0x04002BAA RID: 11178
		private XFashionStorageDocument m_doc;

		// Token: 0x04002BAB RID: 11179
		private FashionSuitTable.RowData m_fashionSuit;

		// Token: 0x04002BAC RID: 11180
		private List<AttributeCharm> m_attributeCharms;

		// Token: 0x04002BAD RID: 11181
		private FashionCharm.RowData m_charm;

		// Token: 0x04002BAE RID: 11182
		private bool m_redPoint = false;

		// Token: 0x04002BAF RID: 11183
		private uint m_activateCount = 0U;
	}
}
