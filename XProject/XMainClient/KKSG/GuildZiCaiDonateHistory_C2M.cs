using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000541 RID: 1345
	[ProtoContract(Name = "GuildZiCaiDonateHistory_C2M")]
	[Serializable]
	public class GuildZiCaiDonateHistory_C2M : IExtensible
	{
		// Token: 0x060044DD RID: 17629 RVA: 0x00082F70 File Offset: 0x00081170
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001134 RID: 4404
		private IExtension extensionObject;
	}
}
