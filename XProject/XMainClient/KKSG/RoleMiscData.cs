using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleMiscData")]
	[Serializable]
	public class RoleMiscData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dummy", DataFormat = DataFormat.TwosComplement)]
		public uint dummy
		{
			get
			{
				return this._dummy ?? 0U;
			}
			set
			{
				this._dummy = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dummySpecified
		{
			get
			{
				return this._dummy != null;
			}
			set
			{
				bool flag = value == (this._dummy == null);
				if (flag)
				{
					this._dummy = (value ? new uint?(this.dummy) : null);
				}
			}
		}

		private bool ShouldSerializedummy()
		{
			return this.dummySpecified;
		}

		private void Resetdummy()
		{
			this.dummySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lastpush", DataFormat = DataFormat.TwosComplement)]
		public uint lastpush
		{
			get
			{
				return this._lastpush ?? 0U;
			}
			set
			{
				this._lastpush = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastpushSpecified
		{
			get
			{
				return this._lastpush != null;
			}
			set
			{
				bool flag = value == (this._lastpush == null);
				if (flag)
				{
					this._lastpush = (value ? new uint?(this.lastpush) : null);
				}
			}
		}

		private bool ShouldSerializelastpush()
		{
			return this.lastpushSpecified;
		}

		private void Resetlastpush()
		{
			this.lastpushSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "pushflag", DataFormat = DataFormat.TwosComplement)]
		public uint pushflag
		{
			get
			{
				return this._pushflag ?? 0U;
			}
			set
			{
				this._pushflag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pushflagSpecified
		{
			get
			{
				return this._pushflag != null;
			}
			set
			{
				bool flag = value == (this._pushflag == null);
				if (flag)
				{
					this._pushflag = (value ? new uint?(this.pushflag) : null);
				}
			}
		}

		private bool ShouldSerializepushflag()
		{
			return this.pushflagSpecified;
		}

		private void Resetpushflag()
		{
			this.pushflagSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "laddertime", DataFormat = DataFormat.TwosComplement)]
		public uint laddertime
		{
			get
			{
				return this._laddertime ?? 0U;
			}
			set
			{
				this._laddertime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool laddertimeSpecified
		{
			get
			{
				return this._laddertime != null;
			}
			set
			{
				bool flag = value == (this._laddertime == null);
				if (flag)
				{
					this._laddertime = (value ? new uint?(this.laddertime) : null);
				}
			}
		}

		private bool ShouldSerializeladdertime()
		{
			return this.laddertimeSpecified;
		}

		private void Resetladdertime()
		{
			this.laddertimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "answersindex", DataFormat = DataFormat.TwosComplement)]
		public uint answersindex
		{
			get
			{
				return this._answersindex ?? 0U;
			}
			set
			{
				this._answersindex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool answersindexSpecified
		{
			get
			{
				return this._answersindex != null;
			}
			set
			{
				bool flag = value == (this._answersindex == null);
				if (flag)
				{
					this._answersindex = (value ? new uint?(this.answersindex) : null);
				}
			}
		}

		private bool ShouldSerializeanswersindex()
		{
			return this.answersindexSpecified;
		}

		private void Resetanswersindex()
		{
			this.answersindexSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "answersversion", DataFormat = DataFormat.TwosComplement)]
		public uint answersversion
		{
			get
			{
				return this._answersversion ?? 0U;
			}
			set
			{
				this._answersversion = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool answersversionSpecified
		{
			get
			{
				return this._answersversion != null;
			}
			set
			{
				bool flag = value == (this._answersversion == null);
				if (flag)
				{
					this._answersversion = (value ? new uint?(this.answersversion) : null);
				}
			}
		}

		private bool ShouldSerializeanswersversion()
		{
			return this.answersversionSpecified;
		}

		private void Resetanswersversion()
		{
			this.answersversionSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "hintflag", DataFormat = DataFormat.TwosComplement)]
		public uint hintflag
		{
			get
			{
				return this._hintflag ?? 0U;
			}
			set
			{
				this._hintflag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hintflagSpecified
		{
			get
			{
				return this._hintflag != null;
			}
			set
			{
				bool flag = value == (this._hintflag == null);
				if (flag)
				{
					this._hintflag = (value ? new uint?(this.hintflag) : null);
				}
			}
		}

		private bool ShouldSerializehintflag()
		{
			return this.hintflagSpecified;
		}

		private void Resethintflag()
		{
			this.hintflagSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "lastchangeprotime", DataFormat = DataFormat.TwosComplement)]
		public uint lastchangeprotime
		{
			get
			{
				return this._lastchangeprotime ?? 0U;
			}
			set
			{
				this._lastchangeprotime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastchangeprotimeSpecified
		{
			get
			{
				return this._lastchangeprotime != null;
			}
			set
			{
				bool flag = value == (this._lastchangeprotime == null);
				if (flag)
				{
					this._lastchangeprotime = (value ? new uint?(this.lastchangeprotime) : null);
				}
			}
		}

		private bool ShouldSerializelastchangeprotime()
		{
			return this.lastchangeprotimeSpecified;
		}

		private void Resetlastchangeprotime()
		{
			this.lastchangeprotimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "changeprocount", DataFormat = DataFormat.TwosComplement)]
		public uint changeprocount
		{
			get
			{
				return this._changeprocount ?? 0U;
			}
			set
			{
				this._changeprocount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool changeprocountSpecified
		{
			get
			{
				return this._changeprocount != null;
			}
			set
			{
				bool flag = value == (this._changeprocount == null);
				if (flag)
				{
					this._changeprocount = (value ? new uint?(this.changeprocount) : null);
				}
			}
		}

		private bool ShouldSerializechangeprocount()
		{
			return this.changeprocountSpecified;
		}

		private void Resetchangeprocount()
		{
			this.changeprocountSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "daily_lb_num", DataFormat = DataFormat.TwosComplement)]
		public uint daily_lb_num
		{
			get
			{
				return this._daily_lb_num ?? 0U;
			}
			set
			{
				this._daily_lb_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_lb_numSpecified
		{
			get
			{
				return this._daily_lb_num != null;
			}
			set
			{
				bool flag = value == (this._daily_lb_num == null);
				if (flag)
				{
					this._daily_lb_num = (value ? new uint?(this.daily_lb_num) : null);
				}
			}
		}

		private bool ShouldSerializedaily_lb_num()
		{
			return this.daily_lb_numSpecified;
		}

		private void Resetdaily_lb_num()
		{
			this.daily_lb_numSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "declaration", DataFormat = DataFormat.Default)]
		public string declaration
		{
			get
			{
				return this._declaration ?? "";
			}
			set
			{
				this._declaration = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool declarationSpecified
		{
			get
			{
				return this._declaration != null;
			}
			set
			{
				bool flag = value == (this._declaration == null);
				if (flag)
				{
					this._declaration = (value ? this.declaration : null);
				}
			}
		}

		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "qqvip_hint", DataFormat = DataFormat.Default)]
		public bool qqvip_hint
		{
			get
			{
				return this._qqvip_hint ?? false;
			}
			set
			{
				this._qqvip_hint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qqvip_hintSpecified
		{
			get
			{
				return this._qqvip_hint != null;
			}
			set
			{
				bool flag = value == (this._qqvip_hint == null);
				if (flag)
				{
					this._qqvip_hint = (value ? new bool?(this.qqvip_hint) : null);
				}
			}
		}

		private bool ShouldSerializeqqvip_hint()
		{
			return this.qqvip_hintSpecified;
		}

		private void Resetqqvip_hint()
		{
			this.qqvip_hintSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "qqvip_hint_read_time", DataFormat = DataFormat.TwosComplement)]
		public uint qqvip_hint_read_time
		{
			get
			{
				return this._qqvip_hint_read_time ?? 0U;
			}
			set
			{
				this._qqvip_hint_read_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qqvip_hint_read_timeSpecified
		{
			get
			{
				return this._qqvip_hint_read_time != null;
			}
			set
			{
				bool flag = value == (this._qqvip_hint_read_time == null);
				if (flag)
				{
					this._qqvip_hint_read_time = (value ? new uint?(this.qqvip_hint_read_time) : null);
				}
			}
		}

		private bool ShouldSerializeqqvip_hint_read_time()
		{
			return this.qqvip_hint_read_timeSpecified;
		}

		private void Resetqqvip_hint_read_time()
		{
			this.qqvip_hint_read_timeSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "egame_hint", DataFormat = DataFormat.Default)]
		public bool egame_hint
		{
			get
			{
				return this._egame_hint ?? false;
			}
			set
			{
				this._egame_hint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool egame_hintSpecified
		{
			get
			{
				return this._egame_hint != null;
			}
			set
			{
				bool flag = value == (this._egame_hint == null);
				if (flag)
				{
					this._egame_hint = (value ? new bool?(this.egame_hint) : null);
				}
			}
		}

		private bool ShouldSerializeegame_hint()
		{
			return this.egame_hintSpecified;
		}

		private void Resetegame_hint()
		{
			this.egame_hintSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "egame_hint_readtime", DataFormat = DataFormat.TwosComplement)]
		public uint egame_hint_readtime
		{
			get
			{
				return this._egame_hint_readtime ?? 0U;
			}
			set
			{
				this._egame_hint_readtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool egame_hint_readtimeSpecified
		{
			get
			{
				return this._egame_hint_readtime != null;
			}
			set
			{
				bool flag = value == (this._egame_hint_readtime == null);
				if (flag)
				{
					this._egame_hint_readtime = (value ? new uint?(this.egame_hint_readtime) : null);
				}
			}
		}

		private bool ShouldSerializeegame_hint_readtime()
		{
			return this.egame_hint_readtimeSpecified;
		}

		private void Resetegame_hint_readtime()
		{
			this.egame_hint_readtimeSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "xinyue_hint", DataFormat = DataFormat.Default)]
		public bool xinyue_hint
		{
			get
			{
				return this._xinyue_hint ?? false;
			}
			set
			{
				this._xinyue_hint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool xinyue_hintSpecified
		{
			get
			{
				return this._xinyue_hint != null;
			}
			set
			{
				bool flag = value == (this._xinyue_hint == null);
				if (flag)
				{
					this._xinyue_hint = (value ? new bool?(this.xinyue_hint) : null);
				}
			}
		}

		private bool ShouldSerializexinyue_hint()
		{
			return this.xinyue_hintSpecified;
		}

		private void Resetxinyue_hint()
		{
			this.xinyue_hintSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "xinyue_readtime", DataFormat = DataFormat.TwosComplement)]
		public uint xinyue_readtime
		{
			get
			{
				return this._xinyue_readtime ?? 0U;
			}
			set
			{
				this._xinyue_readtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool xinyue_readtimeSpecified
		{
			get
			{
				return this._xinyue_readtime != null;
			}
			set
			{
				bool flag = value == (this._xinyue_readtime == null);
				if (flag)
				{
					this._xinyue_readtime = (value ? new uint?(this.xinyue_readtime) : null);
				}
			}
		}

		private bool ShouldSerializexinyue_readtime()
		{
			return this.xinyue_readtimeSpecified;
		}

		private void Resetxinyue_readtime()
		{
			this.xinyue_readtimeSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "last_level", DataFormat = DataFormat.TwosComplement)]
		public uint last_level
		{
			get
			{
				return this._last_level ?? 0U;
			}
			set
			{
				this._last_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_levelSpecified
		{
			get
			{
				return this._last_level != null;
			}
			set
			{
				bool flag = value == (this._last_level == null);
				if (flag)
				{
					this._last_level = (value ? new uint?(this.last_level) : null);
				}
			}
		}

		private bool ShouldSerializelast_level()
		{
			return this.last_levelSpecified;
		}

		private void Resetlast_level()
		{
			this.last_levelSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "loginacttime", DataFormat = DataFormat.TwosComplement)]
		public uint loginacttime
		{
			get
			{
				return this._loginacttime ?? 0U;
			}
			set
			{
				this._loginacttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginacttimeSpecified
		{
			get
			{
				return this._loginacttime != null;
			}
			set
			{
				bool flag = value == (this._loginacttime == null);
				if (flag)
				{
					this._loginacttime = (value ? new uint?(this.loginacttime) : null);
				}
			}
		}

		private bool ShouldSerializeloginacttime()
		{
			return this.loginacttimeSpecified;
		}

		private void Resetloginacttime()
		{
			this.loginacttimeSpecified = false;
		}

		[ProtoMember(21, IsRequired = false, Name = "loginactstatus", DataFormat = DataFormat.Default)]
		public bool loginactstatus
		{
			get
			{
				return this._loginactstatus ?? false;
			}
			set
			{
				this._loginactstatus = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginactstatusSpecified
		{
			get
			{
				return this._loginactstatus != null;
			}
			set
			{
				bool flag = value == (this._loginactstatus == null);
				if (flag)
				{
					this._loginactstatus = (value ? new bool?(this.loginactstatus) : null);
				}
			}
		}

		private bool ShouldSerializeloginactstatus()
		{
			return this.loginactstatusSpecified;
		}

		private void Resetloginactstatus()
		{
			this.loginactstatusSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "daygiftitems", DataFormat = DataFormat.TwosComplement)]
		public uint daygiftitems
		{
			get
			{
				return this._daygiftitems ?? 0U;
			}
			set
			{
				this._daygiftitems = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daygiftitemsSpecified
		{
			get
			{
				return this._daygiftitems != null;
			}
			set
			{
				bool flag = value == (this._daygiftitems == null);
				if (flag)
				{
					this._daygiftitems = (value ? new uint?(this.daygiftitems) : null);
				}
			}
		}

		private bool ShouldSerializedaygiftitems()
		{
			return this.daygiftitemsSpecified;
		}

		private void Resetdaygiftitems()
		{
			this.daygiftitemsSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "hardestNestExpID", DataFormat = DataFormat.TwosComplement)]
		public uint hardestNestExpID
		{
			get
			{
				return this._hardestNestExpID ?? 0U;
			}
			set
			{
				this._hardestNestExpID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hardestNestExpIDSpecified
		{
			get
			{
				return this._hardestNestExpID != null;
			}
			set
			{
				bool flag = value == (this._hardestNestExpID == null);
				if (flag)
				{
					this._hardestNestExpID = (value ? new uint?(this.hardestNestExpID) : null);
				}
			}
		}

		private bool ShouldSerializehardestNestExpID()
		{
			return this.hardestNestExpIDSpecified;
		}

		private void ResethardestNestExpID()
		{
			this.hardestNestExpIDSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "startuptype", DataFormat = DataFormat.TwosComplement)]
		public StartUpType startuptype
		{
			get
			{
				return this._startuptype ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._startuptype = new StartUpType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startuptypeSpecified
		{
			get
			{
				return this._startuptype != null;
			}
			set
			{
				bool flag = value == (this._startuptype == null);
				if (flag)
				{
					this._startuptype = (value ? new StartUpType?(this.startuptype) : null);
				}
			}
		}

		private bool ShouldSerializestartuptype()
		{
			return this.startuptypeSpecified;
		}

		private void Resetstartuptype()
		{
			this.startuptypeSpecified = false;
		}

		[ProtoMember(25, IsRequired = false, Name = "startuptime", DataFormat = DataFormat.TwosComplement)]
		public uint startuptime
		{
			get
			{
				return this._startuptime ?? 0U;
			}
			set
			{
				this._startuptime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startuptimeSpecified
		{
			get
			{
				return this._startuptime != null;
			}
			set
			{
				bool flag = value == (this._startuptime == null);
				if (flag)
				{
					this._startuptime = (value ? new uint?(this.startuptime) : null);
				}
			}
		}

		private bool ShouldSerializestartuptime()
		{
			return this.startuptimeSpecified;
		}

		private void Resetstartuptime()
		{
			this.startuptimeSpecified = false;
		}

		[ProtoMember(26, IsRequired = false, Name = "weddingflow_count", DataFormat = DataFormat.TwosComplement)]
		public uint weddingflow_count
		{
			get
			{
				return this._weddingflow_count ?? 0U;
			}
			set
			{
				this._weddingflow_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingflow_countSpecified
		{
			get
			{
				return this._weddingflow_count != null;
			}
			set
			{
				bool flag = value == (this._weddingflow_count == null);
				if (flag)
				{
					this._weddingflow_count = (value ? new uint?(this.weddingflow_count) : null);
				}
			}
		}

		private bool ShouldSerializeweddingflow_count()
		{
			return this.weddingflow_countSpecified;
		}

		private void Resetweddingflow_count()
		{
			this.weddingflow_countSpecified = false;
		}

		[ProtoMember(27, IsRequired = false, Name = "weddingfireworks_count", DataFormat = DataFormat.TwosComplement)]
		public uint weddingfireworks_count
		{
			get
			{
				return this._weddingfireworks_count ?? 0U;
			}
			set
			{
				this._weddingfireworks_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingfireworks_countSpecified
		{
			get
			{
				return this._weddingfireworks_count != null;
			}
			set
			{
				bool flag = value == (this._weddingfireworks_count == null);
				if (flag)
				{
					this._weddingfireworks_count = (value ? new uint?(this.weddingfireworks_count) : null);
				}
			}
		}

		private bool ShouldSerializeweddingfireworks_count()
		{
			return this.weddingfireworks_countSpecified;
		}

		private void Resetweddingfireworks_count()
		{
			this.weddingfireworks_countSpecified = false;
		}

		[ProtoMember(28, IsRequired = false, Name = "weddingcandy_count", DataFormat = DataFormat.TwosComplement)]
		public uint weddingcandy_count
		{
			get
			{
				return this._weddingcandy_count ?? 0U;
			}
			set
			{
				this._weddingcandy_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingcandy_countSpecified
		{
			get
			{
				return this._weddingcandy_count != null;
			}
			set
			{
				bool flag = value == (this._weddingcandy_count == null);
				if (flag)
				{
					this._weddingcandy_count = (value ? new uint?(this.weddingcandy_count) : null);
				}
			}
		}

		private bool ShouldSerializeweddingcandy_count()
		{
			return this.weddingcandy_countSpecified;
		}

		private void Resetweddingcandy_count()
		{
			this.weddingcandy_countSpecified = false;
		}

		[ProtoMember(29, Name = "gmattrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> gmattrs
		{
			get
			{
				return this._gmattrs;
			}
		}

		[ProtoMember(30, IsRequired = false, Name = "surviverec", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SurviveRecord surviverec
		{
			get
			{
				return this._surviverec;
			}
			set
			{
				this._surviverec = value;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "turntable", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LuckyActivity turntable
		{
			get
			{
				return this._turntable;
			}
			set
			{
				this._turntable = value;
			}
		}

		[ProtoMember(32, IsRequired = false, Name = "freeflow_hinttime", DataFormat = DataFormat.TwosComplement)]
		public uint freeflow_hinttime
		{
			get
			{
				return this._freeflow_hinttime ?? 0U;
			}
			set
			{
				this._freeflow_hinttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeflow_hinttimeSpecified
		{
			get
			{
				return this._freeflow_hinttime != null;
			}
			set
			{
				bool flag = value == (this._freeflow_hinttime == null);
				if (flag)
				{
					this._freeflow_hinttime = (value ? new uint?(this.freeflow_hinttime) : null);
				}
			}
		}

		private bool ShouldSerializefreeflow_hinttime()
		{
			return this.freeflow_hinttimeSpecified;
		}

		private void Resetfreeflow_hinttime()
		{
			this.freeflow_hinttimeSpecified = false;
		}

		[ProtoMember(33, IsRequired = false, Name = "kingbackrewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint kingbackrewardcount
		{
			get
			{
				return this._kingbackrewardcount ?? 0U;
			}
			set
			{
				this._kingbackrewardcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kingbackrewardcountSpecified
		{
			get
			{
				return this._kingbackrewardcount != null;
			}
			set
			{
				bool flag = value == (this._kingbackrewardcount == null);
				if (flag)
				{
					this._kingbackrewardcount = (value ? new uint?(this.kingbackrewardcount) : null);
				}
			}
		}

		private bool ShouldSerializekingbackrewardcount()
		{
			return this.kingbackrewardcountSpecified;
		}

		private void Resetkingbackrewardcount()
		{
			this.kingbackrewardcountSpecified = false;
		}

		[ProtoMember(34, IsRequired = false, Name = "chare_back_rewardlevel", DataFormat = DataFormat.TwosComplement)]
		public uint chare_back_rewardlevel
		{
			get
			{
				return this._chare_back_rewardlevel ?? 0U;
			}
			set
			{
				this._chare_back_rewardlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chare_back_rewardlevelSpecified
		{
			get
			{
				return this._chare_back_rewardlevel != null;
			}
			set
			{
				bool flag = value == (this._chare_back_rewardlevel == null);
				if (flag)
				{
					this._chare_back_rewardlevel = (value ? new uint?(this.chare_back_rewardlevel) : null);
				}
			}
		}

		private bool ShouldSerializechare_back_rewardlevel()
		{
			return this.chare_back_rewardlevelSpecified;
		}

		private void Resetchare_back_rewardlevel()
		{
			this.chare_back_rewardlevelSpecified = false;
		}

		[ProtoMember(35, IsRequired = false, Name = "charge_back_total", DataFormat = DataFormat.TwosComplement)]
		public uint charge_back_total
		{
			get
			{
				return this._charge_back_total ?? 0U;
			}
			set
			{
				this._charge_back_total = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool charge_back_totalSpecified
		{
			get
			{
				return this._charge_back_total != null;
			}
			set
			{
				bool flag = value == (this._charge_back_total == null);
				if (flag)
				{
					this._charge_back_total = (value ? new uint?(this.charge_back_total) : null);
				}
			}
		}

		private bool ShouldSerializecharge_back_total()
		{
			return this.charge_back_totalSpecified;
		}

		private void Resetcharge_back_total()
		{
			this.charge_back_totalSpecified = false;
		}

		[ProtoMember(36, IsRequired = false, Name = "multireward", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SRoleMultiReward multireward
		{
			get
			{
				return this._multireward;
			}
			set
			{
				this._multireward = value;
			}
		}

		[ProtoMember(37, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
		public uint version
		{
			get
			{
				return this._version ?? 0U;
			}
			set
			{
				this._version = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? new uint?(this.version) : null);
				}
			}
		}

		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		[ProtoMember(38, IsRequired = false, Name = "take_package_reward", DataFormat = DataFormat.Default)]
		public bool take_package_reward
		{
			get
			{
				return this._take_package_reward ?? false;
			}
			set
			{
				this._take_package_reward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool take_package_rewardSpecified
		{
			get
			{
				return this._take_package_reward != null;
			}
			set
			{
				bool flag = value == (this._take_package_reward == null);
				if (flag)
				{
					this._take_package_reward = (value ? new bool?(this.take_package_reward) : null);
				}
			}
		}

		private bool ShouldSerializetake_package_reward()
		{
			return this.take_package_rewardSpecified;
		}

		private void Resettake_package_reward()
		{
			this.take_package_rewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _dummy;

		private uint? _lastpush;

		private uint? _pushflag;

		private uint? _laddertime;

		private uint? _answersindex;

		private uint? _answersversion;

		private uint? _hintflag;

		private uint? _lastchangeprotime;

		private uint? _changeprocount;

		private uint? _daily_lb_num;

		private uint? _updatetime;

		private string _declaration;

		private bool? _qqvip_hint;

		private uint? _qqvip_hint_read_time;

		private bool? _egame_hint;

		private uint? _egame_hint_readtime;

		private bool? _xinyue_hint;

		private uint? _xinyue_readtime;

		private uint? _last_level;

		private uint? _loginacttime;

		private bool? _loginactstatus;

		private uint? _daygiftitems;

		private uint? _hardestNestExpID;

		private StartUpType? _startuptype;

		private uint? _startuptime;

		private uint? _weddingflow_count;

		private uint? _weddingfireworks_count;

		private uint? _weddingcandy_count;

		private readonly List<AttributeInfo> _gmattrs = new List<AttributeInfo>();

		private SurviveRecord _surviverec = null;

		private LuckyActivity _turntable = null;

		private uint? _freeflow_hinttime;

		private uint? _kingbackrewardcount;

		private uint? _chare_back_rewardlevel;

		private uint? _charge_back_total;

		private SRoleMultiReward _multireward = null;

		private uint? _version;

		private bool? _take_package_reward;

		private IExtension extensionObject;
	}
}
