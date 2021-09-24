using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FashionStorageSuitEffect : FashionStorageTabBase, IFashionStorageSelect
	{

		public FashionStorageSuitEffect(FashionSuitSpecialEffects.RowData row)
		{
			this._rowData = row;
			this._suitEffectID = row.suitid;
			this._suitEffectName = row.Name;
			this.m_fashionList = row.FashionList;
		}

		public override string GetName()
		{
			return this._suitEffectName;
		}

		public override int GetID()
		{
			return (int)this._suitEffectID;
		}

		public override bool Active
		{
			get
			{
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				return specificDocument.isActivateEffect(this._suitEffectID);
			}
		}

		public override void Refresh()
		{
			this._activeAll = (this.GetFashionList().Length == this.GetItems().Count);
		}

		public override bool RedPoint
		{
			get
			{
				return !this.Active && this._activeAll;
			}
		}

		private FashionSuitSpecialEffects.RowData _rowData;

		private uint _suitEffectID = 0U;

		private string _suitEffectName;

		private bool _activeAll = false;
	}
}
