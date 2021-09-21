using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DF RID: 1247
	[ProtoContract(Name = "GetWeeklyTaskInfoArg")]
	[Serializable]
	public class GetWeeklyTaskInfoArg : IExtensible
	{
		// Token: 0x06004065 RID: 16485 RVA: 0x0007A9F0 File Offset: 0x00078BF0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400100D RID: 4109
		private IExtension extensionObject;
	}
}
