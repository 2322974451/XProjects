using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000431 RID: 1073
	[ProtoContract(Name = "GetMobaBattleBriefRecordArg")]
	[Serializable]
	public class GetMobaBattleBriefRecordArg : IExtensible
	{
		// Token: 0x060038CF RID: 14543 RVA: 0x0006CB90 File Offset: 0x0006AD90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E18 RID: 3608
		private IExtension extensionObject;
	}
}
