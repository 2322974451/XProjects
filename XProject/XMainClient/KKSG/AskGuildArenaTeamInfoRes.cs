using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildArenaTeamInfoRes")]
	[Serializable]
	public class AskGuildArenaTeamInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "fightUnit", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> fightUnit
		{
			get
			{
				return this._fightUnit;
			}
		}

		[ProtoMember(2, Name = "guildMember", DataFormat = DataFormat.Default)]
		public List<GuildMemberData> guildMember
		{
			get
			{
				return this._guildMember;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		private readonly List<GuildDarenaUnit> _fightUnit = new List<GuildDarenaUnit>();

		private readonly List<GuildMemberData> _guildMember = new List<GuildMemberData>();

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
