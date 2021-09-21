using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000501 RID: 1281
	[ProtoContract(Name = "SurviveReqArg")]
	[Serializable]
	public class SurviveReqArg : IExtensible
	{
		// Token: 0x0600422C RID: 16940 RVA: 0x0007DFA4 File Offset: 0x0007C1A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001080 RID: 4224
		private IExtension extensionObject;
	}
}
