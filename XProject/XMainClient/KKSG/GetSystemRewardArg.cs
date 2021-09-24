using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetSystemRewardArg")]
	[Serializable]
	public class GetSystemRewardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "RewardUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong RewardUniqueId
		{
			get
			{
				return this._RewardUniqueId ?? 0UL;
			}
			set
			{
				this._RewardUniqueId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RewardUniqueIdSpecified
		{
			get
			{
				return this._RewardUniqueId != null;
			}
			set
			{
				bool flag = value == (this._RewardUniqueId == null);
				if (flag)
				{
					this._RewardUniqueId = (value ? new ulong?(this.RewardUniqueId) : null);
				}
			}
		}

		private bool ShouldSerializeRewardUniqueId()
		{
			return this.RewardUniqueIdSpecified;
		}

		private void ResetRewardUniqueId()
		{
			this.RewardUniqueIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _RewardUniqueId;

		private IExtension extensionObject;
	}
}
