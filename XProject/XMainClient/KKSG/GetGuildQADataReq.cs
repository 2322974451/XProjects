using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016E RID: 366
	[ProtoContract(Name = "GetGuildQADataReq")]
	[Serializable]
	public class GetGuildQADataReq : IExtensible
	{
		// Token: 0x06001602 RID: 5634 RVA: 0x0002C218 File Offset: 0x0002A418
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000578 RID: 1400
		private IExtension extensionObject;
	}
}
