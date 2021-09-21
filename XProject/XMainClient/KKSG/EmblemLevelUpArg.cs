using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003B RID: 59
	[ProtoContract(Name = "EmblemLevelUpArg")]
	[Serializable]
	public class EmblemLevelUpArg : IExtensible
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000A4C8 File Offset: 0x000086C8
		[ProtoMember(1, Name = "EmblemUniqueId", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> EmblemUniqueId
		{
			get
			{
				return this._EmblemUniqueId;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000A4E0 File Offset: 0x000086E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400010C RID: 268
		private readonly List<ulong> _EmblemUniqueId = new List<ulong>();

		// Token: 0x0400010D RID: 269
		private IExtension extensionObject;
	}
}
