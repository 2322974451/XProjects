using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLeagueBattleInfoRes")]
	[Serializable]
	public class GetLeagueBattleInfoRes : IExtensible
	{

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

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

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

		private bool ShouldSerializetoday_state()
		{
			return this.today_stateSpecified;
		}

		private void Resettoday_state()
		{
			this.today_stateSpecified = false;
		}

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

		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

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

		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

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

		private bool ShouldSerializeleague_teamname()
		{
			return this.league_teamnameSpecified;
		}

		private void Resetleague_teamname()
		{
			this.league_teamnameSpecified = false;
		}

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

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

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

		private bool ShouldSerializebattlenum()
		{
			return this.battlenumSpecified;
		}

		private void Resetbattlenum()
		{
			this.battlenumSpecified = false;
		}

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

		private bool ShouldSerializeweek_battlenum()
		{
			return this.week_battlenumSpecified;
		}

		private void Resetweek_battlenum()
		{
			this.week_battlenumSpecified = false;
		}

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

		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		[ProtoMember(10, Name = "member", DataFormat = DataFormat.Default)]
		public List<LeagueTeamMemberDetail> member
		{
			get
			{
				return this._member;
			}
		}

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

		private bool ShouldSerializematchlefttime()
		{
			return this.matchlefttimeSpecified;
		}

		private void Resetmatchlefttime()
		{
			this.matchlefttimeSpecified = false;
		}

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

		private bool ShouldSerializerankreward_lefttime()
		{
			return this.rankreward_lefttimeSpecified;
		}

		private void Resetrankreward_lefttime()
		{
			this.rankreward_lefttimeSpecified = false;
		}

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

		private bool ShouldSerializecrossrankreward_lefttime()
		{
			return this.crossrankreward_lefttimeSpecified;
		}

		private void Resetcrossrankreward_lefttime()
		{
			this.crossrankreward_lefttimeSpecified = false;
		}

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

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

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

		private bool ShouldSerializeeli_type()
		{
			return this.eli_typeSpecified;
		}

		private void Reseteli_type()
		{
			this.eli_typeSpecified = false;
		}

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

		private bool ShouldSerializeis_cross()
		{
			return this.is_crossSpecified;
		}

		private void Resetis_cross()
		{
			this.is_crossSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private LeagueBattleTimeState? _today_state;

		private uint? _timestamp;

		private ulong? _league_teamid;

		private string _league_teamname;

		private uint? _score;

		private uint? _battlenum;

		private uint? _week_battlenum;

		private float? _winrate;

		private readonly List<LeagueTeamMemberDetail> _member = new List<LeagueTeamMemberDetail>();

		private uint? _matchlefttime;

		private uint? _rankreward_lefttime;

		private uint? _crossrankreward_lefttime;

		private uint? _rank;

		private LeagueEliType? _eli_type;

		private bool? _is_cross;

		private IExtension extensionObject;
	}
}
