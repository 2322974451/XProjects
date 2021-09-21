using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053D RID: 1341
	[ProtoContract(Name = "GuildSchoolHallGetRankList_C2M")]
	[Serializable]
	public class GuildSchoolHallGetRankList_C2M : IExtensible
	{
		// Token: 0x060044AF RID: 17583 RVA: 0x00082A00 File Offset: 0x00080C00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001128 RID: 4392
		private IExtension extensionObject;
	}
}
