using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032F RID: 815
	[ProtoContract(Name = "GCFCommonRes")]
	[Serializable]
	public class GCFCommonRes : IExtensible
	{
		// Token: 0x17000DEB RID: 3563
		// (get) Token: 0x06002CE6 RID: 11494 RVA: 0x00056F0C File Offset: 0x0005510C
		// (set) Token: 0x06002CE7 RID: 11495 RVA: 0x00056F38 File Offset: 0x00055138
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000DEC RID: 3564
		// (get) Token: 0x06002CE8 RID: 11496 RVA: 0x00056F48 File Offset: 0x00055148
		// (set) Token: 0x06002CE9 RID: 11497 RVA: 0x00056F68 File Offset: 0x00055168
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x00056FAC File Offset: 0x000551AC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x00056FC4 File Offset: 0x000551C4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000DED RID: 3565
		// (get) Token: 0x06002CEC RID: 11500 RVA: 0x00056FD0 File Offset: 0x000551D0
		[ProtoMember(2, Name = "jvdians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> jvdians
		{
			get
			{
				return this._jvdians;
			}
		}

		// Token: 0x17000DEE RID: 3566
		// (get) Token: 0x06002CED RID: 11501 RVA: 0x00056FE8 File Offset: 0x000551E8
		[ProtoMember(3, Name = "guilds", DataFormat = DataFormat.Default)]
		public List<GCFGuildBrief> guilds
		{
			get
			{
				return this._guilds;
			}
		}

		// Token: 0x17000DEF RID: 3567
		// (get) Token: 0x06002CEE RID: 11502 RVA: 0x00057000 File Offset: 0x00055200
		[ProtoMember(4, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GCFRoleBrief> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x17000DF0 RID: 3568
		// (get) Token: 0x06002CEF RID: 11503 RVA: 0x00057018 File Offset: 0x00055218
		// (set) Token: 0x06002CF0 RID: 11504 RVA: 0x00057030 File Offset: 0x00055230
		[ProtoMember(5, IsRequired = false, Name = "myinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFRoleBrief myinfo
		{
			get
			{
				return this._myinfo;
			}
			set
			{
				this._myinfo = value;
			}
		}

		// Token: 0x17000DF1 RID: 3569
		// (get) Token: 0x06002CF1 RID: 11505 RVA: 0x0005703C File Offset: 0x0005523C
		[ProtoMember(6, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<ItemBrief> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		// Token: 0x17000DF2 RID: 3570
		// (get) Token: 0x06002CF2 RID: 11506 RVA: 0x00057054 File Offset: 0x00055254
		// (set) Token: 0x06002CF3 RID: 11507 RVA: 0x00057080 File Offset: 0x00055280
		[ProtoMember(7, IsRequired = false, Name = "territoryid", DataFormat = DataFormat.TwosComplement)]
		public uint territoryid
		{
			get
			{
				return this._territoryid ?? 0U;
			}
			set
			{
				this._territoryid = new uint?(value);
			}
		}

		// Token: 0x17000DF3 RID: 3571
		// (get) Token: 0x06002CF4 RID: 11508 RVA: 0x00057090 File Offset: 0x00055290
		// (set) Token: 0x06002CF5 RID: 11509 RVA: 0x000570B0 File Offset: 0x000552B0
		[XmlIgnore]
		[Browsable(false)]
		public bool territoryidSpecified
		{
			get
			{
				return this._territoryid != null;
			}
			set
			{
				bool flag = value == (this._territoryid == null);
				if (flag)
				{
					this._territoryid = (value ? new uint?(this.territoryid) : null);
				}
			}
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x000570F4 File Offset: 0x000552F4
		private bool ShouldSerializeterritoryid()
		{
			return this.territoryidSpecified;
		}

		// Token: 0x06002CF7 RID: 11511 RVA: 0x0005710C File Offset: 0x0005530C
		private void Resetterritoryid()
		{
			this.territoryidSpecified = false;
		}

		// Token: 0x17000DF4 RID: 3572
		// (get) Token: 0x06002CF8 RID: 11512 RVA: 0x00057118 File Offset: 0x00055318
		// (set) Token: 0x06002CF9 RID: 11513 RVA: 0x00057130 File Offset: 0x00055330
		[ProtoMember(8, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		// Token: 0x17000DF5 RID: 3573
		// (get) Token: 0x06002CFA RID: 11514 RVA: 0x0005713C File Offset: 0x0005533C
		// (set) Token: 0x06002CFB RID: 11515 RVA: 0x00057168 File Offset: 0x00055368
		[ProtoMember(9, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000DF6 RID: 3574
		// (get) Token: 0x06002CFC RID: 11516 RVA: 0x00057178 File Offset: 0x00055378
		// (set) Token: 0x06002CFD RID: 11517 RVA: 0x00057198 File Offset: 0x00055398
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x000571DC File Offset: 0x000553DC
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002CFF RID: 11519 RVA: 0x000571F4 File Offset: 0x000553F4
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17000DF7 RID: 3575
		// (get) Token: 0x06002D00 RID: 11520 RVA: 0x00057200 File Offset: 0x00055400
		[ProtoMember(10, Name = "fields", DataFormat = DataFormat.Default)]
		public List<GCFBattleField> fields
		{
			get
			{
				return this._fields;
			}
		}

		// Token: 0x06002D01 RID: 11521 RVA: 0x00057218 File Offset: 0x00055418
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B1D RID: 2845
		private ErrorCode? _errorcode;

		// Token: 0x04000B1E RID: 2846
		private readonly List<GCFJvDianInfo> _jvdians = new List<GCFJvDianInfo>();

		// Token: 0x04000B1F RID: 2847
		private readonly List<GCFGuildBrief> _guilds = new List<GCFGuildBrief>();

		// Token: 0x04000B20 RID: 2848
		private readonly List<GCFRoleBrief> _roles = new List<GCFRoleBrief>();

		// Token: 0x04000B21 RID: 2849
		private GCFRoleBrief _myinfo = null;

		// Token: 0x04000B22 RID: 2850
		private readonly List<ItemBrief> _rewards = new List<ItemBrief>();

		// Token: 0x04000B23 RID: 2851
		private uint? _territoryid;

		// Token: 0x04000B24 RID: 2852
		private GCFGuildBrief _winguild = null;

		// Token: 0x04000B25 RID: 2853
		private uint? _lefttime;

		// Token: 0x04000B26 RID: 2854
		private readonly List<GCFBattleField> _fields = new List<GCFBattleField>();

		// Token: 0x04000B27 RID: 2855
		private IExtension extensionObject;
	}
}
