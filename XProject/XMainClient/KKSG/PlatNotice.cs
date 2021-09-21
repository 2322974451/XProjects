using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AF RID: 1455
	[ProtoContract(Name = "PlatNotice")]
	[Serializable]
	public class PlatNotice : IExtensible
	{
		// Token: 0x1700186E RID: 6254
		// (get) Token: 0x06004F2A RID: 20266 RVA: 0x000968F8 File Offset: 0x00094AF8
		// (set) Token: 0x06004F2B RID: 20267 RVA: 0x00096924 File Offset: 0x00094B24
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

		// Token: 0x1700186F RID: 6255
		// (get) Token: 0x06004F2C RID: 20268 RVA: 0x00096934 File Offset: 0x00094B34
		// (set) Token: 0x06004F2D RID: 20269 RVA: 0x00096954 File Offset: 0x00094B54
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

		// Token: 0x06004F2E RID: 20270 RVA: 0x00096998 File Offset: 0x00094B98
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004F2F RID: 20271 RVA: 0x000969B0 File Offset: 0x00094BB0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001870 RID: 6256
		// (get) Token: 0x06004F30 RID: 20272 RVA: 0x000969BC File Offset: 0x00094BBC
		// (set) Token: 0x06004F31 RID: 20273 RVA: 0x000969E8 File Offset: 0x00094BE8
		[ProtoMember(2, IsRequired = false, Name = "noticeid", DataFormat = DataFormat.TwosComplement)]
		public uint noticeid
		{
			get
			{
				return this._noticeid ?? 0U;
			}
			set
			{
				this._noticeid = new uint?(value);
			}
		}

		// Token: 0x17001871 RID: 6257
		// (get) Token: 0x06004F32 RID: 20274 RVA: 0x000969F8 File Offset: 0x00094BF8
		// (set) Token: 0x06004F33 RID: 20275 RVA: 0x00096A18 File Offset: 0x00094C18
		[XmlIgnore]
		[Browsable(false)]
		public bool noticeidSpecified
		{
			get
			{
				return this._noticeid != null;
			}
			set
			{
				bool flag = value == (this._noticeid == null);
				if (flag)
				{
					this._noticeid = (value ? new uint?(this.noticeid) : null);
				}
			}
		}

		// Token: 0x06004F34 RID: 20276 RVA: 0x00096A5C File Offset: 0x00094C5C
		private bool ShouldSerializenoticeid()
		{
			return this.noticeidSpecified;
		}

		// Token: 0x06004F35 RID: 20277 RVA: 0x00096A74 File Offset: 0x00094C74
		private void Resetnoticeid()
		{
			this.noticeidSpecified = false;
		}

		// Token: 0x17001872 RID: 6258
		// (get) Token: 0x06004F36 RID: 20278 RVA: 0x00096A80 File Offset: 0x00094C80
		// (set) Token: 0x06004F37 RID: 20279 RVA: 0x00096AAC File Offset: 0x00094CAC
		[ProtoMember(3, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
		public bool isopen
		{
			get
			{
				return this._isopen ?? false;
			}
			set
			{
				this._isopen = new bool?(value);
			}
		}

		// Token: 0x17001873 RID: 6259
		// (get) Token: 0x06004F38 RID: 20280 RVA: 0x00096ABC File Offset: 0x00094CBC
		// (set) Token: 0x06004F39 RID: 20281 RVA: 0x00096ADC File Offset: 0x00094CDC
		[XmlIgnore]
		[Browsable(false)]
		public bool isopenSpecified
		{
			get
			{
				return this._isopen != null;
			}
			set
			{
				bool flag = value == (this._isopen == null);
				if (flag)
				{
					this._isopen = (value ? new bool?(this.isopen) : null);
				}
			}
		}

		// Token: 0x06004F3A RID: 20282 RVA: 0x00096B20 File Offset: 0x00094D20
		private bool ShouldSerializeisopen()
		{
			return this.isopenSpecified;
		}

		// Token: 0x06004F3B RID: 20283 RVA: 0x00096B38 File Offset: 0x00094D38
		private void Resetisopen()
		{
			this.isopenSpecified = false;
		}

		// Token: 0x17001874 RID: 6260
		// (get) Token: 0x06004F3C RID: 20284 RVA: 0x00096B44 File Offset: 0x00094D44
		// (set) Token: 0x06004F3D RID: 20285 RVA: 0x00096B70 File Offset: 0x00094D70
		[ProtoMember(4, IsRequired = false, Name = "areaid", DataFormat = DataFormat.TwosComplement)]
		public uint areaid
		{
			get
			{
				return this._areaid ?? 0U;
			}
			set
			{
				this._areaid = new uint?(value);
			}
		}

		// Token: 0x17001875 RID: 6261
		// (get) Token: 0x06004F3E RID: 20286 RVA: 0x00096B80 File Offset: 0x00094D80
		// (set) Token: 0x06004F3F RID: 20287 RVA: 0x00096BA0 File Offset: 0x00094DA0
		[XmlIgnore]
		[Browsable(false)]
		public bool areaidSpecified
		{
			get
			{
				return this._areaid != null;
			}
			set
			{
				bool flag = value == (this._areaid == null);
				if (flag)
				{
					this._areaid = (value ? new uint?(this.areaid) : null);
				}
			}
		}

		// Token: 0x06004F40 RID: 20288 RVA: 0x00096BE4 File Offset: 0x00094DE4
		private bool ShouldSerializeareaid()
		{
			return this.areaidSpecified;
		}

		// Token: 0x06004F41 RID: 20289 RVA: 0x00096BFC File Offset: 0x00094DFC
		private void Resetareaid()
		{
			this.areaidSpecified = false;
		}

		// Token: 0x17001876 RID: 6262
		// (get) Token: 0x06004F42 RID: 20290 RVA: 0x00096C08 File Offset: 0x00094E08
		// (set) Token: 0x06004F43 RID: 20291 RVA: 0x00096C34 File Offset: 0x00094E34
		[ProtoMember(5, IsRequired = false, Name = "platid", DataFormat = DataFormat.TwosComplement)]
		public uint platid
		{
			get
			{
				return this._platid ?? 0U;
			}
			set
			{
				this._platid = new uint?(value);
			}
		}

		// Token: 0x17001877 RID: 6263
		// (get) Token: 0x06004F44 RID: 20292 RVA: 0x00096C44 File Offset: 0x00094E44
		// (set) Token: 0x06004F45 RID: 20293 RVA: 0x00096C64 File Offset: 0x00094E64
		[XmlIgnore]
		[Browsable(false)]
		public bool platidSpecified
		{
			get
			{
				return this._platid != null;
			}
			set
			{
				bool flag = value == (this._platid == null);
				if (flag)
				{
					this._platid = (value ? new uint?(this.platid) : null);
				}
			}
		}

		// Token: 0x06004F46 RID: 20294 RVA: 0x00096CA8 File Offset: 0x00094EA8
		private bool ShouldSerializeplatid()
		{
			return this.platidSpecified;
		}

		// Token: 0x06004F47 RID: 20295 RVA: 0x00096CC0 File Offset: 0x00094EC0
		private void Resetplatid()
		{
			this.platidSpecified = false;
		}

		// Token: 0x17001878 RID: 6264
		// (get) Token: 0x06004F48 RID: 20296 RVA: 0x00096CCC File Offset: 0x00094ECC
		// (set) Token: 0x06004F49 RID: 20297 RVA: 0x00096CED File Offset: 0x00094EED
		[ProtoMember(6, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001879 RID: 6265
		// (get) Token: 0x06004F4A RID: 20298 RVA: 0x00096CF8 File Offset: 0x00094EF8
		// (set) Token: 0x06004F4B RID: 20299 RVA: 0x00096D14 File Offset: 0x00094F14
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

		// Token: 0x06004F4C RID: 20300 RVA: 0x00096D44 File Offset: 0x00094F44
		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		// Token: 0x06004F4D RID: 20301 RVA: 0x00096D5C File Offset: 0x00094F5C
		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		// Token: 0x1700187A RID: 6266
		// (get) Token: 0x06004F4E RID: 20302 RVA: 0x00096D68 File Offset: 0x00094F68
		// (set) Token: 0x06004F4F RID: 20303 RVA: 0x00096D94 File Offset: 0x00094F94
		[ProtoMember(7, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700187B RID: 6267
		// (get) Token: 0x06004F50 RID: 20304 RVA: 0x00096DA4 File Offset: 0x00094FA4
		// (set) Token: 0x06004F51 RID: 20305 RVA: 0x00096DC4 File Offset: 0x00094FC4
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

		// Token: 0x06004F52 RID: 20306 RVA: 0x00096E08 File Offset: 0x00095008
		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		// Token: 0x06004F53 RID: 20307 RVA: 0x00096E20 File Offset: 0x00095020
		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		// Token: 0x1700187C RID: 6268
		// (get) Token: 0x06004F54 RID: 20308 RVA: 0x00096E2C File Offset: 0x0009502C
		// (set) Token: 0x06004F55 RID: 20309 RVA: 0x00096E58 File Offset: 0x00095058
		[ProtoMember(8, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		// Token: 0x1700187D RID: 6269
		// (get) Token: 0x06004F56 RID: 20310 RVA: 0x00096E68 File Offset: 0x00095068
		// (set) Token: 0x06004F57 RID: 20311 RVA: 0x00096E88 File Offset: 0x00095088
		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		// Token: 0x06004F58 RID: 20312 RVA: 0x00096ECC File Offset: 0x000950CC
		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		// Token: 0x06004F59 RID: 20313 RVA: 0x00096EE4 File Offset: 0x000950E4
		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		// Token: 0x1700187E RID: 6270
		// (get) Token: 0x06004F5A RID: 20314 RVA: 0x00096EF0 File Offset: 0x000950F0
		// (set) Token: 0x06004F5B RID: 20315 RVA: 0x00096F11 File Offset: 0x00095111
		[ProtoMember(9, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700187F RID: 6271
		// (get) Token: 0x06004F5C RID: 20316 RVA: 0x00096F1C File Offset: 0x0009511C
		// (set) Token: 0x06004F5D RID: 20317 RVA: 0x00096F38 File Offset: 0x00095138
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

		// Token: 0x06004F5E RID: 20318 RVA: 0x00096F68 File Offset: 0x00095168
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x00096F80 File Offset: 0x00095180
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x06004F60 RID: 20320 RVA: 0x00096F8C File Offset: 0x0009518C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400138C RID: 5004
		private uint? _type;

		// Token: 0x0400138D RID: 5005
		private uint? _noticeid;

		// Token: 0x0400138E RID: 5006
		private bool? _isopen;

		// Token: 0x0400138F RID: 5007
		private uint? _areaid;

		// Token: 0x04001390 RID: 5008
		private uint? _platid;

		// Token: 0x04001391 RID: 5009
		private string _content;

		// Token: 0x04001392 RID: 5010
		private uint? _updatetime;

		// Token: 0x04001393 RID: 5011
		private bool? _isnew;

		// Token: 0x04001394 RID: 5012
		private string _title;

		// Token: 0x04001395 RID: 5013
		private IExtension extensionObject;
	}
}
