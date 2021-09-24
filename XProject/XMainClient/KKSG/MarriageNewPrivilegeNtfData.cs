using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageNewPrivilegeNtfData")]
	[Serializable]
	public class MarriageNewPrivilegeNtfData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "marriageLevel", DataFormat = DataFormat.TwosComplement)]
		public int marriageLevel
		{
			get
			{
				return this._marriageLevel ?? 0;
			}
			set
			{
				this._marriageLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool marriageLevelSpecified
		{
			get
			{
				return this._marriageLevel != null;
			}
			set
			{
				bool flag = value == (this._marriageLevel == null);
				if (flag)
				{
					this._marriageLevel = (value ? new int?(this.marriageLevel) : null);
				}
			}
		}

		private bool ShouldSerializemarriageLevel()
		{
			return this.marriageLevelSpecified;
		}

		private void ResetmarriageLevel()
		{
			this.marriageLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _marriageLevel;

		private IExtension extensionObject;
	}
}
