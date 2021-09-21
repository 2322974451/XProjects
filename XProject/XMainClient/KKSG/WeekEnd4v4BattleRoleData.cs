using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DC RID: 1500
	[ProtoContract(Name = "WeekEnd4v4BattleRoleData")]
	[Serializable]
	public class WeekEnd4v4BattleRoleData : IExtensible
	{
		// Token: 0x17001AC7 RID: 6855
		// (get) Token: 0x06005643 RID: 22083 RVA: 0x000A43B4 File Offset: 0x000A25B4
		// (set) Token: 0x06005644 RID: 22084 RVA: 0x000A43E1 File Offset: 0x000A25E1
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001AC8 RID: 6856
		// (get) Token: 0x06005645 RID: 22085 RVA: 0x000A43F0 File Offset: 0x000A25F0
		// (set) Token: 0x06005646 RID: 22086 RVA: 0x000A4410 File Offset: 0x000A2610
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06005647 RID: 22087 RVA: 0x000A4454 File Offset: 0x000A2654
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06005648 RID: 22088 RVA: 0x000A446C File Offset: 0x000A266C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001AC9 RID: 6857
		// (get) Token: 0x06005649 RID: 22089 RVA: 0x000A4478 File Offset: 0x000A2678
		// (set) Token: 0x0600564A RID: 22090 RVA: 0x000A44A4 File Offset: 0x000A26A4
		[ProtoMember(2, IsRequired = false, Name = "redblue", DataFormat = DataFormat.TwosComplement)]
		public uint redblue
		{
			get
			{
				return this._redblue ?? 0U;
			}
			set
			{
				this._redblue = new uint?(value);
			}
		}

		// Token: 0x17001ACA RID: 6858
		// (get) Token: 0x0600564B RID: 22091 RVA: 0x000A44B4 File Offset: 0x000A26B4
		// (set) Token: 0x0600564C RID: 22092 RVA: 0x000A44D4 File Offset: 0x000A26D4
		[XmlIgnore]
		[Browsable(false)]
		public bool redblueSpecified
		{
			get
			{
				return this._redblue != null;
			}
			set
			{
				bool flag = value == (this._redblue == null);
				if (flag)
				{
					this._redblue = (value ? new uint?(this.redblue) : null);
				}
			}
		}

		// Token: 0x0600564D RID: 22093 RVA: 0x000A4518 File Offset: 0x000A2718
		private bool ShouldSerializeredblue()
		{
			return this.redblueSpecified;
		}

		// Token: 0x0600564E RID: 22094 RVA: 0x000A4530 File Offset: 0x000A2730
		private void Resetredblue()
		{
			this.redblueSpecified = false;
		}

		// Token: 0x17001ACB RID: 6859
		// (get) Token: 0x0600564F RID: 22095 RVA: 0x000A453C File Offset: 0x000A273C
		// (set) Token: 0x06005650 RID: 22096 RVA: 0x000A4568 File Offset: 0x000A2768
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

		// Token: 0x17001ACC RID: 6860
		// (get) Token: 0x06005651 RID: 22097 RVA: 0x000A4578 File Offset: 0x000A2778
		// (set) Token: 0x06005652 RID: 22098 RVA: 0x000A4598 File Offset: 0x000A2798
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

		// Token: 0x06005653 RID: 22099 RVA: 0x000A45DC File Offset: 0x000A27DC
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06005654 RID: 22100 RVA: 0x000A45F4 File Offset: 0x000A27F4
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001ACD RID: 6861
		// (get) Token: 0x06005655 RID: 22101 RVA: 0x000A4600 File Offset: 0x000A2800
		// (set) Token: 0x06005656 RID: 22102 RVA: 0x000A462C File Offset: 0x000A282C
		[ProtoMember(4, IsRequired = false, Name = "killCount", DataFormat = DataFormat.TwosComplement)]
		public uint killCount
		{
			get
			{
				return this._killCount ?? 0U;
			}
			set
			{
				this._killCount = new uint?(value);
			}
		}

		// Token: 0x17001ACE RID: 6862
		// (get) Token: 0x06005657 RID: 22103 RVA: 0x000A463C File Offset: 0x000A283C
		// (set) Token: 0x06005658 RID: 22104 RVA: 0x000A465C File Offset: 0x000A285C
		[XmlIgnore]
		[Browsable(false)]
		public bool killCountSpecified
		{
			get
			{
				return this._killCount != null;
			}
			set
			{
				bool flag = value == (this._killCount == null);
				if (flag)
				{
					this._killCount = (value ? new uint?(this.killCount) : null);
				}
			}
		}

		// Token: 0x06005659 RID: 22105 RVA: 0x000A46A0 File Offset: 0x000A28A0
		private bool ShouldSerializekillCount()
		{
			return this.killCountSpecified;
		}

		// Token: 0x0600565A RID: 22106 RVA: 0x000A46B8 File Offset: 0x000A28B8
		private void ResetkillCount()
		{
			this.killCountSpecified = false;
		}

		// Token: 0x17001ACF RID: 6863
		// (get) Token: 0x0600565B RID: 22107 RVA: 0x000A46C4 File Offset: 0x000A28C4
		// (set) Token: 0x0600565C RID: 22108 RVA: 0x000A46F0 File Offset: 0x000A28F0
		[ProtoMember(5, IsRequired = false, Name = "bekilledCount", DataFormat = DataFormat.TwosComplement)]
		public uint bekilledCount
		{
			get
			{
				return this._bekilledCount ?? 0U;
			}
			set
			{
				this._bekilledCount = new uint?(value);
			}
		}

		// Token: 0x17001AD0 RID: 6864
		// (get) Token: 0x0600565D RID: 22109 RVA: 0x000A4700 File Offset: 0x000A2900
		// (set) Token: 0x0600565E RID: 22110 RVA: 0x000A4720 File Offset: 0x000A2920
		[XmlIgnore]
		[Browsable(false)]
		public bool bekilledCountSpecified
		{
			get
			{
				return this._bekilledCount != null;
			}
			set
			{
				bool flag = value == (this._bekilledCount == null);
				if (flag)
				{
					this._bekilledCount = (value ? new uint?(this.bekilledCount) : null);
				}
			}
		}

		// Token: 0x0600565F RID: 22111 RVA: 0x000A4764 File Offset: 0x000A2964
		private bool ShouldSerializebekilledCount()
		{
			return this.bekilledCountSpecified;
		}

		// Token: 0x06005660 RID: 22112 RVA: 0x000A477C File Offset: 0x000A297C
		private void ResetbekilledCount()
		{
			this.bekilledCountSpecified = false;
		}

		// Token: 0x17001AD1 RID: 6865
		// (get) Token: 0x06005661 RID: 22113 RVA: 0x000A4788 File Offset: 0x000A2988
		// (set) Token: 0x06005662 RID: 22114 RVA: 0x000A47B4 File Offset: 0x000A29B4
		[ProtoMember(6, IsRequired = false, Name = "timeSeconds", DataFormat = DataFormat.TwosComplement)]
		public uint timeSeconds
		{
			get
			{
				return this._timeSeconds ?? 0U;
			}
			set
			{
				this._timeSeconds = new uint?(value);
			}
		}

		// Token: 0x17001AD2 RID: 6866
		// (get) Token: 0x06005663 RID: 22115 RVA: 0x000A47C4 File Offset: 0x000A29C4
		// (set) Token: 0x06005664 RID: 22116 RVA: 0x000A47E4 File Offset: 0x000A29E4
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSecondsSpecified
		{
			get
			{
				return this._timeSeconds != null;
			}
			set
			{
				bool flag = value == (this._timeSeconds == null);
				if (flag)
				{
					this._timeSeconds = (value ? new uint?(this.timeSeconds) : null);
				}
			}
		}

		// Token: 0x06005665 RID: 22117 RVA: 0x000A4828 File Offset: 0x000A2A28
		private bool ShouldSerializetimeSeconds()
		{
			return this.timeSecondsSpecified;
		}

		// Token: 0x06005666 RID: 22118 RVA: 0x000A4840 File Offset: 0x000A2A40
		private void ResettimeSeconds()
		{
			this.timeSecondsSpecified = false;
		}

		// Token: 0x17001AD3 RID: 6867
		// (get) Token: 0x06005667 RID: 22119 RVA: 0x000A484C File Offset: 0x000A2A4C
		// (set) Token: 0x06005668 RID: 22120 RVA: 0x000A486D File Offset: 0x000A2A6D
		[ProtoMember(7, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17001AD4 RID: 6868
		// (get) Token: 0x06005669 RID: 22121 RVA: 0x000A4878 File Offset: 0x000A2A78
		// (set) Token: 0x0600566A RID: 22122 RVA: 0x000A4894 File Offset: 0x000A2A94
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x0600566B RID: 22123 RVA: 0x000A48C4 File Offset: 0x000A2AC4
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x0600566C RID: 22124 RVA: 0x000A48DC File Offset: 0x000A2ADC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001AD5 RID: 6869
		// (get) Token: 0x0600566D RID: 22125 RVA: 0x000A48E8 File Offset: 0x000A2AE8
		// (set) Token: 0x0600566E RID: 22126 RVA: 0x000A4914 File Offset: 0x000A2B14
		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17001AD6 RID: 6870
		// (get) Token: 0x0600566F RID: 22127 RVA: 0x000A4924 File Offset: 0x000A2B24
		// (set) Token: 0x06005670 RID: 22128 RVA: 0x000A4944 File Offset: 0x000A2B44
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06005671 RID: 22129 RVA: 0x000A4988 File Offset: 0x000A2B88
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06005672 RID: 22130 RVA: 0x000A49A0 File Offset: 0x000A2BA0
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001AD7 RID: 6871
		// (get) Token: 0x06005673 RID: 22131 RVA: 0x000A49AC File Offset: 0x000A2BAC
		// (set) Token: 0x06005674 RID: 22132 RVA: 0x000A49D8 File Offset: 0x000A2BD8
		[ProtoMember(9, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
		public uint rolelevel
		{
			get
			{
				return this._rolelevel ?? 0U;
			}
			set
			{
				this._rolelevel = new uint?(value);
			}
		}

		// Token: 0x17001AD8 RID: 6872
		// (get) Token: 0x06005675 RID: 22133 RVA: 0x000A49E8 File Offset: 0x000A2BE8
		// (set) Token: 0x06005676 RID: 22134 RVA: 0x000A4A08 File Offset: 0x000A2C08
		[XmlIgnore]
		[Browsable(false)]
		public bool rolelevelSpecified
		{
			get
			{
				return this._rolelevel != null;
			}
			set
			{
				bool flag = value == (this._rolelevel == null);
				if (flag)
				{
					this._rolelevel = (value ? new uint?(this.rolelevel) : null);
				}
			}
		}

		// Token: 0x06005677 RID: 22135 RVA: 0x000A4A4C File Offset: 0x000A2C4C
		private bool ShouldSerializerolelevel()
		{
			return this.rolelevelSpecified;
		}

		// Token: 0x06005678 RID: 22136 RVA: 0x000A4A64 File Offset: 0x000A2C64
		private void Resetrolelevel()
		{
			this.rolelevelSpecified = false;
		}

		// Token: 0x17001AD9 RID: 6873
		// (get) Token: 0x06005679 RID: 22137 RVA: 0x000A4A70 File Offset: 0x000A2C70
		// (set) Token: 0x0600567A RID: 22138 RVA: 0x000A4A9C File Offset: 0x000A2C9C
		[ProtoMember(10, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001ADA RID: 6874
		// (get) Token: 0x0600567B RID: 22139 RVA: 0x000A4AAC File Offset: 0x000A2CAC
		// (set) Token: 0x0600567C RID: 22140 RVA: 0x000A4ACC File Offset: 0x000A2CCC
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

		// Token: 0x0600567D RID: 22141 RVA: 0x000A4B10 File Offset: 0x000A2D10
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600567E RID: 22142 RVA: 0x000A4B28 File Offset: 0x000A2D28
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001ADB RID: 6875
		// (get) Token: 0x0600567F RID: 22143 RVA: 0x000A4B34 File Offset: 0x000A2D34
		// (set) Token: 0x06005680 RID: 22144 RVA: 0x000A4B60 File Offset: 0x000A2D60
		[ProtoMember(11, IsRequired = false, Name = "isline", DataFormat = DataFormat.Default)]
		public bool isline
		{
			get
			{
				return this._isline ?? false;
			}
			set
			{
				this._isline = new bool?(value);
			}
		}

		// Token: 0x17001ADC RID: 6876
		// (get) Token: 0x06005681 RID: 22145 RVA: 0x000A4B70 File Offset: 0x000A2D70
		// (set) Token: 0x06005682 RID: 22146 RVA: 0x000A4B90 File Offset: 0x000A2D90
		[XmlIgnore]
		[Browsable(false)]
		public bool islineSpecified
		{
			get
			{
				return this._isline != null;
			}
			set
			{
				bool flag = value == (this._isline == null);
				if (flag)
				{
					this._isline = (value ? new bool?(this.isline) : null);
				}
			}
		}

		// Token: 0x06005683 RID: 22147 RVA: 0x000A4BD4 File Offset: 0x000A2DD4
		private bool ShouldSerializeisline()
		{
			return this.islineSpecified;
		}

		// Token: 0x06005684 RID: 22148 RVA: 0x000A4BEC File Offset: 0x000A2DEC
		private void Resetisline()
		{
			this.islineSpecified = false;
		}

		// Token: 0x06005685 RID: 22149 RVA: 0x000A4BF8 File Offset: 0x000A2DF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014FF RID: 5375
		private ulong? _roleid;

		// Token: 0x04001500 RID: 5376
		private uint? _redblue;

		// Token: 0x04001501 RID: 5377
		private uint? _score;

		// Token: 0x04001502 RID: 5378
		private uint? _killCount;

		// Token: 0x04001503 RID: 5379
		private uint? _bekilledCount;

		// Token: 0x04001504 RID: 5380
		private uint? _timeSeconds;

		// Token: 0x04001505 RID: 5381
		private string _rolename;

		// Token: 0x04001506 RID: 5382
		private uint? _profession;

		// Token: 0x04001507 RID: 5383
		private uint? _rolelevel;

		// Token: 0x04001508 RID: 5384
		private uint? _rank;

		// Token: 0x04001509 RID: 5385
		private bool? _isline;

		// Token: 0x0400150A RID: 5386
		private IExtension extensionObject;
	}
}
