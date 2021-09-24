using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampChatInfo")]
	[Serializable]
	public class GuildCampChatInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "audio_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "audio_time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "chat_text", DataFormat = DataFormat.Default)]
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

		private ulong? _audio_id;

		private uint? _audio_time;

		private string _chat_text;

		private IExtension extensionObject;
	}
}
