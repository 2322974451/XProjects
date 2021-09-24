using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpData")]
	[Serializable]
	public class PvpData : IExtensible
	{

		[ProtoMember(1, Name = "pvprecs", DataFormat = DataFormat.Default)]
		public List<PvpOneRec> pvprecs
		{
			get
			{
				return this._pvprecs;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "wincountall", DataFormat = DataFormat.TwosComplement)]
		public int wincountall
		{
			get
			{
				return this._wincountall ?? 0;
			}
			set
			{
				this._wincountall = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wincountallSpecified
		{
			get
			{
				return this._wincountall != null;
			}
			set
			{
				bool flag = value == (this._wincountall == null);
				if (flag)
				{
					this._wincountall = (value ? new int?(this.wincountall) : null);
				}
			}
		}

		private bool ShouldSerializewincountall()
		{
			return this.wincountallSpecified;
		}

		private void Resetwincountall()
		{
			this.wincountallSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "losecountall", DataFormat = DataFormat.TwosComplement)]
		public int losecountall
		{
			get
			{
				return this._losecountall ?? 0;
			}
			set
			{
				this._losecountall = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losecountallSpecified
		{
			get
			{
				return this._losecountall != null;
			}
			set
			{
				bool flag = value == (this._losecountall == null);
				if (flag)
				{
					this._losecountall = (value ? new int?(this.losecountall) : null);
				}
			}
		}

		private bool ShouldSerializelosecountall()
		{
			return this.losecountallSpecified;
		}

		private void Resetlosecountall()
		{
			this.losecountallSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "drawcountall", DataFormat = DataFormat.TwosComplement)]
		public int drawcountall
		{
			get
			{
				return this._drawcountall ?? 0;
			}
			set
			{
				this._drawcountall = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool drawcountallSpecified
		{
			get
			{
				return this._drawcountall != null;
			}
			set
			{
				bool flag = value == (this._drawcountall == null);
				if (flag)
				{
					this._drawcountall = (value ? new int?(this.drawcountall) : null);
				}
			}
		}

		private bool ShouldSerializedrawcountall()
		{
			return this.drawcountallSpecified;
		}

		private void Resetdrawcountall()
		{
			this.drawcountallSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "joincounttodayint", DataFormat = DataFormat.TwosComplement)]
		public int joincounttodayint
		{
			get
			{
				return this._joincounttodayint ?? 0;
			}
			set
			{
				this._joincounttodayint = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincounttodayintSpecified
		{
			get
			{
				return this._joincounttodayint != null;
			}
			set
			{
				bool flag = value == (this._joincounttodayint == null);
				if (flag)
				{
					this._joincounttodayint = (value ? new int?(this.joincounttodayint) : null);
				}
			}
		}

		private bool ShouldSerializejoincounttodayint()
		{
			return this.joincounttodayintSpecified;
		}

		private void Resetjoincounttodayint()
		{
			this.joincounttodayintSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "wincountthisweek", DataFormat = DataFormat.TwosComplement)]
		public int wincountthisweek
		{
			get
			{
				return this._wincountthisweek ?? 0;
			}
			set
			{
				this._wincountthisweek = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wincountthisweekSpecified
		{
			get
			{
				return this._wincountthisweek != null;
			}
			set
			{
				bool flag = value == (this._wincountthisweek == null);
				if (flag)
				{
					this._wincountthisweek = (value ? new int?(this.wincountthisweek) : null);
				}
			}
		}

		private bool ShouldSerializewincountthisweek()
		{
			return this.wincountthisweekSpecified;
		}

		private void Resetwincountthisweek()
		{
			this.wincountthisweekSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "lastdayupt", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayupt
		{
			get
			{
				return this._lastdayupt ?? 0U;
			}
			set
			{
				this._lastdayupt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayuptSpecified
		{
			get
			{
				return this._lastdayupt != null;
			}
			set
			{
				bool flag = value == (this._lastdayupt == null);
				if (flag)
				{
					this._lastdayupt = (value ? new uint?(this.lastdayupt) : null);
				}
			}
		}

		private bool ShouldSerializelastdayupt()
		{
			return this.lastdayuptSpecified;
		}

		private void Resetlastdayupt()
		{
			this.lastdayuptSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "lastweekupt", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekupt
		{
			get
			{
				return this._lastweekupt ?? 0U;
			}
			set
			{
				this._lastweekupt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekuptSpecified
		{
			get
			{
				return this._lastweekupt != null;
			}
			set
			{
				bool flag = value == (this._lastweekupt == null);
				if (flag)
				{
					this._lastweekupt = (value ? new uint?(this.lastweekupt) : null);
				}
			}
		}

		private bool ShouldSerializelastweekupt()
		{
			return this.lastweekuptSpecified;
		}

		private void Resetlastweekupt()
		{
			this.lastweekuptSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "weekrewardhaveget", DataFormat = DataFormat.Default)]
		public bool weekrewardhaveget
		{
			get
			{
				return this._weekrewardhaveget ?? false;
			}
			set
			{
				this._weekrewardhaveget = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekrewardhavegetSpecified
		{
			get
			{
				return this._weekrewardhaveget != null;
			}
			set
			{
				bool flag = value == (this._weekrewardhaveget == null);
				if (flag)
				{
					this._weekrewardhaveget = (value ? new bool?(this.weekrewardhaveget) : null);
				}
			}
		}

		private bool ShouldSerializeweekrewardhaveget()
		{
			return this.weekrewardhavegetSpecified;
		}

		private void Resetweekrewardhaveget()
		{
			this.weekrewardhavegetSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "todayplaytime", DataFormat = DataFormat.TwosComplement)]
		public uint todayplaytime
		{
			get
			{
				return this._todayplaytime ?? 0U;
			}
			set
			{
				this._todayplaytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todayplaytimeSpecified
		{
			get
			{
				return this._todayplaytime != null;
			}
			set
			{
				bool flag = value == (this._todayplaytime == null);
				if (flag)
				{
					this._todayplaytime = (value ? new uint?(this.todayplaytime) : null);
				}
			}
		}

		private bool ShouldSerializetodayplaytime()
		{
			return this.todayplaytimeSpecified;
		}

		private void Resettodayplaytime()
		{
			this.todayplaytimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "todayplaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint todayplaytimes
		{
			get
			{
				return this._todayplaytimes ?? 0U;
			}
			set
			{
				this._todayplaytimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todayplaytimesSpecified
		{
			get
			{
				return this._todayplaytimes != null;
			}
			set
			{
				bool flag = value == (this._todayplaytimes == null);
				if (flag)
				{
					this._todayplaytimes = (value ? new uint?(this.todayplaytimes) : null);
				}
			}
		}

		private bool ShouldSerializetodayplaytimes()
		{
			return this.todayplaytimesSpecified;
		}

		private void Resettodayplaytimes()
		{
			this.todayplaytimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PvpOneRec> _pvprecs = new List<PvpOneRec>();

		private int? _wincountall;

		private int? _losecountall;

		private int? _drawcountall;

		private int? _joincounttodayint;

		private int? _wincountthisweek;

		private uint? _lastdayupt;

		private uint? _lastweekupt;

		private bool? _weekrewardhaveget;

		private uint? _todayplaytime;

		private uint? _todayplaytimes;

		private IExtension extensionObject;
	}
}
