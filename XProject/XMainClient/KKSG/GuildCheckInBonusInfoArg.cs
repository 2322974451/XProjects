using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012C RID: 300
	[ProtoContract(Name = "GuildCheckInBonusInfoArg")]
	[Serializable]
	public class GuildCheckInBonusInfoArg : IExtensible
	{
		// Token: 0x06001289 RID: 4745 RVA: 0x000259E0 File Offset: 0x00023BE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004A1 RID: 1185
		private IExtension extensionObject;
	}
}
