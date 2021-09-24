using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenPlantEventNoticeArg")]
	[Serializable]
	public class GardenPlantEventNoticeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "event_type", DataFormat = DataFormat.TwosComplement)]
		public GardenPlayEventType event_type
		{
			get
			{
				return this._event_type ?? GardenPlayEventType.PLANT;
			}
			set
			{
				this._event_type = new GardenPlayEventType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool event_typeSpecified
		{
			get
			{
				return this._event_type != null;
			}
			set
			{
				bool flag = value == (this._event_type == null);
				if (flag)
				{
					this._event_type = (value ? new GardenPlayEventType?(this.event_type) : null);
				}
			}
		}

		private bool ShouldSerializeevent_type()
		{
			return this.event_typeSpecified;
		}

		private void Resetevent_type()
		{
			this.event_typeSpecified = false;
		}

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

		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

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

		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "exist", DataFormat = DataFormat.Default)]
		public bool exist
		{
			get
			{
				return this._exist ?? false;
			}
			set
			{
				this._exist = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool existSpecified
		{
			get
			{
				return this._exist != null;
			}
			set
			{
				bool flag = value == (this._exist == null);
				if (flag)
				{
					this._exist = (value ? new bool?(this.exist) : null);
				}
			}
		}

		private bool ShouldSerializeexist()
		{
			return this.existSpecified;
		}

		private void Resetexist()
		{
			this.existSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "fish_result", DataFormat = DataFormat.Default)]
		public bool fish_result
		{
			get
			{
				return this._fish_result ?? false;
			}
			set
			{
				this._fish_result = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fish_resultSpecified
		{
			get
			{
				return this._fish_result != null;
			}
			set
			{
				bool flag = value == (this._fish_result == null);
				if (flag)
				{
					this._fish_result = (value ? new bool?(this.fish_result) : null);
				}
			}
		}

		private bool ShouldSerializefish_result()
		{
			return this.fish_resultSpecified;
		}

		private void Resetfish_result()
		{
			this.fish_resultSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "fish_stop", DataFormat = DataFormat.Default)]
		public bool fish_stop
		{
			get
			{
				return this._fish_stop ?? false;
			}
			set
			{
				this._fish_stop = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fish_stopSpecified
		{
			get
			{
				return this._fish_stop != null;
			}
			set
			{
				bool flag = value == (this._fish_stop == null);
				if (flag)
				{
					this._fish_stop = (value ? new bool?(this.fish_stop) : null);
				}
			}
		}

		private bool ShouldSerializefish_stop()
		{
			return this.fish_stopSpecified;
		}

		private void Resetfish_stop()
		{
			this.fish_stopSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GardenPlayEventType? _event_type;

		private uint? _farmland_id;

		private uint? _sprite_id;

		private ulong? _garden_id;

		private bool? _exist;

		private ulong? _role_id;

		private bool? _fish_result;

		private bool? _fish_stop;

		private IExtension extensionObject;
	}
}
