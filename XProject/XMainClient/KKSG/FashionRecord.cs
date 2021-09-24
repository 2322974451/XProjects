using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionRecord")]
	[Serializable]
	public class FashionRecord : IExtensible
	{

		[ProtoMember(1, Name = "bodyfashion", DataFormat = DataFormat.Default)]
		public List<FashionData> bodyfashion
		{
			get
			{
				return this._bodyfashion;
			}
		}

		[ProtoMember(2, Name = "bagfashion", DataFormat = DataFormat.Default)]
		public List<FashionData> bagfashion
		{
			get
			{
				return this._bagfashion;
			}
		}

		[ProtoMember(3, Name = "collected", DataFormat = DataFormat.TwosComplement)]
		public List<uint> collected
		{
			get
			{
				return this._collected;
			}
		}

		[ProtoMember(4, Name = "display_fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> display_fashion
		{
			get
			{
				return this._display_fashion;
			}
		}

		[ProtoMember(5, Name = "own_fashins", DataFormat = DataFormat.Default)]
		public List<ActivateFashionCharm> own_fashins
		{
			get
			{
				return this._own_fashins;
			}
		}

		[ProtoMember(6, Name = "own_display_items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> own_display_items
		{
			get
			{
				return this._own_display_items;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "conversion", DataFormat = DataFormat.Default)]
		public bool conversion
		{
			get
			{
				return this._conversion ?? false;
			}
			set
			{
				this._conversion = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool conversionSpecified
		{
			get
			{
				return this._conversion != null;
			}
			set
			{
				bool flag = value == (this._conversion == null);
				if (flag)
				{
					this._conversion = (value ? new bool?(this.conversion) : null);
				}
			}
		}

		private bool ShouldSerializeconversion()
		{
			return this.conversionSpecified;
		}

		private void Resetconversion()
		{
			this.conversionSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, Name = "hair_color_info", DataFormat = DataFormat.Default)]
		public List<ActivateHairColor> hair_color_info
		{
			get
			{
				return this._hair_color_info;
			}
		}

		[ProtoMember(10, Name = "fashionsynthersis_fail_info", DataFormat = DataFormat.Default)]
		public List<ItemBrief> fashionsynthersis_fail_info
		{
			get
			{
				return this._fashionsynthersis_fail_info;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "fashioncompose_time", DataFormat = DataFormat.TwosComplement)]
		public uint fashioncompose_time
		{
			get
			{
				return this._fashioncompose_time ?? 0U;
			}
			set
			{
				this._fashioncompose_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fashioncompose_timeSpecified
		{
			get
			{
				return this._fashioncompose_time != null;
			}
			set
			{
				bool flag = value == (this._fashioncompose_time == null);
				if (flag)
				{
					this._fashioncompose_time = (value ? new uint?(this.fashioncompose_time) : null);
				}
			}
		}

		private bool ShouldSerializefashioncompose_time()
		{
			return this.fashioncompose_timeSpecified;
		}

		private void Resetfashioncompose_time()
		{
			this.fashioncompose_timeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "fashionibshop_buy_time", DataFormat = DataFormat.TwosComplement)]
		public uint fashionibshop_buy_time
		{
			get
			{
				return this._fashionibshop_buy_time ?? 0U;
			}
			set
			{
				this._fashionibshop_buy_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fashionibshop_buy_timeSpecified
		{
			get
			{
				return this._fashionibshop_buy_time != null;
			}
			set
			{
				bool flag = value == (this._fashionibshop_buy_time == null);
				if (flag)
				{
					this._fashionibshop_buy_time = (value ? new uint?(this.fashionibshop_buy_time) : null);
				}
			}
		}

		private bool ShouldSerializefashionibshop_buy_time()
		{
			return this.fashionibshop_buy_timeSpecified;
		}

		private void Resetfashionibshop_buy_time()
		{
			this.fashionibshop_buy_timeSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(14, Name = "special_effects_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> special_effects_list
		{
			get
			{
				return this._special_effects_list;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "compose_success_num", DataFormat = DataFormat.TwosComplement)]
		public uint compose_success_num
		{
			get
			{
				return this._compose_success_num ?? 0U;
			}
			set
			{
				this._compose_success_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool compose_success_numSpecified
		{
			get
			{
				return this._compose_success_num != null;
			}
			set
			{
				bool flag = value == (this._compose_success_num == null);
				if (flag)
				{
					this._compose_success_num = (value ? new uint?(this.compose_success_num) : null);
				}
			}
		}

		private bool ShouldSerializecompose_success_num()
		{
			return this.compose_success_numSpecified;
		}

		private void Resetcompose_success_num()
		{
			this.compose_success_numSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "compose_failed_num", DataFormat = DataFormat.TwosComplement)]
		public uint compose_failed_num
		{
			get
			{
				return this._compose_failed_num ?? 0U;
			}
			set
			{
				this._compose_failed_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool compose_failed_numSpecified
		{
			get
			{
				return this._compose_failed_num != null;
			}
			set
			{
				bool flag = value == (this._compose_failed_num == null);
				if (flag)
				{
					this._compose_failed_num = (value ? new uint?(this.compose_failed_num) : null);
				}
			}
		}

		private bool ShouldSerializecompose_failed_num()
		{
			return this.compose_failed_numSpecified;
		}

		private void Resetcompose_failed_num()
		{
			this.compose_failed_numSpecified = false;
		}

		[ProtoMember(17, Name = "quality_num_list", DataFormat = DataFormat.Default)]
		public List<MapIntItem> quality_num_list
		{
			get
			{
				return this._quality_num_list;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<FashionData> _bodyfashion = new List<FashionData>();

		private readonly List<FashionData> _bagfashion = new List<FashionData>();

		private readonly List<uint> _collected = new List<uint>();

		private readonly List<uint> _display_fashion = new List<uint>();

		private readonly List<ActivateFashionCharm> _own_fashins = new List<ActivateFashionCharm>();

		private readonly List<uint> _own_display_items = new List<uint>();

		private bool? _conversion;

		private uint? _hair_color_id;

		private readonly List<ActivateHairColor> _hair_color_info = new List<ActivateHairColor>();

		private readonly List<ItemBrief> _fashionsynthersis_fail_info = new List<ItemBrief>();

		private uint? _fashioncompose_time;

		private uint? _fashionibshop_buy_time;

		private uint? _special_effects_id;

		private readonly List<uint> _special_effects_list = new List<uint>();

		private uint? _compose_success_num;

		private uint? _compose_failed_num;

		private readonly List<MapIntItem> _quality_num_list = new List<MapIntItem>();

		private IExtension extensionObject;
	}
}
