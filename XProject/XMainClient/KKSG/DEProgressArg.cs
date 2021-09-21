using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000204 RID: 516
	[ProtoContract(Name = "DEProgressArg")]
	[Serializable]
	public class DEProgressArg : IExtensible
	{
		// Token: 0x06001D3E RID: 7486 RVA: 0x000398F4 File Offset: 0x00037AF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400074E RID: 1870
		private IExtension extensionObject;
	}
}
