using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000372 RID: 882
	[ProtoContract(Name = "UpdateLeagueBattleSeasonInfo")]
	[Serializable]
	public class UpdateLeagueBattleSeasonInfo : IExtensible
	{
		// Token: 0x17000EE9 RID: 3817
		// (get) Token: 0x06003027 RID: 12327 RVA: 0x0005CEC0 File Offset: 0x0005B0C0
		// (set) Token: 0x06003028 RID: 12328 RVA: 0x0005CEEC File Offset: 0x0005B0EC
		[ProtoMember(1, IsRequired = false, Name = "is_open", DataFormat = DataFormat.Default)]
		public bool is_open
		{
			get
			{
				return this._is_open ?? false;
			}
			set
			{
				this._is_open = new bool?(value);
			}
		}

		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x06003029 RID: 12329 RVA: 0x0005CEFC File Offset: 0x0005B0FC
		// (set) Token: 0x0600302A RID: 12330 RVA: 0x0005CF1C File Offset: 0x0005B11C
		[XmlIgnore]
		[Browsable(false)]
		public bool is_openSpecified
		{
			get
			{
				return this._is_open != null;
			}
			set
			{
				bool flag = value == (this._is_open == null);
				if (flag)
				{
					this._is_open = (value ? new bool?(this.is_open) : null);
				}
			}
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x0005CF60 File Offset: 0x0005B160
		private bool ShouldSerializeis_open()
		{
			return this.is_openSpecified;
		}

		// Token: 0x0600302C RID: 12332 RVA: 0x0005CF78 File Offset: 0x0005B178
		private void Resetis_open()
		{
			this.is_openSpecified = false;
		}

		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x0600302D RID: 12333 RVA: 0x0005CF84 File Offset: 0x0005B184
		// (set) Token: 0x0600302E RID: 12334 RVA: 0x0005CFB0 File Offset: 0x0005B1B0
		[ProtoMember(2, IsRequired = false, Name = "is_cross", DataFormat = DataFormat.Default)]
		public bool is_cross
		{
			get
			{
				return this._is_cross ?? false;
			}
			set
			{
				this._is_cross = new bool?(value);
			}
		}

		// Token: 0x17000EEC RID: 3820
		// (get) Token: 0x0600302F RID: 12335 RVA: 0x0005CFC0 File Offset: 0x0005B1C0
		// (set) Token: 0x06003030 RID: 12336 RVA: 0x0005CFE0 File Offset: 0x0005B1E0
		[XmlIgnore]
		[Browsable(false)]
		public bool is_crossSpecified
		{
			get
			{
				return this._is_cross != null;
			}
			set
			{
				bool flag = value == (this._is_cross == null);
				if (flag)
				{
					this._is_cross = (value ? new bool?(this.is_cross) : null);
				}
			}
		}

		// Token: 0x06003031 RID: 12337 RVA: 0x0005D024 File Offset: 0x0005B224
		private bool ShouldSerializeis_cross()
		{
			return this.is_crossSpecified;
		}

		// Token: 0x06003032 RID: 12338 RVA: 0x0005D03C File Offset: 0x0005B23C
		private void Resetis_cross()
		{
			this.is_crossSpecified = false;
		}

		// Token: 0x17000EED RID: 3821
		// (get) Token: 0x06003033 RID: 12339 RVA: 0x0005D048 File Offset: 0x0005B248
		// (set) Token: 0x06003034 RID: 12340 RVA: 0x0005D075 File Offset: 0x0005B275
		[ProtoMember(3, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong league_teamid
		{
			get
			{
				return this._league_teamid ?? 0UL;
			}
			set
			{
				this._league_teamid = new ulong?(value);
			}
		}

		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x06003035 RID: 12341 RVA: 0x0005D084 File Offset: 0x0005B284
		// (set) Token: 0x06003036 RID: 12342 RVA: 0x0005D0A4 File Offset: 0x0005B2A4
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamidSpecified
		{
			get
			{
				return this._league_teamid != null;
			}
			set
			{
				bool flag = value == (this._league_teamid == null);
				if (flag)
				{
					this._league_teamid = (value ? new ulong?(this.league_teamid) : null);
				}
			}
		}

		// Token: 0x06003037 RID: 12343 RVA: 0x0005D0E8 File Offset: 0x0005B2E8
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x06003038 RID: 12344 RVA: 0x0005D100 File Offset: 0x0005B300
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x17000EEF RID: 3823
		// (get) Token: 0x06003039 RID: 12345 RVA: 0x0005D10C File Offset: 0x0005B30C
		[ProtoMember(4, Name = "league_teammember", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> league_teammember
		{
			get
			{
				return this._league_teammember;
			}
		}

		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x0600303A RID: 12346 RVA: 0x0005D124 File Offset: 0x0005B324
		// (set) Token: 0x0600303B RID: 12347 RVA: 0x0005D150 File Offset: 0x0005B350
		[ProtoMember(5, IsRequired = false, Name = "league_teamstate", DataFormat = DataFormat.TwosComplement)]
		public LeagueTeamState league_teamstate
		{
			get
			{
				return this._league_teamstate ?? LeagueTeamState.LeagueTeamState_Idle;
			}
			set
			{
				this._league_teamstate = new LeagueTeamState?(value);
			}
		}

		// Token: 0x17000EF1 RID: 3825
		// (get) Token: 0x0600303C RID: 12348 RVA: 0x0005D160 File Offset: 0x0005B360
		// (set) Token: 0x0600303D RID: 12349 RVA: 0x0005D180 File Offset: 0x0005B380
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamstateSpecified
		{
			get
			{
				return this._league_teamstate != null;
			}
			set
			{
				bool flag = value == (this._league_teamstate == null);
				if (flag)
				{
					this._league_teamstate = (value ? new LeagueTeamState?(this.league_teamstate) : null);
				}
			}
		}

		// Token: 0x0600303E RID: 12350 RVA: 0x0005D1C4 File Offset: 0x0005B3C4
		private bool ShouldSerializeleague_teamstate()
		{
			return this.league_teamstateSpecified;
		}

		// Token: 0x0600303F RID: 12351 RVA: 0x0005D1DC File Offset: 0x0005B3DC
		private void Resetleague_teamstate()
		{
			this.league_teamstateSpecified = false;
		}

		// Token: 0x17000EF2 RID: 3826
		// (get) Token: 0x06003040 RID: 12352 RVA: 0x0005D1E8 File Offset: 0x0005B3E8
		// (set) Token: 0x06003041 RID: 12353 RVA: 0x0005D214 File Offset: 0x0005B414
		[ProtoMember(6, IsRequired = false, Name = "season_num", DataFormat = DataFormat.TwosComplement)]
		public uint season_num
		{
			get
			{
				return this._season_num ?? 0U;
			}
			set
			{
				this._season_num = new uint?(value);
			}
		}

		// Token: 0x17000EF3 RID: 3827
		// (get) Token: 0x06003042 RID: 12354 RVA: 0x0005D224 File Offset: 0x0005B424
		// (set) Token: 0x06003043 RID: 12355 RVA: 0x0005D244 File Offset: 0x0005B444
		[XmlIgnore]
		[Browsable(false)]
		public bool season_numSpecified
		{
			get
			{
				return this._season_num != null;
			}
			set
			{
				bool flag = value == (this._season_num == null);
				if (flag)
				{
					this._season_num = (value ? new uint?(this.season_num) : null);
				}
			}
		}

		// Token: 0x06003044 RID: 12356 RVA: 0x0005D288 File Offset: 0x0005B488
		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		// Token: 0x06003045 RID: 12357 RVA: 0x0005D2A0 File Offset: 0x0005B4A0
		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

		// Token: 0x17000EF4 RID: 3828
		// (get) Token: 0x06003046 RID: 12358 RVA: 0x0005D2AC File Offset: 0x0005B4AC
		// (set) Token: 0x06003047 RID: 12359 RVA: 0x0005D2D8 File Offset: 0x0005B4D8
		[ProtoMember(7, IsRequired = false, Name = "matchlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint matchlefttime
		{
			get
			{
				return this._matchlefttime ?? 0U;
			}
			set
			{
				this._matchlefttime = new uint?(value);
			}
		}

		// Token: 0x17000EF5 RID: 3829
		// (get) Token: 0x06003048 RID: 12360 RVA: 0x0005D2E8 File Offset: 0x0005B4E8
		// (set) Token: 0x06003049 RID: 12361 RVA: 0x0005D308 File Offset: 0x0005B508
		[XmlIgnore]
		[Browsable(false)]
		public bool matchlefttimeSpecified
		{
			get
			{
				return this._matchlefttime != null;
			}
			set
			{
				bool flag = value == (this._matchlefttime == null);
				if (flag)
				{
					this._matchlefttime = (value ? new uint?(this.matchlefttime) : null);
				}
			}
		}

		// Token: 0x0600304A RID: 12362 RVA: 0x0005D34C File Offset: 0x0005B54C
		private bool ShouldSerializematchlefttime()
		{
			return this.matchlefttimeSpecified;
		}

		// Token: 0x0600304B RID: 12363 RVA: 0x0005D364 File Offset: 0x0005B564
		private void Resetmatchlefttime()
		{
			this.matchlefttimeSpecified = false;
		}

		// Token: 0x17000EF6 RID: 3830
		// (get) Token: 0x0600304C RID: 12364 RVA: 0x0005D370 File Offset: 0x0005B570
		// (set) Token: 0x0600304D RID: 12365 RVA: 0x0005D39C File Offset: 0x0005B59C
		[ProtoMember(8, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleTimeState state
		{
			get
			{
				return this._state ?? LeagueBattleTimeState.LBTS_BeforeOpen;
			}
			set
			{
				this._state = new LeagueBattleTimeState?(value);
			}
		}

		// Token: 0x17000EF7 RID: 3831
		// (get) Token: 0x0600304E RID: 12366 RVA: 0x0005D3AC File Offset: 0x0005B5AC
		// (set) Token: 0x0600304F RID: 12367 RVA: 0x0005D3CC File Offset: 0x0005B5CC
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
					this._state = (value ? new LeagueBattleTimeState?(this.state) : null);
				}
			}
		}

		// Token: 0x06003050 RID: 12368 RVA: 0x0005D410 File Offset: 0x0005B610
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06003051 RID: 12369 RVA: 0x0005D428 File Offset: 0x0005B628
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06003052 RID: 12370 RVA: 0x0005D434 File Offset: 0x0005B634
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BF0 RID: 3056
		private bool? _is_open;

		// Token: 0x04000BF1 RID: 3057
		private bool? _is_cross;

		// Token: 0x04000BF2 RID: 3058
		private ulong? _league_teamid;

		// Token: 0x04000BF3 RID: 3059
		private readonly List<ulong> _league_teammember = new List<ulong>();

		// Token: 0x04000BF4 RID: 3060
		private LeagueTeamState? _league_teamstate;

		// Token: 0x04000BF5 RID: 3061
		private uint? _season_num;

		// Token: 0x04000BF6 RID: 3062
		private uint? _matchlefttime;

		// Token: 0x04000BF7 RID: 3063
		private LeagueBattleTimeState? _state;

		// Token: 0x04000BF8 RID: 3064
		private IExtension extensionObject;
	}
}
