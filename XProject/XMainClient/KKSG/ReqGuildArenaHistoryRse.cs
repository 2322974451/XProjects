using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C6 RID: 710
	[ProtoContract(Name = "ReqGuildArenaHistoryRse")]
	[Serializable]
	public class ReqGuildArenaHistoryRse : IExtensible
	{
		// Token: 0x17000C35 RID: 3125
		// (get) Token: 0x06002742 RID: 10050 RVA: 0x0004C570 File Offset: 0x0004A770
		[ProtoMember(1, Name = "history", DataFormat = DataFormat.Default)]
		public List<GuildArenaHistory> history
		{
			get
			{
				return this._history;
			}
		}

		// Token: 0x06002743 RID: 10051 RVA: 0x0004C588 File Offset: 0x0004A788
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009C3 RID: 2499
		private readonly List<GuildArenaHistory> _history = new List<GuildArenaHistory>();

		// Token: 0x040009C4 RID: 2500
		private IExtension extensionObject;
	}
}
