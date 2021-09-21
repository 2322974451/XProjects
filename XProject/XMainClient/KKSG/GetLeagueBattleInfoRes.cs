using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000371 RID: 881
	[ProtoContract(Name = "GetLeagueBattleInfoRes")]
	[Serializable]
	public class GetLeagueBattleInfoRes : IExtensible
	{
		// Token: 0x17000ECA RID: 3786
		// (get) Token: 0x06002FCA RID: 12234 RVA: 0x0005C31C File Offset: 0x0005A51C
		// (set) Token: 0x06002FCB RID: 12235 RVA: 0x0005C348 File Offset: 0x0005A548
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000ECB RID: 3787
		// (get) Token: 0x06002FCC RID: 12236 RVA: 0x0005C358 File Offset: 0x0005A558
		// (set) Token: 0x06002FCD RID: 12237 RVA: 0x0005C378 File Offset: 0x0005A578
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002FCE RID: 12238 RVA: 0x0005C3BC File Offset: 0x0005A5BC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002FCF RID: 12239 RVA: 0x0005C3D4 File Offset: 0x0005A5D4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000ECC RID: 3788
		// (get) Token: 0x06002FD0 RID: 12240 RVA: 0x0005C3E0 File Offset: 0x0005A5E0
		// (set) Token: 0x06002FD1 RID: 12241 RVA: 0x0005C40C File Offset: 0x0005A60C
		[ProtoMember(2, IsRequired = false, Name = "today_state", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleTimeState today_state
		{
			get
			{
				return this._today_state ?? LeagueBattleTimeState.LBTS_BeforeOpen;
			}
			set
			{
				this._today_state = new LeagueBattleTimeState?(value);
			}
		}

		// Token: 0x17000ECD RID: 3789
		// (get) Token: 0x06002FD2 RID: 12242 RVA: 0x0005C41C File Offset: 0x0005A61C
		// (set) Token: 0x06002FD3 RID: 12243 RVA: 0x0005C43C File Offset: 0x0005A63C
		[XmlIgnore]
		[Browsable(false)]
		public bool today_stateSpecified
		{
			get
			{
				return this._today_state != null;
			}
			set
			{
				bool flag = value == (this._today_state == null);
				if (flag)
				{
					this._today_state = (value ? new LeagueBattleTimeState?(this.today_state) : null);
				}
			}
		}

		// Token: 0x06002FD4 RID: 12244 RVA: 0x0005C480 File Offset: 0x0005A680
		private bool ShouldSerializetoday_state()
		{
			return this.today_stateSpecified;
		}

		// Token: 0x06002FD5 RID: 12245 RVA: 0x0005C498 File Offset: 0x0005A698
		private void Resettoday_state()
		{
			this.today_stateSpecified = false;
		}

		// Token: 0x17000ECE RID: 3790
		// (get) Token: 0x06002FD6 RID: 12246 RVA: 0x0005C4A4 File Offset: 0x0005A6A4
		// (set) Token: 0x06002FD7 RID: 12247 RVA: 0x0005C4D0 File Offset: 0x0005A6D0
		[ProtoMember(3, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		// Token: 0x17000ECF RID: 3791
		// (get) Token: 0x06002FD8 RID: 12248 RVA: 0x0005C4E0 File Offset: 0x0005A6E0
		// (set) Token: 0x06002FD9 RID: 12249 RVA: 0x0005C500 File Offset: 0x0005A700
		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		// Token: 0x06002FDA RID: 12250 RVA: 0x0005C544 File Offset: 0x0005A744
		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		// Token: 0x06002FDB RID: 12251 RVA: 0x0005C55C File Offset: 0x0005A75C
		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		// Token: 0x17000ED0 RID: 3792
		// (get) Token: 0x06002FDC RID: 12252 RVA: 0x0005C568 File Offset: 0x0005A768
		// (set) Token: 0x06002FDD RID: 12253 RVA: 0x0005C595 File Offset: 0x0005A795
		[ProtoMember(4, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000ED1 RID: 3793
		// (get) Token: 0x06002FDE RID: 12254 RVA: 0x0005C5A4 File Offset: 0x0005A7A4
		// (set) Token: 0x06002FDF RID: 12255 RVA: 0x0005C5C4 File Offset: 0x0005A7C4
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

		// Token: 0x06002FE0 RID: 12256 RVA: 0x0005C608 File Offset: 0x0005A808
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x06002FE1 RID: 12257 RVA: 0x0005C620 File Offset: 0x0005A820
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x17000ED2 RID: 3794
		// (get) Token: 0x06002FE2 RID: 12258 RVA: 0x0005C62C File Offset: 0x0005A82C
		// (set) Token: 0x06002FE3 RID: 12259 RVA: 0x0005C64D File Offset: 0x0005A84D
		[ProtoMember(5, IsRequired = false, Name = "league_teamname", DataFormat = DataFormat.Default)]
		public string league_teamname
		{
			get
			{
				return this._league_teamname ?? "";
			}
			set
			{
				this._league_teamname = value;
			}
		}

		// Token: 0x17000ED3 RID: 3795
		// (get) Token: 0x06002FE4 RID: 12260 RVA: 0x0005C658 File Offset: 0x0005A858
		// (set) Token: 0x06002FE5 RID: 12261 RVA: 0x0005C674 File Offset: 0x0005A874
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamnameSpecified
		{
			get
			{
				return this._league_teamname != null;
			}
			set
			{
				bool flag = value == (this._league_teamname == null);
				if (flag)
				{
					this._league_teamname = (value ? this.league_teamname : null);
				}
			}
		}

		// Token: 0x06002FE6 RID: 12262 RVA: 0x0005C6A4 File Offset: 0x0005A8A4
		private bool ShouldSerializeleague_teamname()
		{
			return this.league_teamnameSpecified;
		}

		// Token: 0x06002FE7 RID: 12263 RVA: 0x0005C6BC File Offset: 0x0005A8BC
		private void Resetleague_teamname()
		{
			this.league_teamnameSpecified = false;
		}

		// Token: 0x17000ED4 RID: 3796
		// (get) Token: 0x06002FE8 RID: 12264 RVA: 0x0005C6C8 File Offset: 0x0005A8C8
		// (set) Token: 0x06002FE9 RID: 12265 RVA: 0x0005C6F4 File Offset: 0x0005A8F4
		[ProtoMember(6, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x17000ED5 RID: 3797
		// (get) Token: 0x06002FEA RID: 12266 RVA: 0x0005C704 File Offset: 0x0005A904
		// (set) Token: 0x06002FEB RID: 12267 RVA: 0x0005C724 File Offset: 0x0005A924
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06002FEC RID: 12268 RVA: 0x0005C768 File Offset: 0x0005A968
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06002FED RID: 12269 RVA: 0x0005C780 File Offset: 0x0005A980
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17000ED6 RID: 3798
		// (get) Token: 0x06002FEE RID: 12270 RVA: 0x0005C78C File Offset: 0x0005A98C
		// (set) Token: 0x06002FEF RID: 12271 RVA: 0x0005C7B8 File Offset: 0x0005A9B8
		[ProtoMember(7, IsRequired = false, Name = "battlenum", DataFormat = DataFormat.TwosComplement)]
		public uint battlenum
		{
			get
			{
				return this._battlenum ?? 0U;
			}
			set
			{
				this._battlenum = new uint?(value);
			}
		}

		// Token: 0x17000ED7 RID: 3799
		// (get) Token: 0x06002FF0 RID: 12272 RVA: 0x0005C7C8 File Offset: 0x0005A9C8
		// (set) Token: 0x06002FF1 RID: 12273 RVA: 0x0005C7E8 File Offset: 0x0005A9E8
		[XmlIgnore]
		[Browsable(false)]
		public bool battlenumSpecified
		{
			get
			{
				return this._battlenum != null;
			}
			set
			{
				bool flag = value == (this._battlenum == null);
				if (flag)
				{
					this._battlenum = (value ? new uint?(this.battlenum) : null);
				}
			}
		}

		// Token: 0x06002FF2 RID: 12274 RVA: 0x0005C82C File Offset: 0x0005AA2C
		private bool ShouldSerializebattlenum()
		{
			return this.battlenumSpecified;
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x0005C844 File Offset: 0x0005AA44
		private void Resetbattlenum()
		{
			this.battlenumSpecified = false;
		}

		// Token: 0x17000ED8 RID: 3800
		// (get) Token: 0x06002FF4 RID: 12276 RVA: 0x0005C850 File Offset: 0x0005AA50
		// (set) Token: 0x06002FF5 RID: 12277 RVA: 0x0005C87C File Offset: 0x0005AA7C
		[ProtoMember(8, IsRequired = false, Name = "week_battlenum", DataFormat = DataFormat.TwosComplement)]
		public uint week_battlenum
		{
			get
			{
				return this._week_battlenum ?? 0U;
			}
			set
			{
				this._week_battlenum = new uint?(value);
			}
		}

		// Token: 0x17000ED9 RID: 3801
		// (get) Token: 0x06002FF6 RID: 12278 RVA: 0x0005C88C File Offset: 0x0005AA8C
		// (set) Token: 0x06002FF7 RID: 12279 RVA: 0x0005C8AC File Offset: 0x0005AAAC
		[XmlIgnore]
		[Browsable(false)]
		public bool week_battlenumSpecified
		{
			get
			{
				return this._week_battlenum != null;
			}
			set
			{
				bool flag = value == (this._week_battlenum == null);
				if (flag)
				{
					this._week_battlenum = (value ? new uint?(this.week_battlenum) : null);
				}
			}
		}

		// Token: 0x06002FF8 RID: 12280 RVA: 0x0005C8F0 File Offset: 0x0005AAF0
		private bool ShouldSerializeweek_battlenum()
		{
			return this.week_battlenumSpecified;
		}

		// Token: 0x06002FF9 RID: 12281 RVA: 0x0005C908 File Offset: 0x0005AB08
		private void Resetweek_battlenum()
		{
			this.week_battlenumSpecified = false;
		}

		// Token: 0x17000EDA RID: 3802
		// (get) Token: 0x06002FFA RID: 12282 RVA: 0x0005C914 File Offset: 0x0005AB14
		// (set) Token: 0x06002FFB RID: 12283 RVA: 0x0005C944 File Offset: 0x0005AB44
		[ProtoMember(9, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x17000EDB RID: 3803
		// (get) Token: 0x06002FFC RID: 12284 RVA: 0x0005C954 File Offset: 0x0005AB54
		// (set) Token: 0x06002FFD RID: 12285 RVA: 0x0005C974 File Offset: 0x0005AB74
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x06002FFE RID: 12286 RVA: 0x0005C9B8 File Offset: 0x0005ABB8
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x06002FFF RID: 12287 RVA: 0x0005C9D0 File Offset: 0x0005ABD0
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x17000EDC RID: 3804
		// (get) Token: 0x06003000 RID: 12288 RVA: 0x0005C9DC File Offset: 0x0005ABDC
		[ProtoMember(10, Name = "member", DataFormat = DataFormat.Default)]
		public List<LeagueTeamMemberDetail> member
		{
			get
			{
				return this._member;
			}
		}

		// Token: 0x17000EDD RID: 3805
		// (get) Token: 0x06003001 RID: 12289 RVA: 0x0005C9F4 File Offset: 0x0005ABF4
		// (set) Token: 0x06003002 RID: 12290 RVA: 0x0005CA20 File Offset: 0x0005AC20
		[ProtoMember(11, IsRequired = false, Name = "matchlefttime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000EDE RID: 3806
		// (get) Token: 0x06003003 RID: 12291 RVA: 0x0005CA30 File Offset: 0x0005AC30
		// (set) Token: 0x06003004 RID: 12292 RVA: 0x0005CA50 File Offset: 0x0005AC50
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

		// Token: 0x06003005 RID: 12293 RVA: 0x0005CA94 File Offset: 0x0005AC94
		private bool ShouldSerializematchlefttime()
		{
			return this.matchlefttimeSpecified;
		}

		// Token: 0x06003006 RID: 12294 RVA: 0x0005CAAC File Offset: 0x0005ACAC
		private void Resetmatchlefttime()
		{
			this.matchlefttimeSpecified = false;
		}

		// Token: 0x17000EDF RID: 3807
		// (get) Token: 0x06003007 RID: 12295 RVA: 0x0005CAB8 File Offset: 0x0005ACB8
		// (set) Token: 0x06003008 RID: 12296 RVA: 0x0005CAE4 File Offset: 0x0005ACE4
		[ProtoMember(12, IsRequired = false, Name = "rankreward_lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint rankreward_lefttime
		{
			get
			{
				return this._rankreward_lefttime ?? 0U;
			}
			set
			{
				this._rankreward_lefttime = new uint?(value);
			}
		}

		// Token: 0x17000EE0 RID: 3808
		// (get) Token: 0x06003009 RID: 12297 RVA: 0x0005CAF4 File Offset: 0x0005ACF4
		// (set) Token: 0x0600300A RID: 12298 RVA: 0x0005CB14 File Offset: 0x0005AD14
		[XmlIgnore]
		[Browsable(false)]
		public bool rankreward_lefttimeSpecified
		{
			get
			{
				return this._rankreward_lefttime != null;
			}
			set
			{
				bool flag = value == (this._rankreward_lefttime == null);
				if (flag)
				{
					this._rankreward_lefttime = (value ? new uint?(this.rankreward_lefttime) : null);
				}
			}
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x0005CB58 File Offset: 0x0005AD58
		private bool ShouldSerializerankreward_lefttime()
		{
			return this.rankreward_lefttimeSpecified;
		}

		// Token: 0x0600300C RID: 12300 RVA: 0x0005CB70 File Offset: 0x0005AD70
		private void Resetrankreward_lefttime()
		{
			this.rankreward_lefttimeSpecified = false;
		}

		// Token: 0x17000EE1 RID: 3809
		// (get) Token: 0x0600300D RID: 12301 RVA: 0x0005CB7C File Offset: 0x0005AD7C
		// (set) Token: 0x0600300E RID: 12302 RVA: 0x0005CBA8 File Offset: 0x0005ADA8
		[ProtoMember(13, IsRequired = false, Name = "crossrankreward_lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint crossrankreward_lefttime
		{
			get
			{
				return this._crossrankreward_lefttime ?? 0U;
			}
			set
			{
				this._crossrankreward_lefttime = new uint?(value);
			}
		}

		// Token: 0x17000EE2 RID: 3810
		// (get) Token: 0x0600300F RID: 12303 RVA: 0x0005CBB8 File Offset: 0x0005ADB8
		// (set) Token: 0x06003010 RID: 12304 RVA: 0x0005CBD8 File Offset: 0x0005ADD8
		[XmlIgnore]
		[Browsable(false)]
		public bool crossrankreward_lefttimeSpecified
		{
			get
			{
				return this._crossrankreward_lefttime != null;
			}
			set
			{
				bool flag = value == (this._crossrankreward_lefttime == null);
				if (flag)
				{
					this._crossrankreward_lefttime = (value ? new uint?(this.crossrankreward_lefttime) : null);
				}
			}
		}

		// Token: 0x06003011 RID: 12305 RVA: 0x0005CC1C File Offset: 0x0005AE1C
		private bool ShouldSerializecrossrankreward_lefttime()
		{
			return this.crossrankreward_lefttimeSpecified;
		}

		// Token: 0x06003012 RID: 12306 RVA: 0x0005CC34 File Offset: 0x0005AE34
		private void Resetcrossrankreward_lefttime()
		{
			this.crossrankreward_lefttimeSpecified = false;
		}

		// Token: 0x17000EE3 RID: 3811
		// (get) Token: 0x06003013 RID: 12307 RVA: 0x0005CC40 File Offset: 0x0005AE40
		// (set) Token: 0x06003014 RID: 12308 RVA: 0x0005CC6C File Offset: 0x0005AE6C
		[ProtoMember(14, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17000EE4 RID: 3812
		// (get) Token: 0x06003015 RID: 12309 RVA: 0x0005CC7C File Offset: 0x0005AE7C
		// (set) Token: 0x06003016 RID: 12310 RVA: 0x0005CC9C File Offset: 0x0005AE9C
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06003017 RID: 12311 RVA: 0x0005CCE0 File Offset: 0x0005AEE0
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06003018 RID: 12312 RVA: 0x0005CCF8 File Offset: 0x0005AEF8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000EE5 RID: 3813
		// (get) Token: 0x06003019 RID: 12313 RVA: 0x0005CD04 File Offset: 0x0005AF04
		// (set) Token: 0x0600301A RID: 12314 RVA: 0x0005CD30 File Offset: 0x0005AF30
		[ProtoMember(15, IsRequired = false, Name = "eli_type", DataFormat = DataFormat.TwosComplement)]
		public LeagueEliType eli_type
		{
			get
			{
				return this._eli_type ?? LeagueEliType.LeagueEliType_None;
			}
			set
			{
				this._eli_type = new LeagueEliType?(value);
			}
		}

		// Token: 0x17000EE6 RID: 3814
		// (get) Token: 0x0600301B RID: 12315 RVA: 0x0005CD40 File Offset: 0x0005AF40
		// (set) Token: 0x0600301C RID: 12316 RVA: 0x0005CD60 File Offset: 0x0005AF60
		[XmlIgnore]
		[Browsable(false)]
		public bool eli_typeSpecified
		{
			get
			{
				return this._eli_type != null;
			}
			set
			{
				bool flag = value == (this._eli_type == null);
				if (flag)
				{
					this._eli_type = (value ? new LeagueEliType?(this.eli_type) : null);
				}
			}
		}

		// Token: 0x0600301D RID: 12317 RVA: 0x0005CDA4 File Offset: 0x0005AFA4
		private bool ShouldSerializeeli_type()
		{
			return this.eli_typeSpecified;
		}

		// Token: 0x0600301E RID: 12318 RVA: 0x0005CDBC File Offset: 0x0005AFBC
		private void Reseteli_type()
		{
			this.eli_typeSpecified = false;
		}

		// Token: 0x17000EE7 RID: 3815
		// (get) Token: 0x0600301F RID: 12319 RVA: 0x0005CDC8 File Offset: 0x0005AFC8
		// (set) Token: 0x06003020 RID: 12320 RVA: 0x0005CDF4 File Offset: 0x0005AFF4
		[ProtoMember(16, IsRequired = false, Name = "is_cross", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000EE8 RID: 3816
		// (get) Token: 0x06003021 RID: 12321 RVA: 0x0005CE04 File Offset: 0x0005B004
		// (set) Token: 0x06003022 RID: 12322 RVA: 0x0005CE24 File Offset: 0x0005B024
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

		// Token: 0x06003023 RID: 12323 RVA: 0x0005CE68 File Offset: 0x0005B068
		private bool ShouldSerializeis_cross()
		{
			return this.is_crossSpecified;
		}

		// Token: 0x06003024 RID: 12324 RVA: 0x0005CE80 File Offset: 0x0005B080
		private void Resetis_cross()
		{
			this.is_crossSpecified = false;
		}

		// Token: 0x06003025 RID: 12325 RVA: 0x0005CE8C File Offset: 0x0005B08C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BDF RID: 3039
		private ErrorCode? _result;

		// Token: 0x04000BE0 RID: 3040
		private LeagueBattleTimeState? _today_state;

		// Token: 0x04000BE1 RID: 3041
		private uint? _timestamp;

		// Token: 0x04000BE2 RID: 3042
		private ulong? _league_teamid;

		// Token: 0x04000BE3 RID: 3043
		private string _league_teamname;

		// Token: 0x04000BE4 RID: 3044
		private uint? _score;

		// Token: 0x04000BE5 RID: 3045
		private uint? _battlenum;

		// Token: 0x04000BE6 RID: 3046
		private uint? _week_battlenum;

		// Token: 0x04000BE7 RID: 3047
		private float? _winrate;

		// Token: 0x04000BE8 RID: 3048
		private readonly List<LeagueTeamMemberDetail> _member = new List<LeagueTeamMemberDetail>();

		// Token: 0x04000BE9 RID: 3049
		private uint? _matchlefttime;

		// Token: 0x04000BEA RID: 3050
		private uint? _rankreward_lefttime;

		// Token: 0x04000BEB RID: 3051
		private uint? _crossrankreward_lefttime;

		// Token: 0x04000BEC RID: 3052
		private uint? _rank;

		// Token: 0x04000BED RID: 3053
		private LeagueEliType? _eli_type;

		// Token: 0x04000BEE RID: 3054
		private bool? _is_cross;

		// Token: 0x04000BEF RID: 3055
		private IExtension extensionObject;
	}
}
