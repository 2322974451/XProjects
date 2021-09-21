using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B6 RID: 182
	[ProtoContract(Name = "GetGuildCheckinRecordsArg")]
	[Serializable]
	public class GetGuildCheckinRecordsArg : IExtensible
	{
		// Token: 0x06000C5C RID: 3164 RVA: 0x0001A184 File Offset: 0x00018384
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000310 RID: 784
		private IExtension extensionObject;
	}
}
