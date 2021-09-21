using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000189 RID: 393
	[ProtoContract(Name = "ReturnToSelectRoleArg")]
	[Serializable]
	public class ReturnToSelectRoleArg : IExtensible
	{
		// Token: 0x060017BE RID: 6078 RVA: 0x0002F67C File Offset: 0x0002D87C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005DC RID: 1500
		private IExtension extensionObject;
	}
}
