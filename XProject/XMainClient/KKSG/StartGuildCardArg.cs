using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009B RID: 155
	[ProtoContract(Name = "StartGuildCardArg")]
	[Serializable]
	public class StartGuildCardArg : IExtensible
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x00016FC0 File Offset: 0x000151C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002B1 RID: 689
		private IExtension extensionObject;
	}
}
