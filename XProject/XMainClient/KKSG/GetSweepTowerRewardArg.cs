using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000226 RID: 550
	[ProtoContract(Name = "GetSweepTowerRewardArg")]
	[Serializable]
	public class GetSweepTowerRewardArg : IExtensible
	{
		// Token: 0x06001EE3 RID: 7907 RVA: 0x0003CA50 File Offset: 0x0003AC50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007B5 RID: 1973
		private IExtension extensionObject;
	}
}
