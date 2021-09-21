using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AD RID: 1197
	[ProtoContract(Name = "MyDragonGuild")]
	[Serializable]
	public class MyDragonGuild : IExtensible
	{
		// Token: 0x1700130F RID: 4879
		// (get) Token: 0x06003E3C RID: 15932 RVA: 0x00076B40 File Offset: 0x00074D40
		// (set) Token: 0x06003E3D RID: 15933 RVA: 0x00076B6D File Offset: 0x00074D6D
		[ProtoMember(1, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		// Token: 0x17001310 RID: 4880
		// (get) Token: 0x06003E3E RID: 15934 RVA: 0x00076B7C File Offset: 0x00074D7C
		// (set) Token: 0x06003E3F RID: 15935 RVA: 0x00076B9C File Offset: 0x00074D9C
		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		// Token: 0x06003E40 RID: 15936 RVA: 0x00076BE0 File Offset: 0x00074DE0
		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		// Token: 0x06003E41 RID: 15937 RVA: 0x00076BF8 File Offset: 0x00074DF8
		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		// Token: 0x17001311 RID: 4881
		// (get) Token: 0x06003E42 RID: 15938 RVA: 0x00076C04 File Offset: 0x00074E04
		// (set) Token: 0x06003E43 RID: 15939 RVA: 0x00076C30 File Offset: 0x00074E30
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		// Token: 0x17001312 RID: 4882
		// (get) Token: 0x06003E44 RID: 15940 RVA: 0x00076C40 File Offset: 0x00074E40
		// (set) Token: 0x06003E45 RID: 15941 RVA: 0x00076C60 File Offset: 0x00074E60
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		// Token: 0x06003E46 RID: 15942 RVA: 0x00076CA4 File Offset: 0x00074EA4
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06003E47 RID: 15943 RVA: 0x00076CBC File Offset: 0x00074EBC
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x17001313 RID: 4883
		// (get) Token: 0x06003E48 RID: 15944 RVA: 0x00076CC8 File Offset: 0x00074EC8
		// (set) Token: 0x06003E49 RID: 15945 RVA: 0x00076CF4 File Offset: 0x00074EF4
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17001314 RID: 4884
		// (get) Token: 0x06003E4A RID: 15946 RVA: 0x00076D04 File Offset: 0x00074F04
		// (set) Token: 0x06003E4B RID: 15947 RVA: 0x00076D24 File Offset: 0x00074F24
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06003E4C RID: 15948 RVA: 0x00076D68 File Offset: 0x00074F68
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06003E4D RID: 15949 RVA: 0x00076D80 File Offset: 0x00074F80
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001315 RID: 4885
		// (get) Token: 0x06003E4E RID: 15950 RVA: 0x00076D8C File Offset: 0x00074F8C
		// (set) Token: 0x06003E4F RID: 15951 RVA: 0x00076DAD File Offset: 0x00074FAD
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001316 RID: 4886
		// (get) Token: 0x06003E50 RID: 15952 RVA: 0x00076DB8 File Offset: 0x00074FB8
		// (set) Token: 0x06003E51 RID: 15953 RVA: 0x00076DD4 File Offset: 0x00074FD4
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

		// Token: 0x06003E52 RID: 15954 RVA: 0x00076E04 File Offset: 0x00075004
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003E53 RID: 15955 RVA: 0x00076E1C File Offset: 0x0007501C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001317 RID: 4887
		// (get) Token: 0x06003E54 RID: 15956 RVA: 0x00076E28 File Offset: 0x00075028
		// (set) Token: 0x06003E55 RID: 15957 RVA: 0x00076E55 File Offset: 0x00075055
		[ProtoMember(5, IsRequired = false, Name = "totalPPT", DataFormat = DataFormat.TwosComplement)]
		public ulong totalPPT
		{
			get
			{
				return this._totalPPT ?? 0UL;
			}
			set
			{
				this._totalPPT = new ulong?(value);
			}
		}

		// Token: 0x17001318 RID: 4888
		// (get) Token: 0x06003E56 RID: 15958 RVA: 0x00076E64 File Offset: 0x00075064
		// (set) Token: 0x06003E57 RID: 15959 RVA: 0x00076E84 File Offset: 0x00075084
		[XmlIgnore]
		[Browsable(false)]
		public bool totalPPTSpecified
		{
			get
			{
				return this._totalPPT != null;
			}
			set
			{
				bool flag = value == (this._totalPPT == null);
				if (flag)
				{
					this._totalPPT = (value ? new ulong?(this.totalPPT) : null);
				}
			}
		}

		// Token: 0x06003E58 RID: 15960 RVA: 0x00076EC8 File Offset: 0x000750C8
		private bool ShouldSerializetotalPPT()
		{
			return this.totalPPTSpecified;
		}

		// Token: 0x06003E59 RID: 15961 RVA: 0x00076EE0 File Offset: 0x000750E0
		private void ResettotalPPT()
		{
			this.totalPPTSpecified = false;
		}

		// Token: 0x17001319 RID: 4889
		// (get) Token: 0x06003E5A RID: 15962 RVA: 0x00076EEC File Offset: 0x000750EC
		// (set) Token: 0x06003E5B RID: 15963 RVA: 0x00076F18 File Offset: 0x00075118
		[ProtoMember(6, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public uint capacity
		{
			get
			{
				return this._capacity ?? 0U;
			}
			set
			{
				this._capacity = new uint?(value);
			}
		}

		// Token: 0x1700131A RID: 4890
		// (get) Token: 0x06003E5C RID: 15964 RVA: 0x00076F28 File Offset: 0x00075128
		// (set) Token: 0x06003E5D RID: 15965 RVA: 0x00076F48 File Offset: 0x00075148
		[XmlIgnore]
		[Browsable(false)]
		public bool capacitySpecified
		{
			get
			{
				return this._capacity != null;
			}
			set
			{
				bool flag = value == (this._capacity == null);
				if (flag)
				{
					this._capacity = (value ? new uint?(this.capacity) : null);
				}
			}
		}

		// Token: 0x06003E5E RID: 15966 RVA: 0x00076F8C File Offset: 0x0007518C
		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		// Token: 0x06003E5F RID: 15967 RVA: 0x00076FA4 File Offset: 0x000751A4
		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		// Token: 0x1700131B RID: 4891
		// (get) Token: 0x06003E60 RID: 15968 RVA: 0x00076FB0 File Offset: 0x000751B0
		// (set) Token: 0x06003E61 RID: 15969 RVA: 0x00076FDC File Offset: 0x000751DC
		[ProtoMember(7, IsRequired = false, Name = "memberCount", DataFormat = DataFormat.TwosComplement)]
		public uint memberCount
		{
			get
			{
				return this._memberCount ?? 0U;
			}
			set
			{
				this._memberCount = new uint?(value);
			}
		}

		// Token: 0x1700131C RID: 4892
		// (get) Token: 0x06003E62 RID: 15970 RVA: 0x00076FEC File Offset: 0x000751EC
		// (set) Token: 0x06003E63 RID: 15971 RVA: 0x0007700C File Offset: 0x0007520C
		[XmlIgnore]
		[Browsable(false)]
		public bool memberCountSpecified
		{
			get
			{
				return this._memberCount != null;
			}
			set
			{
				bool flag = value == (this._memberCount == null);
				if (flag)
				{
					this._memberCount = (value ? new uint?(this.memberCount) : null);
				}
			}
		}

		// Token: 0x06003E64 RID: 15972 RVA: 0x00077050 File Offset: 0x00075250
		private bool ShouldSerializememberCount()
		{
			return this.memberCountSpecified;
		}

		// Token: 0x06003E65 RID: 15973 RVA: 0x00077068 File Offset: 0x00075268
		private void ResetmemberCount()
		{
			this.memberCountSpecified = false;
		}

		// Token: 0x1700131D RID: 4893
		// (get) Token: 0x06003E66 RID: 15974 RVA: 0x00077074 File Offset: 0x00075274
		// (set) Token: 0x06003E67 RID: 15975 RVA: 0x000770A0 File Offset: 0x000752A0
		[ProtoMember(8, IsRequired = false, Name = "mapId", DataFormat = DataFormat.TwosComplement)]
		public uint mapId
		{
			get
			{
				return this._mapId ?? 0U;
			}
			set
			{
				this._mapId = new uint?(value);
			}
		}

		// Token: 0x1700131E RID: 4894
		// (get) Token: 0x06003E68 RID: 15976 RVA: 0x000770B0 File Offset: 0x000752B0
		// (set) Token: 0x06003E69 RID: 15977 RVA: 0x000770D0 File Offset: 0x000752D0
		[XmlIgnore]
		[Browsable(false)]
		public bool mapIdSpecified
		{
			get
			{
				return this._mapId != null;
			}
			set
			{
				bool flag = value == (this._mapId == null);
				if (flag)
				{
					this._mapId = (value ? new uint?(this.mapId) : null);
				}
			}
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x00077114 File Offset: 0x00075314
		private bool ShouldSerializemapId()
		{
			return this.mapIdSpecified;
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x0007712C File Offset: 0x0007532C
		private void ResetmapId()
		{
			this.mapIdSpecified = false;
		}

		// Token: 0x1700131F RID: 4895
		// (get) Token: 0x06003E6C RID: 15980 RVA: 0x00077138 File Offset: 0x00075338
		// (set) Token: 0x06003E6D RID: 15981 RVA: 0x00077164 File Offset: 0x00075364
		[ProtoMember(9, IsRequired = false, Name = "mapCnt", DataFormat = DataFormat.TwosComplement)]
		public uint mapCnt
		{
			get
			{
				return this._mapCnt ?? 0U;
			}
			set
			{
				this._mapCnt = new uint?(value);
			}
		}

		// Token: 0x17001320 RID: 4896
		// (get) Token: 0x06003E6E RID: 15982 RVA: 0x00077174 File Offset: 0x00075374
		// (set) Token: 0x06003E6F RID: 15983 RVA: 0x00077194 File Offset: 0x00075394
		[XmlIgnore]
		[Browsable(false)]
		public bool mapCntSpecified
		{
			get
			{
				return this._mapCnt != null;
			}
			set
			{
				bool flag = value == (this._mapCnt == null);
				if (flag)
				{
					this._mapCnt = (value ? new uint?(this.mapCnt) : null);
				}
			}
		}

		// Token: 0x06003E70 RID: 15984 RVA: 0x000771D8 File Offset: 0x000753D8
		private bool ShouldSerializemapCnt()
		{
			return this.mapCntSpecified;
		}

		// Token: 0x06003E71 RID: 15985 RVA: 0x000771F0 File Offset: 0x000753F0
		private void ResetmapCnt()
		{
			this.mapCntSpecified = false;
		}

		// Token: 0x17001321 RID: 4897
		// (get) Token: 0x06003E72 RID: 15986 RVA: 0x000771FC File Offset: 0x000753FC
		// (set) Token: 0x06003E73 RID: 15987 RVA: 0x00077228 File Offset: 0x00075428
		[ProtoMember(10, IsRequired = false, Name = "firstPassTime", DataFormat = DataFormat.TwosComplement)]
		public uint firstPassTime
		{
			get
			{
				return this._firstPassTime ?? 0U;
			}
			set
			{
				this._firstPassTime = new uint?(value);
			}
		}

		// Token: 0x17001322 RID: 4898
		// (get) Token: 0x06003E74 RID: 15988 RVA: 0x00077238 File Offset: 0x00075438
		// (set) Token: 0x06003E75 RID: 15989 RVA: 0x00077258 File Offset: 0x00075458
		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassTimeSpecified
		{
			get
			{
				return this._firstPassTime != null;
			}
			set
			{
				bool flag = value == (this._firstPassTime == null);
				if (flag)
				{
					this._firstPassTime = (value ? new uint?(this.firstPassTime) : null);
				}
			}
		}

		// Token: 0x06003E76 RID: 15990 RVA: 0x0007729C File Offset: 0x0007549C
		private bool ShouldSerializefirstPassTime()
		{
			return this.firstPassTimeSpecified;
		}

		// Token: 0x06003E77 RID: 15991 RVA: 0x000772B4 File Offset: 0x000754B4
		private void ResetfirstPassTime()
		{
			this.firstPassTimeSpecified = false;
		}

		// Token: 0x17001323 RID: 4899
		// (get) Token: 0x06003E78 RID: 15992 RVA: 0x000772C0 File Offset: 0x000754C0
		// (set) Token: 0x06003E79 RID: 15993 RVA: 0x000772EC File Offset: 0x000754EC
		[ProtoMember(11, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x17001324 RID: 4900
		// (get) Token: 0x06003E7A RID: 15994 RVA: 0x000772FC File Offset: 0x000754FC
		// (set) Token: 0x06003E7B RID: 15995 RVA: 0x0007731C File Offset: 0x0007551C
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x06003E7C RID: 15996 RVA: 0x00077360 File Offset: 0x00075560
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06003E7D RID: 15997 RVA: 0x00077378 File Offset: 0x00075578
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x06003E7E RID: 15998 RVA: 0x00077384 File Offset: 0x00075584
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F7E RID: 3966
		private ulong? _dgid;

		// Token: 0x04000F7F RID: 3967
		private uint? _position;

		// Token: 0x04000F80 RID: 3968
		private uint? _level;

		// Token: 0x04000F81 RID: 3969
		private string _name;

		// Token: 0x04000F82 RID: 3970
		private ulong? _totalPPT;

		// Token: 0x04000F83 RID: 3971
		private uint? _capacity;

		// Token: 0x04000F84 RID: 3972
		private uint? _memberCount;

		// Token: 0x04000F85 RID: 3973
		private uint? _mapId;

		// Token: 0x04000F86 RID: 3974
		private uint? _mapCnt;

		// Token: 0x04000F87 RID: 3975
		private uint? _firstPassTime;

		// Token: 0x04000F88 RID: 3976
		private uint? _exp;

		// Token: 0x04000F89 RID: 3977
		private IExtension extensionObject;
	}
}
