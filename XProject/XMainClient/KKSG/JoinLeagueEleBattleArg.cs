using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A3 RID: 931
	[ProtoContract(Name = "JoinLeagueEleBattleArg")]
	[Serializable]
	public class JoinLeagueEleBattleArg : IExtensible
	{
		// Token: 0x06003222 RID: 12834 RVA: 0x00060804 File Offset: 0x0005EA04
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C74 RID: 3188
		private IExtension extensionObject;
	}
}
