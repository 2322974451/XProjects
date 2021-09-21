using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000537 RID: 1335
	[ProtoContract(Name = "GuildHallGetBuffList_C2M")]
	[Serializable]
	public class GuildHallGetBuffList_C2M : IExtensible
	{
		// Token: 0x0600447C RID: 17532 RVA: 0x00082448 File Offset: 0x00080648
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400111A RID: 4378
		private IExtension extensionObject;
	}
}
