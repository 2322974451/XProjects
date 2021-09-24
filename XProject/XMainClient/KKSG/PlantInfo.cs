using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlantInfo")]
	[Serializable]
	public class PlantInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
		public uint farmland_id
		{
			get
			{
				return this._farmland_id ?? 0U;
			}
			set
			{
				this._farmland_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool farmland_idSpecified
		{
			get
			{
				return this._farmland_id != null;
			}
			set
			{
				bool flag = value == (this._farmland_id == null);
				if (flag)
				{
					this._farmland_id = (value ? new uint?(this.farmland_id) : null);
				}
			}
		}

		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "seed_id", DataFormat = DataFormat.TwosComplement)]
		public uint seed_id
		{
			get
			{
				return this._seed_id ?? 0U;
			}
			set
			{
				this._seed_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seed_idSpecified
		{
			get
			{
				return this._seed_id != null;
			}
			set
			{
				bool flag = value == (this._seed_id == null);
				if (flag)
				{
					this._seed_id = (value ? new uint?(this.seed_id) : null);
				}
			}
		}

		private bool ShouldSerializeseed_id()
		{
			return this.seed_idSpecified;
		}

		private void Resetseed_id()
		{
			this.seed_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "plant_grow_state", DataFormat = DataFormat.TwosComplement)]
		public PlantGrowState plant_grow_state
		{
			get
			{
				return this._plant_grow_state ?? PlantGrowState.growDrought;
			}
			set
			{
				this._plant_grow_state = new PlantGrowState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool plant_grow_stateSpecified
		{
			get
			{
				return this._plant_grow_state != null;
			}
			set
			{
				bool flag = value == (this._plant_grow_state == null);
				if (flag)
				{
					this._plant_grow_state = (value ? new PlantGrowState?(this.plant_grow_state) : null);
				}
			}
		}

		private bool ShouldSerializeplant_grow_state()
		{
			return this.plant_grow_stateSpecified;
		}

		private void Resetplant_grow_state()
		{
			this.plant_grow_stateSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "grow_times", DataFormat = DataFormat.TwosComplement)]
		public uint grow_times
		{
			get
			{
				return this._grow_times ?? 0U;
			}
			set
			{
				this._grow_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool grow_timesSpecified
		{
			get
			{
				return this._grow_times != null;
			}
			set
			{
				bool flag = value == (this._grow_times == null);
				if (flag)
				{
					this._grow_times = (value ? new uint?(this.grow_times) : null);
				}
			}
		}

		private bool ShouldSerializegrow_times()
		{
			return this.grow_timesSpecified;
		}

		private void Resetgrow_times()
		{
			this.grow_timesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "growup_amount", DataFormat = DataFormat.FixedSize)]
		public float growup_amount
		{
			get
			{
				return this._growup_amount ?? 0f;
			}
			set
			{
				this._growup_amount = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool growup_amountSpecified
		{
			get
			{
				return this._growup_amount != null;
			}
			set
			{
				bool flag = value == (this._growup_amount == null);
				if (flag)
				{
					this._growup_amount = (value ? new float?(this.growup_amount) : null);
				}
			}
		}

		private bool ShouldSerializegrowup_amount()
		{
			return this.growup_amountSpecified;
		}

		private void Resetgrowup_amount()
		{
			this.growup_amountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "mature_duration", DataFormat = DataFormat.TwosComplement)]
		public uint mature_duration
		{
			get
			{
				return this._mature_duration ?? 0U;
			}
			set
			{
				this._mature_duration = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mature_durationSpecified
		{
			get
			{
				return this._mature_duration != null;
			}
			set
			{
				bool flag = value == (this._mature_duration == null);
				if (flag)
				{
					this._mature_duration = (value ? new uint?(this.mature_duration) : null);
				}
			}
		}

		private bool ShouldSerializemature_duration()
		{
			return this.mature_durationSpecified;
		}

		private void Resetmature_duration()
		{
			this.mature_durationSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "start_time", DataFormat = DataFormat.TwosComplement)]
		public uint start_time
		{
			get
			{
				return this._start_time ?? 0U;
			}
			set
			{
				this._start_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool start_timeSpecified
		{
			get
			{
				return this._start_time != null;
			}
			set
			{
				bool flag = value == (this._start_time == null);
				if (flag)
				{
					this._start_time = (value ? new uint?(this.start_time) : null);
				}
			}
		}

		private bool ShouldSerializestart_time()
		{
			return this.start_timeSpecified;
		}

		private void Resetstart_time()
		{
			this.start_timeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "stealed_times", DataFormat = DataFormat.TwosComplement)]
		public uint stealed_times
		{
			get
			{
				return this._stealed_times ?? 0U;
			}
			set
			{
				this._stealed_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stealed_timesSpecified
		{
			get
			{
				return this._stealed_times != null;
			}
			set
			{
				bool flag = value == (this._stealed_times == null);
				if (flag)
				{
					this._stealed_times = (value ? new uint?(this.stealed_times) : null);
				}
			}
		}

		private bool ShouldSerializestealed_times()
		{
			return this.stealed_timesSpecified;
		}

		private void Resetstealed_times()
		{
			this.stealed_timesSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "growup_cd", DataFormat = DataFormat.TwosComplement)]
		public uint growup_cd
		{
			get
			{
				return this._growup_cd ?? 0U;
			}
			set
			{
				this._growup_cd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool growup_cdSpecified
		{
			get
			{
				return this._growup_cd != null;
			}
			set
			{
				bool flag = value == (this._growup_cd == null);
				if (flag)
				{
					this._growup_cd = (value ? new uint?(this.growup_cd) : null);
				}
			}
		}

		private bool ShouldSerializegrowup_cd()
		{
			return this.growup_cdSpecified;
		}

		private void Resetgrowup_cd()
		{
			this.growup_cdSpecified = false;
		}

		[ProtoMember(10, Name = "event_log", DataFormat = DataFormat.Default)]
		public List<GardenEventLog> event_log
		{
			get
			{
				return this._event_log;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "notice_times", DataFormat = DataFormat.TwosComplement)]
		public uint notice_times
		{
			get
			{
				return this._notice_times ?? 0U;
			}
			set
			{
				this._notice_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notice_timesSpecified
		{
			get
			{
				return this._notice_times != null;
			}
			set
			{
				bool flag = value == (this._notice_times == null);
				if (flag)
				{
					this._notice_times = (value ? new uint?(this.notice_times) : null);
				}
			}
		}

		private bool ShouldSerializenotice_times()
		{
			return this.notice_timesSpecified;
		}

		private void Resetnotice_times()
		{
			this.notice_timesSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "owner", DataFormat = DataFormat.TwosComplement)]
		public ulong owner
		{
			get
			{
				return this._owner ?? 0UL;
			}
			set
			{
				this._owner = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ownerSpecified
		{
			get
			{
				return this._owner != null;
			}
			set
			{
				bool flag = value == (this._owner == null);
				if (flag)
				{
					this._owner = (value ? new ulong?(this.owner) : null);
				}
			}
		}

		private bool ShouldSerializeowner()
		{
			return this.ownerSpecified;
		}

		private void Resetowner()
		{
			this.ownerSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _farmland_id;

		private uint? _seed_id;

		private PlantGrowState? _plant_grow_state;

		private uint? _grow_times;

		private float? _growup_amount;

		private uint? _mature_duration;

		private uint? _start_time;

		private uint? _stealed_times;

		private uint? _growup_cd;

		private readonly List<GardenEventLog> _event_log = new List<GardenEventLog>();

		private uint? _notice_times;

		private ulong? _owner;

		private IExtension extensionObject;
	}
}
