using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071D RID: 1821
	[ProtoContract(Name = "MobaBattleOneGameRole")]
	[Serializable]
	public class MobaBattleOneGameRole : IExtensible
	{
		// Token: 0x1700276A RID: 10090
		// (get) Token: 0x06007C57 RID: 31831 RVA: 0x000EDBA0 File Offset: 0x000EBDA0
		// (set) Token: 0x06007C58 RID: 31832 RVA: 0x000EDBCD File Offset: 0x000EBDCD
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

		// Token: 0x1700276B RID: 10091
		// (get) Token: 0x06007C59 RID: 31833 RVA: 0x000EDBDC File Offset: 0x000EBDDC
		// (set) Token: 0x06007C5A RID: 31834 RVA: 0x000EDBFC File Offset: 0x000EBDFC
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

		// Token: 0x06007C5B RID: 31835 RVA: 0x000EDC40 File Offset: 0x000EBE40
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007C5C RID: 31836 RVA: 0x000EDC58 File Offset: 0x000EBE58
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700276C RID: 10092
		// (get) Token: 0x06007C5D RID: 31837 RVA: 0x000EDC64 File Offset: 0x000EBE64
		// (set) Token: 0x06007C5E RID: 31838 RVA: 0x000EDC85 File Offset: 0x000EBE85
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700276D RID: 10093
		// (get) Token: 0x06007C5F RID: 31839 RVA: 0x000EDC90 File Offset: 0x000EBE90
		// (set) Token: 0x06007C60 RID: 31840 RVA: 0x000EDCAC File Offset: 0x000EBEAC
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

		// Token: 0x06007C61 RID: 31841 RVA: 0x000EDCDC File Offset: 0x000EBEDC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007C62 RID: 31842 RVA: 0x000EDCF4 File Offset: 0x000EBEF4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700276E RID: 10094
		// (get) Token: 0x06007C63 RID: 31843 RVA: 0x000EDD00 File Offset: 0x000EBF00
		// (set) Token: 0x06007C64 RID: 31844 RVA: 0x000EDD2C File Offset: 0x000EBF2C
		[ProtoMember(3, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x1700276F RID: 10095
		// (get) Token: 0x06007C65 RID: 31845 RVA: 0x000EDD3C File Offset: 0x000EBF3C
		// (set) Token: 0x06007C66 RID: 31846 RVA: 0x000EDD5C File Offset: 0x000EBF5C
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06007C67 RID: 31847 RVA: 0x000EDDA0 File Offset: 0x000EBFA0
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06007C68 RID: 31848 RVA: 0x000EDDB8 File Offset: 0x000EBFB8
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17002770 RID: 10096
		// (get) Token: 0x06007C69 RID: 31849 RVA: 0x000EDDC4 File Offset: 0x000EBFC4
		// (set) Token: 0x06007C6A RID: 31850 RVA: 0x000EDDF0 File Offset: 0x000EBFF0
		[ProtoMember(4, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x17002771 RID: 10097
		// (get) Token: 0x06007C6B RID: 31851 RVA: 0x000EDE00 File Offset: 0x000EC000
		// (set) Token: 0x06007C6C RID: 31852 RVA: 0x000EDE20 File Offset: 0x000EC020
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x06007C6D RID: 31853 RVA: 0x000EDE64 File Offset: 0x000EC064
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06007C6E RID: 31854 RVA: 0x000EDE7C File Offset: 0x000EC07C
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17002772 RID: 10098
		// (get) Token: 0x06007C6F RID: 31855 RVA: 0x000EDE88 File Offset: 0x000EC088
		// (set) Token: 0x06007C70 RID: 31856 RVA: 0x000EDEB4 File Offset: 0x000EC0B4
		[ProtoMember(5, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		// Token: 0x17002773 RID: 10099
		// (get) Token: 0x06007C71 RID: 31857 RVA: 0x000EDEC4 File Offset: 0x000EC0C4
		// (set) Token: 0x06007C72 RID: 31858 RVA: 0x000EDEE4 File Offset: 0x000EC0E4
		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		// Token: 0x06007C73 RID: 31859 RVA: 0x000EDF28 File Offset: 0x000EC128
		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		// Token: 0x06007C74 RID: 31860 RVA: 0x000EDF40 File Offset: 0x000EC140
		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		// Token: 0x17002774 RID: 10100
		// (get) Token: 0x06007C75 RID: 31861 RVA: 0x000EDF4C File Offset: 0x000EC14C
		// (set) Token: 0x06007C76 RID: 31862 RVA: 0x000EDF78 File Offset: 0x000EC178
		[ProtoMember(6, IsRequired = false, Name = "assistcount", DataFormat = DataFormat.TwosComplement)]
		public uint assistcount
		{
			get
			{
				return this._assistcount ?? 0U;
			}
			set
			{
				this._assistcount = new uint?(value);
			}
		}

		// Token: 0x17002775 RID: 10101
		// (get) Token: 0x06007C77 RID: 31863 RVA: 0x000EDF88 File Offset: 0x000EC188
		// (set) Token: 0x06007C78 RID: 31864 RVA: 0x000EDFA8 File Offset: 0x000EC1A8
		[XmlIgnore]
		[Browsable(false)]
		public bool assistcountSpecified
		{
			get
			{
				return this._assistcount != null;
			}
			set
			{
				bool flag = value == (this._assistcount == null);
				if (flag)
				{
					this._assistcount = (value ? new uint?(this.assistcount) : null);
				}
			}
		}

		// Token: 0x06007C79 RID: 31865 RVA: 0x000EDFEC File Offset: 0x000EC1EC
		private bool ShouldSerializeassistcount()
		{
			return this.assistcountSpecified;
		}

		// Token: 0x06007C7A RID: 31866 RVA: 0x000EE004 File Offset: 0x000EC204
		private void Resetassistcount()
		{
			this.assistcountSpecified = false;
		}

		// Token: 0x17002776 RID: 10102
		// (get) Token: 0x06007C7B RID: 31867 RVA: 0x000EE010 File Offset: 0x000EC210
		// (set) Token: 0x06007C7C RID: 31868 RVA: 0x000EE03C File Offset: 0x000EC23C
		[ProtoMember(7, IsRequired = false, Name = "multikillcount", DataFormat = DataFormat.TwosComplement)]
		public uint multikillcount
		{
			get
			{
				return this._multikillcount ?? 0U;
			}
			set
			{
				this._multikillcount = new uint?(value);
			}
		}

		// Token: 0x17002777 RID: 10103
		// (get) Token: 0x06007C7D RID: 31869 RVA: 0x000EE04C File Offset: 0x000EC24C
		// (set) Token: 0x06007C7E RID: 31870 RVA: 0x000EE06C File Offset: 0x000EC26C
		[XmlIgnore]
		[Browsable(false)]
		public bool multikillcountSpecified
		{
			get
			{
				return this._multikillcount != null;
			}
			set
			{
				bool flag = value == (this._multikillcount == null);
				if (flag)
				{
					this._multikillcount = (value ? new uint?(this.multikillcount) : null);
				}
			}
		}

		// Token: 0x06007C7F RID: 31871 RVA: 0x000EE0B0 File Offset: 0x000EC2B0
		private bool ShouldSerializemultikillcount()
		{
			return this.multikillcountSpecified;
		}

		// Token: 0x06007C80 RID: 31872 RVA: 0x000EE0C8 File Offset: 0x000EC2C8
		private void Resetmultikillcount()
		{
			this.multikillcountSpecified = false;
		}

		// Token: 0x17002778 RID: 10104
		// (get) Token: 0x06007C81 RID: 31873 RVA: 0x000EE0D4 File Offset: 0x000EC2D4
		// (set) Token: 0x06007C82 RID: 31874 RVA: 0x000EE104 File Offset: 0x000EC304
		[ProtoMember(8, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		// Token: 0x17002779 RID: 10105
		// (get) Token: 0x06007C83 RID: 31875 RVA: 0x000EE114 File Offset: 0x000EC314
		// (set) Token: 0x06007C84 RID: 31876 RVA: 0x000EE134 File Offset: 0x000EC334
		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		// Token: 0x06007C85 RID: 31877 RVA: 0x000EE178 File Offset: 0x000EC378
		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		// Token: 0x06007C86 RID: 31878 RVA: 0x000EE190 File Offset: 0x000EC390
		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		// Token: 0x1700277A RID: 10106
		// (get) Token: 0x06007C87 RID: 31879 RVA: 0x000EE19C File Offset: 0x000EC39C
		// (set) Token: 0x06007C88 RID: 31880 RVA: 0x000EE1C8 File Offset: 0x000EC3C8
		[ProtoMember(9, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		// Token: 0x1700277B RID: 10107
		// (get) Token: 0x06007C89 RID: 31881 RVA: 0x000EE1D8 File Offset: 0x000EC3D8
		// (set) Token: 0x06007C8A RID: 31882 RVA: 0x000EE1F8 File Offset: 0x000EC3F8
		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		// Token: 0x06007C8B RID: 31883 RVA: 0x000EE23C File Offset: 0x000EC43C
		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		// Token: 0x06007C8C RID: 31884 RVA: 0x000EE254 File Offset: 0x000EC454
		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		// Token: 0x06007C8D RID: 31885 RVA: 0x000EE260 File Offset: 0x000EC460
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D4E RID: 7502
		private ulong? _roleid;

		// Token: 0x04001D4F RID: 7503
		private string _name;

		// Token: 0x04001D50 RID: 7504
		private uint? _heroid;

		// Token: 0x04001D51 RID: 7505
		private uint? _killcount;

		// Token: 0x04001D52 RID: 7506
		private uint? _deathcount;

		// Token: 0x04001D53 RID: 7507
		private uint? _assistcount;

		// Token: 0x04001D54 RID: 7508
		private uint? _multikillcount;

		// Token: 0x04001D55 RID: 7509
		private float? _kda;

		// Token: 0x04001D56 RID: 7510
		private bool? _isescape;

		// Token: 0x04001D57 RID: 7511
		private IExtension extensionObject;
	}
}
