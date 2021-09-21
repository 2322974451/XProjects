using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D4 RID: 724
	[ProtoContract(Name = "GetGuildDonateInfoArg")]
	[Serializable]
	public class GetGuildDonateInfoArg : IExtensible
	{
		// Token: 0x060027EF RID: 10223 RVA: 0x0004D9E4 File Offset: 0x0004BBE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009EF RID: 2543
		private IExtension extensionObject;
	}
}
