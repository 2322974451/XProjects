using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StcDesignationInfo")]
	[Serializable]
	public class StcDesignationInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "designationID", DataFormat = DataFormat.TwosComplement)]
		public uint designationID
		{
			get
			{
				return this._designationID ?? 0U;
			}
			set
			{
				this._designationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool designationIDSpecified
		{
			get
			{
				return this._designationID != null;
			}
			set
			{
				bool flag = value == (this._designationID == null);
				if (flag)
				{
					this._designationID = (value ? new uint?(this.designationID) : null);
				}
			}
		}

		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isNew", DataFormat = DataFormat.Default)]
		public bool isNew
		{
			get
			{
				return this._isNew ?? false;
			}
			set
			{
				this._isNew = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isNewSpecified
		{
			get
			{
				return this._isNew != null;
			}
			set
			{
				bool flag = value == (this._isNew == null);
				if (flag)
				{
					this._isNew = (value ? new bool?(this.isNew) : null);
				}
			}
		}

		private bool ShouldSerializeisNew()
		{
			return this.isNewSpecified;
		}

		private void ResetisNew()
		{
			this.isNewSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "reachTimestamp", DataFormat = DataFormat.TwosComplement)]
		public uint reachTimestamp
		{
			get
			{
				return this._reachTimestamp ?? 0U;
			}
			set
			{
				this._reachTimestamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reachTimestampSpecified
		{
			get
			{
				return this._reachTimestamp != null;
			}
			set
			{
				bool flag = value == (this._reachTimestamp == null);
				if (flag)
				{
					this._reachTimestamp = (value ? new uint?(this.reachTimestamp) : null);
				}
			}
		}

		private bool ShouldSerializereachTimestamp()
		{
			return this.reachTimestampSpecified;
		}

		private void ResetreachTimestamp()
		{
			this.reachTimestampSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _designationID;

		private bool? _isNew;

		private uint? _reachTimestamp;

		private string _name;

		private uint? _type;

		private IExtension extensionObject;
	}
}
