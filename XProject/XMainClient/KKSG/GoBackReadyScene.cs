using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D2 RID: 1234
	[ProtoContract(Name = "GoBackReadyScene")]
	[Serializable]
	public class GoBackReadyScene : IExtensible
	{
		// Token: 0x0600400A RID: 16394 RVA: 0x00079FCC File Offset: 0x000781CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FF1 RID: 4081
		private IExtension extensionObject;
	}
}
