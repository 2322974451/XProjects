using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Item")]
	[Serializable]
	public class Item : IExtensible
	{

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

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

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

		private bool ShouldSerializeItemType()
		{
			return this.ItemTypeSpecified;
		}

		private void ResetItemType()
		{
			this.ItemTypeSpecified = false;
		}

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

		private bool ShouldSerializeItemID()
		{
			return this.ItemIDSpecified;
		}

		private void ResetItemID()
		{
			this.ItemIDSpecified = false;
		}

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

		private bool ShouldSerializeItemCount()
		{
			return this.ItemCountSpecified;
		}

		private void ResetItemCount()
		{
			this.ItemCountSpecified = false;
		}

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

		private bool ShouldSerializeisbind()
		{
			return this.isbindSpecified;
		}

		private void Resetisbind()
		{
			this.isbindSpecified = false;
		}

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

		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		[ProtoMember(7, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		[ProtoMember(8, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		[ProtoMember(9, Name = "EnhanceAttrId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EnhanceAttrId
		{
			get
			{
				return this._EnhanceAttrId;
			}
		}

		[ProtoMember(10, Name = "EnhanceAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EnhanceAttrValue
		{
			get
			{
				return this._EnhanceAttrValue;
			}
		}

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

		private bool ShouldSerializeEnhanceLevel()
		{
			return this.EnhanceLevelSpecified;
		}

		private void ResetEnhanceLevel()
		{
			this.EnhanceLevelSpecified = false;
		}

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

		private bool ShouldSerializeEnhanceCount()
		{
			return this.EnhanceCountSpecified;
		}

		private void ResetEnhanceCount()
		{
			this.EnhanceCountSpecified = false;
		}

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

		private bool ShouldSerializeFashionLevel()
		{
			return this.FashionLevelSpecified;
		}

		private void ResetFashionLevel()
		{
			this.FashionLevelSpecified = false;
		}

		[ProtoMember(15, Name = "circleDrawDatas", DataFormat = DataFormat.Default)]
		public List<CircleDrawData> circleDrawDatas
		{
			get
			{
				return this._circleDrawDatas;
			}
		}

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

		private bool ShouldSerializeEmblemThirdSlot()
		{
			return this.EmblemThirdSlotSpecified;
		}

		private void ResetEmblemThirdSlot()
		{
			this.EmblemThirdSlotSpecified = false;
		}

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

		[ProtoMember(20, Name = "effects", DataFormat = DataFormat.Default)]
		public List<EffectData> effects
		{
			get
			{
				return this._effects;
			}
		}

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

		private bool ShouldSerializeebslottype()
		{
			return this.ebslottypeSpecified;
		}

		private void Resetebslottype()
		{
			this.ebslottypeSpecified = false;
		}

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

		private bool ShouldSerializesmeltCount()
		{
			return this.smeltCountSpecified;
		}

		private void ResetsmeltCount()
		{
			this.smeltCountSpecified = false;
		}

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

		private bool ShouldSerializeexpirationTime()
		{
			return this.expirationTimeSpecified;
		}

		private void ResetexpirationTime()
		{
			this.expirationTimeSpecified = false;
		}

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _ItemType;

		private uint? _ItemID;

		private uint? _ItemCount;

		private bool? _isbind;

		private uint? _cooldown;

		private readonly List<uint> _AttrID = new List<uint>();

		private readonly List<uint> _AttrValue = new List<uint>();

		private readonly List<uint> _EnhanceAttrId = new List<uint>();

		private readonly List<uint> _EnhanceAttrValue = new List<uint>();

		private uint? _EnhanceLevel;

		private uint? _EnhanceCount;

		private ItemJade _ItemJade = null;

		private uint? _FashionLevel;

		private readonly List<CircleDrawData> _circleDrawDatas = new List<CircleDrawData>();

		private uint? _EmblemThirdSlot;

		private ItemEnchant _enchant = null;

		private ItemRandAttr _randAttr = null;

		private ItemForge _forge = null;

		private readonly List<EffectData> _effects = new List<EffectData>();

		private EmblemSlotType? _ebslottype;

		private uint? _smeltCount;

		private uint? _expirationTime;

		private ItemFuse _fuse = null;

		private ItemArtifact _artifact = null;

		private IExtension extensionObject;
	}
}
