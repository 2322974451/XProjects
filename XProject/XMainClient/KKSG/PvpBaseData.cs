using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000684 RID: 1668
	[ProtoContract(Name = "PvpBaseData")]
	[Serializable]
	public class PvpBaseData : IExtensible
	{
		// Token: 0x170021F5 RID: 8693
		// (get) Token: 0x06006B48 RID: 27464 RVA: 0x000CD38C File Offset: 0x000CB58C
		// (set) Token: 0x06006B49 RID: 27465 RVA: 0x000CD3B8 File Offset: 0x000CB5B8
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

		// Token: 0x170021F6 RID: 8694
		// (get) Token: 0x06006B4A RID: 27466 RVA: 0x000CD3C8 File Offset: 0x000CB5C8
		// (set) Token: 0x06006B4B RID: 27467 RVA: 0x000CD3E8 File Offset: 0x000CB5E8
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

		// Token: 0x06006B4C RID: 27468 RVA: 0x000CD42C File Offset: 0x000CB62C
		private bool ShouldSerializewincountall()
		{
			return this.wincountallSpecified;
		}

		// Token: 0x06006B4D RID: 27469 RVA: 0x000CD444 File Offset: 0x000CB644
		private void Resetwincountall()
		{
			this.wincountallSpecified = false;
		}

		// Token: 0x170021F7 RID: 8695
		// (get) Token: 0x06006B4E RID: 27470 RVA: 0x000CD450 File Offset: 0x000CB650
		// (set) Token: 0x06006B4F RID: 27471 RVA: 0x000CD47C File Offset: 0x000CB67C
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

		// Token: 0x170021F8 RID: 8696
		// (get) Token: 0x06006B50 RID: 27472 RVA: 0x000CD48C File Offset: 0x000CB68C
		// (set) Token: 0x06006B51 RID: 27473 RVA: 0x000CD4AC File Offset: 0x000CB6AC
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

		// Token: 0x06006B52 RID: 27474 RVA: 0x000CD4F0 File Offset: 0x000CB6F0
		private bool ShouldSerializelosecountall()
		{
			return this.losecountallSpecified;
		}

		// Token: 0x06006B53 RID: 27475 RVA: 0x000CD508 File Offset: 0x000CB708
		private void Resetlosecountall()
		{
			this.losecountallSpecified = false;
		}

		// Token: 0x170021F9 RID: 8697
		// (get) Token: 0x06006B54 RID: 27476 RVA: 0x000CD514 File Offset: 0x000CB714
		// (set) Token: 0x06006B55 RID: 27477 RVA: 0x000CD540 File Offset: 0x000CB740
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

		// Token: 0x170021FA RID: 8698
		// (get) Token: 0x06006B56 RID: 27478 RVA: 0x000CD550 File Offset: 0x000CB750
		// (set) Token: 0x06006B57 RID: 27479 RVA: 0x000CD570 File Offset: 0x000CB770
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

		// Token: 0x06006B58 RID: 27480 RVA: 0x000CD5B4 File Offset: 0x000CB7B4
		private bool ShouldSerializedrawcountall()
		{
			return this.drawcountallSpecified;
		}

		// Token: 0x06006B59 RID: 27481 RVA: 0x000CD5CC File Offset: 0x000CB7CC
		private void Resetdrawcountall()
		{
			this.drawcountallSpecified = false;
		}

		// Token: 0x170021FB RID: 8699
		// (get) Token: 0x06006B5A RID: 27482 RVA: 0x000CD5D8 File Offset: 0x000CB7D8
		// (set) Token: 0x06006B5B RID: 27483 RVA: 0x000CD604 File Offset: 0x000CB804
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

		// Token: 0x170021FC RID: 8700
		// (get) Token: 0x06006B5C RID: 27484 RVA: 0x000CD614 File Offset: 0x000CB814
		// (set) Token: 0x06006B5D RID: 27485 RVA: 0x000CD634 File Offset: 0x000CB834
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

		// Token: 0x06006B5E RID: 27486 RVA: 0x000CD678 File Offset: 0x000CB878
		private bool ShouldSerializewincountthisweek()
		{
			return this.wincountthisweekSpecified;
		}

		// Token: 0x06006B5F RID: 27487 RVA: 0x000CD690 File Offset: 0x000CB890
		private void Resetwincountthisweek()
		{
			this.wincountthisweekSpecified = false;
		}

		// Token: 0x170021FD RID: 8701
		// (get) Token: 0x06006B60 RID: 27488 RVA: 0x000CD69C File Offset: 0x000CB89C
		// (set) Token: 0x06006B61 RID: 27489 RVA: 0x000CD6C8 File Offset: 0x000CB8C8
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

		// Token: 0x170021FE RID: 8702
		// (get) Token: 0x06006B62 RID: 27490 RVA: 0x000CD6D8 File Offset: 0x000CB8D8
		// (set) Token: 0x06006B63 RID: 27491 RVA: 0x000CD6F8 File Offset: 0x000CB8F8
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

		// Token: 0x06006B64 RID: 27492 RVA: 0x000CD73C File Offset: 0x000CB93C
		private bool ShouldSerializewincountweekmax()
		{
			return this.wincountweekmaxSpecified;
		}

		// Token: 0x06006B65 RID: 27493 RVA: 0x000CD754 File Offset: 0x000CB954
		private void Resetwincountweekmax()
		{
			this.wincountweekmaxSpecified = false;
		}

		// Token: 0x170021FF RID: 8703
		// (get) Token: 0x06006B66 RID: 27494 RVA: 0x000CD760 File Offset: 0x000CB960
		// (set) Token: 0x06006B67 RID: 27495 RVA: 0x000CD78C File Offset: 0x000CB98C
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

		// Token: 0x17002200 RID: 8704
		// (get) Token: 0x06006B68 RID: 27496 RVA: 0x000CD79C File Offset: 0x000CB99C
		// (set) Token: 0x06006B69 RID: 27497 RVA: 0x000CD7BC File Offset: 0x000CB9BC
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

		// Token: 0x06006B6A RID: 27498 RVA: 0x000CD800 File Offset: 0x000CBA00
		private bool ShouldSerializejointodayintime()
		{
			return this.jointodayintimeSpecified;
		}

		// Token: 0x06006B6B RID: 27499 RVA: 0x000CD818 File Offset: 0x000CBA18
		private void Resetjointodayintime()
		{
			this.jointodayintimeSpecified = false;
		}

		// Token: 0x17002201 RID: 8705
		// (get) Token: 0x06006B6C RID: 27500 RVA: 0x000CD824 File Offset: 0x000CBA24
		// (set) Token: 0x06006B6D RID: 27501 RVA: 0x000CD850 File Offset: 0x000CBA50
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

		// Token: 0x17002202 RID: 8706
		// (get) Token: 0x06006B6E RID: 27502 RVA: 0x000CD860 File Offset: 0x000CBA60
		// (set) Token: 0x06006B6F RID: 27503 RVA: 0x000CD880 File Offset: 0x000CBA80
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

		// Token: 0x06006B70 RID: 27504 RVA: 0x000CD8C4 File Offset: 0x000CBAC4
		private bool ShouldSerializejointodayintimemax()
		{
			return this.jointodayintimemaxSpecified;
		}

		// Token: 0x06006B71 RID: 27505 RVA: 0x000CD8DC File Offset: 0x000CBADC
		private void Resetjointodayintimemax()
		{
			this.jointodayintimemaxSpecified = false;
		}

		// Token: 0x17002203 RID: 8707
		// (get) Token: 0x06006B72 RID: 27506 RVA: 0x000CD8E8 File Offset: 0x000CBAE8
		// (set) Token: 0x06006B73 RID: 27507 RVA: 0x000CD914 File Offset: 0x000CBB14
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

		// Token: 0x17002204 RID: 8708
		// (get) Token: 0x06006B74 RID: 27508 RVA: 0x000CD924 File Offset: 0x000CBB24
		// (set) Token: 0x06006B75 RID: 27509 RVA: 0x000CD944 File Offset: 0x000CBB44
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

		// Token: 0x06006B76 RID: 27510 RVA: 0x000CD988 File Offset: 0x000CBB88
		private bool ShouldSerializematchingcount()
		{
			return this.matchingcountSpecified;
		}

		// Token: 0x06006B77 RID: 27511 RVA: 0x000CD9A0 File Offset: 0x000CBBA0
		private void Resetmatchingcount()
		{
			this.matchingcountSpecified = false;
		}

		// Token: 0x17002205 RID: 8709
		// (get) Token: 0x06006B78 RID: 27512 RVA: 0x000CD9AC File Offset: 0x000CBBAC
		// (set) Token: 0x06006B79 RID: 27513 RVA: 0x000CD9D8 File Offset: 0x000CBBD8
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

		// Token: 0x17002206 RID: 8710
		// (get) Token: 0x06006B7A RID: 27514 RVA: 0x000CD9E8 File Offset: 0x000CBBE8
		// (set) Token: 0x06006B7B RID: 27515 RVA: 0x000CDA08 File Offset: 0x000CBC08
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

		// Token: 0x06006B7C RID: 27516 RVA: 0x000CDA4C File Offset: 0x000CBC4C
		private bool ShouldSerializeweekRewardHaveGet()
		{
			return this.weekRewardHaveGetSpecified;
		}

		// Token: 0x06006B7D RID: 27517 RVA: 0x000CDA64 File Offset: 0x000CBC64
		private void ResetweekRewardHaveGet()
		{
			this.weekRewardHaveGetSpecified = false;
		}

		// Token: 0x06006B7E RID: 27518 RVA: 0x000CDA70 File Offset: 0x000CBC70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019CF RID: 6607
		private int? _wincountall;

		// Token: 0x040019D0 RID: 6608
		private int? _losecountall;

		// Token: 0x040019D1 RID: 6609
		private int? _drawcountall;

		// Token: 0x040019D2 RID: 6610
		private int? _wincountthisweek;

		// Token: 0x040019D3 RID: 6611
		private int? _wincountweekmax;

		// Token: 0x040019D4 RID: 6612
		private int? _jointodayintime;

		// Token: 0x040019D5 RID: 6613
		private int? _jointodayintimemax;

		// Token: 0x040019D6 RID: 6614
		private int? _matchingcount;

		// Token: 0x040019D7 RID: 6615
		private bool? _weekRewardHaveGet;

		// Token: 0x040019D8 RID: 6616
		private IExtension extensionObject;
	}
}
