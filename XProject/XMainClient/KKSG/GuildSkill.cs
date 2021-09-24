using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSkill")]
	[Serializable]
	public class GuildSkill : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "skillId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "skillLvl", DataFormat = DataFormat.TwosComplement)]
		public uint skillLvl
		{
			get
			{
				return this._skillLvl ?? 0U;
			}
			set
			{
				this._skillLvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillLvlSpecified
		{
			get
			{
				return this._skillLvl != null;
			}
			set
			{
				bool flag = value == (this._skillLvl == null);
				if (flag)
				{
					this._skillLvl = (value ? new uint?(this.skillLvl) : null);
				}
			}
		}

		private bool ShouldSerializeskillLvl()
		{
			return this.skillLvlSpecified;
		}

		private void ResetskillLvl()
		{
			this.skillLvlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _skillId;

		private uint? _skillLvl;

		private IExtension extensionObject;
	}
}
