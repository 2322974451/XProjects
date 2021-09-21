using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000250 RID: 592
	[ProtoContract(Name = "FetchPlantInfoArg")]
	[Serializable]
	public class FetchPlantInfoArg : IExtensible
	{
		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x0600212E RID: 8494 RVA: 0x00040FB4 File Offset: 0x0003F1B4
		// (set) Token: 0x0600212F RID: 8495 RVA: 0x00040FE1 File Offset: 0x0003F1E1
		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06002130 RID: 8496 RVA: 0x00040FF0 File Offset: 0x0003F1F0
		// (set) Token: 0x06002131 RID: 8497 RVA: 0x00041010 File Offset: 0x0003F210
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

		// Token: 0x06002132 RID: 8498 RVA: 0x00041054 File Offset: 0x0003F254
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002133 RID: 8499 RVA: 0x0004106C File Offset: 0x0003F26C
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06002134 RID: 8500 RVA: 0x00041078 File Offset: 0x0003F278
		// (set) Token: 0x06002135 RID: 8501 RVA: 0x000410A4 File Offset: 0x0003F2A4
		[ProtoMember(2, IsRequired = false, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06002136 RID: 8502 RVA: 0x000410B4 File Offset: 0x0003F2B4
		// (set) Token: 0x06002137 RID: 8503 RVA: 0x000410D4 File Offset: 0x0003F2D4
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

		// Token: 0x06002138 RID: 8504 RVA: 0x00041118 File Offset: 0x0003F318
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x06002139 RID: 8505 RVA: 0x00041130 File Offset: 0x0003F330
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x0600213A RID: 8506 RVA: 0x0004113C File Offset: 0x0003F33C
		// (set) Token: 0x0600213B RID: 8507 RVA: 0x00041168 File Offset: 0x0003F368
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

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x0600213C RID: 8508 RVA: 0x00041178 File Offset: 0x0003F378
		// (set) Token: 0x0600213D RID: 8509 RVA: 0x00041198 File Offset: 0x0003F398
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

		// Token: 0x0600213E RID: 8510 RVA: 0x000411DC File Offset: 0x0003F3DC
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x0600213F RID: 8511 RVA: 0x000411F4 File Offset: 0x0003F3F4
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x00041200 File Offset: 0x0003F400
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000840 RID: 2112
		private ulong? _garden_id;

		// Token: 0x04000841 RID: 2113
		private uint? _farmland_id;

		// Token: 0x04000842 RID: 2114
		private GardenQuestType? _quest_type;

		// Token: 0x04000843 RID: 2115
		private IExtension extensionObject;
	}
}
