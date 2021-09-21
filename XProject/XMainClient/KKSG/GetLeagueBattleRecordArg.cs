using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000399 RID: 921
	[ProtoContract(Name = "GetLeagueBattleRecordArg")]
	[Serializable]
	public class GetLeagueBattleRecordArg : IExtensible
	{
		// Token: 0x060031C0 RID: 12736 RVA: 0x0005FCD8 File Offset: 0x0005DED8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C5A RID: 3162
		private IExtension extensionObject;
	}
}
