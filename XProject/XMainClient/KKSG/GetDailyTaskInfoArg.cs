using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CD RID: 717
	[ProtoContract(Name = "GetDailyTaskInfoArg")]
	[Serializable]
	public class GetDailyTaskInfoArg : IExtensible
	{
		// Token: 0x06002785 RID: 10117 RVA: 0x0004CD30 File Offset: 0x0004AF30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009D7 RID: 2519
		private IExtension extensionObject;
	}
}
