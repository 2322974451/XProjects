using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AF RID: 943
	[ProtoContract(Name = "GetPayRewardArg")]
	[Serializable]
	public class GetPayRewardArg : IExtensible
	{
		// Token: 0x06003287 RID: 12935 RVA: 0x000612B4 File Offset: 0x0005F4B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C91 RID: 3217
		private IExtension extensionObject;
	}
}
