using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000044 RID: 68
	[ProtoContract(Name = "CheckinArg")]
	[Serializable]
	public class CheckinArg : IExtensible
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x0000B870 File Offset: 0x00009A70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000132 RID: 306
		private IExtension extensionObject;
	}
}
