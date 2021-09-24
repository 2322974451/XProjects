using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenOverviewRes")]
	[Serializable]
	public class GardenOverviewRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "visited_times", DataFormat = DataFormat.TwosComplement)]
		public uint visited_times
		{
			get
			{
				return this._visited_times ?? 0U;
			}
			set
			{
				this._visited_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool visited_timesSpecified
		{
			get
			{
				return this._visited_times != null;
			}
			set
			{
				bool flag = value == (this._visited_times == null);
				if (flag)
				{
					this._visited_times = (value ? new uint?(this.visited_times) : null);
				}
			}
		}

		private bool ShouldSerializevisited_times()
		{
			return this.visited_timesSpecified;
		}

		private void Resetvisited_times()
		{
			this.visited_timesSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "fish_level", DataFormat = DataFormat.TwosComplement)]
		public uint fish_level
		{
			get
			{
				return this._fish_level ?? 0U;
			}
			set
			{
				this._fish_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fish_levelSpecified
		{
			get
			{
				return this._fish_level != null;
			}
			set
			{
				bool flag = value == (this._fish_level == null);
				if (flag)
				{
					this._fish_level = (value ? new uint?(this.fish_level) : null);
				}
			}
		}

		private bool ShouldSerializefish_level()
		{
			return this.fish_levelSpecified;
		}

		private void Resetfish_level()
		{
			this.fish_levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "fish_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint fish_experiences
		{
			get
			{
				return this._fish_experiences ?? 0U;
			}
			set
			{
				this._fish_experiences = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fish_experiencesSpecified
		{
			get
			{
				return this._fish_experiences != null;
			}
			set
			{
				bool flag = value == (this._fish_experiences == null);
				if (flag)
				{
					this._fish_experiences = (value ? new uint?(this.fish_experiences) : null);
				}
			}
		}

		private bool ShouldSerializefish_experiences()
		{
			return this.fish_experiencesSpecified;
		}

		private void Resetfish_experiences()
		{
			this.fish_experiencesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "cooking_level", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_level
		{
			get
			{
				return this._cooking_level ?? 0U;
			}
			set
			{
				this._cooking_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_levelSpecified
		{
			get
			{
				return this._cooking_level != null;
			}
			set
			{
				bool flag = value == (this._cooking_level == null);
				if (flag)
				{
					this._cooking_level = (value ? new uint?(this.cooking_level) : null);
				}
			}
		}

		private bool ShouldSerializecooking_level()
		{
			return this.cooking_levelSpecified;
		}

		private void Resetcooking_level()
		{
			this.cooking_levelSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "cooking_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_experiences
		{
			get
			{
				return this._cooking_experiences ?? 0U;
			}
			set
			{
				this._cooking_experiences = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_experiencesSpecified
		{
			get
			{
				return this._cooking_experiences != null;
			}
			set
			{
				bool flag = value == (this._cooking_experiences == null);
				if (flag)
				{
					this._cooking_experiences = (value ? new uint?(this.cooking_experiences) : null);
				}
			}
		}

		private bool ShouldSerializecooking_experiences()
		{
			return this.cooking_experiencesSpecified;
		}

		private void Resetcooking_experiences()
		{
			this.cooking_experiencesSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "plant_amount", DataFormat = DataFormat.TwosComplement)]
		public uint plant_amount
		{
			get
			{
				return this._plant_amount ?? 0U;
			}
			set
			{
				this._plant_amount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool plant_amountSpecified
		{
			get
			{
				return this._plant_amount != null;
			}
			set
			{
				bool flag = value == (this._plant_amount == null);
				if (flag)
				{
					this._plant_amount = (value ? new uint?(this.plant_amount) : null);
				}
			}
		}

		private bool ShouldSerializeplant_amount()
		{
			return this.plant_amountSpecified;
		}

		private void Resetplant_amount()
		{
			this.plant_amountSpecified = false;
		}

		[ProtoMember(8, Name = "friend_log", DataFormat = DataFormat.Default)]
		public List<FriendPlantLog> friend_log
		{
			get
			{
				return this._friend_log;
			}
		}

		[ProtoMember(9, Name = "event_log", DataFormat = DataFormat.Default)]
		public List<GardenEventLog> event_log
		{
			get
			{
				return this._event_log;
			}
		}

		[ProtoMember(10, Name = "plant_info", DataFormat = DataFormat.Default)]
		public List<PlantInfo> plant_info
		{
			get
			{
				return this._plant_info;
			}
		}

		[ProtoMember(11, Name = "food_id", DataFormat = DataFormat.Default)]
		public List<MapIntItem> food_id
		{
			get
			{
				return this._food_id;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "server_time", DataFormat = DataFormat.TwosComplement)]
		public uint server_time
		{
			get
			{
				return this._server_time ?? 0U;
			}
			set
			{
				this._server_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool server_timeSpecified
		{
			get
			{
				return this._server_time != null;
			}
			set
			{
				bool flag = value == (this._server_time == null);
				if (flag)
				{
					this._server_time = (value ? new uint?(this.server_time) : null);
				}
			}
		}

		private bool ShouldSerializeserver_time()
		{
			return this.server_timeSpecified;
		}

		private void Resetserver_time()
		{
			this.server_timeSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "plant_farmland_max", DataFormat = DataFormat.TwosComplement)]
		public uint plant_farmland_max
		{
			get
			{
				return this._plant_farmland_max ?? 0U;
			}
			set
			{
				this._plant_farmland_max = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool plant_farmland_maxSpecified
		{
			get
			{
				return this._plant_farmland_max != null;
			}
			set
			{
				bool flag = value == (this._plant_farmland_max == null);
				if (flag)
				{
					this._plant_farmland_max = (value ? new uint?(this.plant_farmland_max) : null);
				}
			}
		}

		private bool ShouldSerializeplant_farmland_max()
		{
			return this.plant_farmland_maxSpecified;
		}

		private void Resetplant_farmland_max()
		{
			this.plant_farmland_maxSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _visited_times;

		private uint? _fish_level;

		private uint? _fish_experiences;

		private uint? _cooking_level;

		private uint? _cooking_experiences;

		private uint? _plant_amount;

		private readonly List<FriendPlantLog> _friend_log = new List<FriendPlantLog>();

		private readonly List<GardenEventLog> _event_log = new List<GardenEventLog>();

		private readonly List<PlantInfo> _plant_info = new List<PlantInfo>();

		private readonly List<MapIntItem> _food_id = new List<MapIntItem>();

		private uint? _server_time;

		private uint? _plant_farmland_max;

		private uint? _sprite_id;

		private IExtension extensionObject;
	}
}
