using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateDisplayItems")]
	[Serializable]
	public class UpdateDisplayItems : IExtensible
	{

		[ProtoMember(1, Name = "display_items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> display_items
		{
			get
			{
				return this._display_items;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_color_id
		{
			get
			{
				return this._hair_color_id ?? 0U;
			}
			set
			{
				this._hair_color_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hair_color_idSpecified
		{
			get
			{
				return this._hair_color_id != null;
			}
			set
			{
				bool flag = value == (this._hair_color_id == null);
				if (flag)
				{
					this._hair_color_id = (value ? new uint?(this.hair_color_id) : null);
				}
			}
		}

		private bool ShouldSerializehair_color_id()
		{
			return this.hair_color_idSpecified;
		}

		private void Resethair_color_id()
		{
			this.hair_color_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
		public uint special_effects_id
		{
			get
			{
				return this._special_effects_id ?? 0U;
			}
			set
			{
				this._special_effects_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool special_effects_idSpecified
		{
			get
			{
				return this._special_effects_id != null;
			}
			set
			{
				bool flag = value == (this._special_effects_id == null);
				if (flag)
				{
					this._special_effects_id = (value ? new uint?(this.special_effects_id) : null);
				}
			}
		}

		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _display_items = new List<uint>();

		private uint? _hair_color_id;

		private uint? _special_effects_id;

		private IExtension extensionObject;
	}
}
