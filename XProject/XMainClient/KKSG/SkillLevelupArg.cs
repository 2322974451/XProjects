using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillLevelupArg")]
	[Serializable]
	public class SkillLevelupArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "skillHash", DataFormat = DataFormat.TwosComplement)]
		public uint skillHash
		{
			get
			{
				return this._skillHash ?? 0U;
			}
			set
			{
				this._skillHash = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillHashSpecified
		{
			get
			{
				return this._skillHash != null;
			}
			set
			{
				bool flag = value == (this._skillHash == null);
				if (flag)
				{
					this._skillHash = (value ? new uint?(this.skillHash) : null);
				}
			}
		}

		private bool ShouldSerializeskillHash()
		{
			return this.skillHashSpecified;
		}

		private void ResetskillHash()
		{
			this.skillHashSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _skillHash;

		private IExtension extensionObject;
	}
}
