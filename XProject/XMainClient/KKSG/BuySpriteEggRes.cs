using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuySpriteEggRes")]
	[Serializable]
	public class BuySpriteEggRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "goldfreebuycount", DataFormat = DataFormat.TwosComplement)]
		public uint goldfreebuycount
		{
			get
			{
				return this._goldfreebuycount ?? 0U;
			}
			set
			{
				this._goldfreebuycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldfreebuycountSpecified
		{
			get
			{
				return this._goldfreebuycount != null;
			}
			set
			{
				bool flag = value == (this._goldfreebuycount == null);
				if (flag)
				{
					this._goldfreebuycount = (value ? new uint?(this.goldfreebuycount) : null);
				}
			}
		}

		private bool ShouldSerializegoldfreebuycount()
		{
			return this.goldfreebuycountSpecified;
		}

		private void Resetgoldfreebuycount()
		{
			this.goldfreebuycountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "goldfreebuycooldown", DataFormat = DataFormat.TwosComplement)]
		public uint goldfreebuycooldown
		{
			get
			{
				return this._goldfreebuycooldown ?? 0U;
			}
			set
			{
				this._goldfreebuycooldown = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldfreebuycooldownSpecified
		{
			get
			{
				return this._goldfreebuycooldown != null;
			}
			set
			{
				bool flag = value == (this._goldfreebuycooldown == null);
				if (flag)
				{
					this._goldfreebuycooldown = (value ? new uint?(this.goldfreebuycooldown) : null);
				}
			}
		}

		private bool ShouldSerializegoldfreebuycooldown()
		{
			return this.goldfreebuycooldownSpecified;
		}

		private void Resetgoldfreebuycooldown()
		{
			this.goldfreebuycooldownSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		private uint? _cooldown;

		private uint? _goldfreebuycount;

		private uint? _goldfreebuycooldown;

		private IExtension extensionObject;
	}
}
