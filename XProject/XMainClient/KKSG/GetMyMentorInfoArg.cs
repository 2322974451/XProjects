using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030A RID: 778
	[ProtoContract(Name = "GetMyMentorInfoArg")]
	[Serializable]
	public class GetMyMentorInfoArg : IExtensible
	{
		// Token: 0x06002A8B RID: 10891 RVA: 0x0005273C File Offset: 0x0005093C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A8F RID: 2703
		private IExtension extensionObject;
	}
}
