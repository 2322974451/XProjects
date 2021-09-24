using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RewardChanged")]
	[Serializable]
	public class RewardChanged : IExtensible
	{

		[ProtoMember(1, Name = "AddedRewardInfo", DataFormat = DataFormat.Default)]
		public List<RewardInfo> AddedRewardInfo
		{
			get
			{
				return this._AddedRewardInfo;
			}
		}

		[ProtoMember(2, Name = "RemovedRewardUniqueId", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemovedRewardUniqueId
		{
			get
			{
				return this._RemovedRewardUniqueId;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RewardInfo> _AddedRewardInfo = new List<RewardInfo>();

		private readonly List<ulong> _RemovedRewardUniqueId = new List<ulong>();

		private IExtension extensionObject;
	}
}
