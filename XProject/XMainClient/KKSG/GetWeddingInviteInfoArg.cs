using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000471 RID: 1137
	[ProtoContract(Name = "GetWeddingInviteInfoArg")]
	[Serializable]
	public class GetWeddingInviteInfoArg : IExtensible
	{
		// Token: 0x06003B5E RID: 15198 RVA: 0x00071714 File Offset: 0x0006F914
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EC3 RID: 3779
		private IExtension extensionObject;
	}
}
