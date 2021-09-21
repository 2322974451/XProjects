using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B1 RID: 689
	[ProtoContract(Name = "applyguildarenaarg")]
	[Serializable]
	public class applyguildarenaarg : IExtensible
	{
		// Token: 0x06002672 RID: 9842 RVA: 0x0004AD40 File Offset: 0x00048F40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400098A RID: 2442
		private IExtension extensionObject;
	}
}
