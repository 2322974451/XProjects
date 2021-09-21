using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002B RID: 43
	[ProtoContract(Name = "QueryLotteryCDArg")]
	[Serializable]
	public class QueryLotteryCDArg : IExtensible
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x000085FC File Offset: 0x000067FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000CA RID: 202
		private IExtension extensionObject;
	}
}
