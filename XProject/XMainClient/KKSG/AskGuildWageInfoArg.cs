using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028A RID: 650
	[ProtoContract(Name = "AskGuildWageInfoArg")]
	[Serializable]
	public class AskGuildWageInfoArg : IExtensible
	{
		// Token: 0x0600246A RID: 9322 RVA: 0x00047078 File Offset: 0x00045278
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000900 RID: 2304
		private IExtension extensionObject;
	}
}
