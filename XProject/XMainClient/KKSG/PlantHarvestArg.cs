using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025B RID: 603
	[ProtoContract(Name = "PlantHarvestArg")]
	[Serializable]
	public class PlantHarvestArg : IExtensible
	{
		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x060021BB RID: 8635 RVA: 0x00041FE0 File Offset: 0x000401E0
		// (set) Token: 0x060021BC RID: 8636 RVA: 0x0004200D File Offset: 0x0004020D
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

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x060021BD RID: 8637 RVA: 0x0004201C File Offset: 0x0004021C
		// (set) Token: 0x060021BE RID: 8638 RVA: 0x0004203C File Offset: 0x0004023C
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

		// Token: 0x060021BF RID: 8639 RVA: 0x00042080 File Offset: 0x00040280
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x00042098 File Offset: 0x00040298
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x060021C1 RID: 8641 RVA: 0x000420A4 File Offset: 0x000402A4
		// (set) Token: 0x060021C2 RID: 8642 RVA: 0x000420D0 File Offset: 0x000402D0
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

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x060021C3 RID: 8643 RVA: 0x000420E0 File Offset: 0x000402E0
		// (set) Token: 0x060021C4 RID: 8644 RVA: 0x00042100 File Offset: 0x00040300
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

		// Token: 0x060021C5 RID: 8645 RVA: 0x00042144 File Offset: 0x00040344
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x0004215C File Offset: 0x0004035C
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x060021C7 RID: 8647 RVA: 0x00042168 File Offset: 0x00040368
		// (set) Token: 0x060021C8 RID: 8648 RVA: 0x00042194 File Offset: 0x00040394
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

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x060021C9 RID: 8649 RVA: 0x000421A4 File Offset: 0x000403A4
		// (set) Token: 0x060021CA RID: 8650 RVA: 0x000421C4 File Offset: 0x000403C4
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

		// Token: 0x060021CB RID: 8651 RVA: 0x00042208 File Offset: 0x00040408
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x00042220 File Offset: 0x00040420
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x0004222C File Offset: 0x0004042C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000861 RID: 2145
		private ulong? _garden_id;

		// Token: 0x04000862 RID: 2146
		private uint? _farmland_id;

		// Token: 0x04000863 RID: 2147
		private GardenQuestType? _quest_type;

		// Token: 0x04000864 RID: 2148
		private IExtension extensionObject;
	}
}
