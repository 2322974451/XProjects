using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CC RID: 716
	[ProtoContract(Name = "GuildBuffSimpleItem")]
	[Serializable]
	public class GuildBuffSimpleItem : IExtensible
	{
		// Token: 0x17000C46 RID: 3142
		// (get) Token: 0x0600277B RID: 10107 RVA: 0x0004CC1C File Offset: 0x0004AE1C
		// (set) Token: 0x0600277C RID: 10108 RVA: 0x0004CC49 File Offset: 0x0004AE49
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000C47 RID: 3143
		// (get) Token: 0x0600277D RID: 10109 RVA: 0x0004CC58 File Offset: 0x0004AE58
		// (set) Token: 0x0600277E RID: 10110 RVA: 0x0004CC78 File Offset: 0x0004AE78
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x0600277F RID: 10111 RVA: 0x0004CCBC File Offset: 0x0004AEBC
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06002780 RID: 10112 RVA: 0x0004CCD4 File Offset: 0x0004AED4
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17000C48 RID: 3144
		// (get) Token: 0x06002781 RID: 10113 RVA: 0x0004CCE0 File Offset: 0x0004AEE0
		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<GuildBuffItem> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x17000C49 RID: 3145
		// (get) Token: 0x06002782 RID: 10114 RVA: 0x0004CCF8 File Offset: 0x0004AEF8
		[ProtoMember(3, Name = "chatinfo", DataFormat = DataFormat.Default)]
		public List<ChatInfo> chatinfo
		{
			get
			{
				return this._chatinfo;
			}
		}

		// Token: 0x06002783 RID: 10115 RVA: 0x0004CD10 File Offset: 0x0004AF10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009D3 RID: 2515
		private ulong? _guildid;

		// Token: 0x040009D4 RID: 2516
		private readonly List<GuildBuffItem> _item = new List<GuildBuffItem>();

		// Token: 0x040009D5 RID: 2517
		private readonly List<ChatInfo> _chatinfo = new List<ChatInfo>();

		// Token: 0x040009D6 RID: 2518
		private IExtension extensionObject;
	}
}
