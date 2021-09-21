using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000697 RID: 1687
	[ProtoContract(Name = "GmfRole")]
	[Serializable]
	public class GmfRole : IExtensible
	{
		// Token: 0x1700229D RID: 8861
		// (get) Token: 0x06006D5D RID: 27997 RVA: 0x000D13E0 File Offset: 0x000CF5E0
		// (set) Token: 0x06006D5E RID: 27998 RVA: 0x000D140D File Offset: 0x000CF60D
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x1700229E RID: 8862
		// (get) Token: 0x06006D5F RID: 27999 RVA: 0x000D141C File Offset: 0x000CF61C
		// (set) Token: 0x06006D60 RID: 28000 RVA: 0x000D143C File Offset: 0x000CF63C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06006D61 RID: 28001 RVA: 0x000D1480 File Offset: 0x000CF680
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06006D62 RID: 28002 RVA: 0x000D1498 File Offset: 0x000CF698
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700229F RID: 8863
		// (get) Token: 0x06006D63 RID: 28003 RVA: 0x000D14A4 File Offset: 0x000CF6A4
		// (set) Token: 0x06006D64 RID: 28004 RVA: 0x000D14C5 File Offset: 0x000CF6C5
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

		// Token: 0x170022A0 RID: 8864
		// (get) Token: 0x06006D65 RID: 28005 RVA: 0x000D14D0 File Offset: 0x000CF6D0
		// (set) Token: 0x06006D66 RID: 28006 RVA: 0x000D14EC File Offset: 0x000CF6EC
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

		// Token: 0x06006D67 RID: 28007 RVA: 0x000D151C File Offset: 0x000CF71C
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06006D68 RID: 28008 RVA: 0x000D1534 File Offset: 0x000CF734
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170022A1 RID: 8865
		// (get) Token: 0x06006D69 RID: 28009 RVA: 0x000D1540 File Offset: 0x000CF740
		// (set) Token: 0x06006D6A RID: 28010 RVA: 0x000D156C File Offset: 0x000CF76C
		[ProtoMember(3, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		// Token: 0x170022A2 RID: 8866
		// (get) Token: 0x06006D6B RID: 28011 RVA: 0x000D157C File Offset: 0x000CF77C
		// (set) Token: 0x06006D6C RID: 28012 RVA: 0x000D159C File Offset: 0x000CF79C
		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		// Token: 0x06006D6D RID: 28013 RVA: 0x000D15E0 File Offset: 0x000CF7E0
		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		// Token: 0x06006D6E RID: 28014 RVA: 0x000D15F8 File Offset: 0x000CF7F8
		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		// Token: 0x170022A3 RID: 8867
		// (get) Token: 0x06006D6F RID: 28015 RVA: 0x000D1604 File Offset: 0x000CF804
		// (set) Token: 0x06006D70 RID: 28016 RVA: 0x000D1630 File Offset: 0x000CF830
		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x170022A4 RID: 8868
		// (get) Token: 0x06006D71 RID: 28017 RVA: 0x000D1640 File Offset: 0x000CF840
		// (set) Token: 0x06006D72 RID: 28018 RVA: 0x000D1660 File Offset: 0x000CF860
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x06006D73 RID: 28019 RVA: 0x000D16A4 File Offset: 0x000CF8A4
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06006D74 RID: 28020 RVA: 0x000D16BC File Offset: 0x000CF8BC
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170022A5 RID: 8869
		// (get) Token: 0x06006D75 RID: 28021 RVA: 0x000D16C8 File Offset: 0x000CF8C8
		// (set) Token: 0x06006D76 RID: 28022 RVA: 0x000D16F4 File Offset: 0x000CF8F4
		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public GuildMatchFightState state
		{
			get
			{
				return this._state ?? GuildMatchFightState.GUILD_MF_NONE;
			}
			set
			{
				this._state = new GuildMatchFightState?(value);
			}
		}

		// Token: 0x170022A6 RID: 8870
		// (get) Token: 0x06006D77 RID: 28023 RVA: 0x000D1704 File Offset: 0x000CF904
		// (set) Token: 0x06006D78 RID: 28024 RVA: 0x000D1724 File Offset: 0x000CF924
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
					this._state = (value ? new GuildMatchFightState?(this.state) : null);
				}
			}
		}

		// Token: 0x06006D79 RID: 28025 RVA: 0x000D1768 File Offset: 0x000CF968
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006D7A RID: 28026 RVA: 0x000D1780 File Offset: 0x000CF980
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170022A7 RID: 8871
		// (get) Token: 0x06006D7B RID: 28027 RVA: 0x000D178C File Offset: 0x000CF98C
		// (set) Token: 0x06006D7C RID: 28028 RVA: 0x000D17B8 File Offset: 0x000CF9B8
		[ProtoMember(6, IsRequired = false, Name = "guildpos", DataFormat = DataFormat.TwosComplement)]
		public int guildpos
		{
			get
			{
				return this._guildpos ?? 0;
			}
			set
			{
				this._guildpos = new int?(value);
			}
		}

		// Token: 0x170022A8 RID: 8872
		// (get) Token: 0x06006D7D RID: 28029 RVA: 0x000D17C8 File Offset: 0x000CF9C8
		// (set) Token: 0x06006D7E RID: 28030 RVA: 0x000D17E8 File Offset: 0x000CF9E8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildposSpecified
		{
			get
			{
				return this._guildpos != null;
			}
			set
			{
				bool flag = value == (this._guildpos == null);
				if (flag)
				{
					this._guildpos = (value ? new int?(this.guildpos) : null);
				}
			}
		}

		// Token: 0x06006D7F RID: 28031 RVA: 0x000D182C File Offset: 0x000CFA2C
		private bool ShouldSerializeguildpos()
		{
			return this.guildposSpecified;
		}

		// Token: 0x06006D80 RID: 28032 RVA: 0x000D1844 File Offset: 0x000CFA44
		private void Resetguildpos()
		{
			this.guildposSpecified = false;
		}

		// Token: 0x170022A9 RID: 8873
		// (get) Token: 0x06006D81 RID: 28033 RVA: 0x000D1850 File Offset: 0x000CFA50
		// (set) Token: 0x06006D82 RID: 28034 RVA: 0x000D187C File Offset: 0x000CFA7C
		[ProtoMember(7, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		// Token: 0x170022AA RID: 8874
		// (get) Token: 0x06006D83 RID: 28035 RVA: 0x000D188C File Offset: 0x000CFA8C
		// (set) Token: 0x06006D84 RID: 28036 RVA: 0x000D18AC File Offset: 0x000CFAAC
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
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		// Token: 0x06006D85 RID: 28037 RVA: 0x000D18F0 File Offset: 0x000CFAF0
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06006D86 RID: 28038 RVA: 0x000D1908 File Offset: 0x000CFB08
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170022AB RID: 8875
		// (get) Token: 0x06006D87 RID: 28039 RVA: 0x000D1914 File Offset: 0x000CFB14
		// (set) Token: 0x06006D88 RID: 28040 RVA: 0x000D1940 File Offset: 0x000CFB40
		[ProtoMember(8, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x170022AC RID: 8876
		// (get) Token: 0x06006D89 RID: 28041 RVA: 0x000D1950 File Offset: 0x000CFB50
		// (set) Token: 0x06006D8A RID: 28042 RVA: 0x000D1970 File Offset: 0x000CFB70
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06006D8B RID: 28043 RVA: 0x000D19B4 File Offset: 0x000CFBB4
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06006D8C RID: 28044 RVA: 0x000D19CC File Offset: 0x000CFBCC
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x06006D8D RID: 28045 RVA: 0x000D19D8 File Offset: 0x000CFBD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A39 RID: 6713
		private ulong? _roleID;

		// Token: 0x04001A3A RID: 6714
		private string _rolename;

		// Token: 0x04001A3B RID: 6715
		private uint? _pkpoint;

		// Token: 0x04001A3C RID: 6716
		private int? _index;

		// Token: 0x04001A3D RID: 6717
		private GuildMatchFightState? _state;

		// Token: 0x04001A3E RID: 6718
		private int? _guildpos;

		// Token: 0x04001A3F RID: 6719
		private int? _profession;

		// Token: 0x04001A40 RID: 6720
		private uint? _ppt;

		// Token: 0x04001A41 RID: 6721
		private IExtension extensionObject;
	}
}
