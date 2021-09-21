using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041C RID: 1052
	[ProtoContract(Name = "WeekEnd4v4GetInfoArg")]
	[Serializable]
	public class WeekEnd4v4GetInfoArg : IExtensible
	{
		// Token: 0x060037DC RID: 14300 RVA: 0x0006AF2C File Offset: 0x0006912C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DD8 RID: 3544
		private IExtension extensionObject;
	}
}
