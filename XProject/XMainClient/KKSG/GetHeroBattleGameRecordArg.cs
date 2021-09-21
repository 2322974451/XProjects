using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000366 RID: 870
	[ProtoContract(Name = "GetHeroBattleGameRecordArg")]
	[Serializable]
	public class GetHeroBattleGameRecordArg : IExtensible
	{
		// Token: 0x06002F77 RID: 12151 RVA: 0x0005B9BC File Offset: 0x00059BBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BC5 RID: 3013
		private IExtension extensionObject;
	}
}
