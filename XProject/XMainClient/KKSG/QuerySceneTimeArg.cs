using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022D RID: 557
	[ProtoContract(Name = "QuerySceneTimeArg")]
	[Serializable]
	public class QuerySceneTimeArg : IExtensible
	{
		// Token: 0x06001F15 RID: 7957 RVA: 0x0003CFC8 File Offset: 0x0003B1C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007C2 RID: 1986
		private IExtension extensionObject;
	}
}
