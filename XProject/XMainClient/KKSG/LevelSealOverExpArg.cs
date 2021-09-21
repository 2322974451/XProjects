using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011F RID: 287
	[ProtoContract(Name = "LevelSealOverExpArg")]
	[Serializable]
	public class LevelSealOverExpArg : IExtensible
	{
		// Token: 0x060011DF RID: 4575 RVA: 0x00024630 File Offset: 0x00022830
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000477 RID: 1143
		private IExtension extensionObject;
	}
}
