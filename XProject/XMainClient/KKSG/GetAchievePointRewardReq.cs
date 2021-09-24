using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAchievePointRewardReq")]
	[Serializable]
	public class GetAchievePointRewardReq : IExtensible
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _rewardId;

		private IExtension extensionObject;
	}
}
