using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000615 RID: 1557
	[ProtoContract(Name = "PvpData")]
	[Serializable]
	public class PvpData : IExtensible
	{
		// Token: 0x17001D95 RID: 7573
		// (get) Token: 0x06005E4B RID: 24139 RVA: 0x000B3C14 File Offset: 0x000B1E14
		[ProtoMember(1, Name = "pvprecs", DataFormat = DataFormat.Default)]
		public List<PvpOneRec> pvprecs
		{
			get
			{
				return this._pvprecs;
			}
		}

		// Token: 0x17001D96 RID: 7574
		// (get) Token: 0x06005E4C RID: 24140 RVA: 0x000B3C2C File Offset: 0x000B1E2C
		// (set) Token: 0x06005E4D RID: 24141 RVA: 0x000B3C58 File Offset: 0x000B1E58
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

		// Token: 0x17001D97 RID: 7575
		// (get) Token: 0x06005E4E RID: 24142 RVA: 0x000B3C68 File Offset: 0x000B1E68
		// (set) Token: 0x06005E4F RID: 24143 RVA: 0x000B3C88 File Offset: 0x000B1E88
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

		// Token: 0x06005E50 RID: 24144 RVA: 0x000B3CCC File Offset: 0x000B1ECC
		private bool ShouldSerializewincountall()
		{
			return this.wincountallSpecified;
		}

		// Token: 0x06005E51 RID: 24145 RVA: 0x000B3CE4 File Offset: 0x000B1EE4
		private void Resetwincountall()
		{
			this.wincountallSpecified = false;
		}

		// Token: 0x17001D98 RID: 7576
		// (get) Token: 0x06005E52 RID: 24146 RVA: 0x000B3CF0 File Offset: 0x000B1EF0
		// (set) Token: 0x06005E53 RID: 24147 RVA: 0x000B3D1C File Offset: 0x000B1F1C
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

		// Token: 0x17001D99 RID: 7577
		// (get) Token: 0x06005E54 RID: 24148 RVA: 0x000B3D2C File Offset: 0x000B1F2C
		// (set) Token: 0x06005E55 RID: 24149 RVA: 0x000B3D4C File Offset: 0x000B1F4C
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

		// Token: 0x06005E56 RID: 24150 RVA: 0x000B3D90 File Offset: 0x000B1F90
		private bool ShouldSerializelosecountall()
		{
			return this.losecountallSpecified;
		}

		// Token: 0x06005E57 RID: 24151 RVA: 0x000B3DA8 File Offset: 0x000B1FA8
		private void Resetlosecountall()
		{
			this.losecountallSpecified = false;
		}

		// Token: 0x17001D9A RID: 7578
		// (get) Token: 0x06005E58 RID: 24152 RVA: 0x000B3DB4 File Offset: 0x000B1FB4
		// (set) Token: 0x06005E59 RID: 24153 RVA: 0x000B3DE0 File Offset: 0x000B1FE0
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

		// Token: 0x17001D9B RID: 7579
		// (get) Token: 0x06005E5A RID: 24154 RVA: 0x000B3DF0 File Offset: 0x000B1FF0
		// (set) Token: 0x06005E5B RID: 24155 RVA: 0x000B3E10 File Offset: 0x000B2010
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

		// Token: 0x06005E5C RID: 24156 RVA: 0x000B3E54 File Offset: 0x000B2054
		private bool ShouldSerializedrawcountall()
		{
			return this.drawcountallSpecified;
		}

		// Token: 0x06005E5D RID: 24157 RVA: 0x000B3E6C File Offset: 0x000B206C
		private void Resetdrawcountall()
		{
			this.drawcountallSpecified = false;
		}

		// Token: 0x17001D9C RID: 7580
		// (get) Token: 0x06005E5E RID: 24158 RVA: 0x000B3E78 File Offset: 0x000B2078
		// (set) Token: 0x06005E5F RID: 24159 RVA: 0x000B3EA4 File Offset: 0x000B20A4
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

		// Token: 0x17001D9D RID: 7581
		// (get) Token: 0x06005E60 RID: 24160 RVA: 0x000B3EB4 File Offset: 0x000B20B4
		// (set) Token: 0x06005E61 RID: 24161 RVA: 0x000B3ED4 File Offset: 0x000B20D4
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

		// Token: 0x06005E62 RID: 24162 RVA: 0x000B3F18 File Offset: 0x000B2118
		private bool ShouldSerializejoincounttodayint()
		{
			return this.joincounttodayintSpecified;
		}

		// Token: 0x06005E63 RID: 24163 RVA: 0x000B3F30 File Offset: 0x000B2130
		private void Resetjoincounttodayint()
		{
			this.joincounttodayintSpecified = false;
		}

		// Token: 0x17001D9E RID: 7582
		// (get) Token: 0x06005E64 RID: 24164 RVA: 0x000B3F3C File Offset: 0x000B213C
		// (set) Token: 0x06005E65 RID: 24165 RVA: 0x000B3F68 File Offset: 0x000B2168
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

		// Token: 0x17001D9F RID: 7583
		// (get) Token: 0x06005E66 RID: 24166 RVA: 0x000B3F78 File Offset: 0x000B2178
		// (set) Token: 0x06005E67 RID: 24167 RVA: 0x000B3F98 File Offset: 0x000B2198
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

		// Token: 0x06005E68 RID: 24168 RVA: 0x000B3FDC File Offset: 0x000B21DC
		private bool ShouldSerializewincountthisweek()
		{
			return this.wincountthisweekSpecified;
		}

		// Token: 0x06005E69 RID: 24169 RVA: 0x000B3FF4 File Offset: 0x000B21F4
		private void Resetwincountthisweek()
		{
			this.wincountthisweekSpecified = false;
		}

		// Token: 0x17001DA0 RID: 7584
		// (get) Token: 0x06005E6A RID: 24170 RVA: 0x000B4000 File Offset: 0x000B2200
		// (set) Token: 0x06005E6B RID: 24171 RVA: 0x000B402C File Offset: 0x000B222C
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

		// Token: 0x17001DA1 RID: 7585
		// (get) Token: 0x06005E6C RID: 24172 RVA: 0x000B403C File Offset: 0x000B223C
		// (set) Token: 0x06005E6D RID: 24173 RVA: 0x000B405C File Offset: 0x000B225C
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

		// Token: 0x06005E6E RID: 24174 RVA: 0x000B40A0 File Offset: 0x000B22A0
		private bool ShouldSerializelastdayupt()
		{
			return this.lastdayuptSpecified;
		}

		// Token: 0x06005E6F RID: 24175 RVA: 0x000B40B8 File Offset: 0x000B22B8
		private void Resetlastdayupt()
		{
			this.lastdayuptSpecified = false;
		}

		// Token: 0x17001DA2 RID: 7586
		// (get) Token: 0x06005E70 RID: 24176 RVA: 0x000B40C4 File Offset: 0x000B22C4
		// (set) Token: 0x06005E71 RID: 24177 RVA: 0x000B40F0 File Offset: 0x000B22F0
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

		// Token: 0x17001DA3 RID: 7587
		// (get) Token: 0x06005E72 RID: 24178 RVA: 0x000B4100 File Offset: 0x000B2300
		// (set) Token: 0x06005E73 RID: 24179 RVA: 0x000B4120 File Offset: 0x000B2320
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

		// Token: 0x06005E74 RID: 24180 RVA: 0x000B4164 File Offset: 0x000B2364
		private bool ShouldSerializelastweekupt()
		{
			return this.lastweekuptSpecified;
		}

		// Token: 0x06005E75 RID: 24181 RVA: 0x000B417C File Offset: 0x000B237C
		private void Resetlastweekupt()
		{
			this.lastweekuptSpecified = false;
		}

		// Token: 0x17001DA4 RID: 7588
		// (get) Token: 0x06005E76 RID: 24182 RVA: 0x000B4188 File Offset: 0x000B2388
		// (set) Token: 0x06005E77 RID: 24183 RVA: 0x000B41B4 File Offset: 0x000B23B4
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

		// Token: 0x17001DA5 RID: 7589
		// (get) Token: 0x06005E78 RID: 24184 RVA: 0x000B41C4 File Offset: 0x000B23C4
		// (set) Token: 0x06005E79 RID: 24185 RVA: 0x000B41E4 File Offset: 0x000B23E4
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

		// Token: 0x06005E7A RID: 24186 RVA: 0x000B4228 File Offset: 0x000B2428
		private bool ShouldSerializeweekrewardhaveget()
		{
			return this.weekrewardhavegetSpecified;
		}

		// Token: 0x06005E7B RID: 24187 RVA: 0x000B4240 File Offset: 0x000B2440
		private void Resetweekrewardhaveget()
		{
			this.weekrewardhavegetSpecified = false;
		}

		// Token: 0x17001DA6 RID: 7590
		// (get) Token: 0x06005E7C RID: 24188 RVA: 0x000B424C File Offset: 0x000B244C
		// (set) Token: 0x06005E7D RID: 24189 RVA: 0x000B4278 File Offset: 0x000B2478
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

		// Token: 0x17001DA7 RID: 7591
		// (get) Token: 0x06005E7E RID: 24190 RVA: 0x000B4288 File Offset: 0x000B2488
		// (set) Token: 0x06005E7F RID: 24191 RVA: 0x000B42A8 File Offset: 0x000B24A8
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

		// Token: 0x06005E80 RID: 24192 RVA: 0x000B42EC File Offset: 0x000B24EC
		private bool ShouldSerializetodayplaytime()
		{
			return this.todayplaytimeSpecified;
		}

		// Token: 0x06005E81 RID: 24193 RVA: 0x000B4304 File Offset: 0x000B2504
		private void Resettodayplaytime()
		{
			this.todayplaytimeSpecified = false;
		}

		// Token: 0x17001DA8 RID: 7592
		// (get) Token: 0x06005E82 RID: 24194 RVA: 0x000B4310 File Offset: 0x000B2510
		// (set) Token: 0x06005E83 RID: 24195 RVA: 0x000B433C File Offset: 0x000B253C
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

		// Token: 0x17001DA9 RID: 7593
		// (get) Token: 0x06005E84 RID: 24196 RVA: 0x000B434C File Offset: 0x000B254C
		// (set) Token: 0x06005E85 RID: 24197 RVA: 0x000B436C File Offset: 0x000B256C
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

		// Token: 0x06005E86 RID: 24198 RVA: 0x000B43B0 File Offset: 0x000B25B0
		private bool ShouldSerializetodayplaytimes()
		{
			return this.todayplaytimesSpecified;
		}

		// Token: 0x06005E87 RID: 24199 RVA: 0x000B43C8 File Offset: 0x000B25C8
		private void Resettodayplaytimes()
		{
			this.todayplaytimesSpecified = false;
		}

		// Token: 0x06005E88 RID: 24200 RVA: 0x000B43D4 File Offset: 0x000B25D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016E6 RID: 5862
		private readonly List<PvpOneRec> _pvprecs = new List<PvpOneRec>();

		// Token: 0x040016E7 RID: 5863
		private int? _wincountall;

		// Token: 0x040016E8 RID: 5864
		private int? _losecountall;

		// Token: 0x040016E9 RID: 5865
		private int? _drawcountall;

		// Token: 0x040016EA RID: 5866
		private int? _joincounttodayint;

		// Token: 0x040016EB RID: 5867
		private int? _wincountthisweek;

		// Token: 0x040016EC RID: 5868
		private uint? _lastdayupt;

		// Token: 0x040016ED RID: 5869
		private uint? _lastweekupt;

		// Token: 0x040016EE RID: 5870
		private bool? _weekrewardhaveget;

		// Token: 0x040016EF RID: 5871
		private uint? _todayplaytime;

		// Token: 0x040016F0 RID: 5872
		private uint? _todayplaytimes;

		// Token: 0x040016F1 RID: 5873
		private IExtension extensionObject;
	}
}
