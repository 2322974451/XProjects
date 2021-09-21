using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FB RID: 1531
	[ProtoContract(Name = "ShopRecordOne")]
	[Serializable]
	public class ShopRecordOne : IExtensible
	{
		// Token: 0x17001C82 RID: 7298
		// (get) Token: 0x06005B29 RID: 23337 RVA: 0x000AD964 File Offset: 0x000ABB64
		// (set) Token: 0x06005B2A RID: 23338 RVA: 0x000AD990 File Offset: 0x000ABB90
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17001C83 RID: 7299
		// (get) Token: 0x06005B2B RID: 23339 RVA: 0x000AD9A0 File Offset: 0x000ABBA0
		// (set) Token: 0x06005B2C RID: 23340 RVA: 0x000AD9C0 File Offset: 0x000ABBC0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06005B2D RID: 23341 RVA: 0x000ADA04 File Offset: 0x000ABC04
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06005B2E RID: 23342 RVA: 0x000ADA1C File Offset: 0x000ABC1C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001C84 RID: 7300
		// (get) Token: 0x06005B2F RID: 23343 RVA: 0x000ADA28 File Offset: 0x000ABC28
		// (set) Token: 0x06005B30 RID: 23344 RVA: 0x000ADA54 File Offset: 0x000ABC54
		[ProtoMember(2, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		// Token: 0x17001C85 RID: 7301
		// (get) Token: 0x06005B31 RID: 23345 RVA: 0x000ADA64 File Offset: 0x000ABC64
		// (set) Token: 0x06005B32 RID: 23346 RVA: 0x000ADA84 File Offset: 0x000ABC84
		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		// Token: 0x06005B33 RID: 23347 RVA: 0x000ADAC8 File Offset: 0x000ABCC8
		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		// Token: 0x06005B34 RID: 23348 RVA: 0x000ADAE0 File Offset: 0x000ABCE0
		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		// Token: 0x17001C86 RID: 7302
		// (get) Token: 0x06005B35 RID: 23349 RVA: 0x000ADAEC File Offset: 0x000ABCEC
		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<Item> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001C87 RID: 7303
		// (get) Token: 0x06005B36 RID: 23350 RVA: 0x000ADB04 File Offset: 0x000ABD04
		[ProtoMember(4, Name = "slots", DataFormat = DataFormat.TwosComplement)]
		public List<uint> slots
		{
			get
			{
				return this._slots;
			}
		}

		// Token: 0x17001C88 RID: 7304
		// (get) Token: 0x06005B37 RID: 23351 RVA: 0x000ADB1C File Offset: 0x000ABD1C
		[ProtoMember(5, Name = "buycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> buycount
		{
			get
			{
				return this._buycount;
			}
		}

		// Token: 0x17001C89 RID: 7305
		// (get) Token: 0x06005B38 RID: 23352 RVA: 0x000ADB34 File Offset: 0x000ABD34
		[ProtoMember(6, Name = "dailybuycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dailybuycount
		{
			get
			{
				return this._dailybuycount;
			}
		}

		// Token: 0x17001C8A RID: 7306
		// (get) Token: 0x06005B39 RID: 23353 RVA: 0x000ADB4C File Offset: 0x000ABD4C
		// (set) Token: 0x06005B3A RID: 23354 RVA: 0x000ADB78 File Offset: 0x000ABD78
		[ProtoMember(7, IsRequired = false, Name = "refreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint refreshcount
		{
			get
			{
				return this._refreshcount ?? 0U;
			}
			set
			{
				this._refreshcount = new uint?(value);
			}
		}

		// Token: 0x17001C8B RID: 7307
		// (get) Token: 0x06005B3B RID: 23355 RVA: 0x000ADB88 File Offset: 0x000ABD88
		// (set) Token: 0x06005B3C RID: 23356 RVA: 0x000ADBA8 File Offset: 0x000ABDA8
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshcountSpecified
		{
			get
			{
				return this._refreshcount != null;
			}
			set
			{
				bool flag = value == (this._refreshcount == null);
				if (flag)
				{
					this._refreshcount = (value ? new uint?(this.refreshcount) : null);
				}
			}
		}

		// Token: 0x06005B3D RID: 23357 RVA: 0x000ADBEC File Offset: 0x000ABDEC
		private bool ShouldSerializerefreshcount()
		{
			return this.refreshcountSpecified;
		}

		// Token: 0x06005B3E RID: 23358 RVA: 0x000ADC04 File Offset: 0x000ABE04
		private void Resetrefreshcount()
		{
			this.refreshcountSpecified = false;
		}

		// Token: 0x17001C8C RID: 7308
		// (get) Token: 0x06005B3F RID: 23359 RVA: 0x000ADC10 File Offset: 0x000ABE10
		// (set) Token: 0x06005B40 RID: 23360 RVA: 0x000ADC3C File Offset: 0x000ABE3C
		[ProtoMember(8, IsRequired = false, Name = "refreshtime", DataFormat = DataFormat.TwosComplement)]
		public uint refreshtime
		{
			get
			{
				return this._refreshtime ?? 0U;
			}
			set
			{
				this._refreshtime = new uint?(value);
			}
		}

		// Token: 0x17001C8D RID: 7309
		// (get) Token: 0x06005B41 RID: 23361 RVA: 0x000ADC4C File Offset: 0x000ABE4C
		// (set) Token: 0x06005B42 RID: 23362 RVA: 0x000ADC6C File Offset: 0x000ABE6C
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshtimeSpecified
		{
			get
			{
				return this._refreshtime != null;
			}
			set
			{
				bool flag = value == (this._refreshtime == null);
				if (flag)
				{
					this._refreshtime = (value ? new uint?(this.refreshtime) : null);
				}
			}
		}

		// Token: 0x06005B43 RID: 23363 RVA: 0x000ADCB0 File Offset: 0x000ABEB0
		private bool ShouldSerializerefreshtime()
		{
			return this.refreshtimeSpecified;
		}

		// Token: 0x06005B44 RID: 23364 RVA: 0x000ADCC8 File Offset: 0x000ABEC8
		private void Resetrefreshtime()
		{
			this.refreshtimeSpecified = false;
		}

		// Token: 0x17001C8E RID: 7310
		// (get) Token: 0x06005B45 RID: 23365 RVA: 0x000ADCD4 File Offset: 0x000ABED4
		// (set) Token: 0x06005B46 RID: 23366 RVA: 0x000ADD00 File Offset: 0x000ABF00
		[ProtoMember(9, IsRequired = false, Name = "refreshday", DataFormat = DataFormat.TwosComplement)]
		public uint refreshday
		{
			get
			{
				return this._refreshday ?? 0U;
			}
			set
			{
				this._refreshday = new uint?(value);
			}
		}

		// Token: 0x17001C8F RID: 7311
		// (get) Token: 0x06005B47 RID: 23367 RVA: 0x000ADD10 File Offset: 0x000ABF10
		// (set) Token: 0x06005B48 RID: 23368 RVA: 0x000ADD30 File Offset: 0x000ABF30
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshdaySpecified
		{
			get
			{
				return this._refreshday != null;
			}
			set
			{
				bool flag = value == (this._refreshday == null);
				if (flag)
				{
					this._refreshday = (value ? new uint?(this.refreshday) : null);
				}
			}
		}

		// Token: 0x06005B49 RID: 23369 RVA: 0x000ADD74 File Offset: 0x000ABF74
		private bool ShouldSerializerefreshday()
		{
			return this.refreshdaySpecified;
		}

		// Token: 0x06005B4A RID: 23370 RVA: 0x000ADD8C File Offset: 0x000ABF8C
		private void Resetrefreshday()
		{
			this.refreshdaySpecified = false;
		}

		// Token: 0x17001C90 RID: 7312
		// (get) Token: 0x06005B4B RID: 23371 RVA: 0x000ADD98 File Offset: 0x000ABF98
		// (set) Token: 0x06005B4C RID: 23372 RVA: 0x000ADDC4 File Offset: 0x000ABFC4
		[ProtoMember(10, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		// Token: 0x17001C91 RID: 7313
		// (get) Token: 0x06005B4D RID: 23373 RVA: 0x000ADDD4 File Offset: 0x000ABFD4
		// (set) Token: 0x06005B4E RID: 23374 RVA: 0x000ADDF4 File Offset: 0x000ABFF4
		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x000ADE38 File Offset: 0x000AC038
		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		// Token: 0x06005B50 RID: 23376 RVA: 0x000ADE50 File Offset: 0x000AC050
		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		// Token: 0x17001C92 RID: 7314
		// (get) Token: 0x06005B51 RID: 23377 RVA: 0x000ADE5C File Offset: 0x000AC05C
		[ProtoMember(11, Name = "weekbuycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> weekbuycount
		{
			get
			{
				return this._weekbuycount;
			}
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x000ADE74 File Offset: 0x000AC074
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400162E RID: 5678
		private uint? _type;

		// Token: 0x0400162F RID: 5679
		private uint? _updatetime;

		// Token: 0x04001630 RID: 5680
		private readonly List<Item> _items = new List<Item>();

		// Token: 0x04001631 RID: 5681
		private readonly List<uint> _slots = new List<uint>();

		// Token: 0x04001632 RID: 5682
		private readonly List<ItemBrief> _buycount = new List<ItemBrief>();

		// Token: 0x04001633 RID: 5683
		private readonly List<ItemBrief> _dailybuycount = new List<ItemBrief>();

		// Token: 0x04001634 RID: 5684
		private uint? _refreshcount;

		// Token: 0x04001635 RID: 5685
		private uint? _refreshtime;

		// Token: 0x04001636 RID: 5686
		private uint? _refreshday;

		// Token: 0x04001637 RID: 5687
		private bool? _ishint;

		// Token: 0x04001638 RID: 5688
		private readonly List<ItemBrief> _weekbuycount = new List<ItemBrief>();

		// Token: 0x04001639 RID: 5689
		private IExtension extensionObject;
	}
}
