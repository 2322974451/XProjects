using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueRankData")]
	[Serializable]
	public class LeagueRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
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

		[ProtoMember(8, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public uint joincount
		{
			get
			{
				return this._joincount ?? 0U;
			}
			set
			{
				this._joincount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new uint?(this.joincount) : null);
				}
			}
		}

		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _league_teamid;

		private uint? _serverid;

		private string _servername;

		private string _teamname;

		private uint? _point;

		private uint? _winnum;

		private float? _winrate;

		private uint? _continuewin;

		private uint? _joincount;

		private IExtension extensionObject;
	}
}
