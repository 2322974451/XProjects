using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHallBuffData")]
	[Serializable]
	public class GuildHallBuffData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "maxlevel", DataFormat = DataFormat.TwosComplement)]
		public uint maxlevel
		{
			get
			{
				return this._maxlevel ?? 0U;
			}
			set
			{
				this._maxlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxlevelSpecified
		{
			get
			{
				return this._maxlevel != null;
			}
			set
			{
				bool flag = value == (this._maxlevel == null);
				if (flag)
				{
					this._maxlevel = (value ? new uint?(this.maxlevel) : null);
				}
			}
		}

		private bool ShouldSerializemaxlevel()
		{
			return this.maxlevelSpecified;
		}

		private void Resetmaxlevel()
		{
			this.maxlevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isenable", DataFormat = DataFormat.Default)]
		public bool isenable
		{
			get
			{
				return this._isenable ?? false;
			}
			set
			{
				this._isenable = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isenableSpecified
		{
			get
			{
				return this._isenable != null;
			}
			set
			{
				bool flag = value == (this._isenable == null);
				if (flag)
				{
					this._isenable = (value ? new bool?(this.isenable) : null);
				}
			}
		}

		private bool ShouldSerializeisenable()
		{
			return this.isenableSpecified;
		}

		private void Resetisenable()
		{
			this.isenableSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "dailybegintime", DataFormat = DataFormat.TwosComplement)]
		public uint dailybegintime
		{
			get
			{
				return this._dailybegintime ?? 0U;
			}
			set
			{
				this._dailybegintime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dailybegintimeSpecified
		{
			get
			{
				return this._dailybegintime != null;
			}
			set
			{
				bool flag = value == (this._dailybegintime == null);
				if (flag)
				{
					this._dailybegintime = (value ? new uint?(this.dailybegintime) : null);
				}
			}
		}

		private bool ShouldSerializedailybegintime()
		{
			return this.dailybegintimeSpecified;
		}

		private void Resetdailybegintime()
		{
			this.dailybegintimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _buffid;

		private uint? _maxlevel;

		private uint? _level;

		private bool? _isenable;

		private uint? _dailybegintime;

		private IExtension extensionObject;
	}
}
