using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildLadderInfoRes")]
	[Serializable]
	public class ReqGuildLadderInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lestRewardTimes", DataFormat = DataFormat.TwosComplement)]
		public uint lestRewardTimes
		{
			get
			{
				return this._lestRewardTimes ?? 0U;
			}
			set
			{
				this._lestRewardTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lestRewardTimesSpecified
		{
			get
			{
				return this._lestRewardTimes != null;
			}
			set
			{
				bool flag = value == (this._lestRewardTimes == null);
				if (flag)
				{
					this._lestRewardTimes = (value ? new uint?(this.lestRewardTimes) : null);
				}
			}
		}

		private bool ShouldSerializelestRewardTimes()
		{
			return this.lestRewardTimesSpecified;
		}

		private void ResetlestRewardTimes()
		{
			this.lestRewardTimesSpecified = false;
		}

		[ProtoMember(2, Name = "roleRanks", DataFormat = DataFormat.Default)]
		public List<GuildLadderRoleRank> roleRanks
		{
			get
			{
				return this._roleRanks;
			}
		}

		[ProtoMember(3, Name = "guildRanks", DataFormat = DataFormat.Default)]
		public List<GuildLadderRank> guildRanks
		{
			get
			{
				return this._guildRanks;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "nowTime", DataFormat = DataFormat.TwosComplement)]
		public uint nowTime
		{
			get
			{
				return this._nowTime ?? 0U;
			}
			set
			{
				this._nowTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nowTimeSpecified
		{
			get
			{
				return this._nowTime != null;
			}
			set
			{
				bool flag = value == (this._nowTime == null);
				if (flag)
				{
					this._nowTime = (value ? new uint?(this.nowTime) : null);
				}
			}
		}

		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastTime
		{
			get
			{
				return this._lastTime ?? 0U;
			}
			set
			{
				this._lastTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastTimeSpecified
		{
			get
			{
				return this._lastTime != null;
			}
			set
			{
				bool flag = value == (this._lastTime == null);
				if (flag)
				{
					this._lastTime = (value ? new uint?(this.lastTime) : null);
				}
			}
		}

		private bool ShouldSerializelastTime()
		{
			return this.lastTimeSpecified;
		}

		private void ResetlastTime()
		{
			this.lastTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lestRewardTimes;

		private readonly List<GuildLadderRoleRank> _roleRanks = new List<GuildLadderRoleRank>();

		private readonly List<GuildLadderRank> _guildRanks = new List<GuildLadderRank>();

		private ErrorCode? _errorcode;

		private uint? _nowTime;

		private uint? _lastTime;

		private IExtension extensionObject;
	}
}
