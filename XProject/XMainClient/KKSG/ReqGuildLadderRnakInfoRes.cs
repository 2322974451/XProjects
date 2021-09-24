using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildLadderRnakInfoRes")]
	[Serializable]
	public class ReqGuildLadderRnakInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "guildrank", DataFormat = DataFormat.Default)]
		public List<GuildLadderRank> guildrank
		{
			get
			{
				return this._guildrank;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
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

		private readonly List<GuildLadderRank> _guildrank = new List<GuildLadderRank>();

		private ErrorCode? _errorcode;

		private uint? _lastTime;

		private IExtension extensionObject;
	}
}
