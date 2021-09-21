using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000265 RID: 613
	[ProtoContract(Name = "gmfjoinarg")]
	[Serializable]
	public class gmfjoinarg : IExtensible
	{
		// Token: 0x0600224F RID: 8783 RVA: 0x000430EC File Offset: 0x000412EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000882 RID: 2178
		private IExtension extensionObject;
	}
}
