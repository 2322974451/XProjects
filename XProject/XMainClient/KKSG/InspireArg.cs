using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024A RID: 586
	[ProtoContract(Name = "InspireArg")]
	[Serializable]
	public class InspireArg : IExtensible
	{
		// Token: 0x060020C0 RID: 8384 RVA: 0x0004028C File Offset: 0x0003E48C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000828 RID: 2088
		private IExtension extensionObject;
	}
}
