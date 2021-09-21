using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000219 RID: 537
	[ProtoContract(Name = "PlayDiceOverArg")]
	[Serializable]
	public class PlayDiceOverArg : IExtensible
	{
		// Token: 0x06001E13 RID: 7699 RVA: 0x0003B17C File Offset: 0x0003937C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000785 RID: 1925
		private IExtension extensionObject;
	}
}
