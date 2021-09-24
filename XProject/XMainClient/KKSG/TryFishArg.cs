using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TryFishArg")]
	[Serializable]
	public class TryFishArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "casting_net", DataFormat = DataFormat.Default)]
		public bool casting_net
		{
			get
			{
				return this._casting_net ?? false;
			}
			set
			{
				this._casting_net = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool casting_netSpecified
		{
			get
			{
				return this._casting_net != null;
			}
			set
			{
				bool flag = value == (this._casting_net == null);
				if (flag)
				{
					this._casting_net = (value ? new bool?(this.casting_net) : null);
				}
			}
		}

		private bool ShouldSerializecasting_net()
		{
			return this.casting_netSpecified;
		}

		private void Resetcasting_net()
		{
			this.casting_netSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GardenQuestType? _quest_type;

		private ulong? _garden_id;

		private bool? _casting_net;

		private IExtension extensionObject;
	}
}
