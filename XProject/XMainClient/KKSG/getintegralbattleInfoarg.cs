using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B5 RID: 693
	[ProtoContract(Name = "getintegralbattleInfoarg")]
	[Serializable]
	public class getintegralbattleInfoarg : IExtensible
	{
		// Token: 0x06002681 RID: 9857 RVA: 0x0004AEB0 File Offset: 0x000490B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000990 RID: 2448
		private IExtension extensionObject;
	}
}
