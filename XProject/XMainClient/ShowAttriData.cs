using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ShowAttriData
	{

		public ShowAttriData(uint itemId, XItemChangeAttr attr)
		{
			this._itemId = itemId;
			this._nameId = attr.AttrID;
			this._num = attr.AttrValue;
			bool isPercentRange = this.IsPercentRange;
			if (isPercentRange)
			{
				this._typeId = 2U;
			}
			else
			{
				this._typeId = 1U;
			}
			this._data = XBagDocument.GetItemConf((int)itemId);
			bool flag = this._data != null;
			if (flag)
			{
				this._needLevel = (uint)this._data.ReqLevel;
			}
		}

		public ShowAttriData(EmblemBasic.RowData data)
		{
			this._itemId = data.EmblemID;
			this._typeId = 3U;
			this._data = XBagDocument.GetItemConf((int)data.EmblemID);
			bool flag = this._data != null;
			if (flag)
			{
				this._needLevel = (uint)this._data.ReqLevel;
			}
		}

		public void Add(uint num)
		{
			this._num += num;
		}

		public uint TypeID
		{
			get
			{
				return this._typeId;
			}
		}

		public string NeedLevelStr
		{
			get
			{
				return string.Format("[{0}]{1}[-] Lv{2}", XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)this._data.ItemQuality), XSingleton<UiUtility>.singleton.ChooseProfString(this._data.ItemName, (uint)this._data.Profession), this._needLevel);
			}
		}

		public bool IsPercentRange
		{
			get
			{
				return XAttributeCommon.IsPercentRange((int)this._nameId);
			}
		}

		public uint NameId
		{
			get
			{
				return this._nameId;
			}
		}

		public string Name
		{
			get
			{
				return XAttributeCommon.GetAttrStr((int)this._nameId);
			}
		}

		public string NumStr
		{
			get
			{
				bool flag = XAttributeCommon.IsPercentRange((int)this._nameId);
				string result;
				if (flag)
				{
					result = string.Format((this._num >= 0U) ? "+{0}%" : "{0}%", this._num.ToString("0.#"));
				}
				else
				{
					result = string.Format((this._num >= 0U) ? "+{0}" : "{0}", this._num).ToString();
				}
				return result;
			}
		}

		public string SkillDes
		{
			get
			{
				return XEmblemDocument.GetEmblemSkillAttrString(this._itemId);
			}
		}

		private uint _itemId;

		private uint _nameId;

		private uint _num;

		private uint _needLevel;

		private uint _typeId = 1U;

		private ItemList.RowData _data;
	}
}
