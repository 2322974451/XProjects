using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DC RID: 1756
	[ProtoContract(Name = "PartnerLivenessItem")]
	[Serializable]
	public class PartnerLivenessItem : IExtensible
	{
		// Token: 0x17002507 RID: 9479
		// (get) Token: 0x060074EF RID: 29935 RVA: 0x000DFBAC File Offset: 0x000DDDAC
		// (set) Token: 0x060074F0 RID: 29936 RVA: 0x000DFBD9 File Offset: 0x000DDDD9
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

		// Token: 0x17002508 RID: 9480
		// (get) Token: 0x060074F1 RID: 29937 RVA: 0x000DFBE8 File Offset: 0x000DDDE8
		// (set) Token: 0x060074F2 RID: 29938 RVA: 0x000DFC08 File Offset: 0x000DDE08
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

		// Token: 0x060074F3 RID: 29939 RVA: 0x000DFC4C File Offset: 0x000DDE4C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060074F4 RID: 29940 RVA: 0x000DFC64 File Offset: 0x000DDE64
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002509 RID: 9481
		// (get) Token: 0x060074F5 RID: 29941 RVA: 0x000DFC70 File Offset: 0x000DDE70
		// (set) Token: 0x060074F6 RID: 29942 RVA: 0x000DFC9C File Offset: 0x000DDE9C
		[ProtoMember(2, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x1700250A RID: 9482
		// (get) Token: 0x060074F7 RID: 29943 RVA: 0x000DFCAC File Offset: 0x000DDEAC
		// (set) Token: 0x060074F8 RID: 29944 RVA: 0x000DFCCC File Offset: 0x000DDECC
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x060074F9 RID: 29945 RVA: 0x000DFD10 File Offset: 0x000DDF10
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x060074FA RID: 29946 RVA: 0x000DFD28 File Offset: 0x000DDF28
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x1700250B RID: 9483
		// (get) Token: 0x060074FB RID: 29947 RVA: 0x000DFD34 File Offset: 0x000DDF34
		// (set) Token: 0x060074FC RID: 29948 RVA: 0x000DFD60 File Offset: 0x000DDF60
		[ProtoMember(3, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public uint value
		{
			get
			{
				return this._value ?? 0U;
			}
			set
			{
				this._value = new uint?(value);
			}
		}

		// Token: 0x1700250C RID: 9484
		// (get) Token: 0x060074FD RID: 29949 RVA: 0x000DFD70 File Offset: 0x000DDF70
		// (set) Token: 0x060074FE RID: 29950 RVA: 0x000DFD90 File Offset: 0x000DDF90
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new uint?(this.value) : null);
				}
			}
		}

		// Token: 0x060074FF RID: 29951 RVA: 0x000DFDD4 File Offset: 0x000DDFD4
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06007500 RID: 29952 RVA: 0x000DFDEC File Offset: 0x000DDFEC
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x1700250D RID: 9485
		// (get) Token: 0x06007501 RID: 29953 RVA: 0x000DFDF8 File Offset: 0x000DDFF8
		// (set) Token: 0x06007502 RID: 29954 RVA: 0x000DFE24 File Offset: 0x000DE024
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

		// Token: 0x1700250E RID: 9486
		// (get) Token: 0x06007503 RID: 29955 RVA: 0x000DFE34 File Offset: 0x000DE034
		// (set) Token: 0x06007504 RID: 29956 RVA: 0x000DFE54 File Offset: 0x000DE054
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

		// Token: 0x06007505 RID: 29957 RVA: 0x000DFE98 File Offset: 0x000DE098
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007506 RID: 29958 RVA: 0x000DFEB0 File Offset: 0x000DE0B0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700250F RID: 9487
		// (get) Token: 0x06007507 RID: 29959 RVA: 0x000DFEBC File Offset: 0x000DE0BC
		// (set) Token: 0x06007508 RID: 29960 RVA: 0x000DFEDD File Offset: 0x000DE0DD
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

		// Token: 0x17002510 RID: 9488
		// (get) Token: 0x06007509 RID: 29961 RVA: 0x000DFEE8 File Offset: 0x000DE0E8
		// (set) Token: 0x0600750A RID: 29962 RVA: 0x000DFF04 File Offset: 0x000DE104
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

		// Token: 0x0600750B RID: 29963 RVA: 0x000DFF34 File Offset: 0x000DE134
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600750C RID: 29964 RVA: 0x000DFF4C File Offset: 0x000DE14C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x0600750D RID: 29965 RVA: 0x000DFF58 File Offset: 0x000DE158
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BC5 RID: 7109
		private ulong? _roleid;

		// Token: 0x04001BC6 RID: 7110
		private uint? _actid;

		// Token: 0x04001BC7 RID: 7111
		private uint? _value;

		// Token: 0x04001BC8 RID: 7112
		private uint? _time;

		// Token: 0x04001BC9 RID: 7113
		private string _name;

		// Token: 0x04001BCA RID: 7114
		private IExtension extensionObject;
	}
}
