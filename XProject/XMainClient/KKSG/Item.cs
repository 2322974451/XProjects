using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000563 RID: 1379
	[ProtoContract(Name = "Item")]
	[Serializable]
	public class Item : IExtensible
	{
		// Token: 0x17001591 RID: 5521
		// (get) Token: 0x0600469D RID: 18077 RVA: 0x000862AC File Offset: 0x000844AC
		// (set) Token: 0x0600469E RID: 18078 RVA: 0x000862D9 File Offset: 0x000844D9
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17001592 RID: 5522
		// (get) Token: 0x0600469F RID: 18079 RVA: 0x000862E8 File Offset: 0x000844E8
		// (set) Token: 0x060046A0 RID: 18080 RVA: 0x00086308 File Offset: 0x00084508
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x060046A1 RID: 18081 RVA: 0x0008634C File Offset: 0x0008454C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060046A2 RID: 18082 RVA: 0x00086364 File Offset: 0x00084564
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001593 RID: 5523
		// (get) Token: 0x060046A3 RID: 18083 RVA: 0x00086370 File Offset: 0x00084570
		// (set) Token: 0x060046A4 RID: 18084 RVA: 0x0008639C File Offset: 0x0008459C
		[ProtoMember(2, IsRequired = false, Name = "ItemType", DataFormat = DataFormat.TwosComplement)]
		public uint ItemType
		{
			get
			{
				return this._ItemType ?? 0U;
			}
			set
			{
				this._ItemType = new uint?(value);
			}
		}

		// Token: 0x17001594 RID: 5524
		// (get) Token: 0x060046A5 RID: 18085 RVA: 0x000863AC File Offset: 0x000845AC
		// (set) Token: 0x060046A6 RID: 18086 RVA: 0x000863CC File Offset: 0x000845CC
		[XmlIgnore]
		[Browsable(false)]
		public bool ItemTypeSpecified
		{
			get
			{
				return this._ItemType != null;
			}
			set
			{
				bool flag = value == (this._ItemType == null);
				if (flag)
				{
					this._ItemType = (value ? new uint?(this.ItemType) : null);
				}
			}
		}

		// Token: 0x060046A7 RID: 18087 RVA: 0x00086410 File Offset: 0x00084610
		private bool ShouldSerializeItemType()
		{
			return this.ItemTypeSpecified;
		}

		// Token: 0x060046A8 RID: 18088 RVA: 0x00086428 File Offset: 0x00084628
		private void ResetItemType()
		{
			this.ItemTypeSpecified = false;
		}

		// Token: 0x17001595 RID: 5525
		// (get) Token: 0x060046A9 RID: 18089 RVA: 0x00086434 File Offset: 0x00084634
		// (set) Token: 0x060046AA RID: 18090 RVA: 0x00086460 File Offset: 0x00084660
		[ProtoMember(3, IsRequired = false, Name = "ItemID", DataFormat = DataFormat.TwosComplement)]
		public uint ItemID
		{
			get
			{
				return this._ItemID ?? 0U;
			}
			set
			{
				this._ItemID = new uint?(value);
			}
		}

		// Token: 0x17001596 RID: 5526
		// (get) Token: 0x060046AB RID: 18091 RVA: 0x00086470 File Offset: 0x00084670
		// (set) Token: 0x060046AC RID: 18092 RVA: 0x00086490 File Offset: 0x00084690
		[XmlIgnore]
		[Browsable(false)]
		public bool ItemIDSpecified
		{
			get
			{
				return this._ItemID != null;
			}
			set
			{
				bool flag = value == (this._ItemID == null);
				if (flag)
				{
					this._ItemID = (value ? new uint?(this.ItemID) : null);
				}
			}
		}

		// Token: 0x060046AD RID: 18093 RVA: 0x000864D4 File Offset: 0x000846D4
		private bool ShouldSerializeItemID()
		{
			return this.ItemIDSpecified;
		}

		// Token: 0x060046AE RID: 18094 RVA: 0x000864EC File Offset: 0x000846EC
		private void ResetItemID()
		{
			this.ItemIDSpecified = false;
		}

		// Token: 0x17001597 RID: 5527
		// (get) Token: 0x060046AF RID: 18095 RVA: 0x000864F8 File Offset: 0x000846F8
		// (set) Token: 0x060046B0 RID: 18096 RVA: 0x00086524 File Offset: 0x00084724
		[ProtoMember(4, IsRequired = false, Name = "ItemCount", DataFormat = DataFormat.TwosComplement)]
		public uint ItemCount
		{
			get
			{
				return this._ItemCount ?? 0U;
			}
			set
			{
				this._ItemCount = new uint?(value);
			}
		}

		// Token: 0x17001598 RID: 5528
		// (get) Token: 0x060046B1 RID: 18097 RVA: 0x00086534 File Offset: 0x00084734
		// (set) Token: 0x060046B2 RID: 18098 RVA: 0x00086554 File Offset: 0x00084754
		[XmlIgnore]
		[Browsable(false)]
		public bool ItemCountSpecified
		{
			get
			{
				return this._ItemCount != null;
			}
			set
			{
				bool flag = value == (this._ItemCount == null);
				if (flag)
				{
					this._ItemCount = (value ? new uint?(this.ItemCount) : null);
				}
			}
		}

		// Token: 0x060046B3 RID: 18099 RVA: 0x00086598 File Offset: 0x00084798
		private bool ShouldSerializeItemCount()
		{
			return this.ItemCountSpecified;
		}

		// Token: 0x060046B4 RID: 18100 RVA: 0x000865B0 File Offset: 0x000847B0
		private void ResetItemCount()
		{
			this.ItemCountSpecified = false;
		}

		// Token: 0x17001599 RID: 5529
		// (get) Token: 0x060046B5 RID: 18101 RVA: 0x000865BC File Offset: 0x000847BC
		// (set) Token: 0x060046B6 RID: 18102 RVA: 0x000865E8 File Offset: 0x000847E8
		[ProtoMember(5, IsRequired = false, Name = "isbind", DataFormat = DataFormat.Default)]
		public bool isbind
		{
			get
			{
				return this._isbind ?? false;
			}
			set
			{
				this._isbind = new bool?(value);
			}
		}

		// Token: 0x1700159A RID: 5530
		// (get) Token: 0x060046B7 RID: 18103 RVA: 0x000865F8 File Offset: 0x000847F8
		// (set) Token: 0x060046B8 RID: 18104 RVA: 0x00086618 File Offset: 0x00084818
		[XmlIgnore]
		[Browsable(false)]
		public bool isbindSpecified
		{
			get
			{
				return this._isbind != null;
			}
			set
			{
				bool flag = value == (this._isbind == null);
				if (flag)
				{
					this._isbind = (value ? new bool?(this.isbind) : null);
				}
			}
		}

		// Token: 0x060046B9 RID: 18105 RVA: 0x0008665C File Offset: 0x0008485C
		private bool ShouldSerializeisbind()
		{
			return this.isbindSpecified;
		}

		// Token: 0x060046BA RID: 18106 RVA: 0x00086674 File Offset: 0x00084874
		private void Resetisbind()
		{
			this.isbindSpecified = false;
		}

		// Token: 0x1700159B RID: 5531
		// (get) Token: 0x060046BB RID: 18107 RVA: 0x00086680 File Offset: 0x00084880
		// (set) Token: 0x060046BC RID: 18108 RVA: 0x000866AC File Offset: 0x000848AC
		[ProtoMember(6, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x1700159C RID: 5532
		// (get) Token: 0x060046BD RID: 18109 RVA: 0x000866BC File Offset: 0x000848BC
		// (set) Token: 0x060046BE RID: 18110 RVA: 0x000866DC File Offset: 0x000848DC
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x060046BF RID: 18111 RVA: 0x00086720 File Offset: 0x00084920
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x060046C0 RID: 18112 RVA: 0x00086738 File Offset: 0x00084938
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x1700159D RID: 5533
		// (get) Token: 0x060046C1 RID: 18113 RVA: 0x00086744 File Offset: 0x00084944
		[ProtoMember(7, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		// Token: 0x1700159E RID: 5534
		// (get) Token: 0x060046C2 RID: 18114 RVA: 0x0008675C File Offset: 0x0008495C
		[ProtoMember(8, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		// Token: 0x1700159F RID: 5535
		// (get) Token: 0x060046C3 RID: 18115 RVA: 0x00086774 File Offset: 0x00084974
		[ProtoMember(9, Name = "EnhanceAttrId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EnhanceAttrId
		{
			get
			{
				return this._EnhanceAttrId;
			}
		}

		// Token: 0x170015A0 RID: 5536
		// (get) Token: 0x060046C4 RID: 18116 RVA: 0x0008678C File Offset: 0x0008498C
		[ProtoMember(10, Name = "EnhanceAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EnhanceAttrValue
		{
			get
			{
				return this._EnhanceAttrValue;
			}
		}

		// Token: 0x170015A1 RID: 5537
		// (get) Token: 0x060046C5 RID: 18117 RVA: 0x000867A4 File Offset: 0x000849A4
		// (set) Token: 0x060046C6 RID: 18118 RVA: 0x000867D0 File Offset: 0x000849D0
		[ProtoMember(11, IsRequired = false, Name = "EnhanceLevel", DataFormat = DataFormat.TwosComplement)]
		public uint EnhanceLevel
		{
			get
			{
				return this._EnhanceLevel ?? 0U;
			}
			set
			{
				this._EnhanceLevel = new uint?(value);
			}
		}

		// Token: 0x170015A2 RID: 5538
		// (get) Token: 0x060046C7 RID: 18119 RVA: 0x000867E0 File Offset: 0x000849E0
		// (set) Token: 0x060046C8 RID: 18120 RVA: 0x00086800 File Offset: 0x00084A00
		[XmlIgnore]
		[Browsable(false)]
		public bool EnhanceLevelSpecified
		{
			get
			{
				return this._EnhanceLevel != null;
			}
			set
			{
				bool flag = value == (this._EnhanceLevel == null);
				if (flag)
				{
					this._EnhanceLevel = (value ? new uint?(this.EnhanceLevel) : null);
				}
			}
		}

		// Token: 0x060046C9 RID: 18121 RVA: 0x00086844 File Offset: 0x00084A44
		private bool ShouldSerializeEnhanceLevel()
		{
			return this.EnhanceLevelSpecified;
		}

		// Token: 0x060046CA RID: 18122 RVA: 0x0008685C File Offset: 0x00084A5C
		private void ResetEnhanceLevel()
		{
			this.EnhanceLevelSpecified = false;
		}

		// Token: 0x170015A3 RID: 5539
		// (get) Token: 0x060046CB RID: 18123 RVA: 0x00086868 File Offset: 0x00084A68
		// (set) Token: 0x060046CC RID: 18124 RVA: 0x00086894 File Offset: 0x00084A94
		[ProtoMember(12, IsRequired = false, Name = "EnhanceCount", DataFormat = DataFormat.TwosComplement)]
		public uint EnhanceCount
		{
			get
			{
				return this._EnhanceCount ?? 0U;
			}
			set
			{
				this._EnhanceCount = new uint?(value);
			}
		}

		// Token: 0x170015A4 RID: 5540
		// (get) Token: 0x060046CD RID: 18125 RVA: 0x000868A4 File Offset: 0x00084AA4
		// (set) Token: 0x060046CE RID: 18126 RVA: 0x000868C4 File Offset: 0x00084AC4
		[XmlIgnore]
		[Browsable(false)]
		public bool EnhanceCountSpecified
		{
			get
			{
				return this._EnhanceCount != null;
			}
			set
			{
				bool flag = value == (this._EnhanceCount == null);
				if (flag)
				{
					this._EnhanceCount = (value ? new uint?(this.EnhanceCount) : null);
				}
			}
		}

		// Token: 0x060046CF RID: 18127 RVA: 0x00086908 File Offset: 0x00084B08
		private bool ShouldSerializeEnhanceCount()
		{
			return this.EnhanceCountSpecified;
		}

		// Token: 0x060046D0 RID: 18128 RVA: 0x00086920 File Offset: 0x00084B20
		private void ResetEnhanceCount()
		{
			this.EnhanceCountSpecified = false;
		}

		// Token: 0x170015A5 RID: 5541
		// (get) Token: 0x060046D1 RID: 18129 RVA: 0x0008692C File Offset: 0x00084B2C
		// (set) Token: 0x060046D2 RID: 18130 RVA: 0x00086944 File Offset: 0x00084B44
		[ProtoMember(13, IsRequired = false, Name = "ItemJade", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemJade ItemJade
		{
			get
			{
				return this._ItemJade;
			}
			set
			{
				this._ItemJade = value;
			}
		}

		// Token: 0x170015A6 RID: 5542
		// (get) Token: 0x060046D3 RID: 18131 RVA: 0x00086950 File Offset: 0x00084B50
		// (set) Token: 0x060046D4 RID: 18132 RVA: 0x0008697C File Offset: 0x00084B7C
		[ProtoMember(14, IsRequired = false, Name = "FashionLevel", DataFormat = DataFormat.TwosComplement)]
		public uint FashionLevel
		{
			get
			{
				return this._FashionLevel ?? 0U;
			}
			set
			{
				this._FashionLevel = new uint?(value);
			}
		}

		// Token: 0x170015A7 RID: 5543
		// (get) Token: 0x060046D5 RID: 18133 RVA: 0x0008698C File Offset: 0x00084B8C
		// (set) Token: 0x060046D6 RID: 18134 RVA: 0x000869AC File Offset: 0x00084BAC
		[XmlIgnore]
		[Browsable(false)]
		public bool FashionLevelSpecified
		{
			get
			{
				return this._FashionLevel != null;
			}
			set
			{
				bool flag = value == (this._FashionLevel == null);
				if (flag)
				{
					this._FashionLevel = (value ? new uint?(this.FashionLevel) : null);
				}
			}
		}

		// Token: 0x060046D7 RID: 18135 RVA: 0x000869F0 File Offset: 0x00084BF0
		private bool ShouldSerializeFashionLevel()
		{
			return this.FashionLevelSpecified;
		}

		// Token: 0x060046D8 RID: 18136 RVA: 0x00086A08 File Offset: 0x00084C08
		private void ResetFashionLevel()
		{
			this.FashionLevelSpecified = false;
		}

		// Token: 0x170015A8 RID: 5544
		// (get) Token: 0x060046D9 RID: 18137 RVA: 0x00086A14 File Offset: 0x00084C14
		[ProtoMember(15, Name = "circleDrawDatas", DataFormat = DataFormat.Default)]
		public List<CircleDrawData> circleDrawDatas
		{
			get
			{
				return this._circleDrawDatas;
			}
		}

		// Token: 0x170015A9 RID: 5545
		// (get) Token: 0x060046DA RID: 18138 RVA: 0x00086A2C File Offset: 0x00084C2C
		// (set) Token: 0x060046DB RID: 18139 RVA: 0x00086A58 File Offset: 0x00084C58
		[ProtoMember(16, IsRequired = false, Name = "EmblemThirdSlot", DataFormat = DataFormat.TwosComplement)]
		public uint EmblemThirdSlot
		{
			get
			{
				return this._EmblemThirdSlot ?? 0U;
			}
			set
			{
				this._EmblemThirdSlot = new uint?(value);
			}
		}

		// Token: 0x170015AA RID: 5546
		// (get) Token: 0x060046DC RID: 18140 RVA: 0x00086A68 File Offset: 0x00084C68
		// (set) Token: 0x060046DD RID: 18141 RVA: 0x00086A88 File Offset: 0x00084C88
		[XmlIgnore]
		[Browsable(false)]
		public bool EmblemThirdSlotSpecified
		{
			get
			{
				return this._EmblemThirdSlot != null;
			}
			set
			{
				bool flag = value == (this._EmblemThirdSlot == null);
				if (flag)
				{
					this._EmblemThirdSlot = (value ? new uint?(this.EmblemThirdSlot) : null);
				}
			}
		}

		// Token: 0x060046DE RID: 18142 RVA: 0x00086ACC File Offset: 0x00084CCC
		private bool ShouldSerializeEmblemThirdSlot()
		{
			return this.EmblemThirdSlotSpecified;
		}

		// Token: 0x060046DF RID: 18143 RVA: 0x00086AE4 File Offset: 0x00084CE4
		private void ResetEmblemThirdSlot()
		{
			this.EmblemThirdSlotSpecified = false;
		}

		// Token: 0x170015AB RID: 5547
		// (get) Token: 0x060046E0 RID: 18144 RVA: 0x00086AF0 File Offset: 0x00084CF0
		// (set) Token: 0x060046E1 RID: 18145 RVA: 0x00086B08 File Offset: 0x00084D08
		[ProtoMember(17, IsRequired = false, Name = "enchant", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemEnchant enchant
		{
			get
			{
				return this._enchant;
			}
			set
			{
				this._enchant = value;
			}
		}

		// Token: 0x170015AC RID: 5548
		// (get) Token: 0x060046E2 RID: 18146 RVA: 0x00086B14 File Offset: 0x00084D14
		// (set) Token: 0x060046E3 RID: 18147 RVA: 0x00086B2C File Offset: 0x00084D2C
		[ProtoMember(18, IsRequired = false, Name = "randAttr", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemRandAttr randAttr
		{
			get
			{
				return this._randAttr;
			}
			set
			{
				this._randAttr = value;
			}
		}

		// Token: 0x170015AD RID: 5549
		// (get) Token: 0x060046E4 RID: 18148 RVA: 0x00086B38 File Offset: 0x00084D38
		// (set) Token: 0x060046E5 RID: 18149 RVA: 0x00086B50 File Offset: 0x00084D50
		[ProtoMember(19, IsRequired = false, Name = "forge", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemForge forge
		{
			get
			{
				return this._forge;
			}
			set
			{
				this._forge = value;
			}
		}

		// Token: 0x170015AE RID: 5550
		// (get) Token: 0x060046E6 RID: 18150 RVA: 0x00086B5C File Offset: 0x00084D5C
		[ProtoMember(20, Name = "effects", DataFormat = DataFormat.Default)]
		public List<EffectData> effects
		{
			get
			{
				return this._effects;
			}
		}

		// Token: 0x170015AF RID: 5551
		// (get) Token: 0x060046E7 RID: 18151 RVA: 0x00086B74 File Offset: 0x00084D74
		// (set) Token: 0x060046E8 RID: 18152 RVA: 0x00086BA0 File Offset: 0x00084DA0
		[ProtoMember(21, IsRequired = false, Name = "ebslottype", DataFormat = DataFormat.TwosComplement)]
		public EmblemSlotType ebslottype
		{
			get
			{
				return this._ebslottype ?? EmblemSlotType.EmblemSlotType_None;
			}
			set
			{
				this._ebslottype = new EmblemSlotType?(value);
			}
		}

		// Token: 0x170015B0 RID: 5552
		// (get) Token: 0x060046E9 RID: 18153 RVA: 0x00086BB0 File Offset: 0x00084DB0
		// (set) Token: 0x060046EA RID: 18154 RVA: 0x00086BD0 File Offset: 0x00084DD0
		[XmlIgnore]
		[Browsable(false)]
		public bool ebslottypeSpecified
		{
			get
			{
				return this._ebslottype != null;
			}
			set
			{
				bool flag = value == (this._ebslottype == null);
				if (flag)
				{
					this._ebslottype = (value ? new EmblemSlotType?(this.ebslottype) : null);
				}
			}
		}

		// Token: 0x060046EB RID: 18155 RVA: 0x00086C14 File Offset: 0x00084E14
		private bool ShouldSerializeebslottype()
		{
			return this.ebslottypeSpecified;
		}

		// Token: 0x060046EC RID: 18156 RVA: 0x00086C2C File Offset: 0x00084E2C
		private void Resetebslottype()
		{
			this.ebslottypeSpecified = false;
		}

		// Token: 0x170015B1 RID: 5553
		// (get) Token: 0x060046ED RID: 18157 RVA: 0x00086C38 File Offset: 0x00084E38
		// (set) Token: 0x060046EE RID: 18158 RVA: 0x00086C64 File Offset: 0x00084E64
		[ProtoMember(22, IsRequired = false, Name = "smeltCount", DataFormat = DataFormat.TwosComplement)]
		public uint smeltCount
		{
			get
			{
				return this._smeltCount ?? 0U;
			}
			set
			{
				this._smeltCount = new uint?(value);
			}
		}

		// Token: 0x170015B2 RID: 5554
		// (get) Token: 0x060046EF RID: 18159 RVA: 0x00086C74 File Offset: 0x00084E74
		// (set) Token: 0x060046F0 RID: 18160 RVA: 0x00086C94 File Offset: 0x00084E94
		[XmlIgnore]
		[Browsable(false)]
		public bool smeltCountSpecified
		{
			get
			{
				return this._smeltCount != null;
			}
			set
			{
				bool flag = value == (this._smeltCount == null);
				if (flag)
				{
					this._smeltCount = (value ? new uint?(this.smeltCount) : null);
				}
			}
		}

		// Token: 0x060046F1 RID: 18161 RVA: 0x00086CD8 File Offset: 0x00084ED8
		private bool ShouldSerializesmeltCount()
		{
			return this.smeltCountSpecified;
		}

		// Token: 0x060046F2 RID: 18162 RVA: 0x00086CF0 File Offset: 0x00084EF0
		private void ResetsmeltCount()
		{
			this.smeltCountSpecified = false;
		}

		// Token: 0x170015B3 RID: 5555
		// (get) Token: 0x060046F3 RID: 18163 RVA: 0x00086CFC File Offset: 0x00084EFC
		// (set) Token: 0x060046F4 RID: 18164 RVA: 0x00086D28 File Offset: 0x00084F28
		[ProtoMember(23, IsRequired = false, Name = "expirationTime", DataFormat = DataFormat.TwosComplement)]
		public uint expirationTime
		{
			get
			{
				return this._expirationTime ?? 0U;
			}
			set
			{
				this._expirationTime = new uint?(value);
			}
		}

		// Token: 0x170015B4 RID: 5556
		// (get) Token: 0x060046F5 RID: 18165 RVA: 0x00086D38 File Offset: 0x00084F38
		// (set) Token: 0x060046F6 RID: 18166 RVA: 0x00086D58 File Offset: 0x00084F58
		[XmlIgnore]
		[Browsable(false)]
		public bool expirationTimeSpecified
		{
			get
			{
				return this._expirationTime != null;
			}
			set
			{
				bool flag = value == (this._expirationTime == null);
				if (flag)
				{
					this._expirationTime = (value ? new uint?(this.expirationTime) : null);
				}
			}
		}

		// Token: 0x060046F7 RID: 18167 RVA: 0x00086D9C File Offset: 0x00084F9C
		private bool ShouldSerializeexpirationTime()
		{
			return this.expirationTimeSpecified;
		}

		// Token: 0x060046F8 RID: 18168 RVA: 0x00086DB4 File Offset: 0x00084FB4
		private void ResetexpirationTime()
		{
			this.expirationTimeSpecified = false;
		}

		// Token: 0x170015B5 RID: 5557
		// (get) Token: 0x060046F9 RID: 18169 RVA: 0x00086DC0 File Offset: 0x00084FC0
		// (set) Token: 0x060046FA RID: 18170 RVA: 0x00086DD8 File Offset: 0x00084FD8
		[ProtoMember(24, IsRequired = false, Name = "fuse", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemFuse fuse
		{
			get
			{
				return this._fuse;
			}
			set
			{
				this._fuse = value;
			}
		}

		// Token: 0x170015B6 RID: 5558
		// (get) Token: 0x060046FB RID: 18171 RVA: 0x00086DE4 File Offset: 0x00084FE4
		// (set) Token: 0x060046FC RID: 18172 RVA: 0x00086DFC File Offset: 0x00084FFC
		[ProtoMember(25, IsRequired = false, Name = "artifact", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemArtifact artifact
		{
			get
			{
				return this._artifact;
			}
			set
			{
				this._artifact = value;
			}
		}

		// Token: 0x060046FD RID: 18173 RVA: 0x00086E08 File Offset: 0x00085008
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400119D RID: 4509
		private ulong? _uid;

		// Token: 0x0400119E RID: 4510
		private uint? _ItemType;

		// Token: 0x0400119F RID: 4511
		private uint? _ItemID;

		// Token: 0x040011A0 RID: 4512
		private uint? _ItemCount;

		// Token: 0x040011A1 RID: 4513
		private bool? _isbind;

		// Token: 0x040011A2 RID: 4514
		private uint? _cooldown;

		// Token: 0x040011A3 RID: 4515
		private readonly List<uint> _AttrID = new List<uint>();

		// Token: 0x040011A4 RID: 4516
		private readonly List<uint> _AttrValue = new List<uint>();

		// Token: 0x040011A5 RID: 4517
		private readonly List<uint> _EnhanceAttrId = new List<uint>();

		// Token: 0x040011A6 RID: 4518
		private readonly List<uint> _EnhanceAttrValue = new List<uint>();

		// Token: 0x040011A7 RID: 4519
		private uint? _EnhanceLevel;

		// Token: 0x040011A8 RID: 4520
		private uint? _EnhanceCount;

		// Token: 0x040011A9 RID: 4521
		private ItemJade _ItemJade = null;

		// Token: 0x040011AA RID: 4522
		private uint? _FashionLevel;

		// Token: 0x040011AB RID: 4523
		private readonly List<CircleDrawData> _circleDrawDatas = new List<CircleDrawData>();

		// Token: 0x040011AC RID: 4524
		private uint? _EmblemThirdSlot;

		// Token: 0x040011AD RID: 4525
		private ItemEnchant _enchant = null;

		// Token: 0x040011AE RID: 4526
		private ItemRandAttr _randAttr = null;

		// Token: 0x040011AF RID: 4527
		private ItemForge _forge = null;

		// Token: 0x040011B0 RID: 4528
		private readonly List<EffectData> _effects = new List<EffectData>();

		// Token: 0x040011B1 RID: 4529
		private EmblemSlotType? _ebslottype;

		// Token: 0x040011B2 RID: 4530
		private uint? _smeltCount;

		// Token: 0x040011B3 RID: 4531
		private uint? _expirationTime;

		// Token: 0x040011B4 RID: 4532
		private ItemFuse _fuse = null;

		// Token: 0x040011B5 RID: 4533
		private ItemArtifact _artifact = null;

		// Token: 0x040011B6 RID: 4534
		private IExtension extensionObject;
	}
}
