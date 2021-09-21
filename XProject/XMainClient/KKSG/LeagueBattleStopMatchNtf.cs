using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000380 RID: 896
	[ProtoContract(Name = "LeagueBattleStopMatchNtf")]
	[Serializable]
	public class LeagueBattleStopMatchNtf : IExtensible
	{
		// Token: 0x060030B6 RID: 12470 RVA: 0x0005DEE4 File Offset: 0x0005C0E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C16 RID: 3094
		private IExtension extensionObject;
	}
}
