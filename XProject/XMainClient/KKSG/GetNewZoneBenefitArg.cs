using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051F RID: 1311
	[ProtoContract(Name = "GetNewZoneBenefitArg")]
	[Serializable]
	public class GetNewZoneBenefitArg : IExtensible
	{
		// Token: 0x06004372 RID: 17266 RVA: 0x00080510 File Offset: 0x0007E710
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010CF RID: 4303
		private IExtension extensionObject;
	}
}
