using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageLevelInfo")]
	[Serializable]
	public class MarriageLevelInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "marriageLevelValue", DataFormat = DataFormat.TwosComplement)]
		public int marriageLevelValue
		{
			get
			{
				return this._marriageLevelValue ?? 0;
			}
			set
			{
				this._marriageLevelValue = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool marriageLevelValueSpecified
		{
			get
			{
				return this._marriageLevelValue != null;
			}
			set
			{
				bool flag = value == (this._marriageLevelValue == null);
				if (flag)
				{
					this._marriageLevelValue = (value ? new int?(this.marriageLevelValue) : null);
				}
			}
		}

		private bool ShouldSerializemarriageLevelValue()
		{
			return this.marriageLevelValueSpecified;
		}

		private void ResetmarriageLevelValue()
		{
			this.marriageLevelValueSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "canGetPrivilegeReward", DataFormat = DataFormat.TwosComplement)]
		public int canGetPrivilegeReward
		{
			get
			{
				return this._canGetPrivilegeReward ?? 0;
			}
			set
			{
				this._canGetPrivilegeReward = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canGetPrivilegeRewardSpecified
		{
			get
			{
				return this._canGetPrivilegeReward != null;
			}
			set
			{
				bool flag = value == (this._canGetPrivilegeReward == null);
				if (flag)
				{
					this._canGetPrivilegeReward = (value ? new int?(this.canGetPrivilegeReward) : null);
				}
			}
		}

		private bool ShouldSerializecanGetPrivilegeReward()
		{
			return this.canGetPrivilegeRewardSpecified;
		}

		private void ResetcanGetPrivilegeReward()
		{
			this.canGetPrivilegeRewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _marriageLevel;

		private int? _marriageLevelValue;

		private int? _canGetPrivilegeReward;

		private IExtension extensionObject;
	}
}
