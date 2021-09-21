using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D9 RID: 2265
	internal class FashionStorageSuitEffect : FashionStorageTabBase, IFashionStorageSelect
	{
		// Token: 0x06008974 RID: 35188 RVA: 0x00120EFC File Offset: 0x0011F0FC
		public FashionStorageSuitEffect(FashionSuitSpecialEffects.RowData row)
		{
			this._rowData = row;
			this._suitEffectID = row.suitid;
			this._suitEffectName = row.Name;
			this.m_fashionList = row.FashionList;
		}

		// Token: 0x06008975 RID: 35189 RVA: 0x00120F4C File Offset: 0x0011F14C
		public override string GetName()
		{
			return this._suitEffectName;
		}

		// Token: 0x06008976 RID: 35190 RVA: 0x00120F64 File Offset: 0x0011F164
		public override int GetID()
		{
			return (int)this._suitEffectID;
		}

		// Token: 0x17002AD8 RID: 10968
		// (get) Token: 0x06008977 RID: 35191 RVA: 0x00120F7C File Offset: 0x0011F17C
		public override bool Active
		{
			get
			{
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				return specificDocument.isActivateEffect(this._suitEffectID);
			}
		}

		// Token: 0x06008978 RID: 35192 RVA: 0x00120FA5 File Offset: 0x0011F1A5
		public override void Refresh()
		{
			this._activeAll = (this.GetFashionList().Length == this.GetItems().Count);
		}

		// Token: 0x17002AD9 RID: 10969
		// (get) Token: 0x06008979 RID: 35193 RVA: 0x00120FC4 File Offset: 0x0011F1C4
		public override bool RedPoint
		{
			get
			{
				return !this.Active && this._activeAll;
			}
		}

		// Token: 0x04002B9A RID: 11162
		private FashionSuitSpecialEffects.RowData _rowData;

		// Token: 0x04002B9B RID: 11163
		private uint _suitEffectID = 0U;

		// Token: 0x04002B9C RID: 11164
		private string _suitEffectName;

		// Token: 0x04002B9D RID: 11165
		private bool _activeAll = false;
	}
}
