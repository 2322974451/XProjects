using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000212 RID: 530
	[ProtoContract(Name = "ReEnterRiskBattleArg")]
	[Serializable]
	public class ReEnterRiskBattleArg : IExtensible
	{
		// Token: 0x06001DE6 RID: 7654 RVA: 0x0003AC9C File Offset: 0x00038E9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000778 RID: 1912
		private IExtension extensionObject;
	}
}
