using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PrivateChatList")]
	[Serializable]
	public class PrivateChatList : IExtensible
	{

		[ProtoMember(1, Name = "rolelist", DataFormat = DataFormat.Default)]
		public List<ChatSource> rolelist
		{
			get
			{
				return this._rolelist;
			}
		}

		[ProtoMember(2, Name = "hasOfflineChat", DataFormat = DataFormat.Default)]
		public List<bool> hasOfflineChat
		{
			get
			{
				return this._hasOfflineChat;
			}
		}

		[ProtoMember(3, Name = "lastChatTime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lastChatTime
		{
			get
			{
				return this._lastChatTime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ChatSource> _rolelist = new List<ChatSource>();

		private readonly List<bool> _hasOfflineChat = new List<bool>();

		private readonly List<uint> _lastChatTime = new List<uint>();

		private IExtension extensionObject;
	}
}
