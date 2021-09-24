using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetOperationArg")]
	[Serializable]
	public class PetOperationArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PetOP type
		{
			get
			{
				return this._type ?? PetOP.PetFellow;
			}
			set
			{
				this._type = new PetOP?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new PetOP?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "food", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief food
		{
			get
			{
				return this._food;
			}
			set
			{
				this._food = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "destpet_id", DataFormat = DataFormat.TwosComplement)]
		public ulong destpet_id
		{
			get
			{
				return this._destpet_id ?? 0UL;
			}
			set
			{
				this._destpet_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool destpet_idSpecified
		{
			get
			{
				return this._destpet_id != null;
			}
			set
			{
				bool flag = value == (this._destpet_id == null);
				if (flag)
				{
					this._destpet_id = (value ? new ulong?(this.destpet_id) : null);
				}
			}
		}

		private bool ShouldSerializedestpet_id()
		{
			return this.destpet_idSpecified;
		}

		private void Resetdestpet_id()
		{
			this.destpet_idSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "setpairride", DataFormat = DataFormat.Default)]
		public bool setpairride
		{
			get
			{
				return this._setpairride ?? false;
			}
			set
			{
				this._setpairride = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool setpairrideSpecified
		{
			get
			{
				return this._setpairride != null;
			}
			set
			{
				bool flag = value == (this._setpairride == null);
				if (flag)
				{
					this._setpairride = (value ? new bool?(this.setpairride) : null);
				}
			}
		}

		private bool ShouldSerializesetpairride()
		{
			return this.setpairrideSpecified;
		}

		private void Resetsetpairride()
		{
			this.setpairrideSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PetOP? _type;

		private ulong? _uid;

		private ItemBrief _food = null;

		private ulong? _destpet_id;

		private bool? _setpairride;

		private IExtension extensionObject;
	}
}
