using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampExchangeOperateArg")]
	[Serializable]
	public class GuildCampExchangeOperateArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "operate_type", DataFormat = DataFormat.TwosComplement)]
		public GuildCampItemOperate operate_type
		{
			get
			{
				return this._operate_type ?? GuildCampItemOperate.SWINGUPITEM;
			}
			set
			{
				this._operate_type = new GuildCampItemOperate?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool operate_typeSpecified
		{
			get
			{
				return this._operate_type != null;
			}
			set
			{
				bool flag = value == (this._operate_type == null);
				if (flag)
				{
					this._operate_type = (value ? new GuildCampItemOperate?(this.operate_type) : null);
				}
			}
		}

		private bool ShouldSerializeoperate_type()
		{
			return this.operate_typeSpecified;
		}

		private void Resetoperate_type()
		{
			this.operate_typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong item_uid
		{
			get
			{
				return this._item_uid ?? 0UL;
			}
			set
			{
				this._item_uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool item_uidSpecified
		{
			get
			{
				return this._item_uid != null;
			}
			set
			{
				bool flag = value == (this._item_uid == null);
				if (flag)
				{
					this._item_uid = (value ? new ulong?(this.item_uid) : null);
				}
			}
		}

		private bool ShouldSerializeitem_uid()
		{
			return this.item_uidSpecified;
		}

		private void Resetitem_uid()
		{
			this.item_uidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "confirm", DataFormat = DataFormat.Default)]
		public bool confirm
		{
			get
			{
				return this._confirm ?? false;
			}
			set
			{
				this._confirm = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool confirmSpecified
		{
			get
			{
				return this._confirm != null;
			}
			set
			{
				bool flag = value == (this._confirm == null);
				if (flag)
				{
					this._confirm = (value ? new bool?(this.confirm) : null);
				}
			}
		}

		private bool ShouldSerializeconfirm()
		{
			return this.confirmSpecified;
		}

		private void Resetconfirm()
		{
			this.confirmSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "audio_id", DataFormat = DataFormat.TwosComplement)]
		public ulong audio_id
		{
			get
			{
				return this._audio_id ?? 0UL;
			}
			set
			{
				this._audio_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audio_idSpecified
		{
			get
			{
				return this._audio_id != null;
			}
			set
			{
				bool flag = value == (this._audio_id == null);
				if (flag)
				{
					this._audio_id = (value ? new ulong?(this.audio_id) : null);
				}
			}
		}

		private bool ShouldSerializeaudio_id()
		{
			return this.audio_idSpecified;
		}

		private void Resetaudio_id()
		{
			this.audio_idSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "audio_time", DataFormat = DataFormat.TwosComplement)]
		public uint audio_time
		{
			get
			{
				return this._audio_time ?? 0U;
			}
			set
			{
				this._audio_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audio_timeSpecified
		{
			get
			{
				return this._audio_time != null;
			}
			set
			{
				bool flag = value == (this._audio_time == null);
				if (flag)
				{
					this._audio_time = (value ? new uint?(this.audio_time) : null);
				}
			}
		}

		private bool ShouldSerializeaudio_time()
		{
			return this.audio_timeSpecified;
		}

		private void Resetaudio_time()
		{
			this.audio_timeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "chat_text", DataFormat = DataFormat.Default)]
		public string chat_text
		{
			get
			{
				return this._chat_text ?? "";
			}
			set
			{
				this._chat_text = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chat_textSpecified
		{
			get
			{
				return this._chat_text != null;
			}
			set
			{
				bool flag = value == (this._chat_text == null);
				if (flag)
				{
					this._chat_text = (value ? this.chat_text : null);
				}
			}
		}

		private bool ShouldSerializechat_text()
		{
			return this.chat_textSpecified;
		}

		private void Resetchat_text()
		{
			this.chat_textSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildCampItemOperate? _operate_type;

		private ulong? _item_uid;

		private bool? _confirm;

		private ulong? _audio_id;

		private uint? _audio_time;

		private string _chat_text;

		private IExtension extensionObject;
	}
}
