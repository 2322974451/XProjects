using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeNameArg")]
	[Serializable]
	public class ChangeNameArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "iscostitem", DataFormat = DataFormat.Default)]
		public bool iscostitem
		{
			get
			{
				return this._iscostitem ?? false;
			}
			set
			{
				this._iscostitem = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscostitemSpecified
		{
			get
			{
				return this._iscostitem != null;
			}
			set
			{
				bool flag = value == (this._iscostitem == null);
				if (flag)
				{
					this._iscostitem = (value ? new bool?(this.iscostitem) : null);
				}
			}
		}

		private bool ShouldSerializeiscostitem()
		{
			return this.iscostitemSpecified;
		}

		private void Resetiscostitem()
		{
			this.iscostitemSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private bool? _iscostitem;

		private IExtension extensionObject;
	}
}
