using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000330 RID: 816
	[ProtoContract(Name = "GCFReadyInfoArg")]
	[Serializable]
	public class GCFReadyInfoArg : IExtensible
	{
		// Token: 0x06002D03 RID: 11523 RVA: 0x00057238 File Offset: 0x00055438
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B28 RID: 2856
		private IExtension extensionObject;
	}
}
