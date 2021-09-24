using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BagContent")]
	[Serializable]
	public class BagContent : IExtensible
	{

		[ProtoMember(1, Name = "Equips", DataFormat = DataFormat.Default)]
		public List<Item> Equips
		{
			get
			{
				return this._Equips;
			}
		}

		[ProtoMember(2, Name = "Emblems", DataFormat = DataFormat.Default)]
		public List<Item> Emblems
		{
			get
			{
				return this._Emblems;
			}
		}

		[ProtoMember(3, Name = "Items", DataFormat = DataFormat.Default)]
		public List<Item> Items
		{
			get
			{
				return this._Items;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "enhanceSuit", DataFormat = DataFormat.TwosComplement)]
		public uint enhanceSuit
		{
			get
			{
				return this._enhanceSuit ?? 0U;
			}
			set
			{
				this._enhanceSuit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enhanceSuitSpecified
		{
			get
			{
				return this._enhanceSuit != null;
			}
			set
			{
				bool flag = value == (this._enhanceSuit == null);
				if (flag)
				{
					this._enhanceSuit = (value ? new uint?(this.enhanceSuit) : null);
				}
			}
		}

		private bool ShouldSerializeenhanceSuit()
		{
			return this.enhanceSuitSpecified;
		}

		private void ResetenhanceSuit()
		{
			this.enhanceSuitSpecified = false;
		}

		[ProtoMember(5, Name = "virtualitems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> virtualitems
		{
			get
			{
				return this._virtualitems;
			}
		}

		[ProtoMember(6, Name = "Artifacts", DataFormat = DataFormat.Default)]
		public List<Item> Artifacts
		{
			get
			{
				return this._Artifacts;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "extraSkillEbSlotNum", DataFormat = DataFormat.TwosComplement)]
		public uint extraSkillEbSlotNum
		{
			get
			{
				return this._extraSkillEbSlotNum ?? 0U;
			}
			set
			{
				this._extraSkillEbSlotNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extraSkillEbSlotNumSpecified
		{
			get
			{
				return this._extraSkillEbSlotNum != null;
			}
			set
			{
				bool flag = value == (this._extraSkillEbSlotNum == null);
				if (flag)
				{
					this._extraSkillEbSlotNum = (value ? new uint?(this.extraSkillEbSlotNum) : null);
				}
			}
		}

		private bool ShouldSerializeextraSkillEbSlotNum()
		{
			return this.extraSkillEbSlotNumSpecified;
		}

		private void ResetextraSkillEbSlotNum()
		{
			this.extraSkillEbSlotNumSpecified = false;
		}

		[ProtoMember(8, Name = "expand", DataFormat = DataFormat.Default)]
		public List<BagExpandData> expand
		{
			get
			{
				return this._expand;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "FuseCompensation", DataFormat = DataFormat.Default)]
		public bool FuseCompensation
		{
			get
			{
				return this._FuseCompensation ?? false;
			}
			set
			{
				this._FuseCompensation = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FuseCompensationSpecified
		{
			get
			{
				return this._FuseCompensation != null;
			}
			set
			{
				bool flag = value == (this._FuseCompensation == null);
				if (flag)
				{
					this._FuseCompensation = (value ? new bool?(this.FuseCompensation) : null);
				}
			}
		}

		private bool ShouldSerializeFuseCompensation()
		{
			return this.FuseCompensationSpecified;
		}

		private void ResetFuseCompensation()
		{
			this.FuseCompensationSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "ForgeCompensation", DataFormat = DataFormat.Default)]
		public bool ForgeCompensation
		{
			get
			{
				return this._ForgeCompensation ?? false;
			}
			set
			{
				this._ForgeCompensation = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ForgeCompensationSpecified
		{
			get
			{
				return this._ForgeCompensation != null;
			}
			set
			{
				bool flag = value == (this._ForgeCompensation == null);
				if (flag)
				{
					this._ForgeCompensation = (value ? new bool?(this.ForgeCompensation) : null);
				}
			}
		}

		private bool ShouldSerializeForgeCompensation()
		{
			return this.ForgeCompensationSpecified;
		}

		private void ResetForgeCompensation()
		{
			this.ForgeCompensationSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<Item> _Equips = new List<Item>();

		private readonly List<Item> _Emblems = new List<Item>();

		private readonly List<Item> _Items = new List<Item>();

		private uint? _enhanceSuit;

		private readonly List<ulong> _virtualitems = new List<ulong>();

		private readonly List<Item> _Artifacts = new List<Item>();

		private uint? _extraSkillEbSlotNum;

		private readonly List<BagExpandData> _expand = new List<BagExpandData>();

		private bool? _FuseCompensation;

		private bool? _ForgeCompensation;

		private IExtension extensionObject;
	}
}
