using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QANotify")]
	[Serializable]
	public class QANotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "is_playing", DataFormat = DataFormat.Default)]
		public bool is_playing
		{
			get
			{
				return this._is_playing ?? false;
			}
			set
			{
				this._is_playing = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_playingSpecified
		{
			get
			{
				return this._is_playing != null;
			}
			set
			{
				bool flag = value == (this._is_playing == null);
				if (flag)
				{
					this._is_playing = (value ? new bool?(this.is_playing) : null);
				}
			}
		}

		private bool ShouldSerializeis_playing()
		{
			return this.is_playingSpecified;
		}

		private void Resetis_playing()
		{
			this.is_playingSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "is_over", DataFormat = DataFormat.Default)]
		public bool is_over
		{
			get
			{
				return this._is_over ?? false;
			}
			set
			{
				this._is_over = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_overSpecified
		{
			get
			{
				return this._is_over != null;
			}
			set
			{
				bool flag = value == (this._is_over == null);
				if (flag)
				{
					this._is_over = (value ? new bool?(this.is_over) : null);
				}
			}
		}

		private bool ShouldSerializeis_over()
		{
			return this.is_overSpecified;
		}

		private void Resetis_over()
		{
			this.is_overSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private bool? _is_playing;

		private bool? _is_over;

		private IExtension extensionObject;
	}
}
