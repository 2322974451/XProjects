using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildArenaInfoReq")]
	[Serializable]
	public class AskGuildArenaInfoReq : IExtensible
	{

		[ProtoMember(1, Name = "warData", DataFormat = DataFormat.Default)]
		public List<guildArenaWarData> warData
		{
			get
			{
				return this._warData;
			}
		}

		[ProtoMember(2, Name = "allguildInfo", DataFormat = DataFormat.Default)]
		public List<GuildInfo> allguildInfo
		{
			get
			{
				return this._allguildInfo;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "timeState", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState timeState
		{
			get
			{
				return this._timeState ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._timeState = new GuildArenaState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeStateSpecified
		{
			get
			{
				return this._timeState != null;
			}
			set
			{
				bool flag = value == (this._timeState == null);
				if (flag)
				{
					this._timeState = (value ? new GuildArenaState?(this.timeState) : null);
				}
			}
		}

		private bool ShouldSerializetimeState()
		{
			return this.timeStateSpecified;
		}

		private void ResettimeState()
		{
			this.timeStateSpecified = false;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<guildArenaWarData> _warData = new List<guildArenaWarData>();

		private readonly List<GuildInfo> _allguildInfo = new List<GuildInfo>();

		private GuildArenaState? _timeState;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
