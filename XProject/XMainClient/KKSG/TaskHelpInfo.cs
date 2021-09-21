using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063D RID: 1597
	[ProtoContract(Name = "TaskHelpInfo")]
	[Serializable]
	public class TaskHelpInfo : IExtensible
	{
		// Token: 0x17001F24 RID: 7972
		// (get) Token: 0x060062DA RID: 25306 RVA: 0x000BCAA0 File Offset: 0x000BACA0
		// (set) Token: 0x060062DB RID: 25307 RVA: 0x000BCACD File Offset: 0x000BACCD
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

		// Token: 0x17001F25 RID: 7973
		// (get) Token: 0x060062DC RID: 25308 RVA: 0x000BCADC File Offset: 0x000BACDC
		// (set) Token: 0x060062DD RID: 25309 RVA: 0x000BCAFC File Offset: 0x000BACFC
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

		// Token: 0x060062DE RID: 25310 RVA: 0x000BCB40 File Offset: 0x000BAD40
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060062DF RID: 25311 RVA: 0x000BCB58 File Offset: 0x000BAD58
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001F26 RID: 7974
		// (get) Token: 0x060062E0 RID: 25312 RVA: 0x000BCB64 File Offset: 0x000BAD64
		// (set) Token: 0x060062E1 RID: 25313 RVA: 0x000BCB85 File Offset: 0x000BAD85
		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17001F27 RID: 7975
		// (get) Token: 0x060062E2 RID: 25314 RVA: 0x000BCB90 File Offset: 0x000BAD90
		// (set) Token: 0x060062E3 RID: 25315 RVA: 0x000BCBAC File Offset: 0x000BADAC
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x060062E4 RID: 25316 RVA: 0x000BCBDC File Offset: 0x000BADDC
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x060062E5 RID: 25317 RVA: 0x000BCBF4 File Offset: 0x000BADF4
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001F28 RID: 7976
		// (get) Token: 0x060062E6 RID: 25318 RVA: 0x000BCC00 File Offset: 0x000BAE00
		// (set) Token: 0x060062E7 RID: 25319 RVA: 0x000BCC2C File Offset: 0x000BAE2C
		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F29 RID: 7977
		// (get) Token: 0x060062E8 RID: 25320 RVA: 0x000BCC3C File Offset: 0x000BAE3C
		// (set) Token: 0x060062E9 RID: 25321 RVA: 0x000BCC5C File Offset: 0x000BAE5C
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

		// Token: 0x060062EA RID: 25322 RVA: 0x000BCCA0 File Offset: 0x000BAEA0
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060062EB RID: 25323 RVA: 0x000BCCB8 File Offset: 0x000BAEB8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17001F2A RID: 7978
		// (get) Token: 0x060062EC RID: 25324 RVA: 0x000BCCC4 File Offset: 0x000BAEC4
		// (set) Token: 0x060062ED RID: 25325 RVA: 0x000BCCF0 File Offset: 0x000BAEF0
		[ProtoMember(4, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F2B RID: 7979
		// (get) Token: 0x060062EE RID: 25326 RVA: 0x000BCD00 File Offset: 0x000BAF00
		// (set) Token: 0x060062EF RID: 25327 RVA: 0x000BCD20 File Offset: 0x000BAF20
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

		// Token: 0x060062F0 RID: 25328 RVA: 0x000BCD64 File Offset: 0x000BAF64
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x060062F1 RID: 25329 RVA: 0x000BCD7C File Offset: 0x000BAF7C
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17001F2C RID: 7980
		// (get) Token: 0x060062F2 RID: 25330 RVA: 0x000BCD88 File Offset: 0x000BAF88
		// (set) Token: 0x060062F3 RID: 25331 RVA: 0x000BCDB4 File Offset: 0x000BAFB4
		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F2D RID: 7981
		// (get) Token: 0x060062F4 RID: 25332 RVA: 0x000BCDC4 File Offset: 0x000BAFC4
		// (set) Token: 0x060062F5 RID: 25333 RVA: 0x000BCDE4 File Offset: 0x000BAFE4
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

		// Token: 0x060062F6 RID: 25334 RVA: 0x000BCE28 File Offset: 0x000BB028
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060062F7 RID: 25335 RVA: 0x000BCE40 File Offset: 0x000BB040
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060062F8 RID: 25336 RVA: 0x000BCE4C File Offset: 0x000BB04C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017F5 RID: 6133
		private ulong? _roleid;

		// Token: 0x040017F6 RID: 6134
		private string _rolename;

		// Token: 0x040017F7 RID: 6135
		private uint? _itemid;

		// Token: 0x040017F8 RID: 6136
		private uint? _itemcount;

		// Token: 0x040017F9 RID: 6137
		private uint? _time;

		// Token: 0x040017FA RID: 6138
		private IExtension extensionObject;
	}
}
