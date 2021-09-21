using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024C RID: 588
	[ProtoContract(Name = "StartPlantArg")]
	[Serializable]
	public class StartPlantArg : IExtensible
	{
		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x060020D6 RID: 8406 RVA: 0x00040518 File Offset: 0x0003E718
		// (set) Token: 0x060020D7 RID: 8407 RVA: 0x00040544 File Offset: 0x0003E744
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

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x060020D8 RID: 8408 RVA: 0x00040554 File Offset: 0x0003E754
		// (set) Token: 0x060020D9 RID: 8409 RVA: 0x00040574 File Offset: 0x0003E774
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

		// Token: 0x060020DA RID: 8410 RVA: 0x000405B8 File Offset: 0x0003E7B8
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x000405D0 File Offset: 0x0003E7D0
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x060020DC RID: 8412 RVA: 0x000405DC File Offset: 0x0003E7DC
		// (set) Token: 0x060020DD RID: 8413 RVA: 0x00040608 File Offset: 0x0003E808
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

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x060020DE RID: 8414 RVA: 0x00040618 File Offset: 0x0003E818
		// (set) Token: 0x060020DF RID: 8415 RVA: 0x00040638 File Offset: 0x0003E838
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

		// Token: 0x060020E0 RID: 8416 RVA: 0x0004067C File Offset: 0x0003E87C
		private bool ShouldSerializeseed_id()
		{
			return this.seed_idSpecified;
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x00040694 File Offset: 0x0003E894
		private void Resetseed_id()
		{
			this.seed_idSpecified = false;
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x060020E2 RID: 8418 RVA: 0x000406A0 File Offset: 0x0003E8A0
		// (set) Token: 0x060020E3 RID: 8419 RVA: 0x000406CC File Offset: 0x0003E8CC
		[ProtoMember(3, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
		public GardenQuestType quest_type
		{
			get
			{
				return this._quest_type ?? GardenQuestType.MYSELF;
			}
			set
			{
				this._quest_type = new GardenQuestType?(value);
			}
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x060020E4 RID: 8420 RVA: 0x000406DC File Offset: 0x0003E8DC
		// (set) Token: 0x060020E5 RID: 8421 RVA: 0x000406FC File Offset: 0x0003E8FC
		[XmlIgnore]
		[Browsable(false)]
		public bool quest_typeSpecified
		{
			get
			{
				return this._quest_type != null;
			}
			set
			{
				bool flag = value == (this._quest_type == null);
				if (flag)
				{
					this._quest_type = (value ? new GardenQuestType?(this.quest_type) : null);
				}
			}
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x00040740 File Offset: 0x0003E940
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x00040758 File Offset: 0x0003E958
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x060020E8 RID: 8424 RVA: 0x00040764 File Offset: 0x0003E964
		// (set) Token: 0x060020E9 RID: 8425 RVA: 0x00040791 File Offset: 0x0003E991
		[ProtoMember(4, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x060020EA RID: 8426 RVA: 0x000407A0 File Offset: 0x0003E9A0
		// (set) Token: 0x060020EB RID: 8427 RVA: 0x000407C0 File Offset: 0x0003E9C0
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x060020EC RID: 8428 RVA: 0x00040804 File Offset: 0x0003EA04
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x0004081C File Offset: 0x0003EA1C
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x060020EE RID: 8430 RVA: 0x00040828 File Offset: 0x0003EA28
		// (set) Token: 0x060020EF RID: 8431 RVA: 0x00040854 File Offset: 0x0003EA54
		[ProtoMember(5, IsRequired = false, Name = "cancel", DataFormat = DataFormat.Default)]
		public bool cancel
		{
			get
			{
				return this._cancel ?? false;
			}
			set
			{
				this._cancel = new bool?(value);
			}
		}

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x060020F0 RID: 8432 RVA: 0x00040864 File Offset: 0x0003EA64
		// (set) Token: 0x060020F1 RID: 8433 RVA: 0x00040884 File Offset: 0x0003EA84
		[XmlIgnore]
		[Browsable(false)]
		public bool cancelSpecified
		{
			get
			{
				return this._cancel != null;
			}
			set
			{
				bool flag = value == (this._cancel == null);
				if (flag)
				{
					this._cancel = (value ? new bool?(this.cancel) : null);
				}
			}
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x000408C8 File Offset: 0x0003EAC8
		private bool ShouldSerializecancel()
		{
			return this.cancelSpecified;
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x000408E0 File Offset: 0x0003EAE0
		private void Resetcancel()
		{
			this.cancelSpecified = false;
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x000408EC File Offset: 0x0003EAEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400082D RID: 2093
		private uint? _farmland_id;

		// Token: 0x0400082E RID: 2094
		private uint? _seed_id;

		// Token: 0x0400082F RID: 2095
		private GardenQuestType? _quest_type;

		// Token: 0x04000830 RID: 2096
		private ulong? _garden_id;

		// Token: 0x04000831 RID: 2097
		private bool? _cancel;

		// Token: 0x04000832 RID: 2098
		private IExtension extensionObject;
	}
}
