using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033F RID: 831
	[ProtoContract(Name = "ReqGuildTerrAllianceInfoArg")]
	[Serializable]
	public class ReqGuildTerrAllianceInfoArg : IExtensible
	{
		// Token: 0x06002DA4 RID: 11684 RVA: 0x00058514 File Offset: 0x00056714
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B55 RID: 2901
		private IExtension extensionObject;
	}
}
