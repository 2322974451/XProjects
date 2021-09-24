using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LiveNameInfo")]
	[Serializable]
	public class LiveNameInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildID", DataFormat = DataFormat.TwosComplement)]
		public ulong guildID
		{
			get
			{
				return this._guildID ?? 0UL;
			}
			set
			{
				this._guildID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildIDSpecified
		{
			get
			{
				return this._guildID != null;
			}
			set
			{
				bool flag = value == (this._guildID == null);
				if (flag)
				{
					this._guildID = (value ? new ulong?(this.guildID) : null);
				}
			}
		}

		private bool ShouldSerializeguildID()
		{
			return this.guildIDSpecified;
		}

		private void ResetguildID()
		{
			this.guildIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildName", DataFormat = DataFormat.Default)]
		public string guildName
		{
			get
			{
				return this._guildName ?? "";
			}
			set
			{
				this._guildName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildNameSpecified
		{
			get
			{
				return this._guildName != null;
			}
			set
			{
				bool flag = value == (this._guildName == null);
				if (flag)
				{
					this._guildName = (value ? this.guildName : null);
				}
			}
		}

		private bool ShouldSerializeguildName()
		{
			return this.guildNameSpecified;
		}

		private void ResetguildName()
		{
			this.guildNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guildIcon", DataFormat = DataFormat.TwosComplement)]
		public int guildIcon
		{
			get
			{
				return this._guildIcon ?? 0;
			}
			set
			{
				this._guildIcon = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildIconSpecified
		{
			get
			{
				return this._guildIcon != null;
			}
			set
			{
				bool flag = value == (this._guildIcon == null);
				if (flag)
				{
					this._guildIcon = (value ? new int?(this.guildIcon) : null);
				}
			}
		}

		private bool ShouldSerializeguildIcon()
		{
			return this.guildIconSpecified;
		}

		private void ResetguildIcon()
		{
			this.guildIconSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "teamLeaderName", DataFormat = DataFormat.Default)]
		public string teamLeaderName
		{
			get
			{
				return this._teamLeaderName ?? "";
			}
			set
			{
				this._teamLeaderName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamLeaderNameSpecified
		{
			get
			{
				return this._teamLeaderName != null;
			}
			set
			{
				bool flag = value == (this._teamLeaderName == null);
				if (flag)
				{
					this._teamLeaderName = (value ? this.teamLeaderName : null);
				}
			}
		}

		private bool ShouldSerializeteamLeaderName()
		{
			return this.teamLeaderNameSpecified;
		}

		private void ResetteamLeaderName()
		{
			this.teamLeaderNameSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "isLeft", DataFormat = DataFormat.Default)]
		public bool isLeft
		{
			get
			{
				return this._isLeft ?? false;
			}
			set
			{
				this._isLeft = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isLeftSpecified
		{
			get
			{
				return this._isLeft != null;
			}
			set
			{
				bool flag = value == (this._isLeft == null);
				if (flag)
				{
					this._isLeft = (value ? new bool?(this.isLeft) : null);
				}
			}
		}

		private bool ShouldSerializeisLeft()
		{
			return this.isLeftSpecified;
		}

		private void ResetisLeft()
		{
			this.isLeftSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "teamName", DataFormat = DataFormat.Default)]
		public string teamName
		{
			get
			{
				return this._teamName ?? "";
			}
			set
			{
				this._teamName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamNameSpecified
		{
			get
			{
				return this._teamName != null;
			}
			set
			{
				bool flag = value == (this._teamName == null);
				if (flag)
				{
					this._teamName = (value ? this.teamName : null);
				}
			}
		}

		private bool ShouldSerializeteamName()
		{
			return this.teamNameSpecified;
		}

		private void ResetteamName()
		{
			this.teamNameSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "leagueID", DataFormat = DataFormat.TwosComplement)]
		public ulong leagueID
		{
			get
			{
				return this._leagueID ?? 0UL;
			}
			set
			{
				this._leagueID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leagueIDSpecified
		{
			get
			{
				return this._leagueID != null;
			}
			set
			{
				bool flag = value == (this._leagueID == null);
				if (flag)
				{
					this._leagueID = (value ? new ulong?(this.leagueID) : null);
				}
			}
		}

		private bool ShouldSerializeleagueID()
		{
			return this.leagueIDSpecified;
		}

		private void ResetleagueID()
		{
			this.leagueIDSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildID;

		private string _guildName;

		private int? _guildIcon;

		private RoleBriefInfo _roleInfo = null;

		private string _teamLeaderName;

		private bool? _isLeft;

		private string _teamName;

		private ulong? _leagueID;

		private uint? _serverid;

		private IExtension extensionObject;
	}
}
