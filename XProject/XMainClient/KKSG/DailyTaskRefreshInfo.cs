using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskRefreshInfo")]
	[Serializable]
	public class DailyTaskRefreshInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "old_score", DataFormat = DataFormat.TwosComplement)]
		public uint old_score
		{
			get
			{
				return this._old_score ?? 0U;
			}
			set
			{
				this._old_score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool old_scoreSpecified
		{
			get
			{
				return this._old_score != null;
			}
			set
			{
				bool flag = value == (this._old_score == null);
				if (flag)
				{
					this._old_score = (value ? new uint?(this.old_score) : null);
				}
			}
		}

		private bool ShouldSerializeold_score()
		{
			return this.old_scoreSpecified;
		}

		private void Resetold_score()
		{
			this.old_scoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private uint? _score;

		private bool? _isnew;

		private uint? _time;

		private uint? _old_score;

		private IExtension extensionObject;
	}
}
