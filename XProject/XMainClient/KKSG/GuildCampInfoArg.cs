using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BA RID: 698
	[ProtoContract(Name = "GuildCampInfoArg")]
	[Serializable]
	public class GuildCampInfoArg : IExtensible
	{
		// Token: 0x060026D0 RID: 9936 RVA: 0x0004B838 File Offset: 0x00049A38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009A3 RID: 2467
		private IExtension extensionObject;
	}
}
