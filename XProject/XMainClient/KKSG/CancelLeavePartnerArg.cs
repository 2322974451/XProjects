using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000323 RID: 803
	[ProtoContract(Name = "CancelLeavePartnerArg")]
	[Serializable]
	public class CancelLeavePartnerArg : IExtensible
	{
		// Token: 0x06002C47 RID: 11335 RVA: 0x00055C68 File Offset: 0x00053E68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AF6 RID: 2806
		private IExtension extensionObject;
	}
}
