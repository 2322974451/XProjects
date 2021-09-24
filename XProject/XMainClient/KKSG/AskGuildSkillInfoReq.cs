using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildSkillInfoReq")]
	[Serializable]
	public class AskGuildSkillInfoReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "SkillLel", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> SkillLel
		{
			get
			{
				return this._SkillLel;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "LastGuildExp", DataFormat = DataFormat.TwosComplement)]
		public int LastGuildExp
		{
			get
			{
				return this._LastGuildExp ?? 0;
			}
			set
			{
				this._LastGuildExp = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LastGuildExpSpecified
		{
			get
			{
				return this._LastGuildExp != null;
			}
			set
			{
				bool flag = value == (this._LastGuildExp == null);
				if (flag)
				{
					this._LastGuildExp = (value ? new int?(this.LastGuildExp) : null);
				}
			}
		}

		private bool ShouldSerializeLastGuildExp()
		{
			return this.LastGuildExpSpecified;
		}

		private void ResetLastGuildExp()
		{
			this.LastGuildExpSpecified = false;
		}

		[ProtoMember(4, Name = "roleSkills", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> roleSkills
		{
			get
			{
				return this._roleSkills;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<GuildSkillData> _SkillLel = new List<GuildSkillData>();

		private int? _LastGuildExp;

		private readonly List<GuildSkillData> _roleSkills = new List<GuildSkillData>();

		private IExtension extensionObject;
	}
}
