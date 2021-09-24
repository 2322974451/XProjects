using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReportDataRecord")]
	[Serializable]
	public class ReportDataRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "weeklogindays", DataFormat = DataFormat.TwosComplement)]
		public uint weeklogindays
		{
			get
			{
				return this._weeklogindays ?? 0U;
			}
			set
			{
				this._weeklogindays = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklogindaysSpecified
		{
			get
			{
				return this._weeklogindays != null;
			}
			set
			{
				bool flag = value == (this._weeklogindays == null);
				if (flag)
				{
					this._weeklogindays = (value ? new uint?(this.weeklogindays) : null);
				}
			}
		}

		private bool ShouldSerializeweeklogindays()
		{
			return this.weeklogindaysSpecified;
		}

		private void Resetweeklogindays()
		{
			this.weeklogindaysSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "within20minsdays", DataFormat = DataFormat.TwosComplement)]
		public uint within20minsdays
		{
			get
			{
				return this._within20minsdays ?? 0U;
			}
			set
			{
				this._within20minsdays = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool within20minsdaysSpecified
		{
			get
			{
				return this._within20minsdays != null;
			}
			set
			{
				bool flag = value == (this._within20minsdays == null);
				if (flag)
				{
					this._within20minsdays = (value ? new uint?(this.within20minsdays) : null);
				}
			}
		}

		private bool ShouldSerializewithin20minsdays()
		{
			return this.within20minsdaysSpecified;
		}

		private void Resetwithin20minsdays()
		{
			this.within20minsdaysSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastdayonlinetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayonlinetime
		{
			get
			{
				return this._lastdayonlinetime ?? 0U;
			}
			set
			{
				this._lastdayonlinetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayonlinetimeSpecified
		{
			get
			{
				return this._lastdayonlinetime != null;
			}
			set
			{
				bool flag = value == (this._lastdayonlinetime == null);
				if (flag)
				{
					this._lastdayonlinetime = (value ? new uint?(this.lastdayonlinetime) : null);
				}
			}
		}

		private bool ShouldSerializelastdayonlinetime()
		{
			return this.lastdayonlinetimeSpecified;
		}

		private void Resetlastdayonlinetime()
		{
			this.lastdayonlinetimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lastdayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayupdate
		{
			get
			{
				return this._lastdayupdate ?? 0U;
			}
			set
			{
				this._lastdayupdate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayupdateSpecified
		{
			get
			{
				return this._lastdayupdate != null;
			}
			set
			{
				bool flag = value == (this._lastdayupdate == null);
				if (flag)
				{
					this._lastdayupdate = (value ? new uint?(this.lastdayupdate) : null);
				}
			}
		}

		private bool ShouldSerializelastdayupdate()
		{
			return this.lastdayupdateSpecified;
		}

		private void Resetlastdayupdate()
		{
			this.lastdayupdateSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastweekupdate", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekupdate
		{
			get
			{
				return this._lastweekupdate ?? 0U;
			}
			set
			{
				this._lastweekupdate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekupdateSpecified
		{
			get
			{
				return this._lastweekupdate != null;
			}
			set
			{
				bool flag = value == (this._lastweekupdate == null);
				if (flag)
				{
					this._lastweekupdate = (value ? new uint?(this.lastweekupdate) : null);
				}
			}
		}

		private bool ShouldSerializelastweekupdate()
		{
			return this.lastweekupdateSpecified;
		}

		private void Resetlastweekupdate()
		{
			this.lastweekupdateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "weeknestfasttime", DataFormat = DataFormat.TwosComplement)]
		public uint weeknestfasttime
		{
			get
			{
				return this._weeknestfasttime ?? 0U;
			}
			set
			{
				this._weeknestfasttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestfasttimeSpecified
		{
			get
			{
				return this._weeknestfasttime != null;
			}
			set
			{
				bool flag = value == (this._weeknestfasttime == null);
				if (flag)
				{
					this._weeknestfasttime = (value ? new uint?(this.weeknestfasttime) : null);
				}
			}
		}

		private bool ShouldSerializeweeknestfasttime()
		{
			return this.weeknestfasttimeSpecified;
		}

		private void Resetweeknestfasttime()
		{
			this.weeknestfasttimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "weekactivedays", DataFormat = DataFormat.TwosComplement)]
		public uint weekactivedays
		{
			get
			{
				return this._weekactivedays ?? 0U;
			}
			set
			{
				this._weekactivedays = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekactivedaysSpecified
		{
			get
			{
				return this._weekactivedays != null;
			}
			set
			{
				bool flag = value == (this._weekactivedays == null);
				if (flag)
				{
					this._weekactivedays = (value ? new uint?(this.weekactivedays) : null);
				}
			}
		}

		private bool ShouldSerializeweekactivedays()
		{
			return this.weekactivedaysSpecified;
		}

		private void Resetweekactivedays()
		{
			this.weekactivedaysSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "weeknestdaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint weeknestdaytimes
		{
			get
			{
				return this._weeknestdaytimes ?? 0U;
			}
			set
			{
				this._weeknestdaytimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestdaytimesSpecified
		{
			get
			{
				return this._weeknestdaytimes != null;
			}
			set
			{
				bool flag = value == (this._weeknestdaytimes == null);
				if (flag)
				{
					this._weeknestdaytimes = (value ? new uint?(this.weeknestdaytimes) : null);
				}
			}
		}

		private bool ShouldSerializeweeknestdaytimes()
		{
			return this.weeknestdaytimesSpecified;
		}

		private void Resetweeknestdaytimes()
		{
			this.weeknestdaytimesSpecified = false;
		}

		[ProtoMember(9, Name = "wxdata", DataFormat = DataFormat.Default)]
		public List<WeekReportData> wxdata
		{
			get
			{
				return this._wxdata;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "lastrecommondtime", DataFormat = DataFormat.TwosComplement)]
		public uint lastrecommondtime
		{
			get
			{
				return this._lastrecommondtime ?? 0U;
			}
			set
			{
				this._lastrecommondtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastrecommondtimeSpecified
		{
			get
			{
				return this._lastrecommondtime != null;
			}
			set
			{
				bool flag = value == (this._lastrecommondtime == null);
				if (flag)
				{
					this._lastrecommondtime = (value ? new uint?(this.lastrecommondtime) : null);
				}
			}
		}

		private bool ShouldSerializelastrecommondtime()
		{
			return this.lastrecommondtimeSpecified;
		}

		private void Resetlastrecommondtime()
		{
			this.lastrecommondtimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "abyssdaycount", DataFormat = DataFormat.TwosComplement)]
		public uint abyssdaycount
		{
			get
			{
				return this._abyssdaycount ?? 0U;
			}
			set
			{
				this._abyssdaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abyssdaycountSpecified
		{
			get
			{
				return this._abyssdaycount != null;
			}
			set
			{
				bool flag = value == (this._abyssdaycount == null);
				if (flag)
				{
					this._abyssdaycount = (value ? new uint?(this.abyssdaycount) : null);
				}
			}
		}

		private bool ShouldSerializeabyssdaycount()
		{
			return this.abyssdaycountSpecified;
		}

		private void Resetabyssdaycount()
		{
			this.abyssdaycountSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "superrisktodaycount", DataFormat = DataFormat.TwosComplement)]
		public uint superrisktodaycount
		{
			get
			{
				return this._superrisktodaycount ?? 0U;
			}
			set
			{
				this._superrisktodaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool superrisktodaycountSpecified
		{
			get
			{
				return this._superrisktodaycount != null;
			}
			set
			{
				bool flag = value == (this._superrisktodaycount == null);
				if (flag)
				{
					this._superrisktodaycount = (value ? new uint?(this.superrisktodaycount) : null);
				}
			}
		}

		private bool ShouldSerializesuperrisktodaycount()
		{
			return this.superrisktodaycountSpecified;
		}

		private void Resetsuperrisktodaycount()
		{
			this.superrisktodaycountSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "buyibshopcount", DataFormat = DataFormat.TwosComplement)]
		public uint buyibshopcount
		{
			get
			{
				return this._buyibshopcount ?? 0U;
			}
			set
			{
				this._buyibshopcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buyibshopcountSpecified
		{
			get
			{
				return this._buyibshopcount != null;
			}
			set
			{
				bool flag = value == (this._buyibshopcount == null);
				if (flag)
				{
					this._buyibshopcount = (value ? new uint?(this.buyibshopcount) : null);
				}
			}
		}

		private bool ShouldSerializebuyibshopcount()
		{
			return this.buyibshopcountSpecified;
		}

		private void Resetbuyibshopcount()
		{
			this.buyibshopcountSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "pokercount", DataFormat = DataFormat.TwosComplement)]
		public uint pokercount
		{
			get
			{
				return this._pokercount ?? 0U;
			}
			set
			{
				this._pokercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pokercountSpecified
		{
			get
			{
				return this._pokercount != null;
			}
			set
			{
				bool flag = value == (this._pokercount == null);
				if (flag)
				{
					this._pokercount = (value ? new uint?(this.pokercount) : null);
				}
			}
		}

		private bool ShouldSerializepokercount()
		{
			return this.pokercountSpecified;
		}

		private void Resetpokercount()
		{
			this.pokercountSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "lastpokertime", DataFormat = DataFormat.TwosComplement)]
		public uint lastpokertime
		{
			get
			{
				return this._lastpokertime ?? 0U;
			}
			set
			{
				this._lastpokertime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastpokertimeSpecified
		{
			get
			{
				return this._lastpokertime != null;
			}
			set
			{
				bool flag = value == (this._lastpokertime == null);
				if (flag)
				{
					this._lastpokertime = (value ? new uint?(this.lastpokertime) : null);
				}
			}
		}

		private bool ShouldSerializelastpokertime()
		{
			return this.lastpokertimeSpecified;
		}

		private void Resetlastpokertime()
		{
			this.lastpokertimeSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "horsemacthcount", DataFormat = DataFormat.TwosComplement)]
		public uint horsemacthcount
		{
			get
			{
				return this._horsemacthcount ?? 0U;
			}
			set
			{
				this._horsemacthcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool horsemacthcountSpecified
		{
			get
			{
				return this._horsemacthcount != null;
			}
			set
			{
				bool flag = value == (this._horsemacthcount == null);
				if (flag)
				{
					this._horsemacthcount = (value ? new uint?(this.horsemacthcount) : null);
				}
			}
		}

		private bool ShouldSerializehorsemacthcount()
		{
			return this.horsemacthcountSpecified;
		}

		private void Resethorsemacthcount()
		{
			this.horsemacthcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _weeklogindays;

		private uint? _within20minsdays;

		private uint? _lastdayonlinetime;

		private uint? _lastdayupdate;

		private uint? _lastweekupdate;

		private uint? _weeknestfasttime;

		private uint? _weekactivedays;

		private uint? _weeknestdaytimes;

		private readonly List<WeekReportData> _wxdata = new List<WeekReportData>();

		private uint? _lastrecommondtime;

		private uint? _abyssdaycount;

		private uint? _superrisktodaycount;

		private uint? _buyibshopcount;

		private uint? _pokercount;

		private uint? _lastpokertime;

		private uint? _horsemacthcount;

		private IExtension extensionObject;
	}
}
