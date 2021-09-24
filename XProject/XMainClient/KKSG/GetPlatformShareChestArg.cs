using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPlatformShareChestArg")]
	[Serializable]
	public class GetPlatformShareChestArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "box_id", DataFormat = DataFormat.TwosComplement)]
		public uint box_id
		{
			get
			{
				return this._box_id ?? 0U;
			}
			set
			{
				this._box_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool box_idSpecified
		{
			get
			{
				return this._box_id != null;
			}
			set
			{
				bool flag = value == (this._box_id == null);
				if (flag)
				{
					this._box_id = (value ? new uint?(this.box_id) : null);
				}
			}
		}

		private bool ShouldSerializebox_id()
		{
			return this.box_idSpecified;
		}

		private void Resetbox_id()
		{
			this.box_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "open_key", DataFormat = DataFormat.Default)]
		public string open_key
		{
			get
			{
				return this._open_key ?? "";
			}
			set
			{
				this._open_key = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool open_keySpecified
		{
			get
			{
				return this._open_key != null;
			}
			set
			{
				bool flag = value == (this._open_key == null);
				if (flag)
				{
					this._open_key = (value ? this.open_key : null);
				}
			}
		}

		private bool ShouldSerializeopen_key()
		{
			return this.open_keySpecified;
		}

		private void Resetopen_key()
		{
			this.open_keySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "share_type", DataFormat = DataFormat.TwosComplement)]
		public uint share_type
		{
			get
			{
				return this._share_type ?? 0U;
			}
			set
			{
				this._share_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool share_typeSpecified
		{
			get
			{
				return this._share_type != null;
			}
			set
			{
				bool flag = value == (this._share_type == null);
				if (flag)
				{
					this._share_type = (value ? new uint?(this.share_type) : null);
				}
			}
		}

		private bool ShouldSerializeshare_type()
		{
			return this.share_typeSpecified;
		}

		private void Resetshare_type()
		{
			this.share_typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _box_id;

		private string _open_key;

		private uint? _share_type;

		private IExtension extensionObject;
	}
}
