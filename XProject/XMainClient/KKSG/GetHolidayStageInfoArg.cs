using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000397 RID: 919
	[ProtoContract(Name = "GetHolidayStageInfoArg")]
	[Serializable]
	public class GetHolidayStageInfoArg : IExtensible
	{
		// Token: 0x060031A4 RID: 12708 RVA: 0x0005F988 File Offset: 0x0005DB88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C54 RID: 3156
		private IExtension extensionObject;
	}
}
