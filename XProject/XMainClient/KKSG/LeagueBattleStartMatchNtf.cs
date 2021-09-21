using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037F RID: 895
	[ProtoContract(Name = "LeagueBattleStartMatchNtf")]
	[Serializable]
	public class LeagueBattleStartMatchNtf : IExtensible
	{
		// Token: 0x060030B4 RID: 12468 RVA: 0x0005DEC4 File Offset: 0x0005C0C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C15 RID: 3093
		private IExtension extensionObject;
	}
}
