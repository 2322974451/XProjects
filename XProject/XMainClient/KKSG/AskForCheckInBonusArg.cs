using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000130 RID: 304
	[ProtoContract(Name = "AskForCheckInBonusArg")]
	[Serializable]
	public class AskForCheckInBonusArg : IExtensible
	{
		// Token: 0x060012C2 RID: 4802 RVA: 0x000260AC File Offset: 0x000242AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004AE RID: 1198
		private IExtension extensionObject;
	}
}
