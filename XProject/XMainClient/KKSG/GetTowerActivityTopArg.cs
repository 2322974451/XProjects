using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000108 RID: 264
	[ProtoContract(Name = "GetTowerActivityTopArg")]
	[Serializable]
	public class GetTowerActivityTopArg : IExtensible
	{
		// Token: 0x060010CA RID: 4298 RVA: 0x0002260C File Offset: 0x0002080C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000433 RID: 1075
		private IExtension extensionObject;
	}
}
