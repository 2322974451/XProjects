using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CB RID: 203
	[ProtoContract(Name = "OnlineRewardReport")]
	[Serializable]
	public class OnlineRewardReport : IExtensible
	{
		// Token: 0x06000D3D RID: 3389 RVA: 0x0001BB34 File Offset: 0x00019D34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000352 RID: 850
		private IExtension extensionObject;
	}
}
