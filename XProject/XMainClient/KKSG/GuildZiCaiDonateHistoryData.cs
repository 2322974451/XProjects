using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000745 RID: 1861
	[ProtoContract(Name = "GuildZiCaiDonateHistoryData")]
	[Serializable]
	public class GuildZiCaiDonateHistoryData : IExtensible
	{
		// Token: 0x17002929 RID: 10537
		// (get) Token: 0x060081D1 RID: 33233 RVA: 0x000F84C4 File Offset: 0x000F66C4
		// (set) Token: 0x060081D2 RID: 33234 RVA: 0x000F84F0 File Offset: 0x000F66F0
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700292A RID: 10538
		// (get) Token: 0x060081D3 RID: 33235 RVA: 0x000F8500 File Offset: 0x000F6700
		// (set) Token: 0x060081D4 RID: 33236 RVA: 0x000F8520 File Offset: 0x000F6720
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

		// Token: 0x060081D5 RID: 33237 RVA: 0x000F8564 File Offset: 0x000F6764
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060081D6 RID: 33238 RVA: 0x000F857C File Offset: 0x000F677C
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700292B RID: 10539
		// (get) Token: 0x060081D7 RID: 33239 RVA: 0x000F8588 File Offset: 0x000F6788
		// (set) Token: 0x060081D8 RID: 33240 RVA: 0x000F85B5 File Offset: 0x000F67B5
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700292C RID: 10540
		// (get) Token: 0x060081D9 RID: 33241 RVA: 0x000F85C4 File Offset: 0x000F67C4
		// (set) Token: 0x060081DA RID: 33242 RVA: 0x000F85E4 File Offset: 0x000F67E4
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

		// Token: 0x060081DB RID: 33243 RVA: 0x000F8628 File Offset: 0x000F6828
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060081DC RID: 33244 RVA: 0x000F8640 File Offset: 0x000F6840
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700292D RID: 10541
		// (get) Token: 0x060081DD RID: 33245 RVA: 0x000F864C File Offset: 0x000F684C
		// (set) Token: 0x060081DE RID: 33246 RVA: 0x000F866D File Offset: 0x000F686D
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700292E RID: 10542
		// (get) Token: 0x060081DF RID: 33247 RVA: 0x000F8678 File Offset: 0x000F6878
		// (set) Token: 0x060081E0 RID: 33248 RVA: 0x000F8694 File Offset: 0x000F6894
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

		// Token: 0x060081E1 RID: 33249 RVA: 0x000F86C4 File Offset: 0x000F68C4
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x060081E2 RID: 33250 RVA: 0x000F86DC File Offset: 0x000F68DC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700292F RID: 10543
		// (get) Token: 0x060081E3 RID: 33251 RVA: 0x000F86E8 File Offset: 0x000F68E8
		// (set) Token: 0x060081E4 RID: 33252 RVA: 0x000F8714 File Offset: 0x000F6914
		[ProtoMember(4, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17002930 RID: 10544
		// (get) Token: 0x060081E5 RID: 33253 RVA: 0x000F8724 File Offset: 0x000F6924
		// (set) Token: 0x060081E6 RID: 33254 RVA: 0x000F8744 File Offset: 0x000F6944
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x060081E7 RID: 33255 RVA: 0x000F8788 File Offset: 0x000F6988
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060081E8 RID: 33256 RVA: 0x000F87A0 File Offset: 0x000F69A0
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002931 RID: 10545
		// (get) Token: 0x060081E9 RID: 33257 RVA: 0x000F87AC File Offset: 0x000F69AC
		// (set) Token: 0x060081EA RID: 33258 RVA: 0x000F87D8 File Offset: 0x000F69D8
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

		// Token: 0x17002932 RID: 10546
		// (get) Token: 0x060081EB RID: 33259 RVA: 0x000F87E8 File Offset: 0x000F69E8
		// (set) Token: 0x060081EC RID: 33260 RVA: 0x000F8808 File Offset: 0x000F6A08
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

		// Token: 0x060081ED RID: 33261 RVA: 0x000F884C File Offset: 0x000F6A4C
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060081EE RID: 33262 RVA: 0x000F8864 File Offset: 0x000F6A64
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060081EF RID: 33263 RVA: 0x000F8870 File Offset: 0x000F6A70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E5C RID: 7772
		private uint? _itemid;

		// Token: 0x04001E5D RID: 7773
		private ulong? _roleid;

		// Token: 0x04001E5E RID: 7774
		private string _rolename;

		// Token: 0x04001E5F RID: 7775
		private uint? _profession;

		// Token: 0x04001E60 RID: 7776
		private uint? _time;

		// Token: 0x04001E61 RID: 7777
		private IExtension extensionObject;
	}
}
