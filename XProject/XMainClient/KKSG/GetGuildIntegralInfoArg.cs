using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B7 RID: 695
	[ProtoContract(Name = "GetGuildIntegralInfoArg")]
	[Serializable]
	public class GetGuildIntegralInfoArg : IExtensible
	{
		// Token: 0x06002687 RID: 9863 RVA: 0x0004AF40 File Offset: 0x00049140
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000994 RID: 2452
		private IExtension extensionObject;
	}
}
