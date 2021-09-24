using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatformShareResult")]
	[Serializable]
	public class PlatformShareResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		[ProtoMember(2, Name = "firstpass_share_list", DataFormat = DataFormat.Default)]
		public List<MapIntItem> firstpass_share_list
		{
			get
			{
				return this._firstpass_share_list;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "weekly_share_number", DataFormat = DataFormat.TwosComplement)]
		public uint weekly_share_number
		{
			get
			{
				return this._weekly_share_number ?? 0U;
			}
			set
			{
				this._weekly_share_number = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_share_numberSpecified
		{
			get
			{
				return this._weekly_share_number != null;
			}
			set
			{
				bool flag = value == (this._weekly_share_number == null);
				if (flag)
				{
					this._weekly_share_number = (value ? new uint?(this.weekly_share_number) : null);
				}
			}
		}

		private bool ShouldSerializeweekly_share_number()
		{
			return this.weekly_share_numberSpecified;
		}

		private void Resetweekly_share_number()
		{
			this.weekly_share_numberSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "weekly_award", DataFormat = DataFormat.Default)]
		public bool weekly_award
		{
			get
			{
				return this._weekly_award ?? false;
			}
			set
			{
				this._weekly_award = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_awardSpecified
		{
			get
			{
				return this._weekly_award != null;
			}
			set
			{
				bool flag = value == (this._weekly_award == null);
				if (flag)
				{
					this._weekly_award = (value ? new bool?(this.weekly_award) : null);
				}
			}
		}

		private bool ShouldSerializeweekly_award()
		{
			return this.weekly_awardSpecified;
		}

		private void Resetweekly_award()
		{
			this.weekly_awardSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "disappear_redpoint", DataFormat = DataFormat.Default)]
		public bool disappear_redpoint
		{
			get
			{
				return this._disappear_redpoint ?? false;
			}
			set
			{
				this._disappear_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool disappear_redpointSpecified
		{
			get
			{
				return this._disappear_redpoint != null;
			}
			set
			{
				bool flag = value == (this._disappear_redpoint == null);
				if (flag)
				{
					this._disappear_redpoint = (value ? new bool?(this.disappear_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializedisappear_redpoint()
		{
			return this.disappear_redpointSpecified;
		}

		private void Resetdisappear_redpoint()
		{
			this.disappear_redpointSpecified = false;
		}

		[ProtoMember(6, Name = "have_notify_scene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> have_notify_scene
		{
			get
			{
				return this._have_notify_scene;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "consume_dragoncoins_now", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_now
		{
			get
			{
				return this._consume_dragoncoins_now ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_now = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_nowSpecified
		{
			get
			{
				return this._consume_dragoncoins_now != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_now == null);
				if (flag)
				{
					this._consume_dragoncoins_now = (value ? new ulong?(this.consume_dragoncoins_now) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_now()
		{
			return this.consume_dragoncoins_nowSpecified;
		}

		private void Resetconsume_dragoncoins_now()
		{
			this.consume_dragoncoins_nowSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "consume_dragoncoins_before_1", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_1
		{
			get
			{
				return this._consume_dragoncoins_before_1 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_1 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_1Specified
		{
			get
			{
				return this._consume_dragoncoins_before_1 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_1 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_1 = (value ? new ulong?(this.consume_dragoncoins_before_1) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_1()
		{
			return this.consume_dragoncoins_before_1Specified;
		}

		private void Resetconsume_dragoncoins_before_1()
		{
			this.consume_dragoncoins_before_1Specified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "consume_dragoncoins_before_2", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_2
		{
			get
			{
				return this._consume_dragoncoins_before_2 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_2 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_2Specified
		{
			get
			{
				return this._consume_dragoncoins_before_2 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_2 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_2 = (value ? new ulong?(this.consume_dragoncoins_before_2) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_2()
		{
			return this.consume_dragoncoins_before_2Specified;
		}

		private void Resetconsume_dragoncoins_before_2()
		{
			this.consume_dragoncoins_before_2Specified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "consume_dragoncoins_before_3", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_3
		{
			get
			{
				return this._consume_dragoncoins_before_3 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_3 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_3Specified
		{
			get
			{
				return this._consume_dragoncoins_before_3 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_3 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_3 = (value ? new ulong?(this.consume_dragoncoins_before_3) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_3()
		{
			return this.consume_dragoncoins_before_3Specified;
		}

		private void Resetconsume_dragoncoins_before_3()
		{
			this.consume_dragoncoins_before_3Specified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "consume_dragoncoins_before_4", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_4
		{
			get
			{
				return this._consume_dragoncoins_before_4 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_4 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_4Specified
		{
			get
			{
				return this._consume_dragoncoins_before_4 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_4 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_4 = (value ? new ulong?(this.consume_dragoncoins_before_4) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_4()
		{
			return this.consume_dragoncoins_before_4Specified;
		}

		private void Resetconsume_dragoncoins_before_4()
		{
			this.consume_dragoncoins_before_4Specified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "consume_dragoncoins_before_5", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_5
		{
			get
			{
				return this._consume_dragoncoins_before_5 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_5 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_5Specified
		{
			get
			{
				return this._consume_dragoncoins_before_5 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_5 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_5 = (value ? new ulong?(this.consume_dragoncoins_before_5) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_5()
		{
			return this.consume_dragoncoins_before_5Specified;
		}

		private void Resetconsume_dragoncoins_before_5()
		{
			this.consume_dragoncoins_before_5Specified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "consume_dragoncoins_before_6", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_6
		{
			get
			{
				return this._consume_dragoncoins_before_6 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_6 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_6Specified
		{
			get
			{
				return this._consume_dragoncoins_before_6 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_6 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_6 = (value ? new ulong?(this.consume_dragoncoins_before_6) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_6()
		{
			return this.consume_dragoncoins_before_6Specified;
		}

		private void Resetconsume_dragoncoins_before_6()
		{
			this.consume_dragoncoins_before_6Specified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "consume_dragoncoins_before_7", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_7
		{
			get
			{
				return this._consume_dragoncoins_before_7 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_7 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_7Specified
		{
			get
			{
				return this._consume_dragoncoins_before_7 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_7 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_7 = (value ? new ulong?(this.consume_dragoncoins_before_7) : null);
				}
			}
		}

		private bool ShouldSerializeconsume_dragoncoins_before_7()
		{
			return this.consume_dragoncoins_before_7Specified;
		}

		private void Resetconsume_dragoncoins_before_7()
		{
			this.consume_dragoncoins_before_7Specified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "last_update_consume", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_consume
		{
			get
			{
				return this._last_update_consume ?? 0U;
			}
			set
			{
				this._last_update_consume = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_consumeSpecified
		{
			get
			{
				return this._last_update_consume != null;
			}
			set
			{
				bool flag = value == (this._last_update_consume == null);
				if (flag)
				{
					this._last_update_consume = (value ? new uint?(this.last_update_consume) : null);
				}
			}
		}

		private bool ShouldSerializelast_update_consume()
		{
			return this.last_update_consumeSpecified;
		}

		private void Resetlast_update_consume()
		{
			this.last_update_consumeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _last_update_time;

		private readonly List<MapIntItem> _firstpass_share_list = new List<MapIntItem>();

		private uint? _weekly_share_number;

		private bool? _weekly_award;

		private bool? _disappear_redpoint;

		private readonly List<uint> _have_notify_scene = new List<uint>();

		private ulong? _consume_dragoncoins_now;

		private ulong? _consume_dragoncoins_before_1;

		private ulong? _consume_dragoncoins_before_2;

		private ulong? _consume_dragoncoins_before_3;

		private ulong? _consume_dragoncoins_before_4;

		private ulong? _consume_dragoncoins_before_5;

		private ulong? _consume_dragoncoins_before_6;

		private ulong? _consume_dragoncoins_before_7;

		private uint? _last_update_consume;

		private IExtension extensionObject;
	}
}
