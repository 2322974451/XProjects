using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B2 RID: 1714
	[ProtoContract(Name = "PlantInfo")]
	[Serializable]
	public class PlantInfo : IExtensible
	{
		// Token: 0x1700237A RID: 9082
		// (get) Token: 0x06007016 RID: 28694 RVA: 0x000D6784 File Offset: 0x000D4984
		// (set) Token: 0x06007017 RID: 28695 RVA: 0x000D67B0 File Offset: 0x000D49B0
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

		// Token: 0x1700237B RID: 9083
		// (get) Token: 0x06007018 RID: 28696 RVA: 0x000D67C0 File Offset: 0x000D49C0
		// (set) Token: 0x06007019 RID: 28697 RVA: 0x000D67E0 File Offset: 0x000D49E0
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

		// Token: 0x0600701A RID: 28698 RVA: 0x000D6824 File Offset: 0x000D4A24
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x0600701B RID: 28699 RVA: 0x000D683C File Offset: 0x000D4A3C
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x1700237C RID: 9084
		// (get) Token: 0x0600701C RID: 28700 RVA: 0x000D6848 File Offset: 0x000D4A48
		// (set) Token: 0x0600701D RID: 28701 RVA: 0x000D6874 File Offset: 0x000D4A74
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

		// Token: 0x1700237D RID: 9085
		// (get) Token: 0x0600701E RID: 28702 RVA: 0x000D6884 File Offset: 0x000D4A84
		// (set) Token: 0x0600701F RID: 28703 RVA: 0x000D68A4 File Offset: 0x000D4AA4
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

		// Token: 0x06007020 RID: 28704 RVA: 0x000D68E8 File Offset: 0x000D4AE8
		private bool ShouldSerializeseed_id()
		{
			return this.seed_idSpecified;
		}

		// Token: 0x06007021 RID: 28705 RVA: 0x000D6900 File Offset: 0x000D4B00
		private void Resetseed_id()
		{
			this.seed_idSpecified = false;
		}

		// Token: 0x1700237E RID: 9086
		// (get) Token: 0x06007022 RID: 28706 RVA: 0x000D690C File Offset: 0x000D4B0C
		// (set) Token: 0x06007023 RID: 28707 RVA: 0x000D6938 File Offset: 0x000D4B38
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

		// Token: 0x1700237F RID: 9087
		// (get) Token: 0x06007024 RID: 28708 RVA: 0x000D6948 File Offset: 0x000D4B48
		// (set) Token: 0x06007025 RID: 28709 RVA: 0x000D6968 File Offset: 0x000D4B68
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

		// Token: 0x06007026 RID: 28710 RVA: 0x000D69AC File Offset: 0x000D4BAC
		private bool ShouldSerializeplant_grow_state()
		{
			return this.plant_grow_stateSpecified;
		}

		// Token: 0x06007027 RID: 28711 RVA: 0x000D69C4 File Offset: 0x000D4BC4
		private void Resetplant_grow_state()
		{
			this.plant_grow_stateSpecified = false;
		}

		// Token: 0x17002380 RID: 9088
		// (get) Token: 0x06007028 RID: 28712 RVA: 0x000D69D0 File Offset: 0x000D4BD0
		// (set) Token: 0x06007029 RID: 28713 RVA: 0x000D69FC File Offset: 0x000D4BFC
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

		// Token: 0x17002381 RID: 9089
		// (get) Token: 0x0600702A RID: 28714 RVA: 0x000D6A0C File Offset: 0x000D4C0C
		// (set) Token: 0x0600702B RID: 28715 RVA: 0x000D6A2C File Offset: 0x000D4C2C
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

		// Token: 0x0600702C RID: 28716 RVA: 0x000D6A70 File Offset: 0x000D4C70
		private bool ShouldSerializegrow_times()
		{
			return this.grow_timesSpecified;
		}

		// Token: 0x0600702D RID: 28717 RVA: 0x000D6A88 File Offset: 0x000D4C88
		private void Resetgrow_times()
		{
			this.grow_timesSpecified = false;
		}

		// Token: 0x17002382 RID: 9090
		// (get) Token: 0x0600702E RID: 28718 RVA: 0x000D6A94 File Offset: 0x000D4C94
		// (set) Token: 0x0600702F RID: 28719 RVA: 0x000D6AC4 File Offset: 0x000D4CC4
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

		// Token: 0x17002383 RID: 9091
		// (get) Token: 0x06007030 RID: 28720 RVA: 0x000D6AD4 File Offset: 0x000D4CD4
		// (set) Token: 0x06007031 RID: 28721 RVA: 0x000D6AF4 File Offset: 0x000D4CF4
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

		// Token: 0x06007032 RID: 28722 RVA: 0x000D6B38 File Offset: 0x000D4D38
		private bool ShouldSerializegrowup_amount()
		{
			return this.growup_amountSpecified;
		}

		// Token: 0x06007033 RID: 28723 RVA: 0x000D6B50 File Offset: 0x000D4D50
		private void Resetgrowup_amount()
		{
			this.growup_amountSpecified = false;
		}

		// Token: 0x17002384 RID: 9092
		// (get) Token: 0x06007034 RID: 28724 RVA: 0x000D6B5C File Offset: 0x000D4D5C
		// (set) Token: 0x06007035 RID: 28725 RVA: 0x000D6B88 File Offset: 0x000D4D88
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

		// Token: 0x17002385 RID: 9093
		// (get) Token: 0x06007036 RID: 28726 RVA: 0x000D6B98 File Offset: 0x000D4D98
		// (set) Token: 0x06007037 RID: 28727 RVA: 0x000D6BB8 File Offset: 0x000D4DB8
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

		// Token: 0x06007038 RID: 28728 RVA: 0x000D6BFC File Offset: 0x000D4DFC
		private bool ShouldSerializemature_duration()
		{
			return this.mature_durationSpecified;
		}

		// Token: 0x06007039 RID: 28729 RVA: 0x000D6C14 File Offset: 0x000D4E14
		private void Resetmature_duration()
		{
			this.mature_durationSpecified = false;
		}

		// Token: 0x17002386 RID: 9094
		// (get) Token: 0x0600703A RID: 28730 RVA: 0x000D6C20 File Offset: 0x000D4E20
		// (set) Token: 0x0600703B RID: 28731 RVA: 0x000D6C4C File Offset: 0x000D4E4C
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

		// Token: 0x17002387 RID: 9095
		// (get) Token: 0x0600703C RID: 28732 RVA: 0x000D6C5C File Offset: 0x000D4E5C
		// (set) Token: 0x0600703D RID: 28733 RVA: 0x000D6C7C File Offset: 0x000D4E7C
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

		// Token: 0x0600703E RID: 28734 RVA: 0x000D6CC0 File Offset: 0x000D4EC0
		private bool ShouldSerializestart_time()
		{
			return this.start_timeSpecified;
		}

		// Token: 0x0600703F RID: 28735 RVA: 0x000D6CD8 File Offset: 0x000D4ED8
		private void Resetstart_time()
		{
			this.start_timeSpecified = false;
		}

		// Token: 0x17002388 RID: 9096
		// (get) Token: 0x06007040 RID: 28736 RVA: 0x000D6CE4 File Offset: 0x000D4EE4
		// (set) Token: 0x06007041 RID: 28737 RVA: 0x000D6D10 File Offset: 0x000D4F10
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

		// Token: 0x17002389 RID: 9097
		// (get) Token: 0x06007042 RID: 28738 RVA: 0x000D6D20 File Offset: 0x000D4F20
		// (set) Token: 0x06007043 RID: 28739 RVA: 0x000D6D40 File Offset: 0x000D4F40
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

		// Token: 0x06007044 RID: 28740 RVA: 0x000D6D84 File Offset: 0x000D4F84
		private bool ShouldSerializestealed_times()
		{
			return this.stealed_timesSpecified;
		}

		// Token: 0x06007045 RID: 28741 RVA: 0x000D6D9C File Offset: 0x000D4F9C
		private void Resetstealed_times()
		{
			this.stealed_timesSpecified = false;
		}

		// Token: 0x1700238A RID: 9098
		// (get) Token: 0x06007046 RID: 28742 RVA: 0x000D6DA8 File Offset: 0x000D4FA8
		// (set) Token: 0x06007047 RID: 28743 RVA: 0x000D6DD4 File Offset: 0x000D4FD4
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

		// Token: 0x1700238B RID: 9099
		// (get) Token: 0x06007048 RID: 28744 RVA: 0x000D6DE4 File Offset: 0x000D4FE4
		// (set) Token: 0x06007049 RID: 28745 RVA: 0x000D6E04 File Offset: 0x000D5004
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

		// Token: 0x0600704A RID: 28746 RVA: 0x000D6E48 File Offset: 0x000D5048
		private bool ShouldSerializegrowup_cd()
		{
			return this.growup_cdSpecified;
		}

		// Token: 0x0600704B RID: 28747 RVA: 0x000D6E60 File Offset: 0x000D5060
		private void Resetgrowup_cd()
		{
			this.growup_cdSpecified = false;
		}

		// Token: 0x1700238C RID: 9100
		// (get) Token: 0x0600704C RID: 28748 RVA: 0x000D6E6C File Offset: 0x000D506C
		[ProtoMember(10, Name = "event_log", DataFormat = DataFormat.Default)]
		public List<GardenEventLog> event_log
		{
			get
			{
				return this._event_log;
			}
		}

		// Token: 0x1700238D RID: 9101
		// (get) Token: 0x0600704D RID: 28749 RVA: 0x000D6E84 File Offset: 0x000D5084
		// (set) Token: 0x0600704E RID: 28750 RVA: 0x000D6EB0 File Offset: 0x000D50B0
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

		// Token: 0x1700238E RID: 9102
		// (get) Token: 0x0600704F RID: 28751 RVA: 0x000D6EC0 File Offset: 0x000D50C0
		// (set) Token: 0x06007050 RID: 28752 RVA: 0x000D6EE0 File Offset: 0x000D50E0
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

		// Token: 0x06007051 RID: 28753 RVA: 0x000D6F24 File Offset: 0x000D5124
		private bool ShouldSerializenotice_times()
		{
			return this.notice_timesSpecified;
		}

		// Token: 0x06007052 RID: 28754 RVA: 0x000D6F3C File Offset: 0x000D513C
		private void Resetnotice_times()
		{
			this.notice_timesSpecified = false;
		}

		// Token: 0x1700238F RID: 9103
		// (get) Token: 0x06007053 RID: 28755 RVA: 0x000D6F48 File Offset: 0x000D5148
		// (set) Token: 0x06007054 RID: 28756 RVA: 0x000D6F75 File Offset: 0x000D5175
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

		// Token: 0x17002390 RID: 9104
		// (get) Token: 0x06007055 RID: 28757 RVA: 0x000D6F84 File Offset: 0x000D5184
		// (set) Token: 0x06007056 RID: 28758 RVA: 0x000D6FA4 File Offset: 0x000D51A4
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

		// Token: 0x06007057 RID: 28759 RVA: 0x000D6FE8 File Offset: 0x000D51E8
		private bool ShouldSerializeowner()
		{
			return this.ownerSpecified;
		}

		// Token: 0x06007058 RID: 28760 RVA: 0x000D7000 File Offset: 0x000D5200
		private void Resetowner()
		{
			this.ownerSpecified = false;
		}

		// Token: 0x06007059 RID: 28761 RVA: 0x000D700C File Offset: 0x000D520C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AC9 RID: 6857
		private uint? _farmland_id;

		// Token: 0x04001ACA RID: 6858
		private uint? _seed_id;

		// Token: 0x04001ACB RID: 6859
		private PlantGrowState? _plant_grow_state;

		// Token: 0x04001ACC RID: 6860
		private uint? _grow_times;

		// Token: 0x04001ACD RID: 6861
		private float? _growup_amount;

		// Token: 0x04001ACE RID: 6862
		private uint? _mature_duration;

		// Token: 0x04001ACF RID: 6863
		private uint? _start_time;

		// Token: 0x04001AD0 RID: 6864
		private uint? _stealed_times;

		// Token: 0x04001AD1 RID: 6865
		private uint? _growup_cd;

		// Token: 0x04001AD2 RID: 6866
		private readonly List<GardenEventLog> _event_log = new List<GardenEventLog>();

		// Token: 0x04001AD3 RID: 6867
		private uint? _notice_times;

		// Token: 0x04001AD4 RID: 6868
		private ulong? _owner;

		// Token: 0x04001AD5 RID: 6869
		private IExtension extensionObject;
	}
}
