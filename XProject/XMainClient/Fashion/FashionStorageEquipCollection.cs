using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FashionStorageEquipCollection : FashionStorageTabBase
	{

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

		public override bool Active
		{
			get
			{
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || this.m_charm == null;
				return !flag && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this.m_charm.Level;
			}
		}

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

		public override bool ActivateAll
		{
			get
			{
				return (long)this.GetFashionList().Length == (long)((ulong)this.m_activateCount);
			}
		}

		public override List<AttributeCharm> GetAttributeCharm()
		{
			return this.m_attributeCharms;
		}

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

		public override int GetCount()
		{
			return this.GetItems().Count;
		}

		public override bool RedPoint
		{
			get
			{
				return this.m_redPoint;
			}
		}

		public override void SetCount(uint count)
		{
			this.m_activateCount = count;
		}

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

		private XFashionStorageDocument m_doc;

		private EquipSuitTable.RowData m_equipSuit;

		private List<AttributeCharm> m_attributeCharms;

		private FashionCharm.RowData m_charm;

		private bool m_redPoint = false;

		private uint m_activateCount = 0U;
	}
}
