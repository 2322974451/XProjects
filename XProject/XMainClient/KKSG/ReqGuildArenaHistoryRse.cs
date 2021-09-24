using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildArenaHistoryRse")]
	[Serializable]
	public class ReqGuildArenaHistoryRse : IExtensible
	{

		[ProtoMember(1, Name = "history", DataFormat = DataFormat.Default)]
		public List<GuildArenaHistory> history
		{
			get
			{
				return this._history;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildArenaHistory> _history = new List<GuildArenaHistory>();

		private IExtension extensionObject;
	}
}
