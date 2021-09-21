using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015A RID: 346
	[ProtoContract(Name = "AskGuildSkillInfoArg")]
	[Serializable]
	public class AskGuildSkillInfoArg : IExtensible
	{
		// Token: 0x0600152B RID: 5419 RVA: 0x0002A984 File Offset: 0x00028B84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000541 RID: 1345
		private IExtension extensionObject;
	}
}
