using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000731 RID: 1841
	[ProtoContract(Name = "DragonGuildShopRecordItem")]
	[Serializable]
	public class DragonGuildShopRecordItem : IExtensible
	{
		// Token: 0x1700285F RID: 10335
		// (get) Token: 0x06007F54 RID: 32596 RVA: 0x000F37CC File Offset: 0x000F19CC
		// (set) Token: 0x06007F55 RID: 32597 RVA: 0x000F37F9 File Offset: 0x000F19F9
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17002860 RID: 10336
		// (get) Token: 0x06007F56 RID: 32598 RVA: 0x000F3808 File Offset: 0x000F1A08
		// (set) Token: 0x06007F57 RID: 32599 RVA: 0x000F3828 File Offset: 0x000F1A28
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007F58 RID: 32600 RVA: 0x000F386C File Offset: 0x000F1A6C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007F59 RID: 32601 RVA: 0x000F3884 File Offset: 0x000F1A84
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002861 RID: 10337
		// (get) Token: 0x06007F5A RID: 32602 RVA: 0x000F3890 File Offset: 0x000F1A90
		// (set) Token: 0x06007F5B RID: 32603 RVA: 0x000F38BC File Offset: 0x000F1ABC
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x17002862 RID: 10338
		// (get) Token: 0x06007F5C RID: 32604 RVA: 0x000F38CC File Offset: 0x000F1ACC
		// (set) Token: 0x06007F5D RID: 32605 RVA: 0x000F38EC File Offset: 0x000F1AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06007F5E RID: 32606 RVA: 0x000F3930 File Offset: 0x000F1B30
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06007F5F RID: 32607 RVA: 0x000F3948 File Offset: 0x000F1B48
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17002863 RID: 10339
		// (get) Token: 0x06007F60 RID: 32608 RVA: 0x000F3954 File Offset: 0x000F1B54
		// (set) Token: 0x06007F61 RID: 32609 RVA: 0x000F3980 File Offset: 0x000F1B80
		[ProtoMember(3, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x17002864 RID: 10340
		// (get) Token: 0x06007F62 RID: 32610 RVA: 0x000F3990 File Offset: 0x000F1B90
		// (set) Token: 0x06007F63 RID: 32611 RVA: 0x000F39B0 File Offset: 0x000F1BB0
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x06007F64 RID: 32612 RVA: 0x000F39F4 File Offset: 0x000F1BF4
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x06007F65 RID: 32613 RVA: 0x000F3A0C File Offset: 0x000F1C0C
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17002865 RID: 10341
		// (get) Token: 0x06007F66 RID: 32614 RVA: 0x000F3A18 File Offset: 0x000F1C18
		// (set) Token: 0x06007F67 RID: 32615 RVA: 0x000F3A44 File Offset: 0x000F1C44
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17002866 RID: 10342
		// (get) Token: 0x06007F68 RID: 32616 RVA: 0x000F3A54 File Offset: 0x000F1C54
		// (set) Token: 0x06007F69 RID: 32617 RVA: 0x000F3A74 File Offset: 0x000F1C74
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007F6A RID: 32618 RVA: 0x000F3AB8 File Offset: 0x000F1CB8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007F6B RID: 32619 RVA: 0x000F3AD0 File Offset: 0x000F1CD0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002867 RID: 10343
		// (get) Token: 0x06007F6C RID: 32620 RVA: 0x000F3ADC File Offset: 0x000F1CDC
		// (set) Token: 0x06007F6D RID: 32621 RVA: 0x000F3AFD File Offset: 0x000F1CFD
		[ProtoMember(5, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002868 RID: 10344
		// (get) Token: 0x06007F6E RID: 32622 RVA: 0x000F3B08 File Offset: 0x000F1D08
		// (set) Token: 0x06007F6F RID: 32623 RVA: 0x000F3B24 File Offset: 0x000F1D24
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007F70 RID: 32624 RVA: 0x000F3B54 File Offset: 0x000F1D54
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007F71 RID: 32625 RVA: 0x000F3B6C File Offset: 0x000F1D6C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002869 RID: 10345
		// (get) Token: 0x06007F72 RID: 32626 RVA: 0x000F3B78 File Offset: 0x000F1D78
		// (set) Token: 0x06007F73 RID: 32627 RVA: 0x000F3BA4 File Offset: 0x000F1DA4
		[ProtoMember(6, IsRequired = false, Name = "titleId", DataFormat = DataFormat.TwosComplement)]
		public uint titleId
		{
			get
			{
				return this._titleId ?? 0U;
			}
			set
			{
				this._titleId = new uint?(value);
			}
		}

		// Token: 0x1700286A RID: 10346
		// (get) Token: 0x06007F74 RID: 32628 RVA: 0x000F3BB4 File Offset: 0x000F1DB4
		// (set) Token: 0x06007F75 RID: 32629 RVA: 0x000F3BD4 File Offset: 0x000F1DD4
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIdSpecified
		{
			get
			{
				return this._titleId != null;
			}
			set
			{
				bool flag = value == (this._titleId == null);
				if (flag)
				{
					this._titleId = (value ? new uint?(this.titleId) : null);
				}
			}
		}

		// Token: 0x06007F76 RID: 32630 RVA: 0x000F3C18 File Offset: 0x000F1E18
		private bool ShouldSerializetitleId()
		{
			return this.titleIdSpecified;
		}

		// Token: 0x06007F77 RID: 32631 RVA: 0x000F3C30 File Offset: 0x000F1E30
		private void ResettitleId()
		{
			this.titleIdSpecified = false;
		}

		// Token: 0x06007F78 RID: 32632 RVA: 0x000F3C3C File Offset: 0x000F1E3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DE0 RID: 7648
		private ulong? _roleid;

		// Token: 0x04001DE1 RID: 7649
		private uint? _itemid;

		// Token: 0x04001DE2 RID: 7650
		private uint? _itemcount;

		// Token: 0x04001DE3 RID: 7651
		private uint? _time;

		// Token: 0x04001DE4 RID: 7652
		private string _name;

		// Token: 0x04001DE5 RID: 7653
		private uint? _titleId;

		// Token: 0x04001DE6 RID: 7654
		private IExtension extensionObject;
	}
}
