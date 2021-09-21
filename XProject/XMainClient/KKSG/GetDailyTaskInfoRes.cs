using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CE RID: 718
	[ProtoContract(Name = "GetDailyTaskInfoRes")]
	[Serializable]
	public class GetDailyTaskInfoRes : IExtensible
	{
		// Token: 0x17000C4A RID: 3146
		// (get) Token: 0x06002787 RID: 10119 RVA: 0x0004CD64 File Offset: 0x0004AF64
		[ProtoMember(1, Name = "task", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> task
		{
			get
			{
				return this._task;
			}
		}

		// Token: 0x17000C4B RID: 3147
		// (get) Token: 0x06002788 RID: 10120 RVA: 0x0004CD7C File Offset: 0x0004AF7C
		// (set) Token: 0x06002789 RID: 10121 RVA: 0x0004CDA8 File Offset: 0x0004AFA8
		[ProtoMember(2, IsRequired = false, Name = "is_rewarded", DataFormat = DataFormat.Default)]
		public bool is_rewarded
		{
			get
			{
				return this._is_rewarded ?? false;
			}
			set
			{
				this._is_rewarded = new bool?(value);
			}
		}

		// Token: 0x17000C4C RID: 3148
		// (get) Token: 0x0600278A RID: 10122 RVA: 0x0004CDB8 File Offset: 0x0004AFB8
		// (set) Token: 0x0600278B RID: 10123 RVA: 0x0004CDD8 File Offset: 0x0004AFD8
		[XmlIgnore]
		[Browsable(false)]
		public bool is_rewardedSpecified
		{
			get
			{
				return this._is_rewarded != null;
			}
			set
			{
				bool flag = value == (this._is_rewarded == null);
				if (flag)
				{
					this._is_rewarded = (value ? new bool?(this.is_rewarded) : null);
				}
			}
		}

		// Token: 0x0600278C RID: 10124 RVA: 0x0004CE1C File Offset: 0x0004B01C
		private bool ShouldSerializeis_rewarded()
		{
			return this.is_rewardedSpecified;
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0004CE34 File Offset: 0x0004B034
		private void Resetis_rewarded()
		{
			this.is_rewardedSpecified = false;
		}

		// Token: 0x17000C4D RID: 3149
		// (get) Token: 0x0600278E RID: 10126 RVA: 0x0004CE40 File Offset: 0x0004B040
		// (set) Token: 0x0600278F RID: 10127 RVA: 0x0004CE6C File Offset: 0x0004B06C
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

		// Token: 0x17000C4E RID: 3150
		// (get) Token: 0x06002790 RID: 10128 RVA: 0x0004CE7C File Offset: 0x0004B07C
		// (set) Token: 0x06002791 RID: 10129 RVA: 0x0004CE9C File Offset: 0x0004B09C
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

		// Token: 0x06002792 RID: 10130 RVA: 0x0004CEE0 File Offset: 0x0004B0E0
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002793 RID: 10131 RVA: 0x0004CEF8 File Offset: 0x0004B0F8
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000C4F RID: 3151
		// (get) Token: 0x06002794 RID: 10132 RVA: 0x0004CF04 File Offset: 0x0004B104
		// (set) Token: 0x06002795 RID: 10133 RVA: 0x0004CF30 File Offset: 0x0004B130
		[ProtoMember(4, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
		public uint accept_level
		{
			get
			{
				return this._accept_level ?? 0U;
			}
			set
			{
				this._accept_level = new uint?(value);
			}
		}

		// Token: 0x17000C50 RID: 3152
		// (get) Token: 0x06002796 RID: 10134 RVA: 0x0004CF40 File Offset: 0x0004B140
		// (set) Token: 0x06002797 RID: 10135 RVA: 0x0004CF60 File Offset: 0x0004B160
		[XmlIgnore]
		[Browsable(false)]
		public bool accept_levelSpecified
		{
			get
			{
				return this._accept_level != null;
			}
			set
			{
				bool flag = value == (this._accept_level == null);
				if (flag)
				{
					this._accept_level = (value ? new uint?(this.accept_level) : null);
				}
			}
		}

		// Token: 0x06002798 RID: 10136 RVA: 0x0004CFA4 File Offset: 0x0004B1A4
		private bool ShouldSerializeaccept_level()
		{
			return this.accept_levelSpecified;
		}

		// Token: 0x06002799 RID: 10137 RVA: 0x0004CFBC File Offset: 0x0004B1BC
		private void Resetaccept_level()
		{
			this.accept_levelSpecified = false;
		}

		// Token: 0x17000C51 RID: 3153
		// (get) Token: 0x0600279A RID: 10138 RVA: 0x0004CFC8 File Offset: 0x0004B1C8
		// (set) Token: 0x0600279B RID: 10139 RVA: 0x0004CFF4 File Offset: 0x0004B1F4
		[ProtoMember(5, IsRequired = false, Name = "askhelp_num", DataFormat = DataFormat.TwosComplement)]
		public uint askhelp_num
		{
			get
			{
				return this._askhelp_num ?? 0U;
			}
			set
			{
				this._askhelp_num = new uint?(value);
			}
		}

		// Token: 0x17000C52 RID: 3154
		// (get) Token: 0x0600279C RID: 10140 RVA: 0x0004D004 File Offset: 0x0004B204
		// (set) Token: 0x0600279D RID: 10141 RVA: 0x0004D024 File Offset: 0x0004B224
		[XmlIgnore]
		[Browsable(false)]
		public bool askhelp_numSpecified
		{
			get
			{
				return this._askhelp_num != null;
			}
			set
			{
				bool flag = value == (this._askhelp_num == null);
				if (flag)
				{
					this._askhelp_num = (value ? new uint?(this.askhelp_num) : null);
				}
			}
		}

		// Token: 0x0600279E RID: 10142 RVA: 0x0004D068 File Offset: 0x0004B268
		private bool ShouldSerializeaskhelp_num()
		{
			return this.askhelp_numSpecified;
		}

		// Token: 0x0600279F RID: 10143 RVA: 0x0004D080 File Offset: 0x0004B280
		private void Resetaskhelp_num()
		{
			this.askhelp_numSpecified = false;
		}

		// Token: 0x17000C53 RID: 3155
		// (get) Token: 0x060027A0 RID: 10144 RVA: 0x0004D08C File Offset: 0x0004B28C
		// (set) Token: 0x060027A1 RID: 10145 RVA: 0x0004D0B8 File Offset: 0x0004B2B8
		[ProtoMember(6, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000C54 RID: 3156
		// (get) Token: 0x060027A2 RID: 10146 RVA: 0x0004D0C8 File Offset: 0x0004B2C8
		// (set) Token: 0x060027A3 RID: 10147 RVA: 0x0004D0E8 File Offset: 0x0004B2E8
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

		// Token: 0x060027A4 RID: 10148 RVA: 0x0004D12C File Offset: 0x0004B32C
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x0004D144 File Offset: 0x0004B344
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17000C55 RID: 3157
		// (get) Token: 0x060027A6 RID: 10150 RVA: 0x0004D150 File Offset: 0x0004B350
		// (set) Token: 0x060027A7 RID: 10151 RVA: 0x0004D17C File Offset: 0x0004B37C
		[ProtoMember(7, IsRequired = false, Name = "remain_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_refresh_count
		{
			get
			{
				return this._remain_refresh_count ?? 0U;
			}
			set
			{
				this._remain_refresh_count = new uint?(value);
			}
		}

		// Token: 0x17000C56 RID: 3158
		// (get) Token: 0x060027A8 RID: 10152 RVA: 0x0004D18C File Offset: 0x0004B38C
		// (set) Token: 0x060027A9 RID: 10153 RVA: 0x0004D1AC File Offset: 0x0004B3AC
		[XmlIgnore]
		[Browsable(false)]
		public bool remain_refresh_countSpecified
		{
			get
			{
				return this._remain_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_refresh_count == null);
				if (flag)
				{
					this._remain_refresh_count = (value ? new uint?(this.remain_refresh_count) : null);
				}
			}
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x0004D1F0 File Offset: 0x0004B3F0
		private bool ShouldSerializeremain_refresh_count()
		{
			return this.remain_refresh_countSpecified;
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x0004D208 File Offset: 0x0004B408
		private void Resetremain_refresh_count()
		{
			this.remain_refresh_countSpecified = false;
		}

		// Token: 0x17000C57 RID: 3159
		// (get) Token: 0x060027AC RID: 10156 RVA: 0x0004D214 File Offset: 0x0004B414
		// (set) Token: 0x060027AD RID: 10157 RVA: 0x0004D240 File Offset: 0x0004B440
		[ProtoMember(8, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		// Token: 0x17000C58 RID: 3160
		// (get) Token: 0x060027AE RID: 10158 RVA: 0x0004D250 File Offset: 0x0004B450
		// (set) Token: 0x060027AF RID: 10159 RVA: 0x0004D270 File Offset: 0x0004B470
		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x0004D2B4 File Offset: 0x0004B4B4
		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x0004D2CC File Offset: 0x0004B4CC
		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		// Token: 0x060027B2 RID: 10162 RVA: 0x0004D2D8 File Offset: 0x0004B4D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009D8 RID: 2520
		private readonly List<DailyTaskInfo> _task = new List<DailyTaskInfo>();

		// Token: 0x040009D9 RID: 2521
		private bool? _is_rewarded;

		// Token: 0x040009DA RID: 2522
		private uint? _count;

		// Token: 0x040009DB RID: 2523
		private uint? _accept_level;

		// Token: 0x040009DC RID: 2524
		private uint? _askhelp_num;

		// Token: 0x040009DD RID: 2525
		private uint? _score;

		// Token: 0x040009DE RID: 2526
		private uint? _remain_refresh_count;

		// Token: 0x040009DF RID: 2527
		private uint? _luck;

		// Token: 0x040009E0 RID: 2528
		private IExtension extensionObject;
	}
}
