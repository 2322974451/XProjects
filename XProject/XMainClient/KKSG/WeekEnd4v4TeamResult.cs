using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4TeamResult")]
	[Serializable]
	public class WeekEnd4v4TeamResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamSeconds", DataFormat = DataFormat.TwosComplement)]
		public uint teamSeconds
		{
			get
			{
				return this._teamSeconds ?? 0U;
			}
			set
			{
				this._teamSeconds = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamSecondsSpecified
		{
			get
			{
				return this._teamSeconds != null;
			}
			set
			{
				bool flag = value == (this._teamSeconds == null);
				if (flag)
				{
					this._teamSeconds = (value ? new uint?(this.teamSeconds) : null);
				}
			}
		}

		private bool ShouldSerializeteamSeconds()
		{
			return this.teamSecondsSpecified;
		}

		private void ResetteamSeconds()
		{
			this.teamSecondsSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "redTeamScore", DataFormat = DataFormat.TwosComplement)]
		public uint redTeamScore
		{
			get
			{
				return this._redTeamScore ?? 0U;
			}
			set
			{
				this._redTeamScore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool redTeamScoreSpecified
		{
			get
			{
				return this._redTeamScore != null;
			}
			set
			{
				bool flag = value == (this._redTeamScore == null);
				if (flag)
				{
					this._redTeamScore = (value ? new uint?(this.redTeamScore) : null);
				}
			}
		}

		private bool ShouldSerializeredTeamScore()
		{
			return this.redTeamScoreSpecified;
		}

		private void ResetredTeamScore()
		{
			this.redTeamScoreSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "blueTeamScore", DataFormat = DataFormat.TwosComplement)]
		public uint blueTeamScore
		{
			get
			{
				return this._blueTeamScore ?? 0U;
			}
			set
			{
				this._blueTeamScore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool blueTeamScoreSpecified
		{
			get
			{
				return this._blueTeamScore != null;
			}
			set
			{
				bool flag = value == (this._blueTeamScore == null);
				if (flag)
				{
					this._blueTeamScore = (value ? new uint?(this.blueTeamScore) : null);
				}
			}
		}

		private bool ShouldSerializeblueTeamScore()
		{
			return this.blueTeamScoreSpecified;
		}

		private void ResetblueTeamScore()
		{
			this.blueTeamScoreSpecified = false;
		}

		[ProtoMember(4, Name = "hasRewardsID", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> hasRewardsID
		{
			get
			{
				return this._hasRewardsID;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _teamSeconds;

		private uint? _redTeamScore;

		private uint? _blueTeamScore;

		private readonly List<ulong> _hasRewardsID = new List<ulong>();

		private IExtension extensionObject;
	}
}
