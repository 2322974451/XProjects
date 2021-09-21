using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010B RID: 267
	[ProtoContract(Name = "GetDesignationReq")]
	[Serializable]
	public class GetDesignationReq : IExtensible
	{
		// Token: 0x060010EA RID: 4330 RVA: 0x000229D4 File Offset: 0x00020BD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400043C RID: 1084
		private IExtension extensionObject;
	}
}
