using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000257 RID: 599
	[ProtoContract(Name = "PlantCultivationArg")]
	[Serializable]
	public class PlantCultivationArg : IExtensible
	{
		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x0600217D RID: 8573 RVA: 0x000418C8 File Offset: 0x0003FAC8
		// (set) Token: 0x0600217E RID: 8574 RVA: 0x000418F5 File Offset: 0x0003FAF5
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

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x0600217F RID: 8575 RVA: 0x00041904 File Offset: 0x0003FB04
		// (set) Token: 0x06002180 RID: 8576 RVA: 0x00041924 File Offset: 0x0003FB24
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

		// Token: 0x06002181 RID: 8577 RVA: 0x00041968 File Offset: 0x0003FB68
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x00041980 File Offset: 0x0003FB80
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06002183 RID: 8579 RVA: 0x0004198C File Offset: 0x0003FB8C
		// (set) Token: 0x06002184 RID: 8580 RVA: 0x000419B8 File Offset: 0x0003FBB8
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

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06002185 RID: 8581 RVA: 0x000419C8 File Offset: 0x0003FBC8
		// (set) Token: 0x06002186 RID: 8582 RVA: 0x000419E8 File Offset: 0x0003FBE8
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

		// Token: 0x06002187 RID: 8583 RVA: 0x00041A2C File Offset: 0x0003FC2C
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x00041A44 File Offset: 0x0003FC44
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06002189 RID: 8585 RVA: 0x00041A50 File Offset: 0x0003FC50
		// (set) Token: 0x0600218A RID: 8586 RVA: 0x00041A7C File Offset: 0x0003FC7C
		[ProtoMember(3, IsRequired = false, Name = "operate_type", DataFormat = DataFormat.TwosComplement)]
		public PlantGrowState operate_type
		{
			get
			{
				return this._operate_type ?? PlantGrowState.growDrought;
			}
			set
			{
				this._operate_type = new PlantGrowState?(value);
			}
		}

		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x0600218B RID: 8587 RVA: 0x00041A8C File Offset: 0x0003FC8C
		// (set) Token: 0x0600218C RID: 8588 RVA: 0x00041AAC File Offset: 0x0003FCAC
		[XmlIgnore]
		[Browsable(false)]
		public bool operate_typeSpecified
		{
			get
			{
				return this._operate_type != null;
			}
			set
			{
				bool flag = value == (this._operate_type == null);
				if (flag)
				{
					this._operate_type = (value ? new PlantGrowState?(this.operate_type) : null);
				}
			}
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x00041AF0 File Offset: 0x0003FCF0
		private bool ShouldSerializeoperate_type()
		{
			return this.operate_typeSpecified;
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x00041B08 File Offset: 0x0003FD08
		private void Resetoperate_type()
		{
			this.operate_typeSpecified = false;
		}

		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x0600218F RID: 8591 RVA: 0x00041B14 File Offset: 0x0003FD14
		// (set) Token: 0x06002190 RID: 8592 RVA: 0x00041B40 File Offset: 0x0003FD40
		[ProtoMember(4, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x06002191 RID: 8593 RVA: 0x00041B50 File Offset: 0x0003FD50
		// (set) Token: 0x06002192 RID: 8594 RVA: 0x00041B70 File Offset: 0x0003FD70
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

		// Token: 0x06002193 RID: 8595 RVA: 0x00041BB4 File Offset: 0x0003FDB4
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x00041BCC File Offset: 0x0003FDCC
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x00041BD8 File Offset: 0x0003FDD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000854 RID: 2132
		private ulong? _garden_id;

		// Token: 0x04000855 RID: 2133
		private uint? _farmland_id;

		// Token: 0x04000856 RID: 2134
		private PlantGrowState? _operate_type;

		// Token: 0x04000857 RID: 2135
		private GardenQuestType? _quest_type;

		// Token: 0x04000858 RID: 2136
		private IExtension extensionObject;
	}
}
