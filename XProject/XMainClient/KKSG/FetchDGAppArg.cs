using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AE RID: 1198
	[ProtoContract(Name = "FetchDGAppArg")]
	[Serializable]
	public class FetchDGAppArg : IExtensible
	{
		// Token: 0x06003E80 RID: 16000 RVA: 0x000773A4 File Offset: 0x000755A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F8A RID: 3978
		private IExtension extensionObject;
	}
}
