using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000475 RID: 1141
	[ProtoContract(Name = "GetMarriageRelationArg")]
	[Serializable]
	public class GetMarriageRelationArg : IExtensible
	{
		// Token: 0x06003B89 RID: 15241 RVA: 0x00071C2C File Offset: 0x0006FE2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ED1 RID: 3793
		private IExtension extensionObject;
	}
}
