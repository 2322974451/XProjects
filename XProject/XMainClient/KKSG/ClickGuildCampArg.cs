using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BC RID: 700
	[ProtoContract(Name = "ClickGuildCampArg")]
	[Serializable]
	public class ClickGuildCampArg : IExtensible
	{
		// Token: 0x060026ED RID: 9965 RVA: 0x0004BBB4 File Offset: 0x00049DB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009AA RID: 2474
		private IExtension extensionObject;
	}
}
