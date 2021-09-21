using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A1 RID: 417
	[ProtoContract(Name = "AskGuildArenaTeamInfoArg")]
	[Serializable]
	public class AskGuildArenaTeamInfoArg : IExtensible
	{
		// Token: 0x060018CA RID: 6346 RVA: 0x000314AC File Offset: 0x0002F6AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000624 RID: 1572
		private IExtension extensionObject;
	}
}
