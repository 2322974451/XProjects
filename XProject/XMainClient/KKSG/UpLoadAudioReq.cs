using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpLoadAudioReq")]
	[Serializable]
	public class UpLoadAudioReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "audio", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "srctype", DataFormat = DataFormat.TwosComplement)]
		public uint srctype
		{
			get
			{
				return this._srctype ?? 0U;
			}
			set
			{
				this._srctype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool srctypeSpecified
		{
			get
			{
				return this._srctype != null;
			}
			set
			{
				bool flag = value == (this._srctype == null);
				if (flag)
				{
					this._srctype = (value ? new uint?(this.srctype) : null);
				}
			}
		}

		private bool ShouldSerializesrctype()
		{
			return this.srctypeSpecified;
		}

		private void Resetsrctype()
		{
			this.srctypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "savetype", DataFormat = DataFormat.TwosComplement)]
		public uint savetype
		{
			get
			{
				return this._savetype ?? 0U;
			}
			set
			{
				this._savetype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool savetypeSpecified
		{
			get
			{
				return this._savetype != null;
			}
			set
			{
				bool flag = value == (this._savetype == null);
				if (flag)
				{
					this._savetype = (value ? new uint?(this.savetype) : null);
				}
			}
		}

		private bool ShouldSerializesavetype()
		{
			return this.savetypeSpecified;
		}

		private void Resetsavetype()
		{
			this.savetypeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "iscross", DataFormat = DataFormat.Default)]
		public bool iscross
		{
			get
			{
				return this._iscross ?? false;
			}
			set
			{
				this._iscross = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscrossSpecified
		{
			get
			{
				return this._iscross != null;
			}
			set
			{
				bool flag = value == (this._iscross == null);
				if (flag)
				{
					this._iscross = (value ? new bool?(this.iscross) : null);
				}
			}
		}

		private bool ShouldSerializeiscross()
		{
			return this.iscrossSpecified;
		}

		private void Resetiscross()
		{
			this.iscrossSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rpcid", DataFormat = DataFormat.TwosComplement)]
		public uint rpcid
		{
			get
			{
				return this._rpcid ?? 0U;
			}
			set
			{
				this._rpcid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rpcidSpecified
		{
			get
			{
				return this._rpcid != null;
			}
			set
			{
				bool flag = value == (this._rpcid == null);
				if (flag)
				{
					this._rpcid = (value ? new uint?(this.rpcid) : null);
				}
			}
		}

		private bool ShouldSerializerpcid()
		{
			return this.rpcidSpecified;
		}

		private void Resetrpcid()
		{
			this.rpcidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "audiouid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiouid
		{
			get
			{
				return this._audiouid ?? 0UL;
			}
			set
			{
				this._audiouid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audiouidSpecified
		{
			get
			{
				return this._audiouid != null;
			}
			set
			{
				bool flag = value == (this._audiouid == null);
				if (flag)
				{
					this._audiouid = (value ? new ulong?(this.audiouid) : null);
				}
			}
		}

		private bool ShouldSerializeaudiouid()
		{
			return this.audiouidSpecified;
		}

		private void Resetaudiouid()
		{
			this.audiouidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private byte[] _audio;

		private byte[] _text;

		private uint? _srctype;

		private uint? _savetype;

		private bool? _iscross;

		private uint? _rpcid;

		private ulong? _audiouid;

		private IExtension extensionObject;
	}
}
