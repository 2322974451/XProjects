using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000224 RID: 548
	[ProtoContract(Name = "RefreshSweepRewardArg")]
	[Serializable]
	public class RefreshSweepRewardArg : IExtensible
	{
		// Token: 0x06001ED3 RID: 7891 RVA: 0x0003C888 File Offset: 0x0003AA88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007B1 RID: 1969
		private IExtension extensionObject;
	}
}
