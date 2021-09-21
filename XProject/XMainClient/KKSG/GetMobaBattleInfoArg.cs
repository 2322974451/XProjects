using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000443 RID: 1091
	[ProtoContract(Name = "GetMobaBattleInfoArg")]
	[Serializable]
	public class GetMobaBattleInfoArg : IExtensible
	{
		// Token: 0x0600398B RID: 14731 RVA: 0x0006E148 File Offset: 0x0006C348
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E48 RID: 3656
		private IExtension extensionObject;
	}
}
