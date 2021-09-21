using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000052 RID: 82
	[ProtoContract(Name = "RewardChanged")]
	[Serializable]
	public class RewardChanged : IExtensible
	{
		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x0000D388 File Offset: 0x0000B588
		[ProtoMember(1, Name = "AddedRewardInfo", DataFormat = DataFormat.Default)]
		public List<RewardInfo> AddedRewardInfo
		{
			get
			{
				return this._AddedRewardInfo;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0000D3A0 File Offset: 0x0000B5A0
		[ProtoMember(2, Name = "RemovedRewardUniqueId", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemovedRewardUniqueId
		{
			get
			{
				return this._RemovedRewardUniqueId;
			}
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0000D3B8 File Offset: 0x0000B5B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000166 RID: 358
		private readonly List<RewardInfo> _AddedRewardInfo = new List<RewardInfo>();

		// Token: 0x04000167 RID: 359
		private readonly List<ulong> _RemovedRewardUniqueId = new List<ulong>();

		// Token: 0x04000168 RID: 360
		private IExtension extensionObject;
	}
}
