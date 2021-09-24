using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AudioAuthKeyArg")]
	[Serializable]
	public class AudioAuthKeyArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "open_id", DataFormat = DataFormat.Default)]
		public string open_id
		{
			get
			{
				return this._open_id ?? "";
			}
			set
			{
				this._open_id = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool open_idSpecified
		{
			get
			{
				return this._open_id != null;
			}
			set
			{
				bool flag = value == (this._open_id == null);
				if (flag)
				{
					this._open_id = (value ? this.open_id : null);
				}
			}
		}

		private bool ShouldSerializeopen_id()
		{
			return this.open_idSpecified;
		}

		private void Resetopen_id()
		{
			this.open_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		private void Resetip()
		{
			this.ipSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _open_id;

		private string _ip;

		private IExtension extensionObject;
	}
}
