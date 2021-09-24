using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HellDropInfo")]
	[Serializable]
	public class HellDropInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "common", DataFormat = DataFormat.TwosComplement)]
		public uint common
		{
			get
			{
				return this._common ?? 0U;
			}
			set
			{
				this._common = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commonSpecified
		{
			get
			{
				return this._common != null;
			}
			set
			{
				bool flag = value == (this._common == null);
				if (flag)
				{
					this._common = (value ? new uint?(this.common) : null);
				}
			}
		}

		private bool ShouldSerializecommon()
		{
			return this.commonSpecified;
		}

		private void Resetcommon()
		{
			this.commonSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "worse", DataFormat = DataFormat.TwosComplement)]
		public uint worse
		{
			get
			{
				return this._worse ?? 0U;
			}
			set
			{
				this._worse = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool worseSpecified
		{
			get
			{
				return this._worse != null;
			}
			set
			{
				bool flag = value == (this._worse == null);
				if (flag)
				{
					this._worse = (value ? new uint?(this.worse) : null);
				}
			}
		}

		private bool ShouldSerializeworse()
		{
			return this.worseSpecified;
		}

		private void Resetworse()
		{
			this.worseSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "worst", DataFormat = DataFormat.TwosComplement)]
		public uint worst
		{
			get
			{
				return this._worst ?? 0U;
			}
			set
			{
				this._worst = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool worstSpecified
		{
			get
			{
				return this._worst != null;
			}
			set
			{
				bool flag = value == (this._worst == null);
				if (flag)
				{
					this._worst = (value ? new uint?(this.worst) : null);
				}
			}
		}

		private bool ShouldSerializeworst()
		{
			return this.worstSpecified;
		}

		private void Resetworst()
		{
			this.worstSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private uint? _common;

		private uint? _count;

		private uint? _time;

		private uint? _worse;

		private uint? _worst;

		private IExtension extensionObject;
	}
}
