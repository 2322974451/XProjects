using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000543 RID: 1347
	[ProtoContract(Name = "GetMarriagePrivilegeArg")]
	[Serializable]
	public class GetMarriagePrivilegeArg : IExtensible
	{
		// Token: 0x060044E8 RID: 17640 RVA: 0x000830A0 File Offset: 0x000812A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001138 RID: 4408
		private IExtension extensionObject;
	}
}
