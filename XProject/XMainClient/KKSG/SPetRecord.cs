using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SPetRecord")]
	[Serializable]
	public class SPetRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "touchStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint touchStartTime
		{
			get
			{
				return this._touchStartTime ?? 0U;
			}
			set
			{
				this._touchStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool touchStartTimeSpecified
		{
			get
			{
				return this._touchStartTime != null;
			}
			set
			{
				bool flag = value == (this._touchStartTime == null);
				if (flag)
				{
					this._touchStartTime = (value ? new uint?(this.touchStartTime) : null);
				}
			}
		}

		private bool ShouldSerializetouchStartTime()
		{
			return this.touchStartTimeSpecified;
		}

		private void ResettouchStartTime()
		{
			this.touchStartTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "touchHourAttr", DataFormat = DataFormat.TwosComplement)]
		public uint touchHourAttr
		{
			get
			{
				return this._touchHourAttr ?? 0U;
			}
			set
			{
				this._touchHourAttr = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool touchHourAttrSpecified
		{
			get
			{
				return this._touchHourAttr != null;
			}
			set
			{
				bool flag = value == (this._touchHourAttr == null);
				if (flag)
				{
					this._touchHourAttr = (value ? new uint?(this.touchHourAttr) : null);
				}
			}
		}

		private bool ShouldSerializetouchHourAttr()
		{
			return this.touchHourAttrSpecified;
		}

		private void ResettouchHourAttr()
		{
			this.touchHourAttrSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "touchTodayAttr", DataFormat = DataFormat.TwosComplement)]
		public uint touchTodayAttr
		{
			get
			{
				return this._touchTodayAttr ?? 0U;
			}
			set
			{
				this._touchTodayAttr = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool touchTodayAttrSpecified
		{
			get
			{
				return this._touchTodayAttr != null;
			}
			set
			{
				bool flag = value == (this._touchTodayAttr == null);
				if (flag)
				{
					this._touchTodayAttr = (value ? new uint?(this.touchTodayAttr) : null);
				}
			}
		}

		private bool ShouldSerializetouchTodayAttr()
		{
			return this.touchTodayAttrSpecified;
		}

		private void ResettouchTodayAttr()
		{
			this.touchTodayAttrSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "followStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint followStartTime
		{
			get
			{
				return this._followStartTime ?? 0U;
			}
			set
			{
				this._followStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool followStartTimeSpecified
		{
			get
			{
				return this._followStartTime != null;
			}
			set
			{
				bool flag = value == (this._followStartTime == null);
				if (flag)
				{
					this._followStartTime = (value ? new uint?(this.followStartTime) : null);
				}
			}
		}

		private bool ShouldSerializefollowStartTime()
		{
			return this.followStartTimeSpecified;
		}

		private void ResetfollowStartTime()
		{
			this.followStartTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "followTodayAttr", DataFormat = DataFormat.TwosComplement)]
		public uint followTodayAttr
		{
			get
			{
				return this._followTodayAttr ?? 0U;
			}
			set
			{
				this._followTodayAttr = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool followTodayAttrSpecified
		{
			get
			{
				return this._followTodayAttr != null;
			}
			set
			{
				bool flag = value == (this._followTodayAttr == null);
				if (flag)
				{
					this._followTodayAttr = (value ? new uint?(this.followTodayAttr) : null);
				}
			}
		}

		private bool ShouldSerializefollowTodayAttr()
		{
			return this.followTodayAttrSpecified;
		}

		private void ResetfollowTodayAttr()
		{
			this.followTodayAttrSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "hungryStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint hungryStartTime
		{
			get
			{
				return this._hungryStartTime ?? 0U;
			}
			set
			{
				this._hungryStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hungryStartTimeSpecified
		{
			get
			{
				return this._hungryStartTime != null;
			}
			set
			{
				bool flag = value == (this._hungryStartTime == null);
				if (flag)
				{
					this._hungryStartTime = (value ? new uint?(this.hungryStartTime) : null);
				}
			}
		}

		private bool ShouldSerializehungryStartTime()
		{
			return this.hungryStartTimeSpecified;
		}

		private void ResethungryStartTime()
		{
			this.hungryStartTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "moodStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint moodStartTime
		{
			get
			{
				return this._moodStartTime ?? 0U;
			}
			set
			{
				this._moodStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moodStartTimeSpecified
		{
			get
			{
				return this._moodStartTime != null;
			}
			set
			{
				bool flag = value == (this._moodStartTime == null);
				if (flag)
				{
					this._moodStartTime = (value ? new uint?(this.moodStartTime) : null);
				}
			}
		}

		private bool ShouldSerializemoodStartTime()
		{
			return this.moodStartTimeSpecified;
		}

		private void ResetmoodStartTime()
		{
			this.moodStartTimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "max_level", DataFormat = DataFormat.TwosComplement)]
		public uint max_level
		{
			get
			{
				return this._max_level ?? 0U;
			}
			set
			{
				this._max_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool max_levelSpecified
		{
			get
			{
				return this._max_level != null;
			}
			set
			{
				bool flag = value == (this._max_level == null);
				if (flag)
				{
					this._max_level = (value ? new uint?(this.max_level) : null);
				}
			}
		}

		private bool ShouldSerializemax_level()
		{
			return this.max_levelSpecified;
		}

		private void Resetmax_level()
		{
			this.max_levelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _touchStartTime;

		private uint? _touchHourAttr;

		private uint? _touchTodayAttr;

		private uint? _followStartTime;

		private uint? _followTodayAttr;

		private uint? _hungryStartTime;

		private uint? _moodStartTime;

		private uint? _max_level;

		private IExtension extensionObject;
	}
}
