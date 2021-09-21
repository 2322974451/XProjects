using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E0 RID: 1248
	[ProtoContract(Name = "GetWeeklyTaskInfoRes")]
	[Serializable]
	public class GetWeeklyTaskInfoRes : IExtensible
	{
		// Token: 0x170013B4 RID: 5044
		// (get) Token: 0x06004067 RID: 16487 RVA: 0x0007AA3C File Offset: 0x00078C3C
		// (set) Token: 0x06004068 RID: 16488 RVA: 0x0007AA68 File Offset: 0x00078C68
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170013B5 RID: 5045
		// (get) Token: 0x06004069 RID: 16489 RVA: 0x0007AA78 File Offset: 0x00078C78
		// (set) Token: 0x0600406A RID: 16490 RVA: 0x0007AA98 File Offset: 0x00078C98
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x0600406B RID: 16491 RVA: 0x0007AADC File Offset: 0x00078CDC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600406C RID: 16492 RVA: 0x0007AAF4 File Offset: 0x00078CF4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170013B6 RID: 5046
		// (get) Token: 0x0600406D RID: 16493 RVA: 0x0007AB00 File Offset: 0x00078D00
		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<WeeklyTaskInfo> task
		{
			get
			{
				return this._task;
			}
		}

		// Token: 0x170013B7 RID: 5047
		// (get) Token: 0x0600406E RID: 16494 RVA: 0x0007AB18 File Offset: 0x00078D18
		// (set) Token: 0x0600406F RID: 16495 RVA: 0x0007AB44 File Offset: 0x00078D44
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

		// Token: 0x170013B8 RID: 5048
		// (get) Token: 0x06004070 RID: 16496 RVA: 0x0007AB54 File Offset: 0x00078D54
		// (set) Token: 0x06004071 RID: 16497 RVA: 0x0007AB74 File Offset: 0x00078D74
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

		// Token: 0x06004072 RID: 16498 RVA: 0x0007ABB8 File Offset: 0x00078DB8
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06004073 RID: 16499 RVA: 0x0007ABD0 File Offset: 0x00078DD0
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170013B9 RID: 5049
		// (get) Token: 0x06004074 RID: 16500 RVA: 0x0007ABDC File Offset: 0x00078DDC
		// (set) Token: 0x06004075 RID: 16501 RVA: 0x0007AC08 File Offset: 0x00078E08
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

		// Token: 0x170013BA RID: 5050
		// (get) Token: 0x06004076 RID: 16502 RVA: 0x0007AC18 File Offset: 0x00078E18
		// (set) Token: 0x06004077 RID: 16503 RVA: 0x0007AC38 File Offset: 0x00078E38
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

		// Token: 0x06004078 RID: 16504 RVA: 0x0007AC7C File Offset: 0x00078E7C
		private bool ShouldSerializeaskhelp_num()
		{
			return this.askhelp_numSpecified;
		}

		// Token: 0x06004079 RID: 16505 RVA: 0x0007AC94 File Offset: 0x00078E94
		private void Resetaskhelp_num()
		{
			this.askhelp_numSpecified = false;
		}

		// Token: 0x170013BB RID: 5051
		// (get) Token: 0x0600407A RID: 16506 RVA: 0x0007ACA0 File Offset: 0x00078EA0
		[ProtoMember(5, Name = "rewarded_box", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rewarded_box
		{
			get
			{
				return this._rewarded_box;
			}
		}

		// Token: 0x170013BC RID: 5052
		// (get) Token: 0x0600407B RID: 16507 RVA: 0x0007ACB8 File Offset: 0x00078EB8
		// (set) Token: 0x0600407C RID: 16508 RVA: 0x0007ACE4 File Offset: 0x00078EE4
		[ProtoMember(6, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170013BD RID: 5053
		// (get) Token: 0x0600407D RID: 16509 RVA: 0x0007ACF4 File Offset: 0x00078EF4
		// (set) Token: 0x0600407E RID: 16510 RVA: 0x0007AD14 File Offset: 0x00078F14
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

		// Token: 0x0600407F RID: 16511 RVA: 0x0007AD58 File Offset: 0x00078F58
		private bool ShouldSerializeaccept_level()
		{
			return this.accept_levelSpecified;
		}

		// Token: 0x06004080 RID: 16512 RVA: 0x0007AD70 File Offset: 0x00078F70
		private void Resetaccept_level()
		{
			this.accept_levelSpecified = false;
		}

		// Token: 0x170013BE RID: 5054
		// (get) Token: 0x06004081 RID: 16513 RVA: 0x0007AD7C File Offset: 0x00078F7C
		[ProtoMember(7, Name = "helpinfo", DataFormat = DataFormat.Default)]
		public List<TaskHelpInfo> helpinfo
		{
			get
			{
				return this._helpinfo;
			}
		}

		// Token: 0x170013BF RID: 5055
		// (get) Token: 0x06004082 RID: 16514 RVA: 0x0007AD94 File Offset: 0x00078F94
		// (set) Token: 0x06004083 RID: 16515 RVA: 0x0007ADC0 File Offset: 0x00078FC0
		[ProtoMember(8, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x170013C0 RID: 5056
		// (get) Token: 0x06004084 RID: 16516 RVA: 0x0007ADD0 File Offset: 0x00078FD0
		// (set) Token: 0x06004085 RID: 16517 RVA: 0x0007ADF0 File Offset: 0x00078FF0
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06004086 RID: 16518 RVA: 0x0007AE34 File Offset: 0x00079034
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06004087 RID: 16519 RVA: 0x0007AE4C File Offset: 0x0007904C
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x170013C1 RID: 5057
		// (get) Token: 0x06004088 RID: 16520 RVA: 0x0007AE58 File Offset: 0x00079058
		// (set) Token: 0x06004089 RID: 16521 RVA: 0x0007AE84 File Offset: 0x00079084
		[ProtoMember(9, IsRequired = false, Name = "remain_free_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_free_refresh_count
		{
			get
			{
				return this._remain_free_refresh_count ?? 0U;
			}
			set
			{
				this._remain_free_refresh_count = new uint?(value);
			}
		}

		// Token: 0x170013C2 RID: 5058
		// (get) Token: 0x0600408A RID: 16522 RVA: 0x0007AE94 File Offset: 0x00079094
		// (set) Token: 0x0600408B RID: 16523 RVA: 0x0007AEB4 File Offset: 0x000790B4
		[XmlIgnore]
		[Browsable(false)]
		public bool remain_free_refresh_countSpecified
		{
			get
			{
				return this._remain_free_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_free_refresh_count == null);
				if (flag)
				{
					this._remain_free_refresh_count = (value ? new uint?(this.remain_free_refresh_count) : null);
				}
			}
		}

		// Token: 0x0600408C RID: 16524 RVA: 0x0007AEF8 File Offset: 0x000790F8
		private bool ShouldSerializeremain_free_refresh_count()
		{
			return this.remain_free_refresh_countSpecified;
		}

		// Token: 0x0600408D RID: 16525 RVA: 0x0007AF10 File Offset: 0x00079110
		private void Resetremain_free_refresh_count()
		{
			this.remain_free_refresh_countSpecified = false;
		}

		// Token: 0x0600408E RID: 16526 RVA: 0x0007AF1C File Offset: 0x0007911C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400100E RID: 4110
		private ErrorCode? _result;

		// Token: 0x0400100F RID: 4111
		private readonly List<WeeklyTaskInfo> _task = new List<WeeklyTaskInfo>();

		// Token: 0x04001010 RID: 4112
		private uint? _score;

		// Token: 0x04001011 RID: 4113
		private uint? _askhelp_num;

		// Token: 0x04001012 RID: 4114
		private readonly List<uint> _rewarded_box = new List<uint>();

		// Token: 0x04001013 RID: 4115
		private uint? _accept_level;

		// Token: 0x04001014 RID: 4116
		private readonly List<TaskHelpInfo> _helpinfo = new List<TaskHelpInfo>();

		// Token: 0x04001015 RID: 4117
		private uint? _lefttime;

		// Token: 0x04001016 RID: 4118
		private uint? _remain_free_refresh_count;

		// Token: 0x04001017 RID: 4119
		private IExtension extensionObject;
	}
}
