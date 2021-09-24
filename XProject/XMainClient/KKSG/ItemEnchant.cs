using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemEnchant")]
	[Serializable]
	public class ItemEnchant : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "enchantid", DataFormat = DataFormat.TwosComplement)]
		public uint enchantid
		{
			get
			{
				return this._enchantid ?? 0U;
			}
			set
			{
				this._enchantid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enchantidSpecified
		{
			get
			{
				return this._enchantid != null;
			}
			set
			{
				bool flag = value == (this._enchantid == null);
				if (flag)
				{
					this._enchantid = (value ? new uint?(this.enchantid) : null);
				}
			}
		}

		private bool ShouldSerializeenchantid()
		{
			return this.enchantidSpecified;
		}

		private void Resetenchantid()
		{
			this.enchantidSpecified = false;
		}

		[ProtoMember(2, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "chooseAttrid", DataFormat = DataFormat.TwosComplement)]
		public uint chooseAttrid
		{
			get
			{
				return this._chooseAttrid ?? 0U;
			}
			set
			{
				this._chooseAttrid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chooseAttridSpecified
		{
			get
			{
				return this._chooseAttrid != null;
			}
			set
			{
				bool flag = value == (this._chooseAttrid == null);
				if (flag)
				{
					this._chooseAttrid = (value ? new uint?(this.chooseAttrid) : null);
				}
			}
		}

		private bool ShouldSerializechooseAttrid()
		{
			return this.chooseAttridSpecified;
		}

		private void ResetchooseAttrid()
		{
			this.chooseAttridSpecified = false;
		}

		[ProtoMember(4, Name = "enchantids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enchantids
		{
			get
			{
				return this._enchantids;
			}
		}

		[ProtoMember(5, Name = "allAttrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> allAttrs
		{
			get
			{
				return this._allAttrs;
			}
		}

		[ProtoMember(6, Name = "enchantBaodi", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enchantBaodi
		{
			get
			{
				return this._enchantBaodi;
			}
		}

		[ProtoMember(7, Name = "baodiCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> baodiCount
		{
			get
			{
				return this._baodiCount;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _enchantid;

		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		private uint? _chooseAttrid;

		private readonly List<uint> _enchantids = new List<uint>();

		private readonly List<AttributeInfo> _allAttrs = new List<AttributeInfo>();

		private readonly List<uint> _enchantBaodi = new List<uint>();

		private readonly List<uint> _baodiCount = new List<uint>();

		private IExtension extensionObject;
	}
}
