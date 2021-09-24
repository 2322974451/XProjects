using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "STC_ACHIEVE_POINT_REWARD")]
	[Serializable]
	public class STC_ACHIEVE_POINT_REWARD : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rewardId", DataFormat = DataFormat.TwosComplement)]
		public uint rewardId
		{
			get
			{
				return this._rewardId ?? 0U;
			}
			set
			{
				this._rewardId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardIdSpecified
		{
			get
			{
				return this._rewardId != null;
			}
			set
			{
				bool flag = value == (this._rewardId == null);
				if (flag)
				{
					this._rewardId = (value ? new uint?(this.rewardId) : null);
				}
			}
		}

		private bool ShouldSerializerewardId()
		{
			return this.rewardIdSpecified;
		}

		private void ResetrewardId()
		{
			this.rewardIdSpecified = false;
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

		private uint? _rewardId;

		private uint? _rewardStatus;

		private IExtension extensionObject;
	}
}
