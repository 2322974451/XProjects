using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SubScribe")]
	[Serializable]
	public class SubScribe : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
		public string title
		{
			get
			{
				return this._title ?? "";
			}
			set
			{
				this._title = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? this.title : null);
				}
			}
		}

		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "status", DataFormat = DataFormat.Default)]
		public bool status
		{
			get
			{
				return this._status ?? false;
			}
			set
			{
				this._status = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new bool?(this.status) : null);
				}
			}
		}

		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private string _title;

		private bool? _status;

		private IExtension extensionObject;
	}
}
