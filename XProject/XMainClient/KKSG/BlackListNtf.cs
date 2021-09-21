using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007F RID: 127
	[ProtoContract(Name = "BlackListNtf")]
	[Serializable]
	public class BlackListNtf : IExtensible
	{
		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00012394 File Offset: 0x00010594
		[ProtoMember(1, Name = "blacklist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> blacklist
		{
			get
			{
				return this._blacklist;
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x000123AC File Offset: 0x000105AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400021B RID: 539
		private readonly List<Friend2Client> _blacklist = new List<Friend2Client>();

		// Token: 0x0400021C RID: 540
		private IExtension extensionObject;
	}
}
