using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E2 RID: 1506
	[ProtoContract(Name = "SMail")]
	[Serializable]
	public class SMail : IExtensible
	{
		// Token: 0x17001B0F RID: 6927
		// (get) Token: 0x06005723 RID: 22307 RVA: 0x000A5F48 File Offset: 0x000A4148
		// (set) Token: 0x06005724 RID: 22308 RVA: 0x000A5F75 File Offset: 0x000A4175
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17001B10 RID: 6928
		// (get) Token: 0x06005725 RID: 22309 RVA: 0x000A5F84 File Offset: 0x000A4184
		// (set) Token: 0x06005726 RID: 22310 RVA: 0x000A5FA4 File Offset: 0x000A41A4
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06005727 RID: 22311 RVA: 0x000A5FE8 File Offset: 0x000A41E8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06005728 RID: 22312 RVA: 0x000A6000 File Offset: 0x000A4200
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001B11 RID: 6929
		// (get) Token: 0x06005729 RID: 22313 RVA: 0x000A600C File Offset: 0x000A420C
		// (set) Token: 0x0600572A RID: 22314 RVA: 0x000A6038 File Offset: 0x000A4238
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001B12 RID: 6930
		// (get) Token: 0x0600572B RID: 22315 RVA: 0x000A6048 File Offset: 0x000A4248
		// (set) Token: 0x0600572C RID: 22316 RVA: 0x000A6068 File Offset: 0x000A4268
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

		// Token: 0x0600572D RID: 22317 RVA: 0x000A60AC File Offset: 0x000A42AC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600572E RID: 22318 RVA: 0x000A60C4 File Offset: 0x000A42C4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001B13 RID: 6931
		// (get) Token: 0x0600572F RID: 22319 RVA: 0x000A60D0 File Offset: 0x000A42D0
		// (set) Token: 0x06005730 RID: 22320 RVA: 0x000A60FC File Offset: 0x000A42FC
		[ProtoMember(3, IsRequired = false, Name = "isread", DataFormat = DataFormat.Default)]
		public bool isread
		{
			get
			{
				return this._isread ?? false;
			}
			set
			{
				this._isread = new bool?(value);
			}
		}

		// Token: 0x17001B14 RID: 6932
		// (get) Token: 0x06005731 RID: 22321 RVA: 0x000A610C File Offset: 0x000A430C
		// (set) Token: 0x06005732 RID: 22322 RVA: 0x000A612C File Offset: 0x000A432C
		[XmlIgnore]
		[Browsable(false)]
		public bool isreadSpecified
		{
			get
			{
				return this._isread != null;
			}
			set
			{
				bool flag = value == (this._isread == null);
				if (flag)
				{
					this._isread = (value ? new bool?(this.isread) : null);
				}
			}
		}

		// Token: 0x06005733 RID: 22323 RVA: 0x000A6170 File Offset: 0x000A4370
		private bool ShouldSerializeisread()
		{
			return this.isreadSpecified;
		}

		// Token: 0x06005734 RID: 22324 RVA: 0x000A6188 File Offset: 0x000A4388
		private void Resetisread()
		{
			this.isreadSpecified = false;
		}

		// Token: 0x17001B15 RID: 6933
		// (get) Token: 0x06005735 RID: 22325 RVA: 0x000A6194 File Offset: 0x000A4394
		// (set) Token: 0x06005736 RID: 22326 RVA: 0x000A61C0 File Offset: 0x000A43C0
		[ProtoMember(4, IsRequired = false, Name = "isdelete", DataFormat = DataFormat.Default)]
		public bool isdelete
		{
			get
			{
				return this._isdelete ?? false;
			}
			set
			{
				this._isdelete = new bool?(value);
			}
		}

		// Token: 0x17001B16 RID: 6934
		// (get) Token: 0x06005737 RID: 22327 RVA: 0x000A61D0 File Offset: 0x000A43D0
		// (set) Token: 0x06005738 RID: 22328 RVA: 0x000A61F0 File Offset: 0x000A43F0
		[XmlIgnore]
		[Browsable(false)]
		public bool isdeleteSpecified
		{
			get
			{
				return this._isdelete != null;
			}
			set
			{
				bool flag = value == (this._isdelete == null);
				if (flag)
				{
					this._isdelete = (value ? new bool?(this.isdelete) : null);
				}
			}
		}

		// Token: 0x06005739 RID: 22329 RVA: 0x000A6234 File Offset: 0x000A4434
		private bool ShouldSerializeisdelete()
		{
			return this.isdeleteSpecified;
		}

		// Token: 0x0600573A RID: 22330 RVA: 0x000A624C File Offset: 0x000A444C
		private void Resetisdelete()
		{
			this.isdeleteSpecified = false;
		}

		// Token: 0x17001B17 RID: 6935
		// (get) Token: 0x0600573B RID: 22331 RVA: 0x000A6258 File Offset: 0x000A4458
		// (set) Token: 0x0600573C RID: 22332 RVA: 0x000A6284 File Offset: 0x000A4484
		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17001B18 RID: 6936
		// (get) Token: 0x0600573D RID: 22333 RVA: 0x000A6294 File Offset: 0x000A4494
		// (set) Token: 0x0600573E RID: 22334 RVA: 0x000A62B4 File Offset: 0x000A44B4
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x0600573F RID: 22335 RVA: 0x000A62F8 File Offset: 0x000A44F8
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06005740 RID: 22336 RVA: 0x000A6310 File Offset: 0x000A4510
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001B19 RID: 6937
		// (get) Token: 0x06005741 RID: 22337 RVA: 0x000A631C File Offset: 0x000A451C
		// (set) Token: 0x06005742 RID: 22338 RVA: 0x000A6348 File Offset: 0x000A4548
		[ProtoMember(6, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		// Token: 0x17001B1A RID: 6938
		// (get) Token: 0x06005743 RID: 22339 RVA: 0x000A6358 File Offset: 0x000A4558
		// (set) Token: 0x06005744 RID: 22340 RVA: 0x000A6378 File Offset: 0x000A4578
		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		// Token: 0x06005745 RID: 22341 RVA: 0x000A63BC File Offset: 0x000A45BC
		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		// Token: 0x06005746 RID: 22342 RVA: 0x000A63D4 File Offset: 0x000A45D4
		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		// Token: 0x17001B1B RID: 6939
		// (get) Token: 0x06005747 RID: 22343 RVA: 0x000A63E0 File Offset: 0x000A45E0
		// (set) Token: 0x06005748 RID: 22344 RVA: 0x000A640C File Offset: 0x000A460C
		[ProtoMember(7, IsRequired = false, Name = "timeexpire", DataFormat = DataFormat.TwosComplement)]
		public uint timeexpire
		{
			get
			{
				return this._timeexpire ?? 0U;
			}
			set
			{
				this._timeexpire = new uint?(value);
			}
		}

		// Token: 0x17001B1C RID: 6940
		// (get) Token: 0x06005749 RID: 22345 RVA: 0x000A641C File Offset: 0x000A461C
		// (set) Token: 0x0600574A RID: 22346 RVA: 0x000A643C File Offset: 0x000A463C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeexpireSpecified
		{
			get
			{
				return this._timeexpire != null;
			}
			set
			{
				bool flag = value == (this._timeexpire == null);
				if (flag)
				{
					this._timeexpire = (value ? new uint?(this.timeexpire) : null);
				}
			}
		}

		// Token: 0x0600574B RID: 22347 RVA: 0x000A6480 File Offset: 0x000A4680
		private bool ShouldSerializetimeexpire()
		{
			return this.timeexpireSpecified;
		}

		// Token: 0x0600574C RID: 22348 RVA: 0x000A6498 File Offset: 0x000A4698
		private void Resettimeexpire()
		{
			this.timeexpireSpecified = false;
		}

		// Token: 0x17001B1D RID: 6941
		// (get) Token: 0x0600574D RID: 22349 RVA: 0x000A64A4 File Offset: 0x000A46A4
		// (set) Token: 0x0600574E RID: 22350 RVA: 0x000A64D0 File Offset: 0x000A46D0
		[ProtoMember(8, IsRequired = false, Name = "istemplate", DataFormat = DataFormat.Default)]
		public bool istemplate
		{
			get
			{
				return this._istemplate ?? false;
			}
			set
			{
				this._istemplate = new bool?(value);
			}
		}

		// Token: 0x17001B1E RID: 6942
		// (get) Token: 0x0600574F RID: 22351 RVA: 0x000A64E0 File Offset: 0x000A46E0
		// (set) Token: 0x06005750 RID: 22352 RVA: 0x000A6500 File Offset: 0x000A4700
		[XmlIgnore]
		[Browsable(false)]
		public bool istemplateSpecified
		{
			get
			{
				return this._istemplate != null;
			}
			set
			{
				bool flag = value == (this._istemplate == null);
				if (flag)
				{
					this._istemplate = (value ? new bool?(this.istemplate) : null);
				}
			}
		}

		// Token: 0x06005751 RID: 22353 RVA: 0x000A6544 File Offset: 0x000A4744
		private bool ShouldSerializeistemplate()
		{
			return this.istemplateSpecified;
		}

		// Token: 0x06005752 RID: 22354 RVA: 0x000A655C File Offset: 0x000A475C
		private void Resetistemplate()
		{
			this.istemplateSpecified = false;
		}

		// Token: 0x17001B1F RID: 6943
		// (get) Token: 0x06005753 RID: 22355 RVA: 0x000A6568 File Offset: 0x000A4768
		// (set) Token: 0x06005754 RID: 22356 RVA: 0x000A6595 File Offset: 0x000A4795
		[ProtoMember(9, IsRequired = false, Name = "srcid", DataFormat = DataFormat.TwosComplement)]
		public ulong srcid
		{
			get
			{
				return this._srcid ?? 0UL;
			}
			set
			{
				this._srcid = new ulong?(value);
			}
		}

		// Token: 0x17001B20 RID: 6944
		// (get) Token: 0x06005755 RID: 22357 RVA: 0x000A65A4 File Offset: 0x000A47A4
		// (set) Token: 0x06005756 RID: 22358 RVA: 0x000A65C4 File Offset: 0x000A47C4
		[XmlIgnore]
		[Browsable(false)]
		public bool srcidSpecified
		{
			get
			{
				return this._srcid != null;
			}
			set
			{
				bool flag = value == (this._srcid == null);
				if (flag)
				{
					this._srcid = (value ? new ulong?(this.srcid) : null);
				}
			}
		}

		// Token: 0x06005757 RID: 22359 RVA: 0x000A6608 File Offset: 0x000A4808
		private bool ShouldSerializesrcid()
		{
			return this.srcidSpecified;
		}

		// Token: 0x06005758 RID: 22360 RVA: 0x000A6620 File Offset: 0x000A4820
		private void Resetsrcid()
		{
			this.srcidSpecified = false;
		}

		// Token: 0x17001B21 RID: 6945
		// (get) Token: 0x06005759 RID: 22361 RVA: 0x000A662C File Offset: 0x000A482C
		// (set) Token: 0x0600575A RID: 22362 RVA: 0x000A664D File Offset: 0x000A484D
		[ProtoMember(10, IsRequired = false, Name = "srcname", DataFormat = DataFormat.Default)]
		public string srcname
		{
			get
			{
				return this._srcname ?? "";
			}
			set
			{
				this._srcname = value;
			}
		}

		// Token: 0x17001B22 RID: 6946
		// (get) Token: 0x0600575B RID: 22363 RVA: 0x000A6658 File Offset: 0x000A4858
		// (set) Token: 0x0600575C RID: 22364 RVA: 0x000A6674 File Offset: 0x000A4874
		[XmlIgnore]
		[Browsable(false)]
		public bool srcnameSpecified
		{
			get
			{
				return this._srcname != null;
			}
			set
			{
				bool flag = value == (this._srcname == null);
				if (flag)
				{
					this._srcname = (value ? this.srcname : null);
				}
			}
		}

		// Token: 0x0600575D RID: 22365 RVA: 0x000A66A4 File Offset: 0x000A48A4
		private bool ShouldSerializesrcname()
		{
			return this.srcnameSpecified;
		}

		// Token: 0x0600575E RID: 22366 RVA: 0x000A66BC File Offset: 0x000A48BC
		private void Resetsrcname()
		{
			this.srcnameSpecified = false;
		}

		// Token: 0x17001B23 RID: 6947
		// (get) Token: 0x0600575F RID: 22367 RVA: 0x000A66C8 File Offset: 0x000A48C8
		// (set) Token: 0x06005760 RID: 22368 RVA: 0x000A66E9 File Offset: 0x000A48E9
		[ProtoMember(11, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
		public string title
		{
			get
			{
				return this._title ?? "";
			}
			set
			{
				this._title = value;
			}
		}

		// Token: 0x17001B24 RID: 6948
		// (get) Token: 0x06005761 RID: 22369 RVA: 0x000A66F4 File Offset: 0x000A48F4
		// (set) Token: 0x06005762 RID: 22370 RVA: 0x000A6710 File Offset: 0x000A4910
		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? this.title : null);
				}
			}
		}

		// Token: 0x06005763 RID: 22371 RVA: 0x000A6740 File Offset: 0x000A4940
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06005764 RID: 22372 RVA: 0x000A6758 File Offset: 0x000A4958
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x17001B25 RID: 6949
		// (get) Token: 0x06005765 RID: 22373 RVA: 0x000A6764 File Offset: 0x000A4964
		// (set) Token: 0x06005766 RID: 22374 RVA: 0x000A6785 File Offset: 0x000A4985
		[ProtoMember(12, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
		public string content
		{
			get
			{
				return this._content ?? "";
			}
			set
			{
				this._content = value;
			}
		}

		// Token: 0x17001B26 RID: 6950
		// (get) Token: 0x06005767 RID: 22375 RVA: 0x000A6790 File Offset: 0x000A4990
		// (set) Token: 0x06005768 RID: 22376 RVA: 0x000A67AC File Offset: 0x000A49AC
		[XmlIgnore]
		[Browsable(false)]
		public bool contentSpecified
		{
			get
			{
				return this._content != null;
			}
			set
			{
				bool flag = value == (this._content == null);
				if (flag)
				{
					this._content = (value ? this.content : null);
				}
			}
		}

		// Token: 0x06005769 RID: 22377 RVA: 0x000A67DC File Offset: 0x000A49DC
		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		// Token: 0x0600576A RID: 22378 RVA: 0x000A67F4 File Offset: 0x000A49F4
		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		// Token: 0x17001B27 RID: 6951
		// (get) Token: 0x0600576B RID: 22379 RVA: 0x000A6800 File Offset: 0x000A4A00
		[ProtoMember(13, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001B28 RID: 6952
		// (get) Token: 0x0600576C RID: 22380 RVA: 0x000A6818 File Offset: 0x000A4A18
		// (set) Token: 0x0600576D RID: 22381 RVA: 0x000A6844 File Offset: 0x000A4A44
		[ProtoMember(14, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public int timeleft
		{
			get
			{
				return this._timeleft ?? 0;
			}
			set
			{
				this._timeleft = new int?(value);
			}
		}

		// Token: 0x17001B29 RID: 6953
		// (get) Token: 0x0600576E RID: 22382 RVA: 0x000A6854 File Offset: 0x000A4A54
		// (set) Token: 0x0600576F RID: 22383 RVA: 0x000A6874 File Offset: 0x000A4A74
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new int?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06005770 RID: 22384 RVA: 0x000A68B8 File Offset: 0x000A4AB8
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06005771 RID: 22385 RVA: 0x000A68D0 File Offset: 0x000A4AD0
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x17001B2A RID: 6954
		// (get) Token: 0x06005772 RID: 22386 RVA: 0x000A68DC File Offset: 0x000A4ADC
		[ProtoMember(15, Name = "xitems", DataFormat = DataFormat.Default)]
		public List<Item> xitems
		{
			get
			{
				return this._xitems;
			}
		}

		// Token: 0x17001B2B RID: 6955
		// (get) Token: 0x06005773 RID: 22387 RVA: 0x000A68F4 File Offset: 0x000A4AF4
		// (set) Token: 0x06005774 RID: 22388 RVA: 0x000A6920 File Offset: 0x000A4B20
		[ProtoMember(16, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public int reason
		{
			get
			{
				return this._reason ?? 0;
			}
			set
			{
				this._reason = new int?(value);
			}
		}

		// Token: 0x17001B2C RID: 6956
		// (get) Token: 0x06005775 RID: 22389 RVA: 0x000A6930 File Offset: 0x000A4B30
		// (set) Token: 0x06005776 RID: 22390 RVA: 0x000A6950 File Offset: 0x000A4B50
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new int?(this.reason) : null);
				}
			}
		}

		// Token: 0x06005777 RID: 22391 RVA: 0x000A6994 File Offset: 0x000A4B94
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x06005778 RID: 22392 RVA: 0x000A69AC File Offset: 0x000A4BAC
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x17001B2D RID: 6957
		// (get) Token: 0x06005779 RID: 22393 RVA: 0x000A69B8 File Offset: 0x000A4BB8
		// (set) Token: 0x0600577A RID: 22394 RVA: 0x000A69E4 File Offset: 0x000A4BE4
		[ProtoMember(17, IsRequired = false, Name = "subreason", DataFormat = DataFormat.TwosComplement)]
		public int subreason
		{
			get
			{
				return this._subreason ?? 0;
			}
			set
			{
				this._subreason = new int?(value);
			}
		}

		// Token: 0x17001B2E RID: 6958
		// (get) Token: 0x0600577B RID: 22395 RVA: 0x000A69F4 File Offset: 0x000A4BF4
		// (set) Token: 0x0600577C RID: 22396 RVA: 0x000A6A14 File Offset: 0x000A4C14
		[XmlIgnore]
		[Browsable(false)]
		public bool subreasonSpecified
		{
			get
			{
				return this._subreason != null;
			}
			set
			{
				bool flag = value == (this._subreason == null);
				if (flag)
				{
					this._subreason = (value ? new int?(this.subreason) : null);
				}
			}
		}

		// Token: 0x0600577D RID: 22397 RVA: 0x000A6A58 File Offset: 0x000A4C58
		private bool ShouldSerializesubreason()
		{
			return this.subreasonSpecified;
		}

		// Token: 0x0600577E RID: 22398 RVA: 0x000A6A70 File Offset: 0x000A4C70
		private void Resetsubreason()
		{
			this.subreasonSpecified = false;
		}

		// Token: 0x17001B2F RID: 6959
		// (get) Token: 0x0600577F RID: 22399 RVA: 0x000A6A7C File Offset: 0x000A4C7C
		// (set) Token: 0x06005780 RID: 22400 RVA: 0x000A6A9D File Offset: 0x000A4C9D
		[ProtoMember(18, IsRequired = false, Name = "extparam", DataFormat = DataFormat.Default)]
		public string extparam
		{
			get
			{
				return this._extparam ?? "";
			}
			set
			{
				this._extparam = value;
			}
		}

		// Token: 0x17001B30 RID: 6960
		// (get) Token: 0x06005781 RID: 22401 RVA: 0x000A6AA8 File Offset: 0x000A4CA8
		// (set) Token: 0x06005782 RID: 22402 RVA: 0x000A6AC4 File Offset: 0x000A4CC4
		[XmlIgnore]
		[Browsable(false)]
		public bool extparamSpecified
		{
			get
			{
				return this._extparam != null;
			}
			set
			{
				bool flag = value == (this._extparam == null);
				if (flag)
				{
					this._extparam = (value ? this.extparam : null);
				}
			}
		}

		// Token: 0x06005783 RID: 22403 RVA: 0x000A6AF4 File Offset: 0x000A4CF4
		private bool ShouldSerializeextparam()
		{
			return this.extparamSpecified;
		}

		// Token: 0x06005784 RID: 22404 RVA: 0x000A6B0C File Offset: 0x000A4D0C
		private void Resetextparam()
		{
			this.extparamSpecified = false;
		}

		// Token: 0x17001B31 RID: 6961
		// (get) Token: 0x06005785 RID: 22405 RVA: 0x000A6B18 File Offset: 0x000A4D18
		// (set) Token: 0x06005786 RID: 22406 RVA: 0x000A6B44 File Offset: 0x000A4D44
		[ProtoMember(19, IsRequired = false, Name = "minlevel", DataFormat = DataFormat.TwosComplement)]
		public int minlevel
		{
			get
			{
				return this._minlevel ?? 0;
			}
			set
			{
				this._minlevel = new int?(value);
			}
		}

		// Token: 0x17001B32 RID: 6962
		// (get) Token: 0x06005787 RID: 22407 RVA: 0x000A6B54 File Offset: 0x000A4D54
		// (set) Token: 0x06005788 RID: 22408 RVA: 0x000A6B74 File Offset: 0x000A4D74
		[XmlIgnore]
		[Browsable(false)]
		public bool minlevelSpecified
		{
			get
			{
				return this._minlevel != null;
			}
			set
			{
				bool flag = value == (this._minlevel == null);
				if (flag)
				{
					this._minlevel = (value ? new int?(this.minlevel) : null);
				}
			}
		}

		// Token: 0x06005789 RID: 22409 RVA: 0x000A6BB8 File Offset: 0x000A4DB8
		private bool ShouldSerializeminlevel()
		{
			return this.minlevelSpecified;
		}

		// Token: 0x0600578A RID: 22410 RVA: 0x000A6BD0 File Offset: 0x000A4DD0
		private void Resetminlevel()
		{
			this.minlevelSpecified = false;
		}

		// Token: 0x17001B33 RID: 6963
		// (get) Token: 0x0600578B RID: 22411 RVA: 0x000A6BDC File Offset: 0x000A4DDC
		// (set) Token: 0x0600578C RID: 22412 RVA: 0x000A6C08 File Offset: 0x000A4E08
		[ProtoMember(20, IsRequired = false, Name = "maxlevel", DataFormat = DataFormat.TwosComplement)]
		public int maxlevel
		{
			get
			{
				return this._maxlevel ?? 0;
			}
			set
			{
				this._maxlevel = new int?(value);
			}
		}

		// Token: 0x17001B34 RID: 6964
		// (get) Token: 0x0600578D RID: 22413 RVA: 0x000A6C18 File Offset: 0x000A4E18
		// (set) Token: 0x0600578E RID: 22414 RVA: 0x000A6C38 File Offset: 0x000A4E38
		[XmlIgnore]
		[Browsable(false)]
		public bool maxlevelSpecified
		{
			get
			{
				return this._maxlevel != null;
			}
			set
			{
				bool flag = value == (this._maxlevel == null);
				if (flag)
				{
					this._maxlevel = (value ? new int?(this.maxlevel) : null);
				}
			}
		}

		// Token: 0x0600578F RID: 22415 RVA: 0x000A6C7C File Offset: 0x000A4E7C
		private bool ShouldSerializemaxlevel()
		{
			return this.maxlevelSpecified;
		}

		// Token: 0x06005790 RID: 22416 RVA: 0x000A6C94 File Offset: 0x000A4E94
		private void Resetmaxlevel()
		{
			this.maxlevelSpecified = false;
		}

		// Token: 0x06005791 RID: 22417 RVA: 0x000A6CA0 File Offset: 0x000A4EA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400152A RID: 5418
		private ulong? _uid;

		// Token: 0x0400152B RID: 5419
		private uint? _type;

		// Token: 0x0400152C RID: 5420
		private bool? _isread;

		// Token: 0x0400152D RID: 5421
		private bool? _isdelete;

		// Token: 0x0400152E RID: 5422
		private uint? _state;

		// Token: 0x0400152F RID: 5423
		private uint? _timestamp;

		// Token: 0x04001530 RID: 5424
		private uint? _timeexpire;

		// Token: 0x04001531 RID: 5425
		private bool? _istemplate;

		// Token: 0x04001532 RID: 5426
		private ulong? _srcid;

		// Token: 0x04001533 RID: 5427
		private string _srcname;

		// Token: 0x04001534 RID: 5428
		private string _title;

		// Token: 0x04001535 RID: 5429
		private string _content;

		// Token: 0x04001536 RID: 5430
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04001537 RID: 5431
		private int? _timeleft;

		// Token: 0x04001538 RID: 5432
		private readonly List<Item> _xitems = new List<Item>();

		// Token: 0x04001539 RID: 5433
		private int? _reason;

		// Token: 0x0400153A RID: 5434
		private int? _subreason;

		// Token: 0x0400153B RID: 5435
		private string _extparam;

		// Token: 0x0400153C RID: 5436
		private int? _minlevel;

		// Token: 0x0400153D RID: 5437
		private int? _maxlevel;

		// Token: 0x0400153E RID: 5438
		private IExtension extensionObject;
	}
}
