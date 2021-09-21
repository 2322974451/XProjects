using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000060 RID: 96
	[ProtoContract(Name = "TeamOPRes")]
	[Serializable]
	public class TeamOPRes : IExtensible
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x0000EF7C File Offset: 0x0000D17C
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x0000EFA8 File Offset: 0x0000D1A8
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

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0000EFB8 File Offset: 0x0000D1B8
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
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

		// Token: 0x06000670 RID: 1648 RVA: 0x0000F01C File Offset: 0x0000D21C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0000F034 File Offset: 0x0000D234
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0000F040 File Offset: 0x0000D240
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x0000F06D File Offset: 0x0000D26D
		[ProtoMember(2, IsRequired = false, Name = "problem_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong problem_roleid
		{
			get
			{
				return this._problem_roleid ?? 0UL;
			}
			set
			{
				this._problem_roleid = new ulong?(value);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000F07C File Offset: 0x0000D27C
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0000F09C File Offset: 0x0000D29C
		[XmlIgnore]
		[Browsable(false)]
		public bool problem_roleidSpecified
		{
			get
			{
				return this._problem_roleid != null;
			}
			set
			{
				bool flag = value == (this._problem_roleid == null);
				if (flag)
				{
					this._problem_roleid = (value ? new ulong?(this.problem_roleid) : null);
				}
			}
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0000F0E0 File Offset: 0x0000D2E0
		private bool ShouldSerializeproblem_roleid()
		{
			return this.problem_roleidSpecified;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
		private void Resetproblem_roleid()
		{
			this.problem_roleidSpecified = false;
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x0000F104 File Offset: 0x0000D304
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x0000F130 File Offset: 0x0000D330
		[ProtoMember(3, IsRequired = false, Name = "GoddessGetRewardsCount", DataFormat = DataFormat.TwosComplement)]
		public int GoddessGetRewardsCount
		{
			get
			{
				return this._GoddessGetRewardsCount ?? 0;
			}
			set
			{
				this._GoddessGetRewardsCount = new int?(value);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x0000F140 File Offset: 0x0000D340
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x0000F160 File Offset: 0x0000D360
		[XmlIgnore]
		[Browsable(false)]
		public bool GoddessGetRewardsCountSpecified
		{
			get
			{
				return this._GoddessGetRewardsCount != null;
			}
			set
			{
				bool flag = value == (this._GoddessGetRewardsCount == null);
				if (flag)
				{
					this._GoddessGetRewardsCount = (value ? new int?(this.GoddessGetRewardsCount) : null);
				}
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0000F1A4 File Offset: 0x0000D3A4
		private bool ShouldSerializeGoddessGetRewardsCount()
		{
			return this.GoddessGetRewardsCountSpecified;
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0000F1BC File Offset: 0x0000D3BC
		private void ResetGoddessGetRewardsCount()
		{
			this.GoddessGetRewardsCountSpecified = false;
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0000F1C8 File Offset: 0x0000D3C8
		[ProtoMember(4, Name = "teamcount", DataFormat = DataFormat.Default)]
		public List<TeamCountClient> teamcount
		{
			get
			{
				return this._teamcount;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0000F1E0 File Offset: 0x0000D3E0
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x0000F20C File Offset: 0x0000D40C
		[ProtoMember(5, IsRequired = false, Name = "weeknestexpid", DataFormat = DataFormat.TwosComplement)]
		public int weeknestexpid
		{
			get
			{
				return this._weeknestexpid ?? 0;
			}
			set
			{
				this._weeknestexpid = new int?(value);
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000F21C File Offset: 0x0000D41C
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x0000F23C File Offset: 0x0000D43C
		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestexpidSpecified
		{
			get
			{
				return this._weeknestexpid != null;
			}
			set
			{
				bool flag = value == (this._weeknestexpid == null);
				if (flag)
				{
					this._weeknestexpid = (value ? new int?(this.weeknestexpid) : null);
				}
			}
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0000F280 File Offset: 0x0000D480
		private bool ShouldSerializeweeknestexpid()
		{
			return this.weeknestexpidSpecified;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0000F298 File Offset: 0x0000D498
		private void Resetweeknestexpid()
		{
			this.weeknestexpidSpecified = false;
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x0000F2A4 File Offset: 0x0000D4A4
		// (set) Token: 0x06000686 RID: 1670 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
		[ProtoMember(6, IsRequired = false, Name = "opentime", DataFormat = DataFormat.TwosComplement)]
		public uint opentime
		{
			get
			{
				return this._opentime ?? 0U;
			}
			set
			{
				this._opentime = new uint?(value);
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000F2E0 File Offset: 0x0000D4E0
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x0000F300 File Offset: 0x0000D500
		[XmlIgnore]
		[Browsable(false)]
		public bool opentimeSpecified
		{
			get
			{
				return this._opentime != null;
			}
			set
			{
				bool flag = value == (this._opentime == null);
				if (flag)
				{
					this._opentime = (value ? new uint?(this.opentime) : null);
				}
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0000F344 File Offset: 0x0000D544
		private bool ShouldSerializeopentime()
		{
			return this.opentimeSpecified;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0000F35C File Offset: 0x0000D55C
		private void Resetopentime()
		{
			this.opentimeSpecified = false;
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000F368 File Offset: 0x0000D568
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x0000F394 File Offset: 0x0000D594
		[ProtoMember(7, IsRequired = false, Name = "wnrewardleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint wnrewardleftcount
		{
			get
			{
				return this._wnrewardleftcount ?? 0U;
			}
			set
			{
				this._wnrewardleftcount = new uint?(value);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x0000F3C4 File Offset: 0x0000D5C4
		[XmlIgnore]
		[Browsable(false)]
		public bool wnrewardleftcountSpecified
		{
			get
			{
				return this._wnrewardleftcount != null;
			}
			set
			{
				bool flag = value == (this._wnrewardleftcount == null);
				if (flag)
				{
					this._wnrewardleftcount = (value ? new uint?(this.wnrewardleftcount) : null);
				}
			}
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0000F408 File Offset: 0x0000D608
		private bool ShouldSerializewnrewardleftcount()
		{
			return this.wnrewardleftcountSpecified;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0000F420 File Offset: 0x0000D620
		private void Resetwnrewardleftcount()
		{
			this.wnrewardleftcountSpecified = false;
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000F42C File Offset: 0x0000D62C
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x0000F458 File Offset: 0x0000D658
		[ProtoMember(8, IsRequired = false, Name = "wnrewardmaxcount", DataFormat = DataFormat.TwosComplement)]
		public uint wnrewardmaxcount
		{
			get
			{
				return this._wnrewardmaxcount ?? 0U;
			}
			set
			{
				this._wnrewardmaxcount = new uint?(value);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0000F468 File Offset: 0x0000D668
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x0000F488 File Offset: 0x0000D688
		[XmlIgnore]
		[Browsable(false)]
		public bool wnrewardmaxcountSpecified
		{
			get
			{
				return this._wnrewardmaxcount != null;
			}
			set
			{
				bool flag = value == (this._wnrewardmaxcount == null);
				if (flag)
				{
					this._wnrewardmaxcount = (value ? new uint?(this.wnrewardmaxcount) : null);
				}
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0000F4CC File Offset: 0x0000D6CC
		private bool ShouldSerializewnrewardmaxcount()
		{
			return this.wnrewardmaxcountSpecified;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		private void Resetwnrewardmaxcount()
		{
			this.wnrewardmaxcountSpecified = false;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001A0 RID: 416
		private ErrorCode? _result;

		// Token: 0x040001A1 RID: 417
		private ulong? _problem_roleid;

		// Token: 0x040001A2 RID: 418
		private int? _GoddessGetRewardsCount;

		// Token: 0x040001A3 RID: 419
		private readonly List<TeamCountClient> _teamcount = new List<TeamCountClient>();

		// Token: 0x040001A4 RID: 420
		private int? _weeknestexpid;

		// Token: 0x040001A5 RID: 421
		private uint? _opentime;

		// Token: 0x040001A6 RID: 422
		private uint? _wnrewardleftcount;

		// Token: 0x040001A7 RID: 423
		private uint? _wnrewardmaxcount;

		// Token: 0x040001A8 RID: 424
		private IExtension extensionObject;
	}
}
