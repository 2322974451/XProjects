using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StartPlantArg")]
	[Serializable]
	public class StartPlantArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "seed_id", DataFormat = DataFormat.TwosComplement)]
		public uint seed_id
		{
			get
			{
				return this._seed_id ?? 0U;
			}
			set
			{
				this._seed_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seed_idSpecified
		{
			get
			{
				return this._seed_id != null;
			}
			set
			{
				bool flag = value == (this._seed_id == null);
				if (flag)
				{
					this._seed_id = (value ? new uint?(this.seed_id) : null);
				}
			}
		}

		private bool ShouldSerializeseed_id()
		{
			return this.seed_idSpecified;
		}

		private void Resetseed_id()
		{
			this.seed_idSpecified = false;
		}

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

		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
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

		[ProtoMember(5, IsRequired = false, Name = "cancel", DataFormat = DataFormat.Default)]
		public bool cancel
		{
			get
			{
				return this._cancel ?? false;
			}
			set
			{
				this._cancel = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cancelSpecified
		{
			get
			{
				return this._cancel != null;
			}
			set
			{
				bool flag = value == (this._cancel == null);
				if (flag)
				{
					this._cancel = (value ? new bool?(this.cancel) : null);
				}
			}
		}

		private bool ShouldSerializecancel()
		{
			return this.cancelSpecified;
		}

		private void Resetcancel()
		{
			this.cancelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _farmland_id;

		private uint? _seed_id;

		private GardenQuestType? _quest_type;

		private ulong? _garden_id;

		private bool? _cancel;

		private IExtension extensionObject;
	}
}
