using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020F RID: 527
	[ProtoContract(Name = "PlayDiceOverData")]
	[Serializable]
	public class PlayDiceOverData : IExtensible
	{
		// Token: 0x06001DC7 RID: 7623 RVA: 0x0003A900 File Offset: 0x00038B00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000770 RID: 1904
		private IExtension extensionObject;
	}
}
