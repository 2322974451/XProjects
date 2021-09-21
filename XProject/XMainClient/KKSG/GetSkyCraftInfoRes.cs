using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E1 RID: 993
	[ProtoContract(Name = "GetSkyCraftInfoRes")]
	[Serializable]
	public class GetSkyCraftInfoRes : IExtensible
	{
		// Token: 0x17001039 RID: 4153
		// (get) Token: 0x060034BE RID: 13502 RVA: 0x000651B4 File Offset: 0x000633B4
		// (set) Token: 0x060034BF RID: 13503 RVA: 0x000651E0 File Offset: 0x000633E0
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

		// Token: 0x1700103A RID: 4154
		// (get) Token: 0x060034C0 RID: 13504 RVA: 0x000651F0 File Offset: 0x000633F0
		// (set) Token: 0x060034C1 RID: 13505 RVA: 0x00065210 File Offset: 0x00063410
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

		// Token: 0x060034C2 RID: 13506 RVA: 0x00065254 File Offset: 0x00063454
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060034C3 RID: 13507 RVA: 0x0006526C File Offset: 0x0006346C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700103B RID: 4155
		// (get) Token: 0x060034C4 RID: 13508 RVA: 0x00065278 File Offset: 0x00063478
		// (set) Token: 0x060034C5 RID: 13509 RVA: 0x000652A5 File Offset: 0x000634A5
		[ProtoMember(2, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		// Token: 0x1700103C RID: 4156
		// (get) Token: 0x060034C6 RID: 13510 RVA: 0x000652B4 File Offset: 0x000634B4
		// (set) Token: 0x060034C7 RID: 13511 RVA: 0x000652D4 File Offset: 0x000634D4
		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		// Token: 0x060034C8 RID: 13512 RVA: 0x00065318 File Offset: 0x00063518
		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		// Token: 0x060034C9 RID: 13513 RVA: 0x00065330 File Offset: 0x00063530
		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		// Token: 0x1700103D RID: 4157
		// (get) Token: 0x060034CA RID: 13514 RVA: 0x0006533C File Offset: 0x0006353C
		// (set) Token: 0x060034CB RID: 13515 RVA: 0x0006535D File Offset: 0x0006355D
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700103E RID: 4158
		// (get) Token: 0x060034CC RID: 13516 RVA: 0x00065368 File Offset: 0x00063568
		// (set) Token: 0x060034CD RID: 13517 RVA: 0x00065384 File Offset: 0x00063584
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060034CE RID: 13518 RVA: 0x000653B4 File Offset: 0x000635B4
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060034CF RID: 13519 RVA: 0x000653CC File Offset: 0x000635CC
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700103F RID: 4159
		// (get) Token: 0x060034D0 RID: 13520 RVA: 0x000653D8 File Offset: 0x000635D8
		// (set) Token: 0x060034D1 RID: 13521 RVA: 0x00065404 File Offset: 0x00063604
		[ProtoMember(4, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		// Token: 0x17001040 RID: 4160
		// (get) Token: 0x060034D2 RID: 13522 RVA: 0x00065414 File Offset: 0x00063614
		// (set) Token: 0x060034D3 RID: 13523 RVA: 0x00065434 File Offset: 0x00063634
		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		// Token: 0x060034D4 RID: 13524 RVA: 0x00065478 File Offset: 0x00063678
		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		// Token: 0x060034D5 RID: 13525 RVA: 0x00065490 File Offset: 0x00063690
		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		// Token: 0x17001041 RID: 4161
		// (get) Token: 0x060034D6 RID: 13526 RVA: 0x0006549C File Offset: 0x0006369C
		// (set) Token: 0x060034D7 RID: 13527 RVA: 0x000654CC File Offset: 0x000636CC
		[ProtoMember(5, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x17001042 RID: 4162
		// (get) Token: 0x060034D8 RID: 13528 RVA: 0x000654DC File Offset: 0x000636DC
		// (set) Token: 0x060034D9 RID: 13529 RVA: 0x000654FC File Offset: 0x000636FC
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x060034DA RID: 13530 RVA: 0x00065540 File Offset: 0x00063740
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x060034DB RID: 13531 RVA: 0x00065558 File Offset: 0x00063758
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x17001043 RID: 4163
		// (get) Token: 0x060034DC RID: 13532 RVA: 0x00065564 File Offset: 0x00063764
		// (set) Token: 0x060034DD RID: 13533 RVA: 0x00065590 File Offset: 0x00063790
		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17001044 RID: 4164
		// (get) Token: 0x060034DE RID: 13534 RVA: 0x000655A0 File Offset: 0x000637A0
		// (set) Token: 0x060034DF RID: 13535 RVA: 0x000655C0 File Offset: 0x000637C0
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x060034E0 RID: 13536 RVA: 0x00065604 File Offset: 0x00063804
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060034E1 RID: 13537 RVA: 0x0006561C File Offset: 0x0006381C
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001045 RID: 4165
		// (get) Token: 0x060034E2 RID: 13538 RVA: 0x00065628 File Offset: 0x00063828
		[ProtoMember(7, Name = "members", DataFormat = DataFormat.Default)]
		public List<SkyTeamMemberInfo> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x17001046 RID: 4166
		// (get) Token: 0x060034E3 RID: 13539 RVA: 0x00065640 File Offset: 0x00063840
		// (set) Token: 0x060034E4 RID: 13540 RVA: 0x0006566C File Offset: 0x0006386C
		[ProtoMember(8, IsRequired = false, Name = "today_num", DataFormat = DataFormat.TwosComplement)]
		public uint today_num
		{
			get
			{
				return this._today_num ?? 0U;
			}
			set
			{
				this._today_num = new uint?(value);
			}
		}

		// Token: 0x17001047 RID: 4167
		// (get) Token: 0x060034E5 RID: 13541 RVA: 0x0006567C File Offset: 0x0006387C
		// (set) Token: 0x060034E6 RID: 13542 RVA: 0x0006569C File Offset: 0x0006389C
		[XmlIgnore]
		[Browsable(false)]
		public bool today_numSpecified
		{
			get
			{
				return this._today_num != null;
			}
			set
			{
				bool flag = value == (this._today_num == null);
				if (flag)
				{
					this._today_num = (value ? new uint?(this.today_num) : null);
				}
			}
		}

		// Token: 0x060034E7 RID: 13543 RVA: 0x000656E0 File Offset: 0x000638E0
		private bool ShouldSerializetoday_num()
		{
			return this.today_numSpecified;
		}

		// Token: 0x060034E8 RID: 13544 RVA: 0x000656F8 File Offset: 0x000638F8
		private void Resettoday_num()
		{
			this.today_numSpecified = false;
		}

		// Token: 0x060034E9 RID: 13545 RVA: 0x00065704 File Offset: 0x00063904
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D1A RID: 3354
		private ErrorCode? _result;

		// Token: 0x04000D1B RID: 3355
		private ulong? _stid;

		// Token: 0x04000D1C RID: 3356
		private string _name;

		// Token: 0x04000D1D RID: 3357
		private uint? _total_num;

		// Token: 0x04000D1E RID: 3358
		private float? _winrate;

		// Token: 0x04000D1F RID: 3359
		private uint? _rank;

		// Token: 0x04000D20 RID: 3360
		private readonly List<SkyTeamMemberInfo> _members = new List<SkyTeamMemberInfo>();

		// Token: 0x04000D21 RID: 3361
		private uint? _today_num;

		// Token: 0x04000D22 RID: 3362
		private IExtension extensionObject;
	}
}
