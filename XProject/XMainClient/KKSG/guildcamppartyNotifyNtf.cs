using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "guildcamppartyNotifyNtf")]
	[Serializable]
	public class guildcamppartyNotifyNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "notify_type", DataFormat = DataFormat.TwosComplement)]
		public uint notify_type
		{
			get
			{
				return this._notify_type ?? 0U;
			}
			set
			{
				this._notify_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notify_typeSpecified
		{
			get
			{
				return this._notify_type != null;
			}
			set
			{
				bool flag = value == (this._notify_type == null);
				if (flag)
				{
					this._notify_type = (value ? new uint?(this.notify_type) : null);
				}
			}
		}

		private bool ShouldSerializenotify_type()
		{
			return this.notify_typeSpecified;
		}

		private void Resetnotify_type()
		{
			this.notify_typeSpecified = false;
		}

		[ProtoMember(2, Name = "sprite_list", DataFormat = DataFormat.Default)]
		public List<GuildCampSpriteInfo> sprite_list
		{
			get
			{
				return this._sprite_list;
			}
		}

		[ProtoMember(3, Name = "lottery_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lottery_list
		{
			get
			{
				return this._lottery_list;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "left_time", DataFormat = DataFormat.TwosComplement)]
		public uint left_time
		{
			get
			{
				return this._left_time ?? 0U;
			}
			set
			{
				this._left_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool left_timeSpecified
		{
			get
			{
				return this._left_time != null;
			}
			set
			{
				bool flag = value == (this._left_time == null);
				if (flag)
				{
					this._left_time = (value ? new uint?(this.left_time) : null);
				}
			}
		}

		private bool ShouldSerializeleft_time()
		{
			return this.left_timeSpecified;
		}

		private void Resetleft_time()
		{
			this.left_timeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _notify_type;

		private readonly List<GuildCampSpriteInfo> _sprite_list = new List<GuildCampSpriteInfo>();

		private readonly List<uint> _lottery_list = new List<uint>();

		private uint? _left_time;

		private IExtension extensionObject;
	}
}
