using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BE RID: 1470
	[ProtoContract(Name = "PrivateChatList")]
	[Serializable]
	public class PrivateChatList : IExtensible
	{
		// Token: 0x1700196E RID: 6510
		// (get) Token: 0x06005245 RID: 21061 RVA: 0x0009C7A4 File Offset: 0x0009A9A4
		[ProtoMember(1, Name = "rolelist", DataFormat = DataFormat.Default)]
		public List<ChatSource> rolelist
		{
			get
			{
				return this._rolelist;
			}
		}

		// Token: 0x1700196F RID: 6511
		// (get) Token: 0x06005246 RID: 21062 RVA: 0x0009C7BC File Offset: 0x0009A9BC
		[ProtoMember(2, Name = "hasOfflineChat", DataFormat = DataFormat.Default)]
		public List<bool> hasOfflineChat
		{
			get
			{
				return this._hasOfflineChat;
			}
		}

		// Token: 0x17001970 RID: 6512
		// (get) Token: 0x06005247 RID: 21063 RVA: 0x0009C7D4 File Offset: 0x0009A9D4
		[ProtoMember(3, Name = "lastChatTime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lastChatTime
		{
			get
			{
				return this._lastChatTime;
			}
		}

		// Token: 0x06005248 RID: 21064 RVA: 0x0009C7EC File Offset: 0x0009A9EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400141C RID: 5148
		private readonly List<ChatSource> _rolelist = new List<ChatSource>();

		// Token: 0x0400141D RID: 5149
		private readonly List<bool> _hasOfflineChat = new List<bool>();

		// Token: 0x0400141E RID: 5150
		private readonly List<uint> _lastChatTime = new List<uint>();

		// Token: 0x0400141F RID: 5151
		private IExtension extensionObject;
	}
}
