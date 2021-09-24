using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildGoblinInfoRes")]
	[Serializable]
	public class GuildGoblinInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leftEnterCount", DataFormat = DataFormat.TwosComplement)]
		public int leftEnterCount
		{
			get
			{
				return this._leftEnterCount ?? 0;
			}
			set
			{
				this._leftEnterCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftEnterCountSpecified
		{
			get
			{
				return this._leftEnterCount != null;
			}
			set
			{
				bool flag = value == (this._leftEnterCount == null);
				if (flag)
				{
					this._leftEnterCount = (value ? new int?(this.leftEnterCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftEnterCount()
		{
			return this.leftEnterCountSpecified;
		}

		private void ResetleftEnterCount()
		{
			this.leftEnterCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guildTotalKillCount", DataFormat = DataFormat.TwosComplement)]
		public int guildTotalKillCount
		{
			get
			{
				return this._guildTotalKillCount ?? 0;
			}
			set
			{
				this._guildTotalKillCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildTotalKillCountSpecified
		{
			get
			{
				return this._guildTotalKillCount != null;
			}
			set
			{
				bool flag = value == (this._guildTotalKillCount == null);
				if (flag)
				{
					this._guildTotalKillCount = (value ? new int?(this.guildTotalKillCount) : null);
				}
			}
		}

		private bool ShouldSerializeguildTotalKillCount()
		{
			return this.guildTotalKillCountSpecified;
		}

		private void ResetguildTotalKillCount()
		{
			this.guildTotalKillCountSpecified = false;
		}

		[ProtoMember(4, Name = "memberRankInfo", DataFormat = DataFormat.Default)]
		public List<GuildGoblinRoleKillInfo> memberRankInfo
		{
			get
			{
				return this._memberRankInfo;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _level;

		private int? _leftEnterCount;

		private int? _guildTotalKillCount;

		private readonly List<GuildGoblinRoleKillInfo> _memberRankInfo = new List<GuildGoblinRoleKillInfo>();

		private ErrorCode? _errorCode;

		private IExtension extensionObject;
	}
}
