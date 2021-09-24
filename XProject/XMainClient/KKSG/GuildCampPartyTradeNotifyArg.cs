using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampPartyTradeNotifyArg")]
	[Serializable]
	public class GuildCampPartyTradeNotifyArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "notify_type", DataFormat = DataFormat.TwosComplement)]
		public GuildCampPartyTradeType notify_type
		{
			get
			{
				return this._notify_type ?? GuildCampPartyTradeType.TRADE_INVITATION;
			}
			set
			{
				this._notify_type = new GuildCampPartyTradeType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notify_typeSpecified
		{
			get
			{
				return this._notify_type != null;
			}
			set
			{
				bool flag = value == (this._notify_type == null);
				if (flag)
				{
					this._notify_type = (value ? new GuildCampPartyTradeType?(this.notify_type) : null);
				}
			}
		}

		private bool ShouldSerializenotify_type()
		{
			return this.notify_typeSpecified;
		}

		private void Resetnotify_type()
		{
			this.notify_typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0UL;
			}
			set
			{
				this._lauch_role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new ulong?(this.lauch_role_id) : null);
				}
			}
		}

		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lauch_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_item_id
		{
			get
			{
				return this._lauch_item_id ?? 0U;
			}
			set
			{
				this._lauch_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_idSpecified
		{
			get
			{
				return this._lauch_item_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_id == null);
				if (flag)
				{
					this._lauch_item_id = (value ? new uint?(this.lauch_item_id) : null);
				}
			}
		}

		private bool ShouldSerializelauch_item_id()
		{
			return this.lauch_item_idSpecified;
		}

		private void Resetlauch_item_id()
		{
			this.lauch_item_idSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lauch_item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_item_uid
		{
			get
			{
				return this._lauch_item_uid ?? 0UL;
			}
			set
			{
				this._lauch_item_uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_uidSpecified
		{
			get
			{
				return this._lauch_item_uid != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_uid == null);
				if (flag)
				{
					this._lauch_item_uid = (value ? new ulong?(this.lauch_item_uid) : null);
				}
			}
		}

		private bool ShouldSerializelauch_item_uid()
		{
			return this.lauch_item_uidSpecified;
		}

		private void Resetlauch_item_uid()
		{
			this.lauch_item_uidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lauch_confirm", DataFormat = DataFormat.Default)]
		public bool lauch_confirm
		{
			get
			{
				return this._lauch_confirm ?? false;
			}
			set
			{
				this._lauch_confirm = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_confirmSpecified
		{
			get
			{
				return this._lauch_confirm != null;
			}
			set
			{
				bool flag = value == (this._lauch_confirm == null);
				if (flag)
				{
					this._lauch_confirm = (value ? new bool?(this.lauch_confirm) : null);
				}
			}
		}

		private bool ShouldSerializelauch_confirm()
		{
			return this.lauch_confirmSpecified;
		}

		private void Resetlauch_confirm()
		{
			this.lauch_confirmSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "target_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong target_role_id
		{
			get
			{
				return this._target_role_id ?? 0UL;
			}
			set
			{
				this._target_role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_role_idSpecified
		{
			get
			{
				return this._target_role_id != null;
			}
			set
			{
				bool flag = value == (this._target_role_id == null);
				if (flag)
				{
					this._target_role_id = (value ? new ulong?(this.target_role_id) : null);
				}
			}
		}

		private bool ShouldSerializetarget_role_id()
		{
			return this.target_role_idSpecified;
		}

		private void Resettarget_role_id()
		{
			this.target_role_idSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "target_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_item_id
		{
			get
			{
				return this._target_item_id ?? 0U;
			}
			set
			{
				this._target_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_idSpecified
		{
			get
			{
				return this._target_item_id != null;
			}
			set
			{
				bool flag = value == (this._target_item_id == null);
				if (flag)
				{
					this._target_item_id = (value ? new uint?(this.target_item_id) : null);
				}
			}
		}

		private bool ShouldSerializetarget_item_id()
		{
			return this.target_item_idSpecified;
		}

		private void Resettarget_item_id()
		{
			this.target_item_idSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "target_item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong target_item_uid
		{
			get
			{
				return this._target_item_uid ?? 0UL;
			}
			set
			{
				this._target_item_uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_uidSpecified
		{
			get
			{
				return this._target_item_uid != null;
			}
			set
			{
				bool flag = value == (this._target_item_uid == null);
				if (flag)
				{
					this._target_item_uid = (value ? new ulong?(this.target_item_uid) : null);
				}
			}
		}

		private bool ShouldSerializetarget_item_uid()
		{
			return this.target_item_uidSpecified;
		}

		private void Resettarget_item_uid()
		{
			this.target_item_uidSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "target_confirm", DataFormat = DataFormat.Default)]
		public bool target_confirm
		{
			get
			{
				return this._target_confirm ?? false;
			}
			set
			{
				this._target_confirm = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_confirmSpecified
		{
			get
			{
				return this._target_confirm != null;
			}
			set
			{
				bool flag = value == (this._target_confirm == null);
				if (flag)
				{
					this._target_confirm = (value ? new bool?(this.target_confirm) : null);
				}
			}
		}

		private bool ShouldSerializetarget_confirm()
		{
			return this.target_confirmSpecified;
		}

		private void Resettarget_confirm()
		{
			this.target_confirmSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "lauch_count", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_count
		{
			get
			{
				return this._lauch_count ?? 0U;
			}
			set
			{
				this._lauch_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_countSpecified
		{
			get
			{
				return this._lauch_count != null;
			}
			set
			{
				bool flag = value == (this._lauch_count == null);
				if (flag)
				{
					this._lauch_count = (value ? new uint?(this.lauch_count) : null);
				}
			}
		}

		private bool ShouldSerializelauch_count()
		{
			return this.lauch_countSpecified;
		}

		private void Resetlauch_count()
		{
			this.lauch_countSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "open_trade", DataFormat = DataFormat.Default)]
		public bool open_trade
		{
			get
			{
				return this._open_trade ?? false;
			}
			set
			{
				this._open_trade = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool open_tradeSpecified
		{
			get
			{
				return this._open_trade != null;
			}
			set
			{
				bool flag = value == (this._open_trade == null);
				if (flag)
				{
					this._open_trade = (value ? new bool?(this.open_trade) : null);
				}
			}
		}

		private bool ShouldSerializeopen_trade()
		{
			return this.open_tradeSpecified;
		}

		private void Resetopen_trade()
		{
			this.open_tradeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "lauch_name", DataFormat = DataFormat.Default)]
		public string lauch_name
		{
			get
			{
				return this._lauch_name ?? "";
			}
			set
			{
				this._lauch_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_nameSpecified
		{
			get
			{
				return this._lauch_name != null;
			}
			set
			{
				bool flag = value == (this._lauch_name == null);
				if (flag)
				{
					this._lauch_name = (value ? this.lauch_name : null);
				}
			}
		}

		private bool ShouldSerializelauch_name()
		{
			return this.lauch_nameSpecified;
		}

		private void Resetlauch_name()
		{
			this.lauch_nameSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "lauch_profession", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_profession
		{
			get
			{
				return this._lauch_profession ?? 0U;
			}
			set
			{
				this._lauch_profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_professionSpecified
		{
			get
			{
				return this._lauch_profession != null;
			}
			set
			{
				bool flag = value == (this._lauch_profession == null);
				if (flag)
				{
					this._lauch_profession = (value ? new uint?(this.lauch_profession) : null);
				}
			}
		}

		private bool ShouldSerializelauch_profession()
		{
			return this.lauch_professionSpecified;
		}

		private void Resetlauch_profession()
		{
			this.lauch_professionSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "target_name", DataFormat = DataFormat.Default)]
		public string target_name
		{
			get
			{
				return this._target_name ?? "";
			}
			set
			{
				this._target_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_nameSpecified
		{
			get
			{
				return this._target_name != null;
			}
			set
			{
				bool flag = value == (this._target_name == null);
				if (flag)
				{
					this._target_name = (value ? this.target_name : null);
				}
			}
		}

		private bool ShouldSerializetarget_name()
		{
			return this.target_nameSpecified;
		}

		private void Resettarget_name()
		{
			this.target_nameSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "target_profession", DataFormat = DataFormat.TwosComplement)]
		public uint target_profession
		{
			get
			{
				return this._target_profession ?? 0U;
			}
			set
			{
				this._target_profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_professionSpecified
		{
			get
			{
				return this._target_profession != null;
			}
			set
			{
				bool flag = value == (this._target_profession == null);
				if (flag)
				{
					this._target_profession = (value ? new uint?(this.target_profession) : null);
				}
			}
		}

		private bool ShouldSerializetarget_profession()
		{
			return this.target_professionSpecified;
		}

		private void Resettarget_profession()
		{
			this.target_professionSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "lauch_chat_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildCampChatInfo lauch_chat_info
		{
			get
			{
				return this._lauch_chat_info;
			}
			set
			{
				this._lauch_chat_info = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "target_chat_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildCampChatInfo target_chat_info
		{
			get
			{
				return this._target_chat_info;
			}
			set
			{
				this._target_chat_info = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildCampPartyTradeType? _notify_type;

		private ulong? _lauch_role_id;

		private uint? _lauch_item_id;

		private ulong? _lauch_item_uid;

		private bool? _lauch_confirm;

		private ulong? _target_role_id;

		private uint? _target_item_id;

		private ulong? _target_item_uid;

		private bool? _target_confirm;

		private uint? _lauch_count;

		private bool? _open_trade;

		private string _lauch_name;

		private uint? _lauch_profession;

		private string _target_name;

		private uint? _target_profession;

		private GuildCampChatInfo _lauch_chat_info = null;

		private GuildCampChatInfo _target_chat_info = null;

		private IExtension extensionObject;
	}
}
