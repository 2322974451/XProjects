using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatOfflineNotify")]
	[Serializable]
	public class ChatOfflineNotify : IExtensible
	{

		[ProtoMember(1, Name = "rolechat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> rolechat
		{
			get
			{
				return this._rolechat;
			}
		}

		[ProtoMember(2, Name = "guildchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> guildchat
		{
			get
			{
				return this._guildchat;
			}
		}

		[ProtoMember(3, Name = "worldchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> worldchat
		{
			get
			{
				return this._worldchat;
			}
		}

		[ProtoMember(4, Name = "teamchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> teamchat
		{
			get
			{
				return this._teamchat;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "privatechatlist", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PrivateChatList privatechatlist
		{
			get
			{
				return this._privatechatlist;
			}
			set
			{
				this._privatechatlist = value;
			}
		}

		[ProtoMember(6, Name = "partnerchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> partnerchat
		{
			get
			{
				return this._partnerchat;
			}
		}

		[ProtoMember(7, Name = "groupchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> groupchat
		{
			get
			{
				return this._groupchat;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ChatInfo> _rolechat = new List<ChatInfo>();

		private readonly List<ChatInfo> _guildchat = new List<ChatInfo>();

		private readonly List<ChatInfo> _worldchat = new List<ChatInfo>();

		private readonly List<ChatInfo> _teamchat = new List<ChatInfo>();

		private PrivateChatList _privatechatlist = null;

		private readonly List<ChatInfo> _partnerchat = new List<ChatInfo>();

		private readonly List<ChatInfo> _groupchat = new List<ChatInfo>();

		private IExtension extensionObject;
	}
}
