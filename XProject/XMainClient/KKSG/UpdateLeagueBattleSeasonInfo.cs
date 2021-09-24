using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateLeagueBattleSeasonInfo")]
	[Serializable]
	public class UpdateLeagueBattleSeasonInfo : IExtensible
	{

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

		private bool ShouldSerializeis_open()
		{
			return this.is_openSpecified;
		}

		private void Resetis_open()
		{
			this.is_openSpecified = false;
		}

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

		[ProtoMember(4, Name = "league_teammember", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> league_teammember
		{
			get
			{
				return this._league_teammember;
			}
		}

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

		private bool ShouldSerializeleague_teamstate()
		{
			return this.league_teamstateSpecified;
		}

		private void Resetleague_teamstate()
		{
			this.league_teamstateSpecified = false;
		}

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

		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

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

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _is_open;

		private bool? _is_cross;

		private ulong? _league_teamid;

		private readonly List<ulong> _league_teammember = new List<ulong>();

		private LeagueTeamState? _league_teamstate;

		private uint? _season_num;

		private uint? _matchlefttime;

		private LeagueBattleTimeState? _state;

		private IExtension extensionObject;
	}
}
