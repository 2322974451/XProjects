using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052E RID: 1326
	[ProtoContract(Name = "GetCrossGvgDataArg")]
	[Serializable]
	public class GetCrossGvgDataArg : IExtensible
	{
		// Token: 0x06004432 RID: 17458 RVA: 0x00081BCC File Offset: 0x0007FDCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001101 RID: 4353
		private IExtension extensionObject;
	}
}
