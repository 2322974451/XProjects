using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpBaseData")]
	[Serializable]
	public class PvpBaseData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "wincountall", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "losecountall", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "drawcountall", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "wincountthisweek", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "wincountweekmax", DataFormat = DataFormat.TwosComplement)]
		public int wincountweekmax
		{
			get
			{
				return this._wincountweekmax ?? 0;
			}
			set
			{
				this._wincountweekmax = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wincountweekmaxSpecified
		{
			get
			{
				return this._wincountweekmax != null;
			}
			set
			{
				bool flag = value == (this._wincountweekmax == null);
				if (flag)
				{
					this._wincountweekmax = (value ? new int?(this.wincountweekmax) : null);
				}
			}
		}

		private bool ShouldSerializewincountweekmax()
		{
			return this.wincountweekmaxSpecified;
		}

		private void Resetwincountweekmax()
		{
			this.wincountweekmaxSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "jointodayintime", DataFormat = DataFormat.TwosComplement)]
		public int jointodayintime
		{
			get
			{
				return this._jointodayintime ?? 0;
			}
			set
			{
				this._jointodayintime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jointodayintimeSpecified
		{
			get
			{
				return this._jointodayintime != null;
			}
			set
			{
				bool flag = value == (this._jointodayintime == null);
				if (flag)
				{
					this._jointodayintime = (value ? new int?(this.jointodayintime) : null);
				}
			}
		}

		private bool ShouldSerializejointodayintime()
		{
			return this.jointodayintimeSpecified;
		}

		private void Resetjointodayintime()
		{
			this.jointodayintimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "jointodayintimemax", DataFormat = DataFormat.TwosComplement)]
		public int jointodayintimemax
		{
			get
			{
				return this._jointodayintimemax ?? 0;
			}
			set
			{
				this._jointodayintimemax = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jointodayintimemaxSpecified
		{
			get
			{
				return this._jointodayintimemax != null;
			}
			set
			{
				bool flag = value == (this._jointodayintimemax == null);
				if (flag)
				{
					this._jointodayintimemax = (value ? new int?(this.jointodayintimemax) : null);
				}
			}
		}

		private bool ShouldSerializejointodayintimemax()
		{
			return this.jointodayintimemaxSpecified;
		}

		private void Resetjointodayintimemax()
		{
			this.jointodayintimemaxSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "matchingcount", DataFormat = DataFormat.TwosComplement)]
		public int matchingcount
		{
			get
			{
				return this._matchingcount ?? 0;
			}
			set
			{
				this._matchingcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool matchingcountSpecified
		{
			get
			{
				return this._matchingcount != null;
			}
			set
			{
				bool flag = value == (this._matchingcount == null);
				if (flag)
				{
					this._matchingcount = (value ? new int?(this.matchingcount) : null);
				}
			}
		}

		private bool ShouldSerializematchingcount()
		{
			return this.matchingcountSpecified;
		}

		private void Resetmatchingcount()
		{
			this.matchingcountSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "weekRewardHaveGet", DataFormat = DataFormat.Default)]
		public bool weekRewardHaveGet
		{
			get
			{
				return this._weekRewardHaveGet ?? false;
			}
			set
			{
				this._weekRewardHaveGet = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekRewardHaveGetSpecified
		{
			get
			{
				return this._weekRewardHaveGet != null;
			}
			set
			{
				bool flag = value == (this._weekRewardHaveGet == null);
				if (flag)
				{
					this._weekRewardHaveGet = (value ? new bool?(this.weekRewardHaveGet) : null);
				}
			}
		}

		private bool ShouldSerializeweekRewardHaveGet()
		{
			return this.weekRewardHaveGetSpecified;
		}

		private void ResetweekRewardHaveGet()
		{
			this.weekRewardHaveGetSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _wincountall;

		private int? _losecountall;

		private int? _drawcountall;

		private int? _wincountthisweek;

		private int? _wincountweekmax;

		private int? _jointodayintime;

		private int? _jointodayintimemax;

		private int? _matchingcount;

		private bool? _weekRewardHaveGet;

		private IExtension extensionObject;
	}
}
