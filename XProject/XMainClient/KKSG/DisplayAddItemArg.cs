using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DisplayAddItemArg")]
	[Serializable]
	public class DisplayAddItemArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "add_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint add_item_id
		{
			get
			{
				return this._add_item_id ?? 0U;
			}
			set
			{
				this._add_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool add_item_idSpecified
		{
			get
			{
				return this._add_item_id != null;
			}
			set
			{
				bool flag = value == (this._add_item_id == null);
				if (flag)
				{
					this._add_item_id = (value ? new uint?(this.add_item_id) : null);
				}
			}
		}

		private bool ShouldSerializeadd_item_id()
		{
			return this.add_item_idSpecified;
		}

		private void Resetadd_item_id()
		{
			this.add_item_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "del_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint del_item_id
		{
			get
			{
				return this._del_item_id ?? 0U;
			}
			set
			{
				this._del_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool del_item_idSpecified
		{
			get
			{
				return this._del_item_id != null;
			}
			set
			{
				bool flag = value == (this._del_item_id == null);
				if (flag)
				{
					this._del_item_id = (value ? new uint?(this.del_item_id) : null);
				}
			}
		}

		private bool ShouldSerializedel_item_id()
		{
			return this.del_item_idSpecified;
		}

		private void Resetdel_item_id()
		{
			this.del_item_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _add_item_id;

		private uint? _del_item_id;

		private IExtension extensionObject;
	}
}
