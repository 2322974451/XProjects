using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B3 RID: 691
	[ProtoContract(Name = "getapplyguildlistarg")]
	[Serializable]
	public class getapplyguildlistarg : IExtensible
	{
		// Token: 0x0600267C RID: 9852 RVA: 0x0004AE44 File Offset: 0x00049044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400098D RID: 2445
		private IExtension extensionObject;
	}
}
