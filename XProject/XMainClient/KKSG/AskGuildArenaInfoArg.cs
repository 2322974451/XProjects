using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000190 RID: 400
	[ProtoContract(Name = "AskGuildArenaInfoArg")]
	[Serializable]
	public class AskGuildArenaInfoArg : IExtensible
	{
		// Token: 0x06001825 RID: 6181 RVA: 0x0003023C File Offset: 0x0002E43C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005F6 RID: 1526
		private IExtension extensionObject;
	}
}
