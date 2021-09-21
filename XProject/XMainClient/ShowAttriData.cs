using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BC3 RID: 3011
	internal class ShowAttriData
	{
		// Token: 0x0600AC00 RID: 44032 RVA: 0x001F964C File Offset: 0x001F784C
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

		// Token: 0x0600AC01 RID: 44033 RVA: 0x001F96CC File Offset: 0x001F78CC
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

		// Token: 0x0600AC02 RID: 44034 RVA: 0x001F972A File Offset: 0x001F792A
		public void Add(uint num)
		{
			this._num += num;
		}

		// Token: 0x1700306A RID: 12394
		// (get) Token: 0x0600AC03 RID: 44035 RVA: 0x001F973C File Offset: 0x001F793C
		public uint TypeID
		{
			get
			{
				return this._typeId;
			}
		}

		// Token: 0x1700306B RID: 12395
		// (get) Token: 0x0600AC04 RID: 44036 RVA: 0x001F9754 File Offset: 0x001F7954
		public string NeedLevelStr
		{
			get
			{
				return string.Format("[{0}]{1}[-] Lv{2}", XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)this._data.ItemQuality), XSingleton<UiUtility>.singleton.ChooseProfString(this._data.ItemName, (uint)this._data.Profession), this._needLevel);
			}
		}

		// Token: 0x1700306C RID: 12396
		// (get) Token: 0x0600AC05 RID: 44037 RVA: 0x001F97B0 File Offset: 0x001F79B0
		public bool IsPercentRange
		{
			get
			{
				return XAttributeCommon.IsPercentRange((int)this._nameId);
			}
		}

		// Token: 0x1700306D RID: 12397
		// (get) Token: 0x0600AC06 RID: 44038 RVA: 0x001F97D0 File Offset: 0x001F79D0
		public uint NameId
		{
			get
			{
				return this._nameId;
			}
		}

		// Token: 0x1700306E RID: 12398
		// (get) Token: 0x0600AC07 RID: 44039 RVA: 0x001F97E8 File Offset: 0x001F79E8
		public string Name
		{
			get
			{
				return XAttributeCommon.GetAttrStr((int)this._nameId);
			}
		}

		// Token: 0x1700306F RID: 12399
		// (get) Token: 0x0600AC08 RID: 44040 RVA: 0x001F9808 File Offset: 0x001F7A08
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

		// Token: 0x17003070 RID: 12400
		// (get) Token: 0x0600AC09 RID: 44041 RVA: 0x001F9884 File Offset: 0x001F7A84
		public string SkillDes
		{
			get
			{
				return XEmblemDocument.GetEmblemSkillAttrString(this._itemId);
			}
		}

		// Token: 0x040040A3 RID: 16547
		private uint _itemId;

		// Token: 0x040040A4 RID: 16548
		private uint _nameId;

		// Token: 0x040040A5 RID: 16549
		private uint _num;

		// Token: 0x040040A6 RID: 16550
		private uint _needLevel;

		// Token: 0x040040A7 RID: 16551
		private uint _typeId = 1U;

		// Token: 0x040040A8 RID: 16552
		private ItemList.RowData _data;
	}
}
