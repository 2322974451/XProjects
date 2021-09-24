using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResetSkillArg")]
	[Serializable]
	public class ResetSkillArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "resetType", DataFormat = DataFormat.TwosComplement)]
		public ResetType resetType
		{
			get
			{
				return this._resetType ?? ResetType.RESET_SKILL;
			}
			set
			{
				this._resetType = new ResetType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resetTypeSpecified
		{
			get
			{
				return this._resetType != null;
			}
			set
			{
				bool flag = value == (this._resetType == null);
				if (flag)
				{
					this._resetType = (value ? new ResetType?(this.resetType) : null);
				}
			}
		}

		private bool ShouldSerializeresetType()
		{
			return this.resetTypeSpecified;
		}

		private void ResetresetType()
		{
			this.resetTypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ResetType? _resetType;

		private IExtension extensionObject;
	}
}
