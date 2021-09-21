using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DF RID: 735
	[ProtoContract(Name = "DelGuildInheritArg")]
	[Serializable]
	public class DelGuildInheritArg : IExtensible
	{
		// Token: 0x0600287C RID: 10364 RVA: 0x0004EAA4 File Offset: 0x0004CCA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A12 RID: 2578
		private IExtension extensionObject;
	}
}
