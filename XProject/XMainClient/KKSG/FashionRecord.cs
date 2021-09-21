using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061A RID: 1562
	[ProtoContract(Name = "FashionRecord")]
	[Serializable]
	public class FashionRecord : IExtensible
	{
		// Token: 0x17001DCF RID: 7631
		// (get) Token: 0x06005EF7 RID: 24311 RVA: 0x000B5204 File Offset: 0x000B3404
		[ProtoMember(1, Name = "bodyfashion", DataFormat = DataFormat.Default)]
		public List<FashionData> bodyfashion
		{
			get
			{
				return this._bodyfashion;
			}
		}

		// Token: 0x17001DD0 RID: 7632
		// (get) Token: 0x06005EF8 RID: 24312 RVA: 0x000B521C File Offset: 0x000B341C
		[ProtoMember(2, Name = "bagfashion", DataFormat = DataFormat.Default)]
		public List<FashionData> bagfashion
		{
			get
			{
				return this._bagfashion;
			}
		}

		// Token: 0x17001DD1 RID: 7633
		// (get) Token: 0x06005EF9 RID: 24313 RVA: 0x000B5234 File Offset: 0x000B3434
		[ProtoMember(3, Name = "collected", DataFormat = DataFormat.TwosComplement)]
		public List<uint> collected
		{
			get
			{
				return this._collected;
			}
		}

		// Token: 0x17001DD2 RID: 7634
		// (get) Token: 0x06005EFA RID: 24314 RVA: 0x000B524C File Offset: 0x000B344C
		[ProtoMember(4, Name = "display_fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> display_fashion
		{
			get
			{
				return this._display_fashion;
			}
		}

		// Token: 0x17001DD3 RID: 7635
		// (get) Token: 0x06005EFB RID: 24315 RVA: 0x000B5264 File Offset: 0x000B3464
		[ProtoMember(5, Name = "own_fashins", DataFormat = DataFormat.Default)]
		public List<ActivateFashionCharm> own_fashins
		{
			get
			{
				return this._own_fashins;
			}
		}

		// Token: 0x17001DD4 RID: 7636
		// (get) Token: 0x06005EFC RID: 24316 RVA: 0x000B527C File Offset: 0x000B347C
		[ProtoMember(6, Name = "own_display_items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> own_display_items
		{
			get
			{
				return this._own_display_items;
			}
		}

		// Token: 0x17001DD5 RID: 7637
		// (get) Token: 0x06005EFD RID: 24317 RVA: 0x000B5294 File Offset: 0x000B3494
		// (set) Token: 0x06005EFE RID: 24318 RVA: 0x000B52C0 File Offset: 0x000B34C0
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

		// Token: 0x17001DD6 RID: 7638
		// (get) Token: 0x06005EFF RID: 24319 RVA: 0x000B52D0 File Offset: 0x000B34D0
		// (set) Token: 0x06005F00 RID: 24320 RVA: 0x000B52F0 File Offset: 0x000B34F0
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

		// Token: 0x06005F01 RID: 24321 RVA: 0x000B5334 File Offset: 0x000B3534
		private bool ShouldSerializeconversion()
		{
			return this.conversionSpecified;
		}

		// Token: 0x06005F02 RID: 24322 RVA: 0x000B534C File Offset: 0x000B354C
		private void Resetconversion()
		{
			this.conversionSpecified = false;
		}

		// Token: 0x17001DD7 RID: 7639
		// (get) Token: 0x06005F03 RID: 24323 RVA: 0x000B5358 File Offset: 0x000B3558
		// (set) Token: 0x06005F04 RID: 24324 RVA: 0x000B5384 File Offset: 0x000B3584
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

		// Token: 0x17001DD8 RID: 7640
		// (get) Token: 0x06005F05 RID: 24325 RVA: 0x000B5394 File Offset: 0x000B3594
		// (set) Token: 0x06005F06 RID: 24326 RVA: 0x000B53B4 File Offset: 0x000B35B4
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

		// Token: 0x06005F07 RID: 24327 RVA: 0x000B53F8 File Offset: 0x000B35F8
		private bool ShouldSerializehair_color_id()
		{
			return this.hair_color_idSpecified;
		}

		// Token: 0x06005F08 RID: 24328 RVA: 0x000B5410 File Offset: 0x000B3610
		private void Resethair_color_id()
		{
			this.hair_color_idSpecified = false;
		}

		// Token: 0x17001DD9 RID: 7641
		// (get) Token: 0x06005F09 RID: 24329 RVA: 0x000B541C File Offset: 0x000B361C
		[ProtoMember(9, Name = "hair_color_info", DataFormat = DataFormat.Default)]
		public List<ActivateHairColor> hair_color_info
		{
			get
			{
				return this._hair_color_info;
			}
		}

		// Token: 0x17001DDA RID: 7642
		// (get) Token: 0x06005F0A RID: 24330 RVA: 0x000B5434 File Offset: 0x000B3634
		[ProtoMember(10, Name = "fashionsynthersis_fail_info", DataFormat = DataFormat.Default)]
		public List<ItemBrief> fashionsynthersis_fail_info
		{
			get
			{
				return this._fashionsynthersis_fail_info;
			}
		}

		// Token: 0x17001DDB RID: 7643
		// (get) Token: 0x06005F0B RID: 24331 RVA: 0x000B544C File Offset: 0x000B364C
		// (set) Token: 0x06005F0C RID: 24332 RVA: 0x000B5478 File Offset: 0x000B3678
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

		// Token: 0x17001DDC RID: 7644
		// (get) Token: 0x06005F0D RID: 24333 RVA: 0x000B5488 File Offset: 0x000B3688
		// (set) Token: 0x06005F0E RID: 24334 RVA: 0x000B54A8 File Offset: 0x000B36A8
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

		// Token: 0x06005F0F RID: 24335 RVA: 0x000B54EC File Offset: 0x000B36EC
		private bool ShouldSerializefashioncompose_time()
		{
			return this.fashioncompose_timeSpecified;
		}

		// Token: 0x06005F10 RID: 24336 RVA: 0x000B5504 File Offset: 0x000B3704
		private void Resetfashioncompose_time()
		{
			this.fashioncompose_timeSpecified = false;
		}

		// Token: 0x17001DDD RID: 7645
		// (get) Token: 0x06005F11 RID: 24337 RVA: 0x000B5510 File Offset: 0x000B3710
		// (set) Token: 0x06005F12 RID: 24338 RVA: 0x000B553C File Offset: 0x000B373C
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

		// Token: 0x17001DDE RID: 7646
		// (get) Token: 0x06005F13 RID: 24339 RVA: 0x000B554C File Offset: 0x000B374C
		// (set) Token: 0x06005F14 RID: 24340 RVA: 0x000B556C File Offset: 0x000B376C
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

		// Token: 0x06005F15 RID: 24341 RVA: 0x000B55B0 File Offset: 0x000B37B0
		private bool ShouldSerializefashionibshop_buy_time()
		{
			return this.fashionibshop_buy_timeSpecified;
		}

		// Token: 0x06005F16 RID: 24342 RVA: 0x000B55C8 File Offset: 0x000B37C8
		private void Resetfashionibshop_buy_time()
		{
			this.fashionibshop_buy_timeSpecified = false;
		}

		// Token: 0x17001DDF RID: 7647
		// (get) Token: 0x06005F17 RID: 24343 RVA: 0x000B55D4 File Offset: 0x000B37D4
		// (set) Token: 0x06005F18 RID: 24344 RVA: 0x000B5600 File Offset: 0x000B3800
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

		// Token: 0x17001DE0 RID: 7648
		// (get) Token: 0x06005F19 RID: 24345 RVA: 0x000B5610 File Offset: 0x000B3810
		// (set) Token: 0x06005F1A RID: 24346 RVA: 0x000B5630 File Offset: 0x000B3830
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

		// Token: 0x06005F1B RID: 24347 RVA: 0x000B5674 File Offset: 0x000B3874
		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		// Token: 0x06005F1C RID: 24348 RVA: 0x000B568C File Offset: 0x000B388C
		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		// Token: 0x17001DE1 RID: 7649
		// (get) Token: 0x06005F1D RID: 24349 RVA: 0x000B5698 File Offset: 0x000B3898
		[ProtoMember(14, Name = "special_effects_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> special_effects_list
		{
			get
			{
				return this._special_effects_list;
			}
		}

		// Token: 0x17001DE2 RID: 7650
		// (get) Token: 0x06005F1E RID: 24350 RVA: 0x000B56B0 File Offset: 0x000B38B0
		// (set) Token: 0x06005F1F RID: 24351 RVA: 0x000B56DC File Offset: 0x000B38DC
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

		// Token: 0x17001DE3 RID: 7651
		// (get) Token: 0x06005F20 RID: 24352 RVA: 0x000B56EC File Offset: 0x000B38EC
		// (set) Token: 0x06005F21 RID: 24353 RVA: 0x000B570C File Offset: 0x000B390C
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

		// Token: 0x06005F22 RID: 24354 RVA: 0x000B5750 File Offset: 0x000B3950
		private bool ShouldSerializecompose_success_num()
		{
			return this.compose_success_numSpecified;
		}

		// Token: 0x06005F23 RID: 24355 RVA: 0x000B5768 File Offset: 0x000B3968
		private void Resetcompose_success_num()
		{
			this.compose_success_numSpecified = false;
		}

		// Token: 0x17001DE4 RID: 7652
		// (get) Token: 0x06005F24 RID: 24356 RVA: 0x000B5774 File Offset: 0x000B3974
		// (set) Token: 0x06005F25 RID: 24357 RVA: 0x000B57A0 File Offset: 0x000B39A0
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

		// Token: 0x17001DE5 RID: 7653
		// (get) Token: 0x06005F26 RID: 24358 RVA: 0x000B57B0 File Offset: 0x000B39B0
		// (set) Token: 0x06005F27 RID: 24359 RVA: 0x000B57D0 File Offset: 0x000B39D0
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

		// Token: 0x06005F28 RID: 24360 RVA: 0x000B5814 File Offset: 0x000B3A14
		private bool ShouldSerializecompose_failed_num()
		{
			return this.compose_failed_numSpecified;
		}

		// Token: 0x06005F29 RID: 24361 RVA: 0x000B582C File Offset: 0x000B3A2C
		private void Resetcompose_failed_num()
		{
			this.compose_failed_numSpecified = false;
		}

		// Token: 0x17001DE6 RID: 7654
		// (get) Token: 0x06005F2A RID: 24362 RVA: 0x000B5838 File Offset: 0x000B3A38
		[ProtoMember(17, Name = "quality_num_list", DataFormat = DataFormat.Default)]
		public List<MapIntItem> quality_num_list
		{
			get
			{
				return this._quality_num_list;
			}
		}

		// Token: 0x06005F2B RID: 24363 RVA: 0x000B5850 File Offset: 0x000B3A50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400170B RID: 5899
		private readonly List<FashionData> _bodyfashion = new List<FashionData>();

		// Token: 0x0400170C RID: 5900
		private readonly List<FashionData> _bagfashion = new List<FashionData>();

		// Token: 0x0400170D RID: 5901
		private readonly List<uint> _collected = new List<uint>();

		// Token: 0x0400170E RID: 5902
		private readonly List<uint> _display_fashion = new List<uint>();

		// Token: 0x0400170F RID: 5903
		private readonly List<ActivateFashionCharm> _own_fashins = new List<ActivateFashionCharm>();

		// Token: 0x04001710 RID: 5904
		private readonly List<uint> _own_display_items = new List<uint>();

		// Token: 0x04001711 RID: 5905
		private bool? _conversion;

		// Token: 0x04001712 RID: 5906
		private uint? _hair_color_id;

		// Token: 0x04001713 RID: 5907
		private readonly List<ActivateHairColor> _hair_color_info = new List<ActivateHairColor>();

		// Token: 0x04001714 RID: 5908
		private readonly List<ItemBrief> _fashionsynthersis_fail_info = new List<ItemBrief>();

		// Token: 0x04001715 RID: 5909
		private uint? _fashioncompose_time;

		// Token: 0x04001716 RID: 5910
		private uint? _fashionibshop_buy_time;

		// Token: 0x04001717 RID: 5911
		private uint? _special_effects_id;

		// Token: 0x04001718 RID: 5912
		private readonly List<uint> _special_effects_list = new List<uint>();

		// Token: 0x04001719 RID: 5913
		private uint? _compose_success_num;

		// Token: 0x0400171A RID: 5914
		private uint? _compose_failed_num;

		// Token: 0x0400171B RID: 5915
		private readonly List<MapIntItem> _quality_num_list = new List<MapIntItem>();

		// Token: 0x0400171C RID: 5916
		private IExtension extensionObject;
	}
}
