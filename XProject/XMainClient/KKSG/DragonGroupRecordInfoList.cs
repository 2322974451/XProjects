using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGroupRecordInfoList")]
	[Serializable]
	public class DragonGroupRecordInfoList : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "stageid", DataFormat = DataFormat.TwosComplement)]
		public uint stageid
		{
			get
			{
				return this._stageid ?? 0U;
			}
			set
			{
				this._stageid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageidSpecified
		{
			get
			{
				return this._stageid != null;
			}
			set
			{
				bool flag = value == (this._stageid == null);
				if (flag)
				{
					this._stageid = (value ? new uint?(this.stageid) : null);
				}
			}
		}

		private bool ShouldSerializestageid()
		{
			return this.stageidSpecified;
		}

		private void Resetstageid()
		{
			this.stageidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "costtime", DataFormat = DataFormat.TwosComplement)]
		public uint costtime
		{
			get
			{
				return this._costtime ?? 0U;
			}
			set
			{
				this._costtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costtimeSpecified
		{
			get
			{
				return this._costtime != null;
			}
			set
			{
				bool flag = value == (this._costtime == null);
				if (flag)
				{
					this._costtime = (value ? new uint?(this.costtime) : null);
				}
			}
		}

		private bool ShouldSerializecosttime()
		{
			return this.costtimeSpecified;
		}

		private void Resetcosttime()
		{
			this.costtimeSpecified = false;
		}

		[ProtoMember(4, Name = "roleinfo", DataFormat = DataFormat.Default)]
		public List<DragonGroupRoleInfo> roleinfo
		{
			get
			{
				return this._roleinfo;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "isFirstPass", DataFormat = DataFormat.Default)]
		public bool isFirstPass
		{
			get
			{
				return this._isFirstPass ?? false;
			}
			set
			{
				this._isFirstPass = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstPassSpecified
		{
			get
			{
				return this._isFirstPass != null;
			}
			set
			{
				bool flag = value == (this._isFirstPass == null);
				if (flag)
				{
					this._isFirstPass = (value ? new bool?(this.isFirstPass) : null);
				}
			}
		}

		private bool ShouldSerializeisFirstPass()
		{
			return this.isFirstPassSpecified;
		}

		private void ResetisFirstPass()
		{
			this.isFirstPassSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isServerFirstPass", DataFormat = DataFormat.Default)]
		public bool isServerFirstPass
		{
			get
			{
				return this._isServerFirstPass ?? false;
			}
			set
			{
				this._isServerFirstPass = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isServerFirstPassSpecified
		{
			get
			{
				return this._isServerFirstPass != null;
			}
			set
			{
				bool flag = value == (this._isServerFirstPass == null);
				if (flag)
				{
					this._isServerFirstPass = (value ? new bool?(this.isServerFirstPass) : null);
				}
			}
		}

		private bool ShouldSerializeisServerFirstPass()
		{
			return this.isServerFirstPassSpecified;
		}

		private void ResetisServerFirstPass()
		{
			this.isServerFirstPassSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "commendnum", DataFormat = DataFormat.TwosComplement)]
		public uint commendnum
		{
			get
			{
				return this._commendnum ?? 0U;
			}
			set
			{
				this._commendnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commendnumSpecified
		{
			get
			{
				return this._commendnum != null;
			}
			set
			{
				bool flag = value == (this._commendnum == null);
				if (flag)
				{
					this._commendnum = (value ? new uint?(this.commendnum) : null);
				}
			}
		}

		private bool ShouldSerializecommendnum()
		{
			return this.commendnumSpecified;
		}

		private void Resetcommendnum()
		{
			this.commendnumSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "watchnum", DataFormat = DataFormat.TwosComplement)]
		public uint watchnum
		{
			get
			{
				return this._watchnum ?? 0U;
			}
			set
			{
				this._watchnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool watchnumSpecified
		{
			get
			{
				return this._watchnum != null;
			}
			set
			{
				bool flag = value == (this._watchnum == null);
				if (flag)
				{
					this._watchnum = (value ? new uint?(this.watchnum) : null);
				}
			}
		}

		private bool ShouldSerializewatchnum()
		{
			return this.watchnumSpecified;
		}

		private void Resetwatchnum()
		{
			this.watchnumSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "ismostcommendnum", DataFormat = DataFormat.Default)]
		public bool ismostcommendnum
		{
			get
			{
				return this._ismostcommendnum ?? false;
			}
			set
			{
				this._ismostcommendnum = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismostcommendnumSpecified
		{
			get
			{
				return this._ismostcommendnum != null;
			}
			set
			{
				bool flag = value == (this._ismostcommendnum == null);
				if (flag)
				{
					this._ismostcommendnum = (value ? new bool?(this.ismostcommendnum) : null);
				}
			}
		}

		private bool ShouldSerializeismostcommendnum()
		{
			return this.ismostcommendnumSpecified;
		}

		private void Resetismostcommendnum()
		{
			this.ismostcommendnumSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "ismostwatchnum", DataFormat = DataFormat.Default)]
		public bool ismostwatchnum
		{
			get
			{
				return this._ismostwatchnum ?? false;
			}
			set
			{
				this._ismostwatchnum = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismostwatchnumSpecified
		{
			get
			{
				return this._ismostwatchnum != null;
			}
			set
			{
				bool flag = value == (this._ismostwatchnum == null);
				if (flag)
				{
					this._ismostwatchnum = (value ? new bool?(this.ismostwatchnum) : null);
				}
			}
		}

		private bool ShouldSerializeismostwatchnum()
		{
			return this.ismostwatchnumSpecified;
		}

		private void Resetismostwatchnum()
		{
			this.ismostwatchnumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _stageid;

		private uint? _time;

		private uint? _costtime;

		private readonly List<DragonGroupRoleInfo> _roleinfo = new List<DragonGroupRoleInfo>();

		private bool? _iswin;

		private bool? _isFirstPass;

		private bool? _isServerFirstPass;

		private uint? _commendnum;

		private uint? _watchnum;

		private bool? _ismostcommendnum;

		private bool? _ismostwatchnum;

		private IExtension extensionObject;
	}
}
