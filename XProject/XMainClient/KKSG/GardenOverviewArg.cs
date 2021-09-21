using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000276 RID: 630
	[ProtoContract(Name = "GardenOverviewArg")]
	[Serializable]
	public class GardenOverviewArg : IExtensible
	{
		// Token: 0x06002301 RID: 8961 RVA: 0x000445A4 File Offset: 0x000427A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008B0 RID: 2224
		private IExtension extensionObject;
	}
}
