using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C9 RID: 457
	[ProtoContract(Name = "GetActivityInfoArg")]
	[Serializable]
	public class GetActivityInfoArg : IExtensible
	{
		// Token: 0x06001ACE RID: 6862 RVA: 0x0003510C File Offset: 0x0003330C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006AA RID: 1706
		private IExtension extensionObject;
	}
}
