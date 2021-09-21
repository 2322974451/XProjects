using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019E RID: 414
	[ProtoContract(Name = "GetGoddessTrialRewardsArg")]
	[Serializable]
	public class GetGoddessTrialRewardsArg : IExtensible
	{
		// Token: 0x060018B8 RID: 6328 RVA: 0x000312C4 File Offset: 0x0002F4C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400061F RID: 1567
		private IExtension extensionObject;
	}
}
