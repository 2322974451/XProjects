using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AudioBrief")]
	[Serializable]
	public class AudioBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "audio", DataFormat = DataFormat.Default)]
		public byte[] audio
		{
			get
			{
				return this._audio ?? null;
			}
			set
			{
				this._audio = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioSpecified
		{
			get
			{
				return this._audio != null;
			}
			set
			{
				bool flag = value == (this._audio == null);
				if (flag)
				{
					this._audio = (value ? this.audio : null);
				}
			}
		}

		private bool ShouldSerializeaudio()
		{
			return this.audioSpecified;
		}

		private void Resetaudio()
		{
			this.audioSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public byte[] text
		{
			get
			{
				return this._text ?? null;
			}
			set
			{
				this._text = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		private void Resettext()
		{
			this.textSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _audioUid;

		private byte[] _audio;

		private byte[] _text;

		private IExtension extensionObject;
	}
}
