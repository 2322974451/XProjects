using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000357 RID: 855
	[ProtoContract(Name = "ClearGuildTerrAllianceArg")]
	[Serializable]
	public class ClearGuildTerrAllianceArg : IExtensible
	{
		// Token: 0x06002EF8 RID: 12024 RVA: 0x0005AB98 File Offset: 0x00058D98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BA5 RID: 2981
		private IExtension extensionObject;
	}
}
