using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063B RID: 1595
	[ProtoContract(Name = "WeeklyTaskData")]
	[Serializable]
	public class WeeklyTaskData : IExtensible
	{
		// Token: 0x17001F07 RID: 7943
		// (get) Token: 0x06006285 RID: 25221 RVA: 0x000BC024 File Offset: 0x000BA224
		[ProtoMember(1, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<WeeklyTaskInfo> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		// Token: 0x17001F08 RID: 7944
		// (get) Token: 0x06006286 RID: 25222 RVA: 0x000BC03C File Offset: 0x000BA23C
		// (set) Token: 0x06006287 RID: 25223 RVA: 0x000BC068 File Offset: 0x000BA268
		[ProtoMember(2, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F09 RID: 7945
		// (get) Token: 0x06006288 RID: 25224 RVA: 0x000BC078 File Offset: 0x000BA278
		// (set) Token: 0x06006289 RID: 25225 RVA: 0x000BC098 File Offset: 0x000BA298
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

		// Token: 0x0600628A RID: 25226 RVA: 0x000BC0DC File Offset: 0x000BA2DC
		private bool ShouldSerializeaccept_level()
		{
			return this.accept_levelSpecified;
		}

		// Token: 0x0600628B RID: 25227 RVA: 0x000BC0F4 File Offset: 0x000BA2F4
		private void Resetaccept_level()
		{
			this.accept_levelSpecified = false;
		}

		// Token: 0x17001F0A RID: 7946
		// (get) Token: 0x0600628C RID: 25228 RVA: 0x000BC100 File Offset: 0x000BA300
		// (set) Token: 0x0600628D RID: 25229 RVA: 0x000BC12C File Offset: 0x000BA32C
		[ProtoMember(3, IsRequired = false, Name = "rewarded", DataFormat = DataFormat.Default)]
		public bool rewarded
		{
			get
			{
				return this._rewarded ?? false;
			}
			set
			{
				this._rewarded = new bool?(value);
			}
		}

		// Token: 0x17001F0B RID: 7947
		// (get) Token: 0x0600628E RID: 25230 RVA: 0x000BC13C File Offset: 0x000BA33C
		// (set) Token: 0x0600628F RID: 25231 RVA: 0x000BC15C File Offset: 0x000BA35C
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardedSpecified
		{
			get
			{
				return this._rewarded != null;
			}
			set
			{
				bool flag = value == (this._rewarded == null);
				if (flag)
				{
					this._rewarded = (value ? new bool?(this.rewarded) : null);
				}
			}
		}

		// Token: 0x06006290 RID: 25232 RVA: 0x000BC1A0 File Offset: 0x000BA3A0
		private bool ShouldSerializerewarded()
		{
			return this.rewardedSpecified;
		}

		// Token: 0x06006291 RID: 25233 RVA: 0x000BC1B8 File Offset: 0x000BA3B8
		private void Resetrewarded()
		{
			this.rewardedSpecified = false;
		}

		// Token: 0x17001F0C RID: 7948
		// (get) Token: 0x06006292 RID: 25234 RVA: 0x000BC1C4 File Offset: 0x000BA3C4
		// (set) Token: 0x06006293 RID: 25235 RVA: 0x000BC1F0 File Offset: 0x000BA3F0
		[ProtoMember(4, IsRequired = false, Name = "askhelp_num", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F0D RID: 7949
		// (get) Token: 0x06006294 RID: 25236 RVA: 0x000BC200 File Offset: 0x000BA400
		// (set) Token: 0x06006295 RID: 25237 RVA: 0x000BC220 File Offset: 0x000BA420
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

		// Token: 0x06006296 RID: 25238 RVA: 0x000BC264 File Offset: 0x000BA464
		private bool ShouldSerializeaskhelp_num()
		{
			return this.askhelp_numSpecified;
		}

		// Token: 0x06006297 RID: 25239 RVA: 0x000BC27C File Offset: 0x000BA47C
		private void Resetaskhelp_num()
		{
			this.askhelp_numSpecified = false;
		}

		// Token: 0x17001F0E RID: 7950
		// (get) Token: 0x06006298 RID: 25240 RVA: 0x000BC288 File Offset: 0x000BA488
		// (set) Token: 0x06006299 RID: 25241 RVA: 0x000BC2B4 File Offset: 0x000BA4B4
		[ProtoMember(5, IsRequired = false, Name = "accept", DataFormat = DataFormat.Default)]
		public bool accept
		{
			get
			{
				return this._accept ?? false;
			}
			set
			{
				this._accept = new bool?(value);
			}
		}

		// Token: 0x17001F0F RID: 7951
		// (get) Token: 0x0600629A RID: 25242 RVA: 0x000BC2C4 File Offset: 0x000BA4C4
		// (set) Token: 0x0600629B RID: 25243 RVA: 0x000BC2E4 File Offset: 0x000BA4E4
		[XmlIgnore]
		[Browsable(false)]
		public bool acceptSpecified
		{
			get
			{
				return this._accept != null;
			}
			set
			{
				bool flag = value == (this._accept == null);
				if (flag)
				{
					this._accept = (value ? new bool?(this.accept) : null);
				}
			}
		}

		// Token: 0x0600629C RID: 25244 RVA: 0x000BC328 File Offset: 0x000BA528
		private bool ShouldSerializeaccept()
		{
			return this.acceptSpecified;
		}

		// Token: 0x0600629D RID: 25245 RVA: 0x000BC340 File Offset: 0x000BA540
		private void Resetaccept()
		{
			this.acceptSpecified = false;
		}

		// Token: 0x17001F10 RID: 7952
		// (get) Token: 0x0600629E RID: 25246 RVA: 0x000BC34C File Offset: 0x000BA54C
		// (set) Token: 0x0600629F RID: 25247 RVA: 0x000BC378 File Offset: 0x000BA578
		[ProtoMember(6, IsRequired = false, Name = "accept_count", DataFormat = DataFormat.TwosComplement)]
		public uint accept_count
		{
			get
			{
				return this._accept_count ?? 0U;
			}
			set
			{
				this._accept_count = new uint?(value);
			}
		}

		// Token: 0x17001F11 RID: 7953
		// (get) Token: 0x060062A0 RID: 25248 RVA: 0x000BC388 File Offset: 0x000BA588
		// (set) Token: 0x060062A1 RID: 25249 RVA: 0x000BC3A8 File Offset: 0x000BA5A8
		[XmlIgnore]
		[Browsable(false)]
		public bool accept_countSpecified
		{
			get
			{
				return this._accept_count != null;
			}
			set
			{
				bool flag = value == (this._accept_count == null);
				if (flag)
				{
					this._accept_count = (value ? new uint?(this.accept_count) : null);
				}
			}
		}

		// Token: 0x060062A2 RID: 25250 RVA: 0x000BC3EC File Offset: 0x000BA5EC
		private bool ShouldSerializeaccept_count()
		{
			return this.accept_countSpecified;
		}

		// Token: 0x060062A3 RID: 25251 RVA: 0x000BC404 File Offset: 0x000BA604
		private void Resetaccept_count()
		{
			this.accept_countSpecified = false;
		}

		// Token: 0x17001F12 RID: 7954
		// (get) Token: 0x060062A4 RID: 25252 RVA: 0x000BC410 File Offset: 0x000BA610
		// (set) Token: 0x060062A5 RID: 25253 RVA: 0x000BC43C File Offset: 0x000BA63C
		[ProtoMember(7, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F13 RID: 7955
		// (get) Token: 0x060062A6 RID: 25254 RVA: 0x000BC44C File Offset: 0x000BA64C
		// (set) Token: 0x060062A7 RID: 25255 RVA: 0x000BC46C File Offset: 0x000BA66C
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

		// Token: 0x060062A8 RID: 25256 RVA: 0x000BC4B0 File Offset: 0x000BA6B0
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060062A9 RID: 25257 RVA: 0x000BC4C8 File Offset: 0x000BA6C8
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001F14 RID: 7956
		// (get) Token: 0x060062AA RID: 25258 RVA: 0x000BC4D4 File Offset: 0x000BA6D4
		[ProtoMember(8, Name = "rewarded_box", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rewarded_box
		{
			get
			{
				return this._rewarded_box;
			}
		}

		// Token: 0x17001F15 RID: 7957
		// (get) Token: 0x060062AB RID: 25259 RVA: 0x000BC4EC File Offset: 0x000BA6EC
		[ProtoMember(9, Name = "helpinfo", DataFormat = DataFormat.Default)]
		public List<TaskHelpInfo> helpinfo
		{
			get
			{
				return this._helpinfo;
			}
		}

		// Token: 0x17001F16 RID: 7958
		// (get) Token: 0x060062AC RID: 25260 RVA: 0x000BC504 File Offset: 0x000BA704
		// (set) Token: 0x060062AD RID: 25261 RVA: 0x000BC530 File Offset: 0x000BA730
		[ProtoMember(10, IsRequired = false, Name = "free_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint free_refresh_count
		{
			get
			{
				return this._free_refresh_count ?? 0U;
			}
			set
			{
				this._free_refresh_count = new uint?(value);
			}
		}

		// Token: 0x17001F17 RID: 7959
		// (get) Token: 0x060062AE RID: 25262 RVA: 0x000BC540 File Offset: 0x000BA740
		// (set) Token: 0x060062AF RID: 25263 RVA: 0x000BC560 File Offset: 0x000BA760
		[XmlIgnore]
		[Browsable(false)]
		public bool free_refresh_countSpecified
		{
			get
			{
				return this._free_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._free_refresh_count == null);
				if (flag)
				{
					this._free_refresh_count = (value ? new uint?(this.free_refresh_count) : null);
				}
			}
		}

		// Token: 0x060062B0 RID: 25264 RVA: 0x000BC5A4 File Offset: 0x000BA7A4
		private bool ShouldSerializefree_refresh_count()
		{
			return this.free_refresh_countSpecified;
		}

		// Token: 0x060062B1 RID: 25265 RVA: 0x000BC5BC File Offset: 0x000BA7BC
		private void Resetfree_refresh_count()
		{
			this.free_refresh_countSpecified = false;
		}

		// Token: 0x060062B2 RID: 25266 RVA: 0x000BC5C8 File Offset: 0x000BA7C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017E3 RID: 6115
		private readonly List<WeeklyTaskInfo> _tasks = new List<WeeklyTaskInfo>();

		// Token: 0x040017E4 RID: 6116
		private uint? _accept_level;

		// Token: 0x040017E5 RID: 6117
		private bool? _rewarded;

		// Token: 0x040017E6 RID: 6118
		private uint? _askhelp_num;

		// Token: 0x040017E7 RID: 6119
		private bool? _accept;

		// Token: 0x040017E8 RID: 6120
		private uint? _accept_count;

		// Token: 0x040017E9 RID: 6121
		private uint? _score;

		// Token: 0x040017EA RID: 6122
		private readonly List<uint> _rewarded_box = new List<uint>();

		// Token: 0x040017EB RID: 6123
		private readonly List<TaskHelpInfo> _helpinfo = new List<TaskHelpInfo>();

		// Token: 0x040017EC RID: 6124
		private uint? _free_refresh_count;

		// Token: 0x040017ED RID: 6125
		private IExtension extensionObject;
	}
}
