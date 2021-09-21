using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033B RID: 827
	[ProtoContract(Name = "ReqGuildTerrCityInfoArg")]
	[Serializable]
	public class ReqGuildTerrCityInfoArg : IExtensible
	{
		// Token: 0x06002D76 RID: 11638 RVA: 0x00057FA4 File Offset: 0x000561A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B49 RID: 2889
		private IExtension extensionObject;
	}
}
