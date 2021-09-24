using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StcAchieveInfo")]
	[Serializable]
	public class StcAchieveInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "achieveID", DataFormat = DataFormat.TwosComplement)]
		public uint achieveID
		{
			get
			{
				return this._achieveID ?? 0U;
			}
			set
			{
				this._achieveID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool achieveIDSpecified
		{
			get
			{
				return this._achieveID != null;
			}
			set
			{
				bool flag = value == (this._achieveID == null);
				if (flag)
				{
					this._achieveID = (value ? new uint?(this.achieveID) : null);
				}
			}
		}

		private bool ShouldSerializeachieveID()
		{
			return this.achieveIDSpecified;
		}

		private void ResetachieveID()
		{
			this.achieveIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rewardStatus", DataFormat = DataFormat.TwosComplement)]
		public uint rewardStatus
		{
			get
			{
				return this._rewardStatus ?? 0U;
			}
			set
			{
				this._rewardStatus = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardStatusSpecified
		{
			get
			{
				return this._rewardStatus != null;
			}
			set
			{
				bool flag = value == (this._rewardStatus == null);
				if (flag)
				{
					this._rewardStatus = (value ? new uint?(this.rewardStatus) : null);
				}
			}
		}

		private bool ShouldSerializerewardStatus()
		{
			return this.rewardStatusSpecified;
		}

		private void ResetrewardStatus()
		{
			this.rewardStatusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _achieveID;

		private uint? _rewardStatus;

		private IExtension extensionObject;
	}
}
