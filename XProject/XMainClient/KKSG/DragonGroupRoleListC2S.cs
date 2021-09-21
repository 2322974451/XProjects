using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048D RID: 1165
	[ProtoContract(Name = "DragonGroupRoleListC2S")]
	[Serializable]
	public class DragonGroupRoleListC2S : IExtensible
	{
		// Token: 0x06003CD3 RID: 15571 RVA: 0x00074220 File Offset: 0x00072420
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F24 RID: 3876
		private IExtension extensionObject;
	}
}
