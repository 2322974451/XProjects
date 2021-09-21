using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AE RID: 942
	[ProtoContract(Name = "PokerTournamentEndReFundMsg")]
	[Serializable]
	public class PokerTournamentEndReFundMsg : IExtensible
	{
		// Token: 0x06003285 RID: 12933 RVA: 0x00061294 File Offset: 0x0005F494
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C90 RID: 3216
		private IExtension extensionObject;
	}
}
