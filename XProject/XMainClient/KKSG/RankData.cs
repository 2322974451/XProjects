using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000587 RID: 1415
	[ProtoContract(Name = "RankData")]
	[Serializable]
	public class RankData : IExtensible
	{
		// Token: 0x170016A0 RID: 5792
		// (get) Token: 0x060049B3 RID: 18867 RVA: 0x0008C220 File Offset: 0x0008A420
		// (set) Token: 0x060049B4 RID: 18868 RVA: 0x0008C24D File Offset: 0x0008A44D
		[ProtoMember(1, IsRequired = false, Name = "RoleId", DataFormat = DataFormat.TwosComplement)]
		public ulong RoleId
		{
			get
			{
				return this._RoleId ?? 0UL;
			}
			set
			{
				this._RoleId = new ulong?(value);
			}
		}

		// Token: 0x170016A1 RID: 5793
		// (get) Token: 0x060049B5 RID: 18869 RVA: 0x0008C25C File Offset: 0x0008A45C
		// (set) Token: 0x060049B6 RID: 18870 RVA: 0x0008C27C File Offset: 0x0008A47C
		[XmlIgnore]
		[Browsable(false)]
		public bool RoleIdSpecified
		{
			get
			{
				return this._RoleId != null;
			}
			set
			{
				bool flag = value == (this._RoleId == null);
				if (flag)
				{
					this._RoleId = (value ? new ulong?(this.RoleId) : null);
				}
			}
		}

		// Token: 0x060049B7 RID: 18871 RVA: 0x0008C2C0 File Offset: 0x0008A4C0
		private bool ShouldSerializeRoleId()
		{
			return this.RoleIdSpecified;
		}

		// Token: 0x060049B8 RID: 18872 RVA: 0x0008C2D8 File Offset: 0x0008A4D8
		private void ResetRoleId()
		{
			this.RoleIdSpecified = false;
		}

		// Token: 0x170016A2 RID: 5794
		// (get) Token: 0x060049B9 RID: 18873 RVA: 0x0008C2E4 File Offset: 0x0008A4E4
		// (set) Token: 0x060049BA RID: 18874 RVA: 0x0008C305 File Offset: 0x0008A505
		[ProtoMember(2, IsRequired = false, Name = "RoleName", DataFormat = DataFormat.Default)]
		public string RoleName
		{
			get
			{
				return this._RoleName ?? "";
			}
			set
			{
				this._RoleName = value;
			}
		}

		// Token: 0x170016A3 RID: 5795
		// (get) Token: 0x060049BB RID: 18875 RVA: 0x0008C310 File Offset: 0x0008A510
		// (set) Token: 0x060049BC RID: 18876 RVA: 0x0008C32C File Offset: 0x0008A52C
		[XmlIgnore]
		[Browsable(false)]
		public bool RoleNameSpecified
		{
			get
			{
				return this._RoleName != null;
			}
			set
			{
				bool flag = value == (this._RoleName == null);
				if (flag)
				{
					this._RoleName = (value ? this.RoleName : null);
				}
			}
		}

		// Token: 0x060049BD RID: 18877 RVA: 0x0008C35C File Offset: 0x0008A55C
		private bool ShouldSerializeRoleName()
		{
			return this.RoleNameSpecified;
		}

		// Token: 0x060049BE RID: 18878 RVA: 0x0008C374 File Offset: 0x0008A574
		private void ResetRoleName()
		{
			this.RoleNameSpecified = false;
		}

		// Token: 0x170016A4 RID: 5796
		// (get) Token: 0x060049BF RID: 18879 RVA: 0x0008C380 File Offset: 0x0008A580
		// (set) Token: 0x060049C0 RID: 18880 RVA: 0x0008C3AC File Offset: 0x0008A5AC
		[ProtoMember(3, IsRequired = false, Name = "RoleLevel", DataFormat = DataFormat.TwosComplement)]
		public uint RoleLevel
		{
			get
			{
				return this._RoleLevel ?? 0U;
			}
			set
			{
				this._RoleLevel = new uint?(value);
			}
		}

		// Token: 0x170016A5 RID: 5797
		// (get) Token: 0x060049C1 RID: 18881 RVA: 0x0008C3BC File Offset: 0x0008A5BC
		// (set) Token: 0x060049C2 RID: 18882 RVA: 0x0008C3DC File Offset: 0x0008A5DC
		[XmlIgnore]
		[Browsable(false)]
		public bool RoleLevelSpecified
		{
			get
			{
				return this._RoleLevel != null;
			}
			set
			{
				bool flag = value == (this._RoleLevel == null);
				if (flag)
				{
					this._RoleLevel = (value ? new uint?(this.RoleLevel) : null);
				}
			}
		}

		// Token: 0x060049C3 RID: 18883 RVA: 0x0008C420 File Offset: 0x0008A620
		private bool ShouldSerializeRoleLevel()
		{
			return this.RoleLevelSpecified;
		}

		// Token: 0x060049C4 RID: 18884 RVA: 0x0008C438 File Offset: 0x0008A638
		private void ResetRoleLevel()
		{
			this.RoleLevelSpecified = false;
		}

		// Token: 0x170016A6 RID: 5798
		// (get) Token: 0x060049C5 RID: 18885 RVA: 0x0008C444 File Offset: 0x0008A644
		// (set) Token: 0x060049C6 RID: 18886 RVA: 0x0008C470 File Offset: 0x0008A670
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

		// Token: 0x170016A7 RID: 5799
		// (get) Token: 0x060049C7 RID: 18887 RVA: 0x0008C480 File Offset: 0x0008A680
		// (set) Token: 0x060049C8 RID: 18888 RVA: 0x0008C4A0 File Offset: 0x0008A6A0
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

		// Token: 0x060049C9 RID: 18889 RVA: 0x0008C4E4 File Offset: 0x0008A6E4
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060049CA RID: 18890 RVA: 0x0008C4FC File Offset: 0x0008A6FC
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170016A8 RID: 5800
		// (get) Token: 0x060049CB RID: 18891 RVA: 0x0008C508 File Offset: 0x0008A708
		// (set) Token: 0x060049CC RID: 18892 RVA: 0x0008C538 File Offset: 0x0008A738
		[ProtoMember(5, IsRequired = false, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public float damage
		{
			get
			{
				return this._damage ?? 0f;
			}
			set
			{
				this._damage = new float?(value);
			}
		}

		// Token: 0x170016A9 RID: 5801
		// (get) Token: 0x060049CD RID: 18893 RVA: 0x0008C548 File Offset: 0x0008A748
		// (set) Token: 0x060049CE RID: 18894 RVA: 0x0008C568 File Offset: 0x0008A768
		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new float?(this.damage) : null);
				}
			}
		}

		// Token: 0x060049CF RID: 18895 RVA: 0x0008C5AC File Offset: 0x0008A7AC
		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		// Token: 0x060049D0 RID: 18896 RVA: 0x0008C5C4 File Offset: 0x0008A7C4
		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		// Token: 0x170016AA RID: 5802
		// (get) Token: 0x060049D1 RID: 18897 RVA: 0x0008C5D0 File Offset: 0x0008A7D0
		// (set) Token: 0x060049D2 RID: 18898 RVA: 0x0008C5FC File Offset: 0x0008A7FC
		[ProtoMember(6, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		// Token: 0x170016AB RID: 5803
		// (get) Token: 0x060049D3 RID: 18899 RVA: 0x0008C60C File Offset: 0x0008A80C
		// (set) Token: 0x060049D4 RID: 18900 RVA: 0x0008C62C File Offset: 0x0008A82C
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x060049D5 RID: 18901 RVA: 0x0008C670 File Offset: 0x0008A870
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x060049D6 RID: 18902 RVA: 0x0008C688 File Offset: 0x0008A888
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x170016AC RID: 5804
		// (get) Token: 0x060049D7 RID: 18903 RVA: 0x0008C694 File Offset: 0x0008A894
		// (set) Token: 0x060049D8 RID: 18904 RVA: 0x0008C6C0 File Offset: 0x0008A8C0
		[ProtoMember(7, IsRequired = false, Name = "flowercount", DataFormat = DataFormat.TwosComplement)]
		public uint flowercount
		{
			get
			{
				return this._flowercount ?? 0U;
			}
			set
			{
				this._flowercount = new uint?(value);
			}
		}

		// Token: 0x170016AD RID: 5805
		// (get) Token: 0x060049D9 RID: 18905 RVA: 0x0008C6D0 File Offset: 0x0008A8D0
		// (set) Token: 0x060049DA RID: 18906 RVA: 0x0008C6F0 File Offset: 0x0008A8F0
		[XmlIgnore]
		[Browsable(false)]
		public bool flowercountSpecified
		{
			get
			{
				return this._flowercount != null;
			}
			set
			{
				bool flag = value == (this._flowercount == null);
				if (flag)
				{
					this._flowercount = (value ? new uint?(this.flowercount) : null);
				}
			}
		}

		// Token: 0x060049DB RID: 18907 RVA: 0x0008C734 File Offset: 0x0008A934
		private bool ShouldSerializeflowercount()
		{
			return this.flowercountSpecified;
		}

		// Token: 0x060049DC RID: 18908 RVA: 0x0008C74C File Offset: 0x0008A94C
		private void Resetflowercount()
		{
			this.flowercountSpecified = false;
		}

		// Token: 0x170016AE RID: 5806
		// (get) Token: 0x060049DD RID: 18909 RVA: 0x0008C758 File Offset: 0x0008A958
		// (set) Token: 0x060049DE RID: 18910 RVA: 0x0008C784 File Offset: 0x0008A984
		[ProtoMember(8, IsRequired = false, Name = "Rank", DataFormat = DataFormat.TwosComplement)]
		public uint Rank
		{
			get
			{
				return this._Rank ?? 0U;
			}
			set
			{
				this._Rank = new uint?(value);
			}
		}

		// Token: 0x170016AF RID: 5807
		// (get) Token: 0x060049DF RID: 18911 RVA: 0x0008C794 File Offset: 0x0008A994
		// (set) Token: 0x060049E0 RID: 18912 RVA: 0x0008C7B4 File Offset: 0x0008A9B4
		[XmlIgnore]
		[Browsable(false)]
		public bool RankSpecified
		{
			get
			{
				return this._Rank != null;
			}
			set
			{
				bool flag = value == (this._Rank == null);
				if (flag)
				{
					this._Rank = (value ? new uint?(this.Rank) : null);
				}
			}
		}

		// Token: 0x060049E1 RID: 18913 RVA: 0x0008C7F8 File Offset: 0x0008A9F8
		private bool ShouldSerializeRank()
		{
			return this.RankSpecified;
		}

		// Token: 0x060049E2 RID: 18914 RVA: 0x0008C810 File Offset: 0x0008AA10
		private void ResetRank()
		{
			this.RankSpecified = false;
		}

		// Token: 0x170016B0 RID: 5808
		// (get) Token: 0x060049E3 RID: 18915 RVA: 0x0008C81C File Offset: 0x0008AA1C
		// (set) Token: 0x060049E4 RID: 18916 RVA: 0x0008C848 File Offset: 0x0008AA48
		[ProtoMember(9, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		// Token: 0x170016B1 RID: 5809
		// (get) Token: 0x060049E5 RID: 18917 RVA: 0x0008C858 File Offset: 0x0008AA58
		// (set) Token: 0x060049E6 RID: 18918 RVA: 0x0008C878 File Offset: 0x0008AA78
		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		// Token: 0x060049E7 RID: 18919 RVA: 0x0008C8BC File Offset: 0x0008AABC
		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		// Token: 0x060049E8 RID: 18920 RVA: 0x0008C8D4 File Offset: 0x0008AAD4
		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		// Token: 0x170016B2 RID: 5810
		// (get) Token: 0x060049E9 RID: 18921 RVA: 0x0008C8E0 File Offset: 0x0008AAE0
		// (set) Token: 0x060049EA RID: 18922 RVA: 0x0008C901 File Offset: 0x0008AB01
		[ProtoMember(10, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x170016B3 RID: 5811
		// (get) Token: 0x060049EB RID: 18923 RVA: 0x0008C90C File Offset: 0x0008AB0C
		// (set) Token: 0x060049EC RID: 18924 RVA: 0x0008C928 File Offset: 0x0008AB28
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x060049ED RID: 18925 RVA: 0x0008C958 File Offset: 0x0008AB58
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x060049EE RID: 18926 RVA: 0x0008C970 File Offset: 0x0008AB70
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x170016B4 RID: 5812
		// (get) Token: 0x060049EF RID: 18927 RVA: 0x0008C97C File Offset: 0x0008AB7C
		// (set) Token: 0x060049F0 RID: 18928 RVA: 0x0008C9A8 File Offset: 0x0008ABA8
		[ProtoMember(11, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170016B5 RID: 5813
		// (get) Token: 0x060049F1 RID: 18929 RVA: 0x0008C9B8 File Offset: 0x0008ABB8
		// (set) Token: 0x060049F2 RID: 18930 RVA: 0x0008C9D8 File Offset: 0x0008ABD8
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

		// Token: 0x060049F3 RID: 18931 RVA: 0x0008CA1C File Offset: 0x0008AC1C
		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		// Token: 0x060049F4 RID: 18932 RVA: 0x0008CA34 File Offset: 0x0008AC34
		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		// Token: 0x170016B6 RID: 5814
		// (get) Token: 0x060049F5 RID: 18933 RVA: 0x0008CA40 File Offset: 0x0008AC40
		// (set) Token: 0x060049F6 RID: 18934 RVA: 0x0008CA6C File Offset: 0x0008AC6C
		[ProtoMember(12, IsRequired = false, Name = "tshowvotecount", DataFormat = DataFormat.TwosComplement)]
		public uint tshowvotecount
		{
			get
			{
				return this._tshowvotecount ?? 0U;
			}
			set
			{
				this._tshowvotecount = new uint?(value);
			}
		}

		// Token: 0x170016B7 RID: 5815
		// (get) Token: 0x060049F7 RID: 18935 RVA: 0x0008CA7C File Offset: 0x0008AC7C
		// (set) Token: 0x060049F8 RID: 18936 RVA: 0x0008CA9C File Offset: 0x0008AC9C
		[XmlIgnore]
		[Browsable(false)]
		public bool tshowvotecountSpecified
		{
			get
			{
				return this._tshowvotecount != null;
			}
			set
			{
				bool flag = value == (this._tshowvotecount == null);
				if (flag)
				{
					this._tshowvotecount = (value ? new uint?(this.tshowvotecount) : null);
				}
			}
		}

		// Token: 0x060049F9 RID: 18937 RVA: 0x0008CAE0 File Offset: 0x0008ACE0
		private bool ShouldSerializetshowvotecount()
		{
			return this.tshowvotecountSpecified;
		}

		// Token: 0x060049FA RID: 18938 RVA: 0x0008CAF8 File Offset: 0x0008ACF8
		private void Resettshowvotecount()
		{
			this.tshowvotecountSpecified = false;
		}

		// Token: 0x170016B8 RID: 5816
		// (get) Token: 0x060049FB RID: 18939 RVA: 0x0008CB04 File Offset: 0x0008AD04
		// (set) Token: 0x060049FC RID: 18940 RVA: 0x0008CB30 File Offset: 0x0008AD30
		[ProtoMember(13, IsRequired = false, Name = "intervaltimestamp", DataFormat = DataFormat.TwosComplement)]
		public uint intervaltimestamp
		{
			get
			{
				return this._intervaltimestamp ?? 0U;
			}
			set
			{
				this._intervaltimestamp = new uint?(value);
			}
		}

		// Token: 0x170016B9 RID: 5817
		// (get) Token: 0x060049FD RID: 18941 RVA: 0x0008CB40 File Offset: 0x0008AD40
		// (set) Token: 0x060049FE RID: 18942 RVA: 0x0008CB60 File Offset: 0x0008AD60
		[XmlIgnore]
		[Browsable(false)]
		public bool intervaltimestampSpecified
		{
			get
			{
				return this._intervaltimestamp != null;
			}
			set
			{
				bool flag = value == (this._intervaltimestamp == null);
				if (flag)
				{
					this._intervaltimestamp = (value ? new uint?(this.intervaltimestamp) : null);
				}
			}
		}

		// Token: 0x060049FF RID: 18943 RVA: 0x0008CBA4 File Offset: 0x0008ADA4
		private bool ShouldSerializeintervaltimestamp()
		{
			return this.intervaltimestampSpecified;
		}

		// Token: 0x06004A00 RID: 18944 RVA: 0x0008CBBC File Offset: 0x0008ADBC
		private void Resetintervaltimestamp()
		{
			this.intervaltimestampSpecified = false;
		}

		// Token: 0x170016BA RID: 5818
		// (get) Token: 0x06004A01 RID: 18945 RVA: 0x0008CBC8 File Offset: 0x0008ADC8
		// (set) Token: 0x06004A02 RID: 18946 RVA: 0x0008CBF4 File Offset: 0x0008ADF4
		[ProtoMember(14, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170016BB RID: 5819
		// (get) Token: 0x06004A03 RID: 18947 RVA: 0x0008CC04 File Offset: 0x0008AE04
		// (set) Token: 0x06004A04 RID: 18948 RVA: 0x0008CC24 File Offset: 0x0008AE24
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

		// Token: 0x06004A05 RID: 18949 RVA: 0x0008CC68 File Offset: 0x0008AE68
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x0008CC80 File Offset: 0x0008AE80
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170016BC RID: 5820
		// (get) Token: 0x06004A07 RID: 18951 RVA: 0x0008CC8C File Offset: 0x0008AE8C
		[ProtoMember(15, Name = "RoleIds", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RoleIds
		{
			get
			{
				return this._RoleIds;
			}
		}

		// Token: 0x170016BD RID: 5821
		// (get) Token: 0x06004A08 RID: 18952 RVA: 0x0008CCA4 File Offset: 0x0008AEA4
		[ProtoMember(16, Name = "RoleNames", DataFormat = DataFormat.Default)]
		public List<string> RoleNames
		{
			get
			{
				return this._RoleNames;
			}
		}

		// Token: 0x170016BE RID: 5822
		// (get) Token: 0x06004A09 RID: 18953 RVA: 0x0008CCBC File Offset: 0x0008AEBC
		// (set) Token: 0x06004A0A RID: 18954 RVA: 0x0008CCE8 File Offset: 0x0008AEE8
		[ProtoMember(17, IsRequired = false, Name = "towerHardLevel", DataFormat = DataFormat.TwosComplement)]
		public uint towerHardLevel
		{
			get
			{
				return this._towerHardLevel ?? 0U;
			}
			set
			{
				this._towerHardLevel = new uint?(value);
			}
		}

		// Token: 0x170016BF RID: 5823
		// (get) Token: 0x06004A0B RID: 18955 RVA: 0x0008CCF8 File Offset: 0x0008AEF8
		// (set) Token: 0x06004A0C RID: 18956 RVA: 0x0008CD18 File Offset: 0x0008AF18
		[XmlIgnore]
		[Browsable(false)]
		public bool towerHardLevelSpecified
		{
			get
			{
				return this._towerHardLevel != null;
			}
			set
			{
				bool flag = value == (this._towerHardLevel == null);
				if (flag)
				{
					this._towerHardLevel = (value ? new uint?(this.towerHardLevel) : null);
				}
			}
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x0008CD5C File Offset: 0x0008AF5C
		private bool ShouldSerializetowerHardLevel()
		{
			return this.towerHardLevelSpecified;
		}

		// Token: 0x06004A0E RID: 18958 RVA: 0x0008CD74 File Offset: 0x0008AF74
		private void ResettowerHardLevel()
		{
			this.towerHardLevelSpecified = false;
		}

		// Token: 0x170016C0 RID: 5824
		// (get) Token: 0x06004A0F RID: 18959 RVA: 0x0008CD80 File Offset: 0x0008AF80
		// (set) Token: 0x06004A10 RID: 18960 RVA: 0x0008CDAC File Offset: 0x0008AFAC
		[ProtoMember(18, IsRequired = false, Name = "towerFloor", DataFormat = DataFormat.TwosComplement)]
		public uint towerFloor
		{
			get
			{
				return this._towerFloor ?? 0U;
			}
			set
			{
				this._towerFloor = new uint?(value);
			}
		}

		// Token: 0x170016C1 RID: 5825
		// (get) Token: 0x06004A11 RID: 18961 RVA: 0x0008CDBC File Offset: 0x0008AFBC
		// (set) Token: 0x06004A12 RID: 18962 RVA: 0x0008CDDC File Offset: 0x0008AFDC
		[XmlIgnore]
		[Browsable(false)]
		public bool towerFloorSpecified
		{
			get
			{
				return this._towerFloor != null;
			}
			set
			{
				bool flag = value == (this._towerFloor == null);
				if (flag)
				{
					this._towerFloor = (value ? new uint?(this.towerFloor) : null);
				}
			}
		}

		// Token: 0x06004A13 RID: 18963 RVA: 0x0008CE20 File Offset: 0x0008B020
		private bool ShouldSerializetowerFloor()
		{
			return this.towerFloorSpecified;
		}

		// Token: 0x06004A14 RID: 18964 RVA: 0x0008CE38 File Offset: 0x0008B038
		private void ResettowerFloor()
		{
			this.towerFloorSpecified = false;
		}

		// Token: 0x170016C2 RID: 5826
		// (get) Token: 0x06004A15 RID: 18965 RVA: 0x0008CE44 File Offset: 0x0008B044
		// (set) Token: 0x06004A16 RID: 18966 RVA: 0x0008CE70 File Offset: 0x0008B070
		[ProtoMember(19, IsRequired = false, Name = "towerThroughTime", DataFormat = DataFormat.TwosComplement)]
		public uint towerThroughTime
		{
			get
			{
				return this._towerThroughTime ?? 0U;
			}
			set
			{
				this._towerThroughTime = new uint?(value);
			}
		}

		// Token: 0x170016C3 RID: 5827
		// (get) Token: 0x06004A17 RID: 18967 RVA: 0x0008CE80 File Offset: 0x0008B080
		// (set) Token: 0x06004A18 RID: 18968 RVA: 0x0008CEA0 File Offset: 0x0008B0A0
		[XmlIgnore]
		[Browsable(false)]
		public bool towerThroughTimeSpecified
		{
			get
			{
				return this._towerThroughTime != null;
			}
			set
			{
				bool flag = value == (this._towerThroughTime == null);
				if (flag)
				{
					this._towerThroughTime = (value ? new uint?(this.towerThroughTime) : null);
				}
			}
		}

		// Token: 0x06004A19 RID: 18969 RVA: 0x0008CEE4 File Offset: 0x0008B0E4
		private bool ShouldSerializetowerThroughTime()
		{
			return this.towerThroughTimeSpecified;
		}

		// Token: 0x06004A1A RID: 18970 RVA: 0x0008CEFC File Offset: 0x0008B0FC
		private void ResettowerThroughTime()
		{
			this.towerThroughTimeSpecified = false;
		}

		// Token: 0x170016C4 RID: 5828
		// (get) Token: 0x06004A1B RID: 18971 RVA: 0x0008CF08 File Offset: 0x0008B108
		[ProtoMember(20, Name = "receiveFlowers", DataFormat = DataFormat.Default)]
		public List<MapIntItem> receiveFlowers
		{
			get
			{
				return this._receiveFlowers;
			}
		}

		// Token: 0x170016C5 RID: 5829
		// (get) Token: 0x06004A1C RID: 18972 RVA: 0x0008CF20 File Offset: 0x0008B120
		// (set) Token: 0x06004A1D RID: 18973 RVA: 0x0008CF4C File Offset: 0x0008B14C
		[ProtoMember(21, IsRequired = false, Name = "guildBossIndex", DataFormat = DataFormat.TwosComplement)]
		public uint guildBossIndex
		{
			get
			{
				return this._guildBossIndex ?? 0U;
			}
			set
			{
				this._guildBossIndex = new uint?(value);
			}
		}

		// Token: 0x170016C6 RID: 5830
		// (get) Token: 0x06004A1E RID: 18974 RVA: 0x0008CF5C File Offset: 0x0008B15C
		// (set) Token: 0x06004A1F RID: 18975 RVA: 0x0008CF7C File Offset: 0x0008B17C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossIndexSpecified
		{
			get
			{
				return this._guildBossIndex != null;
			}
			set
			{
				bool flag = value == (this._guildBossIndex == null);
				if (flag)
				{
					this._guildBossIndex = (value ? new uint?(this.guildBossIndex) : null);
				}
			}
		}

		// Token: 0x06004A20 RID: 18976 RVA: 0x0008CFC0 File Offset: 0x0008B1C0
		private bool ShouldSerializeguildBossIndex()
		{
			return this.guildBossIndexSpecified;
		}

		// Token: 0x06004A21 RID: 18977 RVA: 0x0008CFD8 File Offset: 0x0008B1D8
		private void ResetguildBossIndex()
		{
			this.guildBossIndexSpecified = false;
		}

		// Token: 0x170016C7 RID: 5831
		// (get) Token: 0x06004A22 RID: 18978 RVA: 0x0008CFE4 File Offset: 0x0008B1E4
		// (set) Token: 0x06004A23 RID: 18979 RVA: 0x0008D005 File Offset: 0x0008B205
		[ProtoMember(22, IsRequired = false, Name = "guildBossName", DataFormat = DataFormat.Default)]
		public string guildBossName
		{
			get
			{
				return this._guildBossName ?? "";
			}
			set
			{
				this._guildBossName = value;
			}
		}

		// Token: 0x170016C8 RID: 5832
		// (get) Token: 0x06004A24 RID: 18980 RVA: 0x0008D010 File Offset: 0x0008B210
		// (set) Token: 0x06004A25 RID: 18981 RVA: 0x0008D02C File Offset: 0x0008B22C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossNameSpecified
		{
			get
			{
				return this._guildBossName != null;
			}
			set
			{
				bool flag = value == (this._guildBossName == null);
				if (flag)
				{
					this._guildBossName = (value ? this.guildBossName : null);
				}
			}
		}

		// Token: 0x06004A26 RID: 18982 RVA: 0x0008D05C File Offset: 0x0008B25C
		private bool ShouldSerializeguildBossName()
		{
			return this.guildBossNameSpecified;
		}

		// Token: 0x06004A27 RID: 18983 RVA: 0x0008D074 File Offset: 0x0008B274
		private void ResetguildBossName()
		{
			this.guildBossNameSpecified = false;
		}

		// Token: 0x170016C9 RID: 5833
		// (get) Token: 0x06004A28 RID: 18984 RVA: 0x0008D080 File Offset: 0x0008B280
		// (set) Token: 0x06004A29 RID: 18985 RVA: 0x0008D0A1 File Offset: 0x0008B2A1
		[ProtoMember(23, IsRequired = false, Name = "guildBossDpsMax", DataFormat = DataFormat.Default)]
		public string guildBossDpsMax
		{
			get
			{
				return this._guildBossDpsMax ?? "";
			}
			set
			{
				this._guildBossDpsMax = value;
			}
		}

		// Token: 0x170016CA RID: 5834
		// (get) Token: 0x06004A2A RID: 18986 RVA: 0x0008D0AC File Offset: 0x0008B2AC
		// (set) Token: 0x06004A2B RID: 18987 RVA: 0x0008D0C8 File Offset: 0x0008B2C8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossDpsMaxSpecified
		{
			get
			{
				return this._guildBossDpsMax != null;
			}
			set
			{
				bool flag = value == (this._guildBossDpsMax == null);
				if (flag)
				{
					this._guildBossDpsMax = (value ? this.guildBossDpsMax : null);
				}
			}
		}

		// Token: 0x06004A2C RID: 18988 RVA: 0x0008D0F8 File Offset: 0x0008B2F8
		private bool ShouldSerializeguildBossDpsMax()
		{
			return this.guildBossDpsMaxSpecified;
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x0008D110 File Offset: 0x0008B310
		private void ResetguildBossDpsMax()
		{
			this.guildBossDpsMaxSpecified = false;
		}

		// Token: 0x170016CB RID: 5835
		// (get) Token: 0x06004A2E RID: 18990 RVA: 0x0008D11C File Offset: 0x0008B31C
		// (set) Token: 0x06004A2F RID: 18991 RVA: 0x0008D148 File Offset: 0x0008B348
		[ProtoMember(24, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		// Token: 0x170016CC RID: 5836
		// (get) Token: 0x06004A30 RID: 18992 RVA: 0x0008D158 File Offset: 0x0008B358
		// (set) Token: 0x06004A31 RID: 18993 RVA: 0x0008D178 File Offset: 0x0008B378
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		// Token: 0x06004A32 RID: 18994 RVA: 0x0008D1BC File Offset: 0x0008B3BC
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x06004A33 RID: 18995 RVA: 0x0008D1D4 File Offset: 0x0008B3D4
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x170016CD RID: 5837
		// (get) Token: 0x06004A34 RID: 18996 RVA: 0x0008D1E0 File Offset: 0x0008B3E0
		[ProtoMember(25, Name = "titleIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> titleIDs
		{
			get
			{
				return this._titleIDs;
			}
		}

		// Token: 0x170016CE RID: 5838
		// (get) Token: 0x06004A35 RID: 18997 RVA: 0x0008D1F8 File Offset: 0x0008B3F8
		// (set) Token: 0x06004A36 RID: 18998 RVA: 0x0008D224 File Offset: 0x0008B424
		[ProtoMember(26, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		// Token: 0x170016CF RID: 5839
		// (get) Token: 0x06004A37 RID: 18999 RVA: 0x0008D234 File Offset: 0x0008B434
		// (set) Token: 0x06004A38 RID: 19000 RVA: 0x0008D254 File Offset: 0x0008B454
		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		// Token: 0x06004A39 RID: 19001 RVA: 0x0008D298 File Offset: 0x0008B498
		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		// Token: 0x06004A3A RID: 19002 RVA: 0x0008D2B0 File Offset: 0x0008B4B0
		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		// Token: 0x170016D0 RID: 5840
		// (get) Token: 0x06004A3B RID: 19003 RVA: 0x0008D2BC File Offset: 0x0008B4BC
		// (set) Token: 0x06004A3C RID: 19004 RVA: 0x0008D2E8 File Offset: 0x0008B4E8
		[ProtoMember(27, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x170016D1 RID: 5841
		// (get) Token: 0x06004A3D RID: 19005 RVA: 0x0008D2F8 File Offset: 0x0008B4F8
		// (set) Token: 0x06004A3E RID: 19006 RVA: 0x0008D318 File Offset: 0x0008B518
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06004A3F RID: 19007 RVA: 0x0008D35C File Offset: 0x0008B55C
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06004A40 RID: 19008 RVA: 0x0008D374 File Offset: 0x0008B574
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x170016D2 RID: 5842
		// (get) Token: 0x06004A41 RID: 19009 RVA: 0x0008D380 File Offset: 0x0008B580
		// (set) Token: 0x06004A42 RID: 19010 RVA: 0x0008D3AC File Offset: 0x0008B5AC
		[ProtoMember(28, IsRequired = false, Name = "bossavghppercent", DataFormat = DataFormat.TwosComplement)]
		public uint bossavghppercent
		{
			get
			{
				return this._bossavghppercent ?? 0U;
			}
			set
			{
				this._bossavghppercent = new uint?(value);
			}
		}

		// Token: 0x170016D3 RID: 5843
		// (get) Token: 0x06004A43 RID: 19011 RVA: 0x0008D3BC File Offset: 0x0008B5BC
		// (set) Token: 0x06004A44 RID: 19012 RVA: 0x0008D3DC File Offset: 0x0008B5DC
		[XmlIgnore]
		[Browsable(false)]
		public bool bossavghppercentSpecified
		{
			get
			{
				return this._bossavghppercent != null;
			}
			set
			{
				bool flag = value == (this._bossavghppercent == null);
				if (flag)
				{
					this._bossavghppercent = (value ? new uint?(this.bossavghppercent) : null);
				}
			}
		}

		// Token: 0x06004A45 RID: 19013 RVA: 0x0008D420 File Offset: 0x0008B620
		private bool ShouldSerializebossavghppercent()
		{
			return this.bossavghppercentSpecified;
		}

		// Token: 0x06004A46 RID: 19014 RVA: 0x0008D438 File Offset: 0x0008B638
		private void Resetbossavghppercent()
		{
			this.bossavghppercentSpecified = false;
		}

		// Token: 0x170016D4 RID: 5844
		// (get) Token: 0x06004A47 RID: 19015 RVA: 0x0008D444 File Offset: 0x0008B644
		// (set) Token: 0x06004A48 RID: 19016 RVA: 0x0008D470 File Offset: 0x0008B670
		[ProtoMember(29, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public int groupid
		{
			get
			{
				return this._groupid ?? 0;
			}
			set
			{
				this._groupid = new int?(value);
			}
		}

		// Token: 0x170016D5 RID: 5845
		// (get) Token: 0x06004A49 RID: 19017 RVA: 0x0008D480 File Offset: 0x0008B680
		// (set) Token: 0x06004A4A RID: 19018 RVA: 0x0008D4A0 File Offset: 0x0008B6A0
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new int?(this.groupid) : null);
				}
			}
		}

		// Token: 0x06004A4B RID: 19019 RVA: 0x0008D4E4 File Offset: 0x0008B6E4
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x06004A4C RID: 19020 RVA: 0x0008D4FC File Offset: 0x0008B6FC
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x170016D6 RID: 5846
		// (get) Token: 0x06004A4D RID: 19021 RVA: 0x0008D508 File Offset: 0x0008B708
		// (set) Token: 0x06004A4E RID: 19022 RVA: 0x0008D535 File Offset: 0x0008B735
		[ProtoMember(30, IsRequired = false, Name = "petuid", DataFormat = DataFormat.TwosComplement)]
		public ulong petuid
		{
			get
			{
				return this._petuid ?? 0UL;
			}
			set
			{
				this._petuid = new ulong?(value);
			}
		}

		// Token: 0x170016D7 RID: 5847
		// (get) Token: 0x06004A4F RID: 19023 RVA: 0x0008D544 File Offset: 0x0008B744
		// (set) Token: 0x06004A50 RID: 19024 RVA: 0x0008D564 File Offset: 0x0008B764
		[XmlIgnore]
		[Browsable(false)]
		public bool petuidSpecified
		{
			get
			{
				return this._petuid != null;
			}
			set
			{
				bool flag = value == (this._petuid == null);
				if (flag)
				{
					this._petuid = (value ? new ulong?(this.petuid) : null);
				}
			}
		}

		// Token: 0x06004A51 RID: 19025 RVA: 0x0008D5A8 File Offset: 0x0008B7A8
		private bool ShouldSerializepetuid()
		{
			return this.petuidSpecified;
		}

		// Token: 0x06004A52 RID: 19026 RVA: 0x0008D5C0 File Offset: 0x0008B7C0
		private void Resetpetuid()
		{
			this.petuidSpecified = false;
		}

		// Token: 0x170016D8 RID: 5848
		// (get) Token: 0x06004A53 RID: 19027 RVA: 0x0008D5CC File Offset: 0x0008B7CC
		// (set) Token: 0x06004A54 RID: 19028 RVA: 0x0008D5F8 File Offset: 0x0008B7F8
		[ProtoMember(31, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public uint petid
		{
			get
			{
				return this._petid ?? 0U;
			}
			set
			{
				this._petid = new uint?(value);
			}
		}

		// Token: 0x170016D9 RID: 5849
		// (get) Token: 0x06004A55 RID: 19029 RVA: 0x0008D608 File Offset: 0x0008B808
		// (set) Token: 0x06004A56 RID: 19030 RVA: 0x0008D628 File Offset: 0x0008B828
		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new uint?(this.petid) : null);
				}
			}
		}

		// Token: 0x06004A57 RID: 19031 RVA: 0x0008D66C File Offset: 0x0008B86C
		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		// Token: 0x06004A58 RID: 19032 RVA: 0x0008D684 File Offset: 0x0008B884
		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		// Token: 0x170016DA RID: 5850
		// (get) Token: 0x06004A59 RID: 19033 RVA: 0x0008D690 File Offset: 0x0008B890
		// (set) Token: 0x06004A5A RID: 19034 RVA: 0x0008D6B1 File Offset: 0x0008B8B1
		[ProtoMember(32, IsRequired = false, Name = "headpic", DataFormat = DataFormat.Default)]
		public string headpic
		{
			get
			{
				return this._headpic ?? "";
			}
			set
			{
				this._headpic = value;
			}
		}

		// Token: 0x170016DB RID: 5851
		// (get) Token: 0x06004A5B RID: 19035 RVA: 0x0008D6BC File Offset: 0x0008B8BC
		// (set) Token: 0x06004A5C RID: 19036 RVA: 0x0008D6D8 File Offset: 0x0008B8D8
		[XmlIgnore]
		[Browsable(false)]
		public bool headpicSpecified
		{
			get
			{
				return this._headpic != null;
			}
			set
			{
				bool flag = value == (this._headpic == null);
				if (flag)
				{
					this._headpic = (value ? this.headpic : null);
				}
			}
		}

		// Token: 0x06004A5D RID: 19037 RVA: 0x0008D708 File Offset: 0x0008B908
		private bool ShouldSerializeheadpic()
		{
			return this.headpicSpecified;
		}

		// Token: 0x06004A5E RID: 19038 RVA: 0x0008D720 File Offset: 0x0008B920
		private void Resetheadpic()
		{
			this.headpicSpecified = false;
		}

		// Token: 0x170016DC RID: 5852
		// (get) Token: 0x06004A5F RID: 19039 RVA: 0x0008D72C File Offset: 0x0008B92C
		// (set) Token: 0x06004A60 RID: 19040 RVA: 0x0008D758 File Offset: 0x0008B958
		[ProtoMember(33, IsRequired = false, Name = "starttype", DataFormat = DataFormat.TwosComplement)]
		public StartUpType starttype
		{
			get
			{
				return this._starttype ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._starttype = new StartUpType?(value);
			}
		}

		// Token: 0x170016DD RID: 5853
		// (get) Token: 0x06004A61 RID: 19041 RVA: 0x0008D768 File Offset: 0x0008B968
		// (set) Token: 0x06004A62 RID: 19042 RVA: 0x0008D788 File Offset: 0x0008B988
		[XmlIgnore]
		[Browsable(false)]
		public bool starttypeSpecified
		{
			get
			{
				return this._starttype != null;
			}
			set
			{
				bool flag = value == (this._starttype == null);
				if (flag)
				{
					this._starttype = (value ? new StartUpType?(this.starttype) : null);
				}
			}
		}

		// Token: 0x06004A63 RID: 19043 RVA: 0x0008D7CC File Offset: 0x0008B9CC
		private bool ShouldSerializestarttype()
		{
			return this.starttypeSpecified;
		}

		// Token: 0x06004A64 RID: 19044 RVA: 0x0008D7E4 File Offset: 0x0008B9E4
		private void Resetstarttype()
		{
			this.starttypeSpecified = false;
		}

		// Token: 0x170016DE RID: 5854
		// (get) Token: 0x06004A65 RID: 19045 RVA: 0x0008D7F0 File Offset: 0x0008B9F0
		// (set) Token: 0x06004A66 RID: 19046 RVA: 0x0008D81C File Offset: 0x0008BA1C
		[ProtoMember(34, IsRequired = false, Name = "is_vip", DataFormat = DataFormat.Default)]
		public bool is_vip
		{
			get
			{
				return this._is_vip ?? false;
			}
			set
			{
				this._is_vip = new bool?(value);
			}
		}

		// Token: 0x170016DF RID: 5855
		// (get) Token: 0x06004A67 RID: 19047 RVA: 0x0008D82C File Offset: 0x0008BA2C
		// (set) Token: 0x06004A68 RID: 19048 RVA: 0x0008D84C File Offset: 0x0008BA4C
		[XmlIgnore]
		[Browsable(false)]
		public bool is_vipSpecified
		{
			get
			{
				return this._is_vip != null;
			}
			set
			{
				bool flag = value == (this._is_vip == null);
				if (flag)
				{
					this._is_vip = (value ? new bool?(this.is_vip) : null);
				}
			}
		}

		// Token: 0x06004A69 RID: 19049 RVA: 0x0008D890 File Offset: 0x0008BA90
		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		// Token: 0x06004A6A RID: 19050 RVA: 0x0008D8A8 File Offset: 0x0008BAA8
		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		// Token: 0x170016E0 RID: 5856
		// (get) Token: 0x06004A6B RID: 19051 RVA: 0x0008D8B4 File Offset: 0x0008BAB4
		// (set) Token: 0x06004A6C RID: 19052 RVA: 0x0008D8E0 File Offset: 0x0008BAE0
		[ProtoMember(35, IsRequired = false, Name = "is_svip", DataFormat = DataFormat.Default)]
		public bool is_svip
		{
			get
			{
				return this._is_svip ?? false;
			}
			set
			{
				this._is_svip = new bool?(value);
			}
		}

		// Token: 0x170016E1 RID: 5857
		// (get) Token: 0x06004A6D RID: 19053 RVA: 0x0008D8F0 File Offset: 0x0008BAF0
		// (set) Token: 0x06004A6E RID: 19054 RVA: 0x0008D910 File Offset: 0x0008BB10
		[XmlIgnore]
		[Browsable(false)]
		public bool is_svipSpecified
		{
			get
			{
				return this._is_svip != null;
			}
			set
			{
				bool flag = value == (this._is_svip == null);
				if (flag)
				{
					this._is_svip = (value ? new bool?(this.is_svip) : null);
				}
			}
		}

		// Token: 0x06004A6F RID: 19055 RVA: 0x0008D954 File Offset: 0x0008BB54
		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		// Token: 0x06004A70 RID: 19056 RVA: 0x0008D96C File Offset: 0x0008BB6C
		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		// Token: 0x170016E2 RID: 5858
		// (get) Token: 0x06004A71 RID: 19057 RVA: 0x0008D978 File Offset: 0x0008BB78
		// (set) Token: 0x06004A72 RID: 19058 RVA: 0x0008D9A4 File Offset: 0x0008BBA4
		[ProtoMember(36, IsRequired = false, Name = "usetime", DataFormat = DataFormat.TwosComplement)]
		public uint usetime
		{
			get
			{
				return this._usetime ?? 0U;
			}
			set
			{
				this._usetime = new uint?(value);
			}
		}

		// Token: 0x170016E3 RID: 5859
		// (get) Token: 0x06004A73 RID: 19059 RVA: 0x0008D9B4 File Offset: 0x0008BBB4
		// (set) Token: 0x06004A74 RID: 19060 RVA: 0x0008D9D4 File Offset: 0x0008BBD4
		[XmlIgnore]
		[Browsable(false)]
		public bool usetimeSpecified
		{
			get
			{
				return this._usetime != null;
			}
			set
			{
				bool flag = value == (this._usetime == null);
				if (flag)
				{
					this._usetime = (value ? new uint?(this.usetime) : null);
				}
			}
		}

		// Token: 0x06004A75 RID: 19061 RVA: 0x0008DA18 File Offset: 0x0008BC18
		private bool ShouldSerializeusetime()
		{
			return this.usetimeSpecified;
		}

		// Token: 0x06004A76 RID: 19062 RVA: 0x0008DA30 File Offset: 0x0008BC30
		private void Resetusetime()
		{
			this.usetimeSpecified = false;
		}

		// Token: 0x170016E4 RID: 5860
		// (get) Token: 0x06004A77 RID: 19063 RVA: 0x0008DA3C File Offset: 0x0008BC3C
		// (set) Token: 0x06004A78 RID: 19064 RVA: 0x0008DA54 File Offset: 0x0008BC54
		[ProtoMember(37, IsRequired = false, Name = "leagueinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueRankData leagueinfo
		{
			get
			{
				return this._leagueinfo;
			}
			set
			{
				this._leagueinfo = value;
			}
		}

		// Token: 0x170016E5 RID: 5861
		// (get) Token: 0x06004A79 RID: 19065 RVA: 0x0008DA60 File Offset: 0x0008BC60
		// (set) Token: 0x06004A7A RID: 19066 RVA: 0x0008DA78 File Offset: 0x0008BC78
		[ProtoMember(38, IsRequired = false, Name = "heroinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroRankData heroinfo
		{
			get
			{
				return this._heroinfo;
			}
			set
			{
				this._heroinfo = value;
			}
		}

		// Token: 0x170016E6 RID: 5862
		// (get) Token: 0x06004A7B RID: 19067 RVA: 0x0008DA84 File Offset: 0x0008BC84
		// (set) Token: 0x06004A7C RID: 19068 RVA: 0x0008DAA5 File Offset: 0x0008BCA5
		[ProtoMember(39, IsRequired = false, Name = "strRoleid", DataFormat = DataFormat.Default)]
		public string strRoleid
		{
			get
			{
				return this._strRoleid ?? "";
			}
			set
			{
				this._strRoleid = value;
			}
		}

		// Token: 0x170016E7 RID: 5863
		// (get) Token: 0x06004A7D RID: 19069 RVA: 0x0008DAB0 File Offset: 0x0008BCB0
		// (set) Token: 0x06004A7E RID: 19070 RVA: 0x0008DACC File Offset: 0x0008BCCC
		[XmlIgnore]
		[Browsable(false)]
		public bool strRoleidSpecified
		{
			get
			{
				return this._strRoleid != null;
			}
			set
			{
				bool flag = value == (this._strRoleid == null);
				if (flag)
				{
					this._strRoleid = (value ? this.strRoleid : null);
				}
			}
		}

		// Token: 0x06004A7F RID: 19071 RVA: 0x0008DAFC File Offset: 0x0008BCFC
		private bool ShouldSerializestrRoleid()
		{
			return this.strRoleidSpecified;
		}

		// Token: 0x06004A80 RID: 19072 RVA: 0x0008DB14 File Offset: 0x0008BD14
		private void ResetstrRoleid()
		{
			this.strRoleidSpecified = false;
		}

		// Token: 0x170016E8 RID: 5864
		// (get) Token: 0x06004A81 RID: 19073 RVA: 0x0008DB20 File Offset: 0x0008BD20
		// (set) Token: 0x06004A82 RID: 19074 RVA: 0x0008DB4C File Offset: 0x0008BD4C
		[ProtoMember(40, IsRequired = false, Name = "starlevel", DataFormat = DataFormat.TwosComplement)]
		public uint starlevel
		{
			get
			{
				return this._starlevel ?? 0U;
			}
			set
			{
				this._starlevel = new uint?(value);
			}
		}

		// Token: 0x170016E9 RID: 5865
		// (get) Token: 0x06004A83 RID: 19075 RVA: 0x0008DB5C File Offset: 0x0008BD5C
		// (set) Token: 0x06004A84 RID: 19076 RVA: 0x0008DB7C File Offset: 0x0008BD7C
		[XmlIgnore]
		[Browsable(false)]
		public bool starlevelSpecified
		{
			get
			{
				return this._starlevel != null;
			}
			set
			{
				bool flag = value == (this._starlevel == null);
				if (flag)
				{
					this._starlevel = (value ? new uint?(this.starlevel) : null);
				}
			}
		}

		// Token: 0x06004A85 RID: 19077 RVA: 0x0008DBC0 File Offset: 0x0008BDC0
		private bool ShouldSerializestarlevel()
		{
			return this.starlevelSpecified;
		}

		// Token: 0x06004A86 RID: 19078 RVA: 0x0008DBD8 File Offset: 0x0008BDD8
		private void Resetstarlevel()
		{
			this.starlevelSpecified = false;
		}

		// Token: 0x170016EA RID: 5866
		// (get) Token: 0x06004A87 RID: 19079 RVA: 0x0008DBE4 File Offset: 0x0008BDE4
		// (set) Token: 0x06004A88 RID: 19080 RVA: 0x0008DC10 File Offset: 0x0008BE10
		[ProtoMember(41, IsRequired = false, Name = "usectime", DataFormat = DataFormat.TwosComplement)]
		public uint usectime
		{
			get
			{
				return this._usectime ?? 0U;
			}
			set
			{
				this._usectime = new uint?(value);
			}
		}

		// Token: 0x170016EB RID: 5867
		// (get) Token: 0x06004A89 RID: 19081 RVA: 0x0008DC20 File Offset: 0x0008BE20
		// (set) Token: 0x06004A8A RID: 19082 RVA: 0x0008DC40 File Offset: 0x0008BE40
		[XmlIgnore]
		[Browsable(false)]
		public bool usectimeSpecified
		{
			get
			{
				return this._usectime != null;
			}
			set
			{
				bool flag = value == (this._usectime == null);
				if (flag)
				{
					this._usectime = (value ? new uint?(this.usectime) : null);
				}
			}
		}

		// Token: 0x06004A8B RID: 19083 RVA: 0x0008DC84 File Offset: 0x0008BE84
		private bool ShouldSerializeusectime()
		{
			return this.usectimeSpecified;
		}

		// Token: 0x06004A8C RID: 19084 RVA: 0x0008DC9C File Offset: 0x0008BE9C
		private void Resetusectime()
		{
			this.usectimeSpecified = false;
		}

		// Token: 0x170016EC RID: 5868
		// (get) Token: 0x06004A8D RID: 19085 RVA: 0x0008DCA8 File Offset: 0x0008BEA8
		// (set) Token: 0x06004A8E RID: 19086 RVA: 0x0008DCC0 File Offset: 0x0008BEC0
		[ProtoMember(42, IsRequired = false, Name = "military_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MilitaryRankData military_info
		{
			get
			{
				return this._military_info;
			}
			set
			{
				this._military_info = value;
			}
		}

		// Token: 0x170016ED RID: 5869
		// (get) Token: 0x06004A8F RID: 19087 RVA: 0x0008DCCC File Offset: 0x0008BECC
		// (set) Token: 0x06004A90 RID: 19088 RVA: 0x0008DCE4 File Offset: 0x0008BEE4
		[ProtoMember(43, IsRequired = false, Name = "pkextradata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRankExtraData pkextradata
		{
			get
			{
				return this._pkextradata;
			}
			set
			{
				this._pkextradata = value;
			}
		}

		// Token: 0x170016EE RID: 5870
		// (get) Token: 0x06004A91 RID: 19089 RVA: 0x0008DCF0 File Offset: 0x0008BEF0
		// (set) Token: 0x06004A92 RID: 19090 RVA: 0x0008DD08 File Offset: 0x0008BF08
		[ProtoMember(44, IsRequired = false, Name = "scdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCraftRankData scdata
		{
			get
			{
				return this._scdata;
			}
			set
			{
				this._scdata = value;
			}
		}

		// Token: 0x170016EF RID: 5871
		// (get) Token: 0x06004A93 RID: 19091 RVA: 0x0008DD14 File Offset: 0x0008BF14
		// (set) Token: 0x06004A94 RID: 19092 RVA: 0x0008DD2C File Offset: 0x0008BF2C
		[ProtoMember(45, IsRequired = false, Name = "survive", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SurviveRankData survive
		{
			get
			{
				return this._survive;
			}
			set
			{
				this._survive = value;
			}
		}

		// Token: 0x170016F0 RID: 5872
		// (get) Token: 0x06004A95 RID: 19093 RVA: 0x0008DD38 File Offset: 0x0008BF38
		// (set) Token: 0x06004A96 RID: 19094 RVA: 0x0008DD50 File Offset: 0x0008BF50
		[ProtoMember(46, IsRequired = false, Name = "skycity", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityRankData skycity
		{
			get
			{
				return this._skycity;
			}
			set
			{
				this._skycity = value;
			}
		}

		// Token: 0x170016F1 RID: 5873
		// (get) Token: 0x06004A97 RID: 19095 RVA: 0x0008DD5C File Offset: 0x0008BF5C
		// (set) Token: 0x06004A98 RID: 19096 RVA: 0x0008DD74 File Offset: 0x0008BF74
		[ProtoMember(47, IsRequired = false, Name = "riftRankData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiftRankData riftRankData
		{
			get
			{
				return this._riftRankData;
			}
			set
			{
				this._riftRankData = value;
			}
		}

		// Token: 0x170016F2 RID: 5874
		// (get) Token: 0x06004A99 RID: 19097 RVA: 0x0008DD80 File Offset: 0x0008BF80
		// (set) Token: 0x06004A9A RID: 19098 RVA: 0x0008DD98 File Offset: 0x0008BF98
		[ProtoMember(48, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x06004A9B RID: 19099 RVA: 0x0008DDA4 File Offset: 0x0008BFA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001265 RID: 4709
		private ulong? _RoleId;

		// Token: 0x04001266 RID: 4710
		private string _RoleName;

		// Token: 0x04001267 RID: 4711
		private uint? _RoleLevel;

		// Token: 0x04001268 RID: 4712
		private uint? _time;

		// Token: 0x04001269 RID: 4713
		private float? _damage;

		// Token: 0x0400126A RID: 4714
		private uint? _powerpoint;

		// Token: 0x0400126B RID: 4715
		private uint? _flowercount;

		// Token: 0x0400126C RID: 4716
		private uint? _Rank;

		// Token: 0x0400126D RID: 4717
		private uint? _guildicon;

		// Token: 0x0400126E RID: 4718
		private string _guildname;

		// Token: 0x0400126F RID: 4719
		private uint? _pkpoint;

		// Token: 0x04001270 RID: 4720
		private uint? _tshowvotecount;

		// Token: 0x04001271 RID: 4721
		private uint? _intervaltimestamp;

		// Token: 0x04001272 RID: 4722
		private uint? _profession;

		// Token: 0x04001273 RID: 4723
		private readonly List<ulong> _RoleIds = new List<ulong>();

		// Token: 0x04001274 RID: 4724
		private readonly List<string> _RoleNames = new List<string>();

		// Token: 0x04001275 RID: 4725
		private uint? _towerHardLevel;

		// Token: 0x04001276 RID: 4726
		private uint? _towerFloor;

		// Token: 0x04001277 RID: 4727
		private uint? _towerThroughTime;

		// Token: 0x04001278 RID: 4728
		private readonly List<MapIntItem> _receiveFlowers = new List<MapIntItem>();

		// Token: 0x04001279 RID: 4729
		private uint? _guildBossIndex;

		// Token: 0x0400127A RID: 4730
		private string _guildBossName;

		// Token: 0x0400127B RID: 4731
		private string _guildBossDpsMax;

		// Token: 0x0400127C RID: 4732
		private uint? _titleID;

		// Token: 0x0400127D RID: 4733
		private readonly List<uint> _titleIDs = new List<uint>();

		// Token: 0x0400127E RID: 4734
		private int? _commendNum;

		// Token: 0x0400127F RID: 4735
		private uint? _sceneid;

		// Token: 0x04001280 RID: 4736
		private uint? _bossavghppercent;

		// Token: 0x04001281 RID: 4737
		private int? _groupid;

		// Token: 0x04001282 RID: 4738
		private ulong? _petuid;

		// Token: 0x04001283 RID: 4739
		private uint? _petid;

		// Token: 0x04001284 RID: 4740
		private string _headpic;

		// Token: 0x04001285 RID: 4741
		private StartUpType? _starttype;

		// Token: 0x04001286 RID: 4742
		private bool? _is_vip;

		// Token: 0x04001287 RID: 4743
		private bool? _is_svip;

		// Token: 0x04001288 RID: 4744
		private uint? _usetime;

		// Token: 0x04001289 RID: 4745
		private LeagueRankData _leagueinfo = null;

		// Token: 0x0400128A RID: 4746
		private HeroRankData _heroinfo = null;

		// Token: 0x0400128B RID: 4747
		private string _strRoleid;

		// Token: 0x0400128C RID: 4748
		private uint? _starlevel;

		// Token: 0x0400128D RID: 4749
		private uint? _usectime;

		// Token: 0x0400128E RID: 4750
		private MilitaryRankData _military_info = null;

		// Token: 0x0400128F RID: 4751
		private PkRankExtraData _pkextradata = null;

		// Token: 0x04001290 RID: 4752
		private SkyCraftRankData _scdata = null;

		// Token: 0x04001291 RID: 4753
		private SurviveRankData _survive = null;

		// Token: 0x04001292 RID: 4754
		private SkyCityRankData _skycity = null;

		// Token: 0x04001293 RID: 4755
		private RiftRankData _riftRankData = null;

		// Token: 0x04001294 RID: 4756
		private PayConsume _pre = null;

		// Token: 0x04001295 RID: 4757
		private IExtension extensionObject;
	}
}
