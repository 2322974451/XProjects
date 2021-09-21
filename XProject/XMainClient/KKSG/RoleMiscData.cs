using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065E RID: 1630
	[ProtoContract(Name = "RoleMiscData")]
	[Serializable]
	public class RoleMiscData : IExtensible
	{
		// Token: 0x1700202D RID: 8237
		// (get) Token: 0x060065F5 RID: 26101 RVA: 0x000C2B00 File Offset: 0x000C0D00
		// (set) Token: 0x060065F6 RID: 26102 RVA: 0x000C2B2C File Offset: 0x000C0D2C
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

		// Token: 0x1700202E RID: 8238
		// (get) Token: 0x060065F7 RID: 26103 RVA: 0x000C2B3C File Offset: 0x000C0D3C
		// (set) Token: 0x060065F8 RID: 26104 RVA: 0x000C2B5C File Offset: 0x000C0D5C
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

		// Token: 0x060065F9 RID: 26105 RVA: 0x000C2BA0 File Offset: 0x000C0DA0
		private bool ShouldSerializedummy()
		{
			return this.dummySpecified;
		}

		// Token: 0x060065FA RID: 26106 RVA: 0x000C2BB8 File Offset: 0x000C0DB8
		private void Resetdummy()
		{
			this.dummySpecified = false;
		}

		// Token: 0x1700202F RID: 8239
		// (get) Token: 0x060065FB RID: 26107 RVA: 0x000C2BC4 File Offset: 0x000C0DC4
		// (set) Token: 0x060065FC RID: 26108 RVA: 0x000C2BF0 File Offset: 0x000C0DF0
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

		// Token: 0x17002030 RID: 8240
		// (get) Token: 0x060065FD RID: 26109 RVA: 0x000C2C00 File Offset: 0x000C0E00
		// (set) Token: 0x060065FE RID: 26110 RVA: 0x000C2C20 File Offset: 0x000C0E20
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

		// Token: 0x060065FF RID: 26111 RVA: 0x000C2C64 File Offset: 0x000C0E64
		private bool ShouldSerializelastpush()
		{
			return this.lastpushSpecified;
		}

		// Token: 0x06006600 RID: 26112 RVA: 0x000C2C7C File Offset: 0x000C0E7C
		private void Resetlastpush()
		{
			this.lastpushSpecified = false;
		}

		// Token: 0x17002031 RID: 8241
		// (get) Token: 0x06006601 RID: 26113 RVA: 0x000C2C88 File Offset: 0x000C0E88
		// (set) Token: 0x06006602 RID: 26114 RVA: 0x000C2CB4 File Offset: 0x000C0EB4
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

		// Token: 0x17002032 RID: 8242
		// (get) Token: 0x06006603 RID: 26115 RVA: 0x000C2CC4 File Offset: 0x000C0EC4
		// (set) Token: 0x06006604 RID: 26116 RVA: 0x000C2CE4 File Offset: 0x000C0EE4
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

		// Token: 0x06006605 RID: 26117 RVA: 0x000C2D28 File Offset: 0x000C0F28
		private bool ShouldSerializepushflag()
		{
			return this.pushflagSpecified;
		}

		// Token: 0x06006606 RID: 26118 RVA: 0x000C2D40 File Offset: 0x000C0F40
		private void Resetpushflag()
		{
			this.pushflagSpecified = false;
		}

		// Token: 0x17002033 RID: 8243
		// (get) Token: 0x06006607 RID: 26119 RVA: 0x000C2D4C File Offset: 0x000C0F4C
		// (set) Token: 0x06006608 RID: 26120 RVA: 0x000C2D78 File Offset: 0x000C0F78
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

		// Token: 0x17002034 RID: 8244
		// (get) Token: 0x06006609 RID: 26121 RVA: 0x000C2D88 File Offset: 0x000C0F88
		// (set) Token: 0x0600660A RID: 26122 RVA: 0x000C2DA8 File Offset: 0x000C0FA8
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

		// Token: 0x0600660B RID: 26123 RVA: 0x000C2DEC File Offset: 0x000C0FEC
		private bool ShouldSerializeladdertime()
		{
			return this.laddertimeSpecified;
		}

		// Token: 0x0600660C RID: 26124 RVA: 0x000C2E04 File Offset: 0x000C1004
		private void Resetladdertime()
		{
			this.laddertimeSpecified = false;
		}

		// Token: 0x17002035 RID: 8245
		// (get) Token: 0x0600660D RID: 26125 RVA: 0x000C2E10 File Offset: 0x000C1010
		// (set) Token: 0x0600660E RID: 26126 RVA: 0x000C2E3C File Offset: 0x000C103C
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

		// Token: 0x17002036 RID: 8246
		// (get) Token: 0x0600660F RID: 26127 RVA: 0x000C2E4C File Offset: 0x000C104C
		// (set) Token: 0x06006610 RID: 26128 RVA: 0x000C2E6C File Offset: 0x000C106C
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

		// Token: 0x06006611 RID: 26129 RVA: 0x000C2EB0 File Offset: 0x000C10B0
		private bool ShouldSerializeanswersindex()
		{
			return this.answersindexSpecified;
		}

		// Token: 0x06006612 RID: 26130 RVA: 0x000C2EC8 File Offset: 0x000C10C8
		private void Resetanswersindex()
		{
			this.answersindexSpecified = false;
		}

		// Token: 0x17002037 RID: 8247
		// (get) Token: 0x06006613 RID: 26131 RVA: 0x000C2ED4 File Offset: 0x000C10D4
		// (set) Token: 0x06006614 RID: 26132 RVA: 0x000C2F00 File Offset: 0x000C1100
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

		// Token: 0x17002038 RID: 8248
		// (get) Token: 0x06006615 RID: 26133 RVA: 0x000C2F10 File Offset: 0x000C1110
		// (set) Token: 0x06006616 RID: 26134 RVA: 0x000C2F30 File Offset: 0x000C1130
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

		// Token: 0x06006617 RID: 26135 RVA: 0x000C2F74 File Offset: 0x000C1174
		private bool ShouldSerializeanswersversion()
		{
			return this.answersversionSpecified;
		}

		// Token: 0x06006618 RID: 26136 RVA: 0x000C2F8C File Offset: 0x000C118C
		private void Resetanswersversion()
		{
			this.answersversionSpecified = false;
		}

		// Token: 0x17002039 RID: 8249
		// (get) Token: 0x06006619 RID: 26137 RVA: 0x000C2F98 File Offset: 0x000C1198
		// (set) Token: 0x0600661A RID: 26138 RVA: 0x000C2FC4 File Offset: 0x000C11C4
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

		// Token: 0x1700203A RID: 8250
		// (get) Token: 0x0600661B RID: 26139 RVA: 0x000C2FD4 File Offset: 0x000C11D4
		// (set) Token: 0x0600661C RID: 26140 RVA: 0x000C2FF4 File Offset: 0x000C11F4
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

		// Token: 0x0600661D RID: 26141 RVA: 0x000C3038 File Offset: 0x000C1238
		private bool ShouldSerializehintflag()
		{
			return this.hintflagSpecified;
		}

		// Token: 0x0600661E RID: 26142 RVA: 0x000C3050 File Offset: 0x000C1250
		private void Resethintflag()
		{
			this.hintflagSpecified = false;
		}

		// Token: 0x1700203B RID: 8251
		// (get) Token: 0x0600661F RID: 26143 RVA: 0x000C305C File Offset: 0x000C125C
		// (set) Token: 0x06006620 RID: 26144 RVA: 0x000C3088 File Offset: 0x000C1288
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

		// Token: 0x1700203C RID: 8252
		// (get) Token: 0x06006621 RID: 26145 RVA: 0x000C3098 File Offset: 0x000C1298
		// (set) Token: 0x06006622 RID: 26146 RVA: 0x000C30B8 File Offset: 0x000C12B8
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

		// Token: 0x06006623 RID: 26147 RVA: 0x000C30FC File Offset: 0x000C12FC
		private bool ShouldSerializelastchangeprotime()
		{
			return this.lastchangeprotimeSpecified;
		}

		// Token: 0x06006624 RID: 26148 RVA: 0x000C3114 File Offset: 0x000C1314
		private void Resetlastchangeprotime()
		{
			this.lastchangeprotimeSpecified = false;
		}

		// Token: 0x1700203D RID: 8253
		// (get) Token: 0x06006625 RID: 26149 RVA: 0x000C3120 File Offset: 0x000C1320
		// (set) Token: 0x06006626 RID: 26150 RVA: 0x000C314C File Offset: 0x000C134C
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

		// Token: 0x1700203E RID: 8254
		// (get) Token: 0x06006627 RID: 26151 RVA: 0x000C315C File Offset: 0x000C135C
		// (set) Token: 0x06006628 RID: 26152 RVA: 0x000C317C File Offset: 0x000C137C
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

		// Token: 0x06006629 RID: 26153 RVA: 0x000C31C0 File Offset: 0x000C13C0
		private bool ShouldSerializechangeprocount()
		{
			return this.changeprocountSpecified;
		}

		// Token: 0x0600662A RID: 26154 RVA: 0x000C31D8 File Offset: 0x000C13D8
		private void Resetchangeprocount()
		{
			this.changeprocountSpecified = false;
		}

		// Token: 0x1700203F RID: 8255
		// (get) Token: 0x0600662B RID: 26155 RVA: 0x000C31E4 File Offset: 0x000C13E4
		// (set) Token: 0x0600662C RID: 26156 RVA: 0x000C3210 File Offset: 0x000C1410
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

		// Token: 0x17002040 RID: 8256
		// (get) Token: 0x0600662D RID: 26157 RVA: 0x000C3220 File Offset: 0x000C1420
		// (set) Token: 0x0600662E RID: 26158 RVA: 0x000C3240 File Offset: 0x000C1440
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

		// Token: 0x0600662F RID: 26159 RVA: 0x000C3284 File Offset: 0x000C1484
		private bool ShouldSerializedaily_lb_num()
		{
			return this.daily_lb_numSpecified;
		}

		// Token: 0x06006630 RID: 26160 RVA: 0x000C329C File Offset: 0x000C149C
		private void Resetdaily_lb_num()
		{
			this.daily_lb_numSpecified = false;
		}

		// Token: 0x17002041 RID: 8257
		// (get) Token: 0x06006631 RID: 26161 RVA: 0x000C32A8 File Offset: 0x000C14A8
		// (set) Token: 0x06006632 RID: 26162 RVA: 0x000C32D4 File Offset: 0x000C14D4
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

		// Token: 0x17002042 RID: 8258
		// (get) Token: 0x06006633 RID: 26163 RVA: 0x000C32E4 File Offset: 0x000C14E4
		// (set) Token: 0x06006634 RID: 26164 RVA: 0x000C3304 File Offset: 0x000C1504
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

		// Token: 0x06006635 RID: 26165 RVA: 0x000C3348 File Offset: 0x000C1548
		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		// Token: 0x06006636 RID: 26166 RVA: 0x000C3360 File Offset: 0x000C1560
		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		// Token: 0x17002043 RID: 8259
		// (get) Token: 0x06006637 RID: 26167 RVA: 0x000C336C File Offset: 0x000C156C
		// (set) Token: 0x06006638 RID: 26168 RVA: 0x000C338D File Offset: 0x000C158D
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

		// Token: 0x17002044 RID: 8260
		// (get) Token: 0x06006639 RID: 26169 RVA: 0x000C3398 File Offset: 0x000C1598
		// (set) Token: 0x0600663A RID: 26170 RVA: 0x000C33B4 File Offset: 0x000C15B4
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

		// Token: 0x0600663B RID: 26171 RVA: 0x000C33E4 File Offset: 0x000C15E4
		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		// Token: 0x0600663C RID: 26172 RVA: 0x000C33FC File Offset: 0x000C15FC
		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		// Token: 0x17002045 RID: 8261
		// (get) Token: 0x0600663D RID: 26173 RVA: 0x000C3408 File Offset: 0x000C1608
		// (set) Token: 0x0600663E RID: 26174 RVA: 0x000C3434 File Offset: 0x000C1634
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

		// Token: 0x17002046 RID: 8262
		// (get) Token: 0x0600663F RID: 26175 RVA: 0x000C3444 File Offset: 0x000C1644
		// (set) Token: 0x06006640 RID: 26176 RVA: 0x000C3464 File Offset: 0x000C1664
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

		// Token: 0x06006641 RID: 26177 RVA: 0x000C34A8 File Offset: 0x000C16A8
		private bool ShouldSerializeqqvip_hint()
		{
			return this.qqvip_hintSpecified;
		}

		// Token: 0x06006642 RID: 26178 RVA: 0x000C34C0 File Offset: 0x000C16C0
		private void Resetqqvip_hint()
		{
			this.qqvip_hintSpecified = false;
		}

		// Token: 0x17002047 RID: 8263
		// (get) Token: 0x06006643 RID: 26179 RVA: 0x000C34CC File Offset: 0x000C16CC
		// (set) Token: 0x06006644 RID: 26180 RVA: 0x000C34F8 File Offset: 0x000C16F8
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

		// Token: 0x17002048 RID: 8264
		// (get) Token: 0x06006645 RID: 26181 RVA: 0x000C3508 File Offset: 0x000C1708
		// (set) Token: 0x06006646 RID: 26182 RVA: 0x000C3528 File Offset: 0x000C1728
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

		// Token: 0x06006647 RID: 26183 RVA: 0x000C356C File Offset: 0x000C176C
		private bool ShouldSerializeqqvip_hint_read_time()
		{
			return this.qqvip_hint_read_timeSpecified;
		}

		// Token: 0x06006648 RID: 26184 RVA: 0x000C3584 File Offset: 0x000C1784
		private void Resetqqvip_hint_read_time()
		{
			this.qqvip_hint_read_timeSpecified = false;
		}

		// Token: 0x17002049 RID: 8265
		// (get) Token: 0x06006649 RID: 26185 RVA: 0x000C3590 File Offset: 0x000C1790
		// (set) Token: 0x0600664A RID: 26186 RVA: 0x000C35BC File Offset: 0x000C17BC
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

		// Token: 0x1700204A RID: 8266
		// (get) Token: 0x0600664B RID: 26187 RVA: 0x000C35CC File Offset: 0x000C17CC
		// (set) Token: 0x0600664C RID: 26188 RVA: 0x000C35EC File Offset: 0x000C17EC
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

		// Token: 0x0600664D RID: 26189 RVA: 0x000C3630 File Offset: 0x000C1830
		private bool ShouldSerializeegame_hint()
		{
			return this.egame_hintSpecified;
		}

		// Token: 0x0600664E RID: 26190 RVA: 0x000C3648 File Offset: 0x000C1848
		private void Resetegame_hint()
		{
			this.egame_hintSpecified = false;
		}

		// Token: 0x1700204B RID: 8267
		// (get) Token: 0x0600664F RID: 26191 RVA: 0x000C3654 File Offset: 0x000C1854
		// (set) Token: 0x06006650 RID: 26192 RVA: 0x000C3680 File Offset: 0x000C1880
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

		// Token: 0x1700204C RID: 8268
		// (get) Token: 0x06006651 RID: 26193 RVA: 0x000C3690 File Offset: 0x000C1890
		// (set) Token: 0x06006652 RID: 26194 RVA: 0x000C36B0 File Offset: 0x000C18B0
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

		// Token: 0x06006653 RID: 26195 RVA: 0x000C36F4 File Offset: 0x000C18F4
		private bool ShouldSerializeegame_hint_readtime()
		{
			return this.egame_hint_readtimeSpecified;
		}

		// Token: 0x06006654 RID: 26196 RVA: 0x000C370C File Offset: 0x000C190C
		private void Resetegame_hint_readtime()
		{
			this.egame_hint_readtimeSpecified = false;
		}

		// Token: 0x1700204D RID: 8269
		// (get) Token: 0x06006655 RID: 26197 RVA: 0x000C3718 File Offset: 0x000C1918
		// (set) Token: 0x06006656 RID: 26198 RVA: 0x000C3744 File Offset: 0x000C1944
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

		// Token: 0x1700204E RID: 8270
		// (get) Token: 0x06006657 RID: 26199 RVA: 0x000C3754 File Offset: 0x000C1954
		// (set) Token: 0x06006658 RID: 26200 RVA: 0x000C3774 File Offset: 0x000C1974
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

		// Token: 0x06006659 RID: 26201 RVA: 0x000C37B8 File Offset: 0x000C19B8
		private bool ShouldSerializexinyue_hint()
		{
			return this.xinyue_hintSpecified;
		}

		// Token: 0x0600665A RID: 26202 RVA: 0x000C37D0 File Offset: 0x000C19D0
		private void Resetxinyue_hint()
		{
			this.xinyue_hintSpecified = false;
		}

		// Token: 0x1700204F RID: 8271
		// (get) Token: 0x0600665B RID: 26203 RVA: 0x000C37DC File Offset: 0x000C19DC
		// (set) Token: 0x0600665C RID: 26204 RVA: 0x000C3808 File Offset: 0x000C1A08
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

		// Token: 0x17002050 RID: 8272
		// (get) Token: 0x0600665D RID: 26205 RVA: 0x000C3818 File Offset: 0x000C1A18
		// (set) Token: 0x0600665E RID: 26206 RVA: 0x000C3838 File Offset: 0x000C1A38
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

		// Token: 0x0600665F RID: 26207 RVA: 0x000C387C File Offset: 0x000C1A7C
		private bool ShouldSerializexinyue_readtime()
		{
			return this.xinyue_readtimeSpecified;
		}

		// Token: 0x06006660 RID: 26208 RVA: 0x000C3894 File Offset: 0x000C1A94
		private void Resetxinyue_readtime()
		{
			this.xinyue_readtimeSpecified = false;
		}

		// Token: 0x17002051 RID: 8273
		// (get) Token: 0x06006661 RID: 26209 RVA: 0x000C38A0 File Offset: 0x000C1AA0
		// (set) Token: 0x06006662 RID: 26210 RVA: 0x000C38CC File Offset: 0x000C1ACC
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

		// Token: 0x17002052 RID: 8274
		// (get) Token: 0x06006663 RID: 26211 RVA: 0x000C38DC File Offset: 0x000C1ADC
		// (set) Token: 0x06006664 RID: 26212 RVA: 0x000C38FC File Offset: 0x000C1AFC
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

		// Token: 0x06006665 RID: 26213 RVA: 0x000C3940 File Offset: 0x000C1B40
		private bool ShouldSerializelast_level()
		{
			return this.last_levelSpecified;
		}

		// Token: 0x06006666 RID: 26214 RVA: 0x000C3958 File Offset: 0x000C1B58
		private void Resetlast_level()
		{
			this.last_levelSpecified = false;
		}

		// Token: 0x17002053 RID: 8275
		// (get) Token: 0x06006667 RID: 26215 RVA: 0x000C3964 File Offset: 0x000C1B64
		// (set) Token: 0x06006668 RID: 26216 RVA: 0x000C3990 File Offset: 0x000C1B90
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

		// Token: 0x17002054 RID: 8276
		// (get) Token: 0x06006669 RID: 26217 RVA: 0x000C39A0 File Offset: 0x000C1BA0
		// (set) Token: 0x0600666A RID: 26218 RVA: 0x000C39C0 File Offset: 0x000C1BC0
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

		// Token: 0x0600666B RID: 26219 RVA: 0x000C3A04 File Offset: 0x000C1C04
		private bool ShouldSerializeloginacttime()
		{
			return this.loginacttimeSpecified;
		}

		// Token: 0x0600666C RID: 26220 RVA: 0x000C3A1C File Offset: 0x000C1C1C
		private void Resetloginacttime()
		{
			this.loginacttimeSpecified = false;
		}

		// Token: 0x17002055 RID: 8277
		// (get) Token: 0x0600666D RID: 26221 RVA: 0x000C3A28 File Offset: 0x000C1C28
		// (set) Token: 0x0600666E RID: 26222 RVA: 0x000C3A54 File Offset: 0x000C1C54
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

		// Token: 0x17002056 RID: 8278
		// (get) Token: 0x0600666F RID: 26223 RVA: 0x000C3A64 File Offset: 0x000C1C64
		// (set) Token: 0x06006670 RID: 26224 RVA: 0x000C3A84 File Offset: 0x000C1C84
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

		// Token: 0x06006671 RID: 26225 RVA: 0x000C3AC8 File Offset: 0x000C1CC8
		private bool ShouldSerializeloginactstatus()
		{
			return this.loginactstatusSpecified;
		}

		// Token: 0x06006672 RID: 26226 RVA: 0x000C3AE0 File Offset: 0x000C1CE0
		private void Resetloginactstatus()
		{
			this.loginactstatusSpecified = false;
		}

		// Token: 0x17002057 RID: 8279
		// (get) Token: 0x06006673 RID: 26227 RVA: 0x000C3AEC File Offset: 0x000C1CEC
		// (set) Token: 0x06006674 RID: 26228 RVA: 0x000C3B18 File Offset: 0x000C1D18
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

		// Token: 0x17002058 RID: 8280
		// (get) Token: 0x06006675 RID: 26229 RVA: 0x000C3B28 File Offset: 0x000C1D28
		// (set) Token: 0x06006676 RID: 26230 RVA: 0x000C3B48 File Offset: 0x000C1D48
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

		// Token: 0x06006677 RID: 26231 RVA: 0x000C3B8C File Offset: 0x000C1D8C
		private bool ShouldSerializedaygiftitems()
		{
			return this.daygiftitemsSpecified;
		}

		// Token: 0x06006678 RID: 26232 RVA: 0x000C3BA4 File Offset: 0x000C1DA4
		private void Resetdaygiftitems()
		{
			this.daygiftitemsSpecified = false;
		}

		// Token: 0x17002059 RID: 8281
		// (get) Token: 0x06006679 RID: 26233 RVA: 0x000C3BB0 File Offset: 0x000C1DB0
		// (set) Token: 0x0600667A RID: 26234 RVA: 0x000C3BDC File Offset: 0x000C1DDC
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

		// Token: 0x1700205A RID: 8282
		// (get) Token: 0x0600667B RID: 26235 RVA: 0x000C3BEC File Offset: 0x000C1DEC
		// (set) Token: 0x0600667C RID: 26236 RVA: 0x000C3C0C File Offset: 0x000C1E0C
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

		// Token: 0x0600667D RID: 26237 RVA: 0x000C3C50 File Offset: 0x000C1E50
		private bool ShouldSerializehardestNestExpID()
		{
			return this.hardestNestExpIDSpecified;
		}

		// Token: 0x0600667E RID: 26238 RVA: 0x000C3C68 File Offset: 0x000C1E68
		private void ResethardestNestExpID()
		{
			this.hardestNestExpIDSpecified = false;
		}

		// Token: 0x1700205B RID: 8283
		// (get) Token: 0x0600667F RID: 26239 RVA: 0x000C3C74 File Offset: 0x000C1E74
		// (set) Token: 0x06006680 RID: 26240 RVA: 0x000C3CA0 File Offset: 0x000C1EA0
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

		// Token: 0x1700205C RID: 8284
		// (get) Token: 0x06006681 RID: 26241 RVA: 0x000C3CB0 File Offset: 0x000C1EB0
		// (set) Token: 0x06006682 RID: 26242 RVA: 0x000C3CD0 File Offset: 0x000C1ED0
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

		// Token: 0x06006683 RID: 26243 RVA: 0x000C3D14 File Offset: 0x000C1F14
		private bool ShouldSerializestartuptype()
		{
			return this.startuptypeSpecified;
		}

		// Token: 0x06006684 RID: 26244 RVA: 0x000C3D2C File Offset: 0x000C1F2C
		private void Resetstartuptype()
		{
			this.startuptypeSpecified = false;
		}

		// Token: 0x1700205D RID: 8285
		// (get) Token: 0x06006685 RID: 26245 RVA: 0x000C3D38 File Offset: 0x000C1F38
		// (set) Token: 0x06006686 RID: 26246 RVA: 0x000C3D64 File Offset: 0x000C1F64
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

		// Token: 0x1700205E RID: 8286
		// (get) Token: 0x06006687 RID: 26247 RVA: 0x000C3D74 File Offset: 0x000C1F74
		// (set) Token: 0x06006688 RID: 26248 RVA: 0x000C3D94 File Offset: 0x000C1F94
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

		// Token: 0x06006689 RID: 26249 RVA: 0x000C3DD8 File Offset: 0x000C1FD8
		private bool ShouldSerializestartuptime()
		{
			return this.startuptimeSpecified;
		}

		// Token: 0x0600668A RID: 26250 RVA: 0x000C3DF0 File Offset: 0x000C1FF0
		private void Resetstartuptime()
		{
			this.startuptimeSpecified = false;
		}

		// Token: 0x1700205F RID: 8287
		// (get) Token: 0x0600668B RID: 26251 RVA: 0x000C3DFC File Offset: 0x000C1FFC
		// (set) Token: 0x0600668C RID: 26252 RVA: 0x000C3E28 File Offset: 0x000C2028
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

		// Token: 0x17002060 RID: 8288
		// (get) Token: 0x0600668D RID: 26253 RVA: 0x000C3E38 File Offset: 0x000C2038
		// (set) Token: 0x0600668E RID: 26254 RVA: 0x000C3E58 File Offset: 0x000C2058
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

		// Token: 0x0600668F RID: 26255 RVA: 0x000C3E9C File Offset: 0x000C209C
		private bool ShouldSerializeweddingflow_count()
		{
			return this.weddingflow_countSpecified;
		}

		// Token: 0x06006690 RID: 26256 RVA: 0x000C3EB4 File Offset: 0x000C20B4
		private void Resetweddingflow_count()
		{
			this.weddingflow_countSpecified = false;
		}

		// Token: 0x17002061 RID: 8289
		// (get) Token: 0x06006691 RID: 26257 RVA: 0x000C3EC0 File Offset: 0x000C20C0
		// (set) Token: 0x06006692 RID: 26258 RVA: 0x000C3EEC File Offset: 0x000C20EC
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

		// Token: 0x17002062 RID: 8290
		// (get) Token: 0x06006693 RID: 26259 RVA: 0x000C3EFC File Offset: 0x000C20FC
		// (set) Token: 0x06006694 RID: 26260 RVA: 0x000C3F1C File Offset: 0x000C211C
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

		// Token: 0x06006695 RID: 26261 RVA: 0x000C3F60 File Offset: 0x000C2160
		private bool ShouldSerializeweddingfireworks_count()
		{
			return this.weddingfireworks_countSpecified;
		}

		// Token: 0x06006696 RID: 26262 RVA: 0x000C3F78 File Offset: 0x000C2178
		private void Resetweddingfireworks_count()
		{
			this.weddingfireworks_countSpecified = false;
		}

		// Token: 0x17002063 RID: 8291
		// (get) Token: 0x06006697 RID: 26263 RVA: 0x000C3F84 File Offset: 0x000C2184
		// (set) Token: 0x06006698 RID: 26264 RVA: 0x000C3FB0 File Offset: 0x000C21B0
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

		// Token: 0x17002064 RID: 8292
		// (get) Token: 0x06006699 RID: 26265 RVA: 0x000C3FC0 File Offset: 0x000C21C0
		// (set) Token: 0x0600669A RID: 26266 RVA: 0x000C3FE0 File Offset: 0x000C21E0
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

		// Token: 0x0600669B RID: 26267 RVA: 0x000C4024 File Offset: 0x000C2224
		private bool ShouldSerializeweddingcandy_count()
		{
			return this.weddingcandy_countSpecified;
		}

		// Token: 0x0600669C RID: 26268 RVA: 0x000C403C File Offset: 0x000C223C
		private void Resetweddingcandy_count()
		{
			this.weddingcandy_countSpecified = false;
		}

		// Token: 0x17002065 RID: 8293
		// (get) Token: 0x0600669D RID: 26269 RVA: 0x000C4048 File Offset: 0x000C2248
		[ProtoMember(29, Name = "gmattrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> gmattrs
		{
			get
			{
				return this._gmattrs;
			}
		}

		// Token: 0x17002066 RID: 8294
		// (get) Token: 0x0600669E RID: 26270 RVA: 0x000C4060 File Offset: 0x000C2260
		// (set) Token: 0x0600669F RID: 26271 RVA: 0x000C4078 File Offset: 0x000C2278
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

		// Token: 0x17002067 RID: 8295
		// (get) Token: 0x060066A0 RID: 26272 RVA: 0x000C4084 File Offset: 0x000C2284
		// (set) Token: 0x060066A1 RID: 26273 RVA: 0x000C409C File Offset: 0x000C229C
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

		// Token: 0x17002068 RID: 8296
		// (get) Token: 0x060066A2 RID: 26274 RVA: 0x000C40A8 File Offset: 0x000C22A8
		// (set) Token: 0x060066A3 RID: 26275 RVA: 0x000C40D4 File Offset: 0x000C22D4
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

		// Token: 0x17002069 RID: 8297
		// (get) Token: 0x060066A4 RID: 26276 RVA: 0x000C40E4 File Offset: 0x000C22E4
		// (set) Token: 0x060066A5 RID: 26277 RVA: 0x000C4104 File Offset: 0x000C2304
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

		// Token: 0x060066A6 RID: 26278 RVA: 0x000C4148 File Offset: 0x000C2348
		private bool ShouldSerializefreeflow_hinttime()
		{
			return this.freeflow_hinttimeSpecified;
		}

		// Token: 0x060066A7 RID: 26279 RVA: 0x000C4160 File Offset: 0x000C2360
		private void Resetfreeflow_hinttime()
		{
			this.freeflow_hinttimeSpecified = false;
		}

		// Token: 0x1700206A RID: 8298
		// (get) Token: 0x060066A8 RID: 26280 RVA: 0x000C416C File Offset: 0x000C236C
		// (set) Token: 0x060066A9 RID: 26281 RVA: 0x000C4198 File Offset: 0x000C2398
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

		// Token: 0x1700206B RID: 8299
		// (get) Token: 0x060066AA RID: 26282 RVA: 0x000C41A8 File Offset: 0x000C23A8
		// (set) Token: 0x060066AB RID: 26283 RVA: 0x000C41C8 File Offset: 0x000C23C8
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

		// Token: 0x060066AC RID: 26284 RVA: 0x000C420C File Offset: 0x000C240C
		private bool ShouldSerializekingbackrewardcount()
		{
			return this.kingbackrewardcountSpecified;
		}

		// Token: 0x060066AD RID: 26285 RVA: 0x000C4224 File Offset: 0x000C2424
		private void Resetkingbackrewardcount()
		{
			this.kingbackrewardcountSpecified = false;
		}

		// Token: 0x1700206C RID: 8300
		// (get) Token: 0x060066AE RID: 26286 RVA: 0x000C4230 File Offset: 0x000C2430
		// (set) Token: 0x060066AF RID: 26287 RVA: 0x000C425C File Offset: 0x000C245C
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

		// Token: 0x1700206D RID: 8301
		// (get) Token: 0x060066B0 RID: 26288 RVA: 0x000C426C File Offset: 0x000C246C
		// (set) Token: 0x060066B1 RID: 26289 RVA: 0x000C428C File Offset: 0x000C248C
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

		// Token: 0x060066B2 RID: 26290 RVA: 0x000C42D0 File Offset: 0x000C24D0
		private bool ShouldSerializechare_back_rewardlevel()
		{
			return this.chare_back_rewardlevelSpecified;
		}

		// Token: 0x060066B3 RID: 26291 RVA: 0x000C42E8 File Offset: 0x000C24E8
		private void Resetchare_back_rewardlevel()
		{
			this.chare_back_rewardlevelSpecified = false;
		}

		// Token: 0x1700206E RID: 8302
		// (get) Token: 0x060066B4 RID: 26292 RVA: 0x000C42F4 File Offset: 0x000C24F4
		// (set) Token: 0x060066B5 RID: 26293 RVA: 0x000C4320 File Offset: 0x000C2520
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

		// Token: 0x1700206F RID: 8303
		// (get) Token: 0x060066B6 RID: 26294 RVA: 0x000C4330 File Offset: 0x000C2530
		// (set) Token: 0x060066B7 RID: 26295 RVA: 0x000C4350 File Offset: 0x000C2550
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

		// Token: 0x060066B8 RID: 26296 RVA: 0x000C4394 File Offset: 0x000C2594
		private bool ShouldSerializecharge_back_total()
		{
			return this.charge_back_totalSpecified;
		}

		// Token: 0x060066B9 RID: 26297 RVA: 0x000C43AC File Offset: 0x000C25AC
		private void Resetcharge_back_total()
		{
			this.charge_back_totalSpecified = false;
		}

		// Token: 0x17002070 RID: 8304
		// (get) Token: 0x060066BA RID: 26298 RVA: 0x000C43B8 File Offset: 0x000C25B8
		// (set) Token: 0x060066BB RID: 26299 RVA: 0x000C43D0 File Offset: 0x000C25D0
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

		// Token: 0x17002071 RID: 8305
		// (get) Token: 0x060066BC RID: 26300 RVA: 0x000C43DC File Offset: 0x000C25DC
		// (set) Token: 0x060066BD RID: 26301 RVA: 0x000C4408 File Offset: 0x000C2608
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

		// Token: 0x17002072 RID: 8306
		// (get) Token: 0x060066BE RID: 26302 RVA: 0x000C4418 File Offset: 0x000C2618
		// (set) Token: 0x060066BF RID: 26303 RVA: 0x000C4438 File Offset: 0x000C2638
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

		// Token: 0x060066C0 RID: 26304 RVA: 0x000C447C File Offset: 0x000C267C
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x060066C1 RID: 26305 RVA: 0x000C4494 File Offset: 0x000C2694
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x17002073 RID: 8307
		// (get) Token: 0x060066C2 RID: 26306 RVA: 0x000C44A0 File Offset: 0x000C26A0
		// (set) Token: 0x060066C3 RID: 26307 RVA: 0x000C44CC File Offset: 0x000C26CC
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

		// Token: 0x17002074 RID: 8308
		// (get) Token: 0x060066C4 RID: 26308 RVA: 0x000C44DC File Offset: 0x000C26DC
		// (set) Token: 0x060066C5 RID: 26309 RVA: 0x000C44FC File Offset: 0x000C26FC
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

		// Token: 0x060066C6 RID: 26310 RVA: 0x000C4540 File Offset: 0x000C2740
		private bool ShouldSerializetake_package_reward()
		{
			return this.take_package_rewardSpecified;
		}

		// Token: 0x060066C7 RID: 26311 RVA: 0x000C4558 File Offset: 0x000C2758
		private void Resettake_package_reward()
		{
			this.take_package_rewardSpecified = false;
		}

		// Token: 0x060066C8 RID: 26312 RVA: 0x000C4564 File Offset: 0x000C2764
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018AF RID: 6319
		private uint? _dummy;

		// Token: 0x040018B0 RID: 6320
		private uint? _lastpush;

		// Token: 0x040018B1 RID: 6321
		private uint? _pushflag;

		// Token: 0x040018B2 RID: 6322
		private uint? _laddertime;

		// Token: 0x040018B3 RID: 6323
		private uint? _answersindex;

		// Token: 0x040018B4 RID: 6324
		private uint? _answersversion;

		// Token: 0x040018B5 RID: 6325
		private uint? _hintflag;

		// Token: 0x040018B6 RID: 6326
		private uint? _lastchangeprotime;

		// Token: 0x040018B7 RID: 6327
		private uint? _changeprocount;

		// Token: 0x040018B8 RID: 6328
		private uint? _daily_lb_num;

		// Token: 0x040018B9 RID: 6329
		private uint? _updatetime;

		// Token: 0x040018BA RID: 6330
		private string _declaration;

		// Token: 0x040018BB RID: 6331
		private bool? _qqvip_hint;

		// Token: 0x040018BC RID: 6332
		private uint? _qqvip_hint_read_time;

		// Token: 0x040018BD RID: 6333
		private bool? _egame_hint;

		// Token: 0x040018BE RID: 6334
		private uint? _egame_hint_readtime;

		// Token: 0x040018BF RID: 6335
		private bool? _xinyue_hint;

		// Token: 0x040018C0 RID: 6336
		private uint? _xinyue_readtime;

		// Token: 0x040018C1 RID: 6337
		private uint? _last_level;

		// Token: 0x040018C2 RID: 6338
		private uint? _loginacttime;

		// Token: 0x040018C3 RID: 6339
		private bool? _loginactstatus;

		// Token: 0x040018C4 RID: 6340
		private uint? _daygiftitems;

		// Token: 0x040018C5 RID: 6341
		private uint? _hardestNestExpID;

		// Token: 0x040018C6 RID: 6342
		private StartUpType? _startuptype;

		// Token: 0x040018C7 RID: 6343
		private uint? _startuptime;

		// Token: 0x040018C8 RID: 6344
		private uint? _weddingflow_count;

		// Token: 0x040018C9 RID: 6345
		private uint? _weddingfireworks_count;

		// Token: 0x040018CA RID: 6346
		private uint? _weddingcandy_count;

		// Token: 0x040018CB RID: 6347
		private readonly List<AttributeInfo> _gmattrs = new List<AttributeInfo>();

		// Token: 0x040018CC RID: 6348
		private SurviveRecord _surviverec = null;

		// Token: 0x040018CD RID: 6349
		private LuckyActivity _turntable = null;

		// Token: 0x040018CE RID: 6350
		private uint? _freeflow_hinttime;

		// Token: 0x040018CF RID: 6351
		private uint? _kingbackrewardcount;

		// Token: 0x040018D0 RID: 6352
		private uint? _chare_back_rewardlevel;

		// Token: 0x040018D1 RID: 6353
		private uint? _charge_back_total;

		// Token: 0x040018D2 RID: 6354
		private SRoleMultiReward _multireward = null;

		// Token: 0x040018D3 RID: 6355
		private uint? _version;

		// Token: 0x040018D4 RID: 6356
		private bool? _take_package_reward;

		// Token: 0x040018D5 RID: 6357
		private IExtension extensionObject;
	}
}
