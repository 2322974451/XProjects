using System;

namespace ProtoBuf
{
	// Token: 0x02000846 RID: 2118
	public interface IExtensible
	{
		// Token: 0x06008267 RID: 33383
		IExtension GetExtensionObject(bool createIfMissing);
	}
}
