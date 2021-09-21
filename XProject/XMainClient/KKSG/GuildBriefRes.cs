using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000098 RID: 152
	[ProtoContract(Name = "GuildBriefRes")]
	[Serializable]
	public class GuildBriefRes : IExtensible
	{
		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x00015D28 File Offset: 0x00013F28
		// (set) Token: 0x06000A16 RID: 2582 RVA: 0x00015D49 File Offset: 0x00013F49
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x00015D54 File Offset: 0x00013F54
		// (set) Token: 0x06000A18 RID: 2584 RVA: 0x00015D70 File Offset: 0x00013F70
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

		// Token: 0x06000A19 RID: 2585 RVA: 0x00015DA0 File Offset: 0x00013FA0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00015DB8 File Offset: 0x00013FB8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x00015DC4 File Offset: 0x00013FC4
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x00015DE5 File Offset: 0x00013FE5
		[ProtoMember(2, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
		public string leaderName
		{
			get
			{
				return this._leaderName ?? "";
			}
			set
			{
				this._leaderName = value;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x00015DF0 File Offset: 0x00013FF0
		// (set) Token: 0x06000A1E RID: 2590 RVA: 0x00015E0C File Offset: 0x0001400C
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderNameSpecified
		{
			get
			{
				return this._leaderName != null;
			}
			set
			{
				bool flag = value == (this._leaderName == null);
				if (flag)
				{
					this._leaderName = (value ? this.leaderName : null);
				}
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00015E3C File Offset: 0x0001403C
		private bool ShouldSerializeleaderName()
		{
			return this.leaderNameSpecified;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00015E54 File Offset: 0x00014054
		private void ResetleaderName()
		{
			this.leaderNameSpecified = false;
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x00015E60 File Offset: 0x00014060
		// (set) Token: 0x06000A22 RID: 2594 RVA: 0x00015E81 File Offset: 0x00014081
		[ProtoMember(3, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x00015E8C File Offset: 0x0001408C
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x00015EA8 File Offset: 0x000140A8
		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00015ED8 File Offset: 0x000140D8
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00015EF0 File Offset: 0x000140F0
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x00015EFC File Offset: 0x000140FC
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x00015F29 File Offset: 0x00014129
		[ProtoMember(4, IsRequired = false, Name = "leaderID", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderID
		{
			get
			{
				return this._leaderID ?? 0UL;
			}
			set
			{
				this._leaderID = new ulong?(value);
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x00015F38 File Offset: 0x00014138
		// (set) Token: 0x06000A2A RID: 2602 RVA: 0x00015F58 File Offset: 0x00014158
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIDSpecified
		{
			get
			{
				return this._leaderID != null;
			}
			set
			{
				bool flag = value == (this._leaderID == null);
				if (flag)
				{
					this._leaderID = (value ? new ulong?(this.leaderID) : null);
				}
			}
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00015F9C File Offset: 0x0001419C
		private bool ShouldSerializeleaderID()
		{
			return this.leaderIDSpecified;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00015FB4 File Offset: 0x000141B4
		private void ResetleaderID()
		{
			this.leaderIDSpecified = false;
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00015FC0 File Offset: 0x000141C0
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x00015FEC File Offset: 0x000141EC
		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x00015FFC File Offset: 0x000141FC
		// (set) Token: 0x06000A30 RID: 2608 RVA: 0x0001601C File Offset: 0x0001421C
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00016060 File Offset: 0x00014260
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00016078 File Offset: 0x00014278
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x00016084 File Offset: 0x00014284
		// (set) Token: 0x06000A34 RID: 2612 RVA: 0x000160B0 File Offset: 0x000142B0
		[ProtoMember(6, IsRequired = false, Name = "membercount", DataFormat = DataFormat.TwosComplement)]
		public int membercount
		{
			get
			{
				return this._membercount ?? 0;
			}
			set
			{
				this._membercount = new int?(value);
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000A35 RID: 2613 RVA: 0x000160C0 File Offset: 0x000142C0
		// (set) Token: 0x06000A36 RID: 2614 RVA: 0x000160E0 File Offset: 0x000142E0
		[XmlIgnore]
		[Browsable(false)]
		public bool membercountSpecified
		{
			get
			{
				return this._membercount != null;
			}
			set
			{
				bool flag = value == (this._membercount == null);
				if (flag)
				{
					this._membercount = (value ? new int?(this.membercount) : null);
				}
			}
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00016124 File Offset: 0x00014324
		private bool ShouldSerializemembercount()
		{
			return this.membercountSpecified;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0001613C File Offset: 0x0001433C
		private void Resetmembercount()
		{
			this.membercountSpecified = false;
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00016148 File Offset: 0x00014348
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x00016174 File Offset: 0x00014374
		[ProtoMember(7, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public int capacity
		{
			get
			{
				return this._capacity ?? 0;
			}
			set
			{
				this._capacity = new int?(value);
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00016184 File Offset: 0x00014384
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x000161A4 File Offset: 0x000143A4
		[XmlIgnore]
		[Browsable(false)]
		public bool capacitySpecified
		{
			get
			{
				return this._capacity != null;
			}
			set
			{
				bool flag = value == (this._capacity == null);
				if (flag)
				{
					this._capacity = (value ? new int?(this.capacity) : null);
				}
			}
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000161E8 File Offset: 0x000143E8
		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00016200 File Offset: 0x00014400
		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x0001620C File Offset: 0x0001440C
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x00016238 File Offset: 0x00014438
		[ProtoMember(8, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public int icon
		{
			get
			{
				return this._icon ?? 0;
			}
			set
			{
				this._icon = new int?(value);
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00016248 File Offset: 0x00014448
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x00016268 File Offset: 0x00014468
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new int?(this.icon) : null);
				}
			}
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x000162AC File Offset: 0x000144AC
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x000162C4 File Offset: 0x000144C4
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x000162D0 File Offset: 0x000144D0
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x000162FC File Offset: 0x000144FC
		[ProtoMember(9, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x0001630C File Offset: 0x0001450C
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x0001632C File Offset: 0x0001452C
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

		// Token: 0x06000A49 RID: 2633 RVA: 0x00016370 File Offset: 0x00014570
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00016388 File Offset: 0x00014588
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00016394 File Offset: 0x00014594
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x000163C0 File Offset: 0x000145C0
		[ProtoMember(10, IsRequired = false, Name = "recuritppt", DataFormat = DataFormat.TwosComplement)]
		public uint recuritppt
		{
			get
			{
				return this._recuritppt ?? 0U;
			}
			set
			{
				this._recuritppt = new uint?(value);
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x000163D0 File Offset: 0x000145D0
		// (set) Token: 0x06000A4E RID: 2638 RVA: 0x000163F0 File Offset: 0x000145F0
		[XmlIgnore]
		[Browsable(false)]
		public bool recuritpptSpecified
		{
			get
			{
				return this._recuritppt != null;
			}
			set
			{
				bool flag = value == (this._recuritppt == null);
				if (flag)
				{
					this._recuritppt = (value ? new uint?(this.recuritppt) : null);
				}
			}
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00016434 File Offset: 0x00014634
		private bool ShouldSerializerecuritppt()
		{
			return this.recuritpptSpecified;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0001644C File Offset: 0x0001464C
		private void Resetrecuritppt()
		{
			this.recuritpptSpecified = false;
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00016458 File Offset: 0x00014658
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x00016484 File Offset: 0x00014684
		[ProtoMember(11, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public int needApproval
		{
			get
			{
				return this._needApproval ?? 0;
			}
			set
			{
				this._needApproval = new int?(value);
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00016494 File Offset: 0x00014694
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x000164B4 File Offset: 0x000146B4
		[XmlIgnore]
		[Browsable(false)]
		public bool needApprovalSpecified
		{
			get
			{
				return this._needApproval != null;
			}
			set
			{
				bool flag = value == (this._needApproval == null);
				if (flag)
				{
					this._needApproval = (value ? new int?(this.needApproval) : null);
				}
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x000164F8 File Offset: 0x000146F8
		private bool ShouldSerializeneedApproval()
		{
			return this.needApprovalSpecified;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00016510 File Offset: 0x00014710
		private void ResetneedApproval()
		{
			this.needApprovalSpecified = false;
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x0001651C File Offset: 0x0001471C
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x00016548 File Offset: 0x00014748
		[ProtoMember(12, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00016558 File Offset: 0x00014758
		// (set) Token: 0x06000A5A RID: 2650 RVA: 0x00016578 File Offset: 0x00014778
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x000165BC File Offset: 0x000147BC
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x000165D4 File Offset: 0x000147D4
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x000165E0 File Offset: 0x000147E0
		// (set) Token: 0x06000A5E RID: 2654 RVA: 0x0001660C File Offset: 0x0001480C
		[ProtoMember(13, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x0001661C File Offset: 0x0001481C
		// (set) Token: 0x06000A60 RID: 2656 RVA: 0x0001663C File Offset: 0x0001483C
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
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00016680 File Offset: 0x00014880
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00016698 File Offset: 0x00014898
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x000166A4 File Offset: 0x000148A4
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x000166D0 File Offset: 0x000148D0
		[ProtoMember(14, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x000166E0 File Offset: 0x000148E0
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00016700 File Offset: 0x00014900
		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x00016744 File Offset: 0x00014944
		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0001675C File Offset: 0x0001495C
		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00016768 File Offset: 0x00014968
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x00016794 File Offset: 0x00014994
		[ProtoMember(15, IsRequired = false, Name = "activityOne", DataFormat = DataFormat.TwosComplement)]
		public uint activityOne
		{
			get
			{
				return this._activityOne ?? 0U;
			}
			set
			{
				this._activityOne = new uint?(value);
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x000167A4 File Offset: 0x000149A4
		// (set) Token: 0x06000A6C RID: 2668 RVA: 0x000167C4 File Offset: 0x000149C4
		[XmlIgnore]
		[Browsable(false)]
		public bool activityOneSpecified
		{
			get
			{
				return this._activityOne != null;
			}
			set
			{
				bool flag = value == (this._activityOne == null);
				if (flag)
				{
					this._activityOne = (value ? new uint?(this.activityOne) : null);
				}
			}
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00016808 File Offset: 0x00014A08
		private bool ShouldSerializeactivityOne()
		{
			return this.activityOneSpecified;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00016820 File Offset: 0x00014A20
		private void ResetactivityOne()
		{
			this.activityOneSpecified = false;
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x0001682C File Offset: 0x00014A2C
		// (set) Token: 0x06000A70 RID: 2672 RVA: 0x00016858 File Offset: 0x00014A58
		[ProtoMember(16, IsRequired = false, Name = "activityTwo", DataFormat = DataFormat.TwosComplement)]
		public uint activityTwo
		{
			get
			{
				return this._activityTwo ?? 0U;
			}
			set
			{
				this._activityTwo = new uint?(value);
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00016868 File Offset: 0x00014A68
		// (set) Token: 0x06000A72 RID: 2674 RVA: 0x00016888 File Offset: 0x00014A88
		[XmlIgnore]
		[Browsable(false)]
		public bool activityTwoSpecified
		{
			get
			{
				return this._activityTwo != null;
			}
			set
			{
				bool flag = value == (this._activityTwo == null);
				if (flag)
				{
					this._activityTwo = (value ? new uint?(this.activityTwo) : null);
				}
			}
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x000168CC File Offset: 0x00014ACC
		private bool ShouldSerializeactivityTwo()
		{
			return this.activityTwoSpecified;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x000168E4 File Offset: 0x00014AE4
		private void ResetactivityTwo()
		{
			this.activityTwoSpecified = false;
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x000168F0 File Offset: 0x00014AF0
		// (set) Token: 0x06000A76 RID: 2678 RVA: 0x0001691C File Offset: 0x00014B1C
		[ProtoMember(17, IsRequired = false, Name = "activityThree", DataFormat = DataFormat.TwosComplement)]
		public uint activityThree
		{
			get
			{
				return this._activityThree ?? 0U;
			}
			set
			{
				this._activityThree = new uint?(value);
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0001692C File Offset: 0x00014B2C
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x0001694C File Offset: 0x00014B4C
		[XmlIgnore]
		[Browsable(false)]
		public bool activityThreeSpecified
		{
			get
			{
				return this._activityThree != null;
			}
			set
			{
				bool flag = value == (this._activityThree == null);
				if (flag)
				{
					this._activityThree = (value ? new uint?(this.activityThree) : null);
				}
			}
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00016990 File Offset: 0x00014B90
		private bool ShouldSerializeactivityThree()
		{
			return this.activityThreeSpecified;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x000169A8 File Offset: 0x00014BA8
		private void ResetactivityThree()
		{
			this.activityThreeSpecified = false;
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x000169B4 File Offset: 0x00014BB4
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x000169E0 File Offset: 0x00014BE0
		[ProtoMember(18, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
		public uint prestige
		{
			get
			{
				return this._prestige ?? 0U;
			}
			set
			{
				this._prestige = new uint?(value);
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x000169F0 File Offset: 0x00014BF0
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x00016A10 File Offset: 0x00014C10
		[XmlIgnore]
		[Browsable(false)]
		public bool prestigeSpecified
		{
			get
			{
				return this._prestige != null;
			}
			set
			{
				bool flag = value == (this._prestige == null);
				if (flag)
				{
					this._prestige = (value ? new uint?(this.prestige) : null);
				}
			}
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00016A54 File Offset: 0x00014C54
		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00016A6C File Offset: 0x00014C6C
		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00016A78 File Offset: 0x00014C78
		// (set) Token: 0x06000A82 RID: 2690 RVA: 0x00016AA4 File Offset: 0x00014CA4
		[ProtoMember(19, IsRequired = false, Name = "schoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint schoolpoint
		{
			get
			{
				return this._schoolpoint ?? 0U;
			}
			set
			{
				this._schoolpoint = new uint?(value);
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00016AB4 File Offset: 0x00014CB4
		// (set) Token: 0x06000A84 RID: 2692 RVA: 0x00016AD4 File Offset: 0x00014CD4
		[XmlIgnore]
		[Browsable(false)]
		public bool schoolpointSpecified
		{
			get
			{
				return this._schoolpoint != null;
			}
			set
			{
				bool flag = value == (this._schoolpoint == null);
				if (flag)
				{
					this._schoolpoint = (value ? new uint?(this.schoolpoint) : null);
				}
			}
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00016B18 File Offset: 0x00014D18
		private bool ShouldSerializeschoolpoint()
		{
			return this.schoolpointSpecified;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00016B30 File Offset: 0x00014D30
		private void Resetschoolpoint()
		{
			this.schoolpointSpecified = false;
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x00016B3C File Offset: 0x00014D3C
		// (set) Token: 0x06000A88 RID: 2696 RVA: 0x00016B68 File Offset: 0x00014D68
		[ProtoMember(20, IsRequired = false, Name = "hallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint hallpoint
		{
			get
			{
				return this._hallpoint ?? 0U;
			}
			set
			{
				this._hallpoint = new uint?(value);
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x00016B78 File Offset: 0x00014D78
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x00016B98 File Offset: 0x00014D98
		[XmlIgnore]
		[Browsable(false)]
		public bool hallpointSpecified
		{
			get
			{
				return this._hallpoint != null;
			}
			set
			{
				bool flag = value == (this._hallpoint == null);
				if (flag)
				{
					this._hallpoint = (value ? new uint?(this.hallpoint) : null);
				}
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00016BDC File Offset: 0x00014DDC
		private bool ShouldSerializehallpoint()
		{
			return this.hallpointSpecified;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00016BF4 File Offset: 0x00014DF4
		private void Resethallpoint()
		{
			this.hallpointSpecified = false;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00016C00 File Offset: 0x00014E00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000294 RID: 660
		private string _name;

		// Token: 0x04000295 RID: 661
		private string _leaderName;

		// Token: 0x04000296 RID: 662
		private string _annoucement;

		// Token: 0x04000297 RID: 663
		private ulong? _leaderID;

		// Token: 0x04000298 RID: 664
		private int? _level;

		// Token: 0x04000299 RID: 665
		private int? _membercount;

		// Token: 0x0400029A RID: 666
		private int? _capacity;

		// Token: 0x0400029B RID: 667
		private int? _icon;

		// Token: 0x0400029C RID: 668
		private ErrorCode? _result;

		// Token: 0x0400029D RID: 669
		private uint? _recuritppt;

		// Token: 0x0400029E RID: 670
		private int? _needApproval;

		// Token: 0x0400029F RID: 671
		private uint? _exp;

		// Token: 0x040002A0 RID: 672
		private int? _rank;

		// Token: 0x040002A1 RID: 673
		private uint? _activity;

		// Token: 0x040002A2 RID: 674
		private uint? _activityOne;

		// Token: 0x040002A3 RID: 675
		private uint? _activityTwo;

		// Token: 0x040002A4 RID: 676
		private uint? _activityThree;

		// Token: 0x040002A5 RID: 677
		private uint? _prestige;

		// Token: 0x040002A6 RID: 678
		private uint? _schoolpoint;

		// Token: 0x040002A7 RID: 679
		private uint? _hallpoint;

		// Token: 0x040002A8 RID: 680
		private IExtension extensionObject;
	}
}
