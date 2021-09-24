using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleTeamData")]
	[Serializable]
	public class LeagueBattleTeamData : IExtensible
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

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "total_win", DataFormat = DataFormat.TwosComplement)]
		public uint total_win
		{
			get
			{
				return this._total_win ?? 0U;
			}
			set
			{
				this._total_win = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_winSpecified
		{
			get
			{
				return this._total_win != null;
			}
			set
			{
				bool flag = value == (this._total_win == null);
				if (flag)
				{
					this._total_win = (value ? new uint?(this.total_win) : null);
				}
			}
		}

		private bool ShouldSerializetotal_win()
		{
			return this.total_winSpecified;
		}

		private void Resettotal_win()
		{
			this.total_winSpecified = false;
		}

		[ProtoMember(9, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueBattleRoleBrief> members
		{
			get
			{
				return this._members;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _league_teamid;

		private string _name;

		private uint? _serverid;

		private string _servername;

		private uint? _score;

		private uint? _rank;

		private uint? _total_num;

		private uint? _total_win;

		private readonly List<LeagueBattleRoleBrief> _members = new List<LeagueBattleRoleBrief>();

		private IExtension extensionObject;
	}
}
