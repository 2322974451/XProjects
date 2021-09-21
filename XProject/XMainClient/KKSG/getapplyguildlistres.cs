using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B4 RID: 692
	[ProtoContract(Name = "getapplyguildlistres")]
	[Serializable]
	public class getapplyguildlistres : IExtensible
	{
		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x0600267E RID: 9854 RVA: 0x0004AE78 File Offset: 0x00049078
		[ProtoMember(1, Name = "guildlist", DataFormat = DataFormat.Default)]
		public List<Integralunit> guildlist
		{
			get
			{
				return this._guildlist;
			}
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x0004AE90 File Offset: 0x00049090
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400098E RID: 2446
		private readonly List<Integralunit> _guildlist = new List<Integralunit>();

		// Token: 0x0400098F RID: 2447
		private IExtension extensionObject;
	}
}
