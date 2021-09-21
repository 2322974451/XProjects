using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000234 RID: 564
	[ProtoContract(Name = "TowerFirstPassRewardData")]
	[Serializable]
	public class TowerFirstPassRewardData : IExtensible
	{
		// Token: 0x06001F5F RID: 8031 RVA: 0x0003D828 File Offset: 0x0003BA28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007D3 RID: 2003
		private IExtension extensionObject;
	}
}
