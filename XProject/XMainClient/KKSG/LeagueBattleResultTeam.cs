using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleResultTeam")]
	[Serializable]
	public class LeagueBattleResultTeam : IExtensible
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

		[ProtoMember(5, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueBattleResultRole> members
		{
			get
			{
				return this._members;
			}
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

		[ProtoMember(7, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "score_change", DataFormat = DataFormat.TwosComplement)]
		public int score_change
		{
			get
			{
				return this._score_change ?? 0;
			}
			set
			{
				this._score_change = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool score_changeSpecified
		{
			get
			{
				return this._score_change != null;
			}
			set
			{
				bool flag = value == (this._score_change == null);
				if (flag)
				{
					this._score_change = (value ? new int?(this.score_change) : null);
				}
			}
		}

		private bool ShouldSerializescore_change()
		{
			return this.score_changeSpecified;
		}

		private void Resetscore_change()
		{
			this.score_changeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "rank_change", DataFormat = DataFormat.TwosComplement)]
		public int rank_change
		{
			get
			{
				return this._rank_change ?? 0;
			}
			set
			{
				this._rank_change = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rank_changeSpecified
		{
			get
			{
				return this._rank_change != null;
			}
			set
			{
				bool flag = value == (this._rank_change == null);
				if (flag)
				{
					this._rank_change = (value ? new int?(this.rank_change) : null);
				}
			}
		}

		private bool ShouldSerializerank_change()
		{
			return this.rank_changeSpecified;
		}

		private void Resetrank_change()
		{
			this.rank_changeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _league_teamid;

		private string _name;

		private uint? _serverid;

		private string _servername;

		private readonly List<LeagueBattleResultRole> _members = new List<LeagueBattleResultRole>();

		private uint? _rank;

		private uint? _score;

		private int? _score_change;

		private uint? _honorpoint;

		private int? _rank_change;

		private IExtension extensionObject;
	}
}
