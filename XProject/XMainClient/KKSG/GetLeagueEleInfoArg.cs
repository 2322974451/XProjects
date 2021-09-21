using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039F RID: 927
	[ProtoContract(Name = "GetLeagueEleInfoArg")]
	[Serializable]
	public class GetLeagueEleInfoArg : IExtensible
	{
		// Token: 0x0600320F RID: 12815 RVA: 0x00060634 File Offset: 0x0005E834
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C6C RID: 3180
		private IExtension extensionObject;
	}
}
