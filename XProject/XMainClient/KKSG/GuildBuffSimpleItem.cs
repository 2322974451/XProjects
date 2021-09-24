using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBuffSimpleItem")]
	[Serializable]
	public class GuildBuffSimpleItem : IExtensible
	{

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

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<GuildBuffItem> item
		{
			get
			{
				return this._item;
			}
		}

		[ProtoMember(3, Name = "chatinfo", DataFormat = DataFormat.Default)]
		public List<ChatInfo> chatinfo
		{
			get
			{
				return this._chatinfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildid;

		private readonly List<GuildBuffItem> _item = new List<GuildBuffItem>();

		private readonly List<ChatInfo> _chatinfo = new List<ChatInfo>();

		private IExtension extensionObject;
	}
}
