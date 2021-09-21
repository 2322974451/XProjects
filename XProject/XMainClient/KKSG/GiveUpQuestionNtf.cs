using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013C RID: 316
	[ProtoContract(Name = "GiveUpQuestionNtf")]
	[Serializable]
	public class GiveUpQuestionNtf : IExtensible
	{
		// Token: 0x06001345 RID: 4933 RVA: 0x00026F90 File Offset: 0x00025190
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004CE RID: 1230
		private IExtension extensionObject;
	}
}
