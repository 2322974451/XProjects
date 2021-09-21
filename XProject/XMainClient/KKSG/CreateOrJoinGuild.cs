using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008A RID: 138
	[ProtoContract(Name = "CreateOrJoinGuild")]
	[Serializable]
	public class CreateOrJoinGuild : IExtensible
	{
		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00013AF4 File Offset: 0x00011CF4
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x00013B20 File Offset: 0x00011D20
		[ProtoMember(1, IsRequired = false, Name = "iscreate", DataFormat = DataFormat.Default)]
		public bool iscreate
		{
			get
			{
				return this._iscreate ?? false;
			}
			set
			{
				this._iscreate = new bool?(value);
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00013B30 File Offset: 0x00011D30
		// (set) Token: 0x060008F9 RID: 2297 RVA: 0x00013B50 File Offset: 0x00011D50
		[XmlIgnore]
		[Browsable(false)]
		public bool iscreateSpecified
		{
			get
			{
				return this._iscreate != null;
			}
			set
			{
				bool flag = value == (this._iscreate == null);
				if (flag)
				{
					this._iscreate = (value ? new bool?(this.iscreate) : null);
				}
			}
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00013B94 File Offset: 0x00011D94
		private bool ShouldSerializeiscreate()
		{
			return this.iscreateSpecified;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00013BAC File Offset: 0x00011DAC
		private void Resetiscreate()
		{
			this.iscreateSpecified = false;
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x00013BB8 File Offset: 0x00011DB8
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x00013BE5 File Offset: 0x00011DE5
		[ProtoMember(2, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00013BF4 File Offset: 0x00011DF4
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x00013C14 File Offset: 0x00011E14
		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00013C58 File Offset: 0x00011E58
		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00013C70 File Offset: 0x00011E70
		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00013C7C File Offset: 0x00011E7C
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x00013C9D File Offset: 0x00011E9D
		[ProtoMember(3, IsRequired = false, Name = "gname", DataFormat = DataFormat.Default)]
		public string gname
		{
			get
			{
				return this._gname ?? "";
			}
			set
			{
				this._gname = value;
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00013CA8 File Offset: 0x00011EA8
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00013CC4 File Offset: 0x00011EC4
		[XmlIgnore]
		[Browsable(false)]
		public bool gnameSpecified
		{
			get
			{
				return this._gname != null;
			}
			set
			{
				bool flag = value == (this._gname == null);
				if (flag)
				{
					this._gname = (value ? this.gname : null);
				}
			}
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00013CF4 File Offset: 0x00011EF4
		private bool ShouldSerializegname()
		{
			return this.gnameSpecified;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00013D0C File Offset: 0x00011F0C
		private void Resetgname()
		{
			this.gnameSpecified = false;
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00013D18 File Offset: 0x00011F18
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00013D44 File Offset: 0x00011F44
		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public int icon
		{
			get
			{
				return this._icon ?? 0;
			}
			set
			{
				this._icon = new int?(value);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00013D54 File Offset: 0x00011F54
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00013D74 File Offset: 0x00011F74
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new int?(this.icon) : null);
				}
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00013DB8 File Offset: 0x00011FB8
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00013DD0 File Offset: 0x00011FD0
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00013DDC File Offset: 0x00011FDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000255 RID: 597
		private bool? _iscreate;

		// Token: 0x04000256 RID: 598
		private ulong? _gid;

		// Token: 0x04000257 RID: 599
		private string _gname;

		// Token: 0x04000258 RID: 600
		private int? _icon;

		// Token: 0x04000259 RID: 601
		private IExtension extensionObject;
	}
}
