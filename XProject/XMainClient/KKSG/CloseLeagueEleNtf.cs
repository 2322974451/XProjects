using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A2 RID: 930
	[ProtoContract(Name = "CloseLeagueEleNtf")]
	[Serializable]
	public class CloseLeagueEleNtf : IExtensible
	{
		// Token: 0x06003220 RID: 12832 RVA: 0x000607E4 File Offset: 0x0005E9E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C73 RID: 3187
		private IExtension extensionObject;
	}
}
