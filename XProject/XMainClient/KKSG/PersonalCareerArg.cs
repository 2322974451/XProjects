using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PersonalCareerArg")]
	[Serializable]
	public class PersonalCareerArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
		public PersonalCarrerReqType quest_type
		{
			get
			{
				return this._quest_type ?? PersonalCarrerReqType.PCRT_HOME_PAGE;
			}
			set
			{
				this._quest_type = new PersonalCarrerReqType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool quest_typeSpecified
		{
			get
			{
				return this._quest_type != null;
			}
			set
			{
				bool flag = value == (this._quest_type == null);
				if (flag)
				{
					this._quest_type = (value ? new PersonalCarrerReqType?(this.quest_type) : null);
				}
			}
		}

		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PersonalCarrerReqType? _quest_type;

		private ulong? _role_id;

		private IExtension extensionObject;
	}
}
