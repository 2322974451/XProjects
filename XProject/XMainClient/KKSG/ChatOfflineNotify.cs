using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C0 RID: 192
	[ProtoContract(Name = "ChatOfflineNotify")]
	[Serializable]
	public class ChatOfflineNotify : IExtensible
	{
		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x0001B054 File Offset: 0x00019254
		[ProtoMember(1, Name = "rolechat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> rolechat
		{
			get
			{
				return this._rolechat;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x0001B06C File Offset: 0x0001926C
		[ProtoMember(2, Name = "guildchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> guildchat
		{
			get
			{
				return this._guildchat;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0001B084 File Offset: 0x00019284
		[ProtoMember(3, Name = "worldchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> worldchat
		{
			get
			{
				return this._worldchat;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0001B09C File Offset: 0x0001929C
		[ProtoMember(4, Name = "teamchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> teamchat
		{
			get
			{
				return this._teamchat;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x0001B0B4 File Offset: 0x000192B4
		// (set) Token: 0x06000CDD RID: 3293 RVA: 0x0001B0CC File Offset: 0x000192CC
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

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x0001B0D8 File Offset: 0x000192D8
		[ProtoMember(6, Name = "partnerchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> partnerchat
		{
			get
			{
				return this._partnerchat;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x0001B0F0 File Offset: 0x000192F0
		[ProtoMember(7, Name = "groupchat", DataFormat = DataFormat.Default)]
		public List<ChatInfo> groupchat
		{
			get
			{
				return this._groupchat;
			}
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0001B108 File Offset: 0x00019308
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000331 RID: 817
		private readonly List<ChatInfo> _rolechat = new List<ChatInfo>();

		// Token: 0x04000332 RID: 818
		private readonly List<ChatInfo> _guildchat = new List<ChatInfo>();

		// Token: 0x04000333 RID: 819
		private readonly List<ChatInfo> _worldchat = new List<ChatInfo>();

		// Token: 0x04000334 RID: 820
		private readonly List<ChatInfo> _teamchat = new List<ChatInfo>();

		// Token: 0x04000335 RID: 821
		private PrivateChatList _privatechatlist = null;

		// Token: 0x04000336 RID: 822
		private readonly List<ChatInfo> _partnerchat = new List<ChatInfo>();

		// Token: 0x04000337 RID: 823
		private readonly List<ChatInfo> _groupchat = new List<ChatInfo>();

		// Token: 0x04000338 RID: 824
		private IExtension extensionObject;
	}
}
