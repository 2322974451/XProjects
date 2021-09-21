using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000206 RID: 518
	[ProtoContract(Name = "DERankArg")]
	[Serializable]
	public class DERankArg : IExtensible
	{
		// Token: 0x06001D5B RID: 7515 RVA: 0x00039C70 File Offset: 0x00037E70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000755 RID: 1877
		private IExtension extensionObject;
	}
}
