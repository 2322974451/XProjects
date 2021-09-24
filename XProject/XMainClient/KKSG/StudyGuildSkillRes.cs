using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StudyGuildSkillRes")]
	[Serializable]
	public class StudyGuildSkillRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "skillId", DataFormat = DataFormat.TwosComplement)]
		public uint skillId
		{
			get
			{
				return this._skillId ?? 0U;
			}
			set
			{
				this._skillId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillIdSpecified
		{
			get
			{
				return this._skillId != null;
			}
			set
			{
				bool flag = value == (this._skillId == null);
				if (flag)
				{
					this._skillId = (value ? new uint?(this.skillId) : null);
				}
			}
		}

		private bool ShouldSerializeskillId()
		{
			return this.skillIdSpecified;
		}

		private void ResetskillId()
		{
			this.skillIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "skillLel", DataFormat = DataFormat.TwosComplement)]
		public uint skillLel
		{
			get
			{
				return this._skillLel ?? 0U;
			}
			set
			{
				this._skillLel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillLelSpecified
		{
			get
			{
				return this._skillLel != null;
			}
			set
			{
				bool flag = value == (this._skillLel == null);
				if (flag)
				{
					this._skillLel = (value ? new uint?(this.skillLel) : null);
				}
			}
		}

		private bool ShouldSerializeskillLel()
		{
			return this.skillLelSpecified;
		}

		private void ResetskillLel()
		{
			this.skillLelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lastExp", DataFormat = DataFormat.TwosComplement)]
		public uint lastExp
		{
			get
			{
				return this._lastExp ?? 0U;
			}
			set
			{
				this._lastExp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastExpSpecified
		{
			get
			{
				return this._lastExp != null;
			}
			set
			{
				bool flag = value == (this._lastExp == null);
				if (flag)
				{
					this._lastExp = (value ? new uint?(this.lastExp) : null);
				}
			}
		}

		private bool ShouldSerializelastExp()
		{
			return this.lastExpSpecified;
		}

		private void ResetlastExp()
		{
			this.lastExpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _skillId;

		private uint? _skillLel;

		private uint? _lastExp;

		private IExtension extensionObject;
	}
}
