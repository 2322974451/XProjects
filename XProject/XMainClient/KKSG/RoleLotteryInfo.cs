using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005EB RID: 1515
	[ProtoContract(Name = "RoleLotteryInfo")]
	[Serializable]
	public class RoleLotteryInfo : IExtensible
	{
		// Token: 0x17001BDC RID: 7132
		// (get) Token: 0x0600594C RID: 22860 RVA: 0x000A9E58 File Offset: 0x000A8058
		// (set) Token: 0x0600594D RID: 22861 RVA: 0x000A9E84 File Offset: 0x000A8084
		[ProtoMember(1, IsRequired = false, Name = "lastDrawTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastDrawTime
		{
			get
			{
				return this._lastDrawTime ?? 0U;
			}
			set
			{
				this._lastDrawTime = new uint?(value);
			}
		}

		// Token: 0x17001BDD RID: 7133
		// (get) Token: 0x0600594E RID: 22862 RVA: 0x000A9E94 File Offset: 0x000A8094
		// (set) Token: 0x0600594F RID: 22863 RVA: 0x000A9EB4 File Offset: 0x000A80B4
		[XmlIgnore]
		[Browsable(false)]
		public bool lastDrawTimeSpecified
		{
			get
			{
				return this._lastDrawTime != null;
			}
			set
			{
				bool flag = value == (this._lastDrawTime == null);
				if (flag)
				{
					this._lastDrawTime = (value ? new uint?(this.lastDrawTime) : null);
				}
			}
		}

		// Token: 0x06005950 RID: 22864 RVA: 0x000A9EF8 File Offset: 0x000A80F8
		private bool ShouldSerializelastDrawTime()
		{
			return this.lastDrawTimeSpecified;
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x000A9F10 File Offset: 0x000A8110
		private void ResetlastDrawTime()
		{
			this.lastDrawTimeSpecified = false;
		}

		// Token: 0x17001BDE RID: 7134
		// (get) Token: 0x06005952 RID: 22866 RVA: 0x000A9F1C File Offset: 0x000A811C
		// (set) Token: 0x06005953 RID: 22867 RVA: 0x000A9F48 File Offset: 0x000A8148
		[ProtoMember(2, IsRequired = false, Name = "OneDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint OneDrawCount
		{
			get
			{
				return this._OneDrawCount ?? 0U;
			}
			set
			{
				this._OneDrawCount = new uint?(value);
			}
		}

		// Token: 0x17001BDF RID: 7135
		// (get) Token: 0x06005954 RID: 22868 RVA: 0x000A9F58 File Offset: 0x000A8158
		// (set) Token: 0x06005955 RID: 22869 RVA: 0x000A9F78 File Offset: 0x000A8178
		[XmlIgnore]
		[Browsable(false)]
		public bool OneDrawCountSpecified
		{
			get
			{
				return this._OneDrawCount != null;
			}
			set
			{
				bool flag = value == (this._OneDrawCount == null);
				if (flag)
				{
					this._OneDrawCount = (value ? new uint?(this.OneDrawCount) : null);
				}
			}
		}

		// Token: 0x06005956 RID: 22870 RVA: 0x000A9FBC File Offset: 0x000A81BC
		private bool ShouldSerializeOneDrawCount()
		{
			return this.OneDrawCountSpecified;
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x000A9FD4 File Offset: 0x000A81D4
		private void ResetOneDrawCount()
		{
			this.OneDrawCountSpecified = false;
		}

		// Token: 0x17001BE0 RID: 7136
		// (get) Token: 0x06005958 RID: 22872 RVA: 0x000A9FE0 File Offset: 0x000A81E0
		// (set) Token: 0x06005959 RID: 22873 RVA: 0x000AA00C File Offset: 0x000A820C
		[ProtoMember(3, IsRequired = false, Name = "MinimumRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint MinimumRewardCount
		{
			get
			{
				return this._MinimumRewardCount ?? 0U;
			}
			set
			{
				this._MinimumRewardCount = new uint?(value);
			}
		}

		// Token: 0x17001BE1 RID: 7137
		// (get) Token: 0x0600595A RID: 22874 RVA: 0x000AA01C File Offset: 0x000A821C
		// (set) Token: 0x0600595B RID: 22875 RVA: 0x000AA03C File Offset: 0x000A823C
		[XmlIgnore]
		[Browsable(false)]
		public bool MinimumRewardCountSpecified
		{
			get
			{
				return this._MinimumRewardCount != null;
			}
			set
			{
				bool flag = value == (this._MinimumRewardCount == null);
				if (flag)
				{
					this._MinimumRewardCount = (value ? new uint?(this.MinimumRewardCount) : null);
				}
			}
		}

		// Token: 0x0600595C RID: 22876 RVA: 0x000AA080 File Offset: 0x000A8280
		private bool ShouldSerializeMinimumRewardCount()
		{
			return this.MinimumRewardCountSpecified;
		}

		// Token: 0x0600595D RID: 22877 RVA: 0x000AA098 File Offset: 0x000A8298
		private void ResetMinimumRewardCount()
		{
			this.MinimumRewardCountSpecified = false;
		}

		// Token: 0x17001BE2 RID: 7138
		// (get) Token: 0x0600595E RID: 22878 RVA: 0x000AA0A4 File Offset: 0x000A82A4
		// (set) Token: 0x0600595F RID: 22879 RVA: 0x000AA0D0 File Offset: 0x000A82D0
		[ProtoMember(4, IsRequired = false, Name = "goldFreeDrawTime", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawTime
		{
			get
			{
				return this._goldFreeDrawTime ?? 0U;
			}
			set
			{
				this._goldFreeDrawTime = new uint?(value);
			}
		}

		// Token: 0x17001BE3 RID: 7139
		// (get) Token: 0x06005960 RID: 22880 RVA: 0x000AA0E0 File Offset: 0x000A82E0
		// (set) Token: 0x06005961 RID: 22881 RVA: 0x000AA100 File Offset: 0x000A8300
		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawTimeSpecified
		{
			get
			{
				return this._goldFreeDrawTime != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawTime == null);
				if (flag)
				{
					this._goldFreeDrawTime = (value ? new uint?(this.goldFreeDrawTime) : null);
				}
			}
		}

		// Token: 0x06005962 RID: 22882 RVA: 0x000AA144 File Offset: 0x000A8344
		private bool ShouldSerializegoldFreeDrawTime()
		{
			return this.goldFreeDrawTimeSpecified;
		}

		// Token: 0x06005963 RID: 22883 RVA: 0x000AA15C File Offset: 0x000A835C
		private void ResetgoldFreeDrawTime()
		{
			this.goldFreeDrawTimeSpecified = false;
		}

		// Token: 0x17001BE4 RID: 7140
		// (get) Token: 0x06005964 RID: 22884 RVA: 0x000AA168 File Offset: 0x000A8368
		// (set) Token: 0x06005965 RID: 22885 RVA: 0x000AA194 File Offset: 0x000A8394
		[ProtoMember(5, IsRequired = false, Name = "goldFreeDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawCount
		{
			get
			{
				return this._goldFreeDrawCount ?? 0U;
			}
			set
			{
				this._goldFreeDrawCount = new uint?(value);
			}
		}

		// Token: 0x17001BE5 RID: 7141
		// (get) Token: 0x06005966 RID: 22886 RVA: 0x000AA1A4 File Offset: 0x000A83A4
		// (set) Token: 0x06005967 RID: 22887 RVA: 0x000AA1C4 File Offset: 0x000A83C4
		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawCountSpecified
		{
			get
			{
				return this._goldFreeDrawCount != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawCount == null);
				if (flag)
				{
					this._goldFreeDrawCount = (value ? new uint?(this.goldFreeDrawCount) : null);
				}
			}
		}

		// Token: 0x06005968 RID: 22888 RVA: 0x000AA208 File Offset: 0x000A8408
		private bool ShouldSerializegoldFreeDrawCount()
		{
			return this.goldFreeDrawCountSpecified;
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x000AA220 File Offset: 0x000A8420
		private void ResetgoldFreeDrawCount()
		{
			this.goldFreeDrawCountSpecified = false;
		}

		// Token: 0x17001BE6 RID: 7142
		// (get) Token: 0x0600596A RID: 22890 RVA: 0x000AA22C File Offset: 0x000A842C
		// (set) Token: 0x0600596B RID: 22891 RVA: 0x000AA258 File Offset: 0x000A8458
		[ProtoMember(6, IsRequired = false, Name = "goldFreeDrawDay", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawDay
		{
			get
			{
				return this._goldFreeDrawDay ?? 0U;
			}
			set
			{
				this._goldFreeDrawDay = new uint?(value);
			}
		}

		// Token: 0x17001BE7 RID: 7143
		// (get) Token: 0x0600596C RID: 22892 RVA: 0x000AA268 File Offset: 0x000A8468
		// (set) Token: 0x0600596D RID: 22893 RVA: 0x000AA288 File Offset: 0x000A8488
		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawDaySpecified
		{
			get
			{
				return this._goldFreeDrawDay != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawDay == null);
				if (flag)
				{
					this._goldFreeDrawDay = (value ? new uint?(this.goldFreeDrawDay) : null);
				}
			}
		}

		// Token: 0x0600596E RID: 22894 RVA: 0x000AA2CC File Offset: 0x000A84CC
		private bool ShouldSerializegoldFreeDrawDay()
		{
			return this.goldFreeDrawDaySpecified;
		}

		// Token: 0x0600596F RID: 22895 RVA: 0x000AA2E4 File Offset: 0x000A84E4
		private void ResetgoldFreeDrawDay()
		{
			this.goldFreeDrawDaySpecified = false;
		}

		// Token: 0x17001BE8 RID: 7144
		// (get) Token: 0x06005970 RID: 22896 RVA: 0x000AA2F0 File Offset: 0x000A84F0
		// (set) Token: 0x06005971 RID: 22897 RVA: 0x000AA31C File Offset: 0x000A851C
		[ProtoMember(7, IsRequired = false, Name = "goldOneDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldOneDrawCount
		{
			get
			{
				return this._goldOneDrawCount ?? 0U;
			}
			set
			{
				this._goldOneDrawCount = new uint?(value);
			}
		}

		// Token: 0x17001BE9 RID: 7145
		// (get) Token: 0x06005972 RID: 22898 RVA: 0x000AA32C File Offset: 0x000A852C
		// (set) Token: 0x06005973 RID: 22899 RVA: 0x000AA34C File Offset: 0x000A854C
		[XmlIgnore]
		[Browsable(false)]
		public bool goldOneDrawCountSpecified
		{
			get
			{
				return this._goldOneDrawCount != null;
			}
			set
			{
				bool flag = value == (this._goldOneDrawCount == null);
				if (flag)
				{
					this._goldOneDrawCount = (value ? new uint?(this.goldOneDrawCount) : null);
				}
			}
		}

		// Token: 0x06005974 RID: 22900 RVA: 0x000AA390 File Offset: 0x000A8590
		private bool ShouldSerializegoldOneDrawCount()
		{
			return this.goldOneDrawCountSpecified;
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x000AA3A8 File Offset: 0x000A85A8
		private void ResetgoldOneDrawCount()
		{
			this.goldOneDrawCountSpecified = false;
		}

		// Token: 0x17001BEA RID: 7146
		// (get) Token: 0x06005976 RID: 22902 RVA: 0x000AA3B4 File Offset: 0x000A85B4
		// (set) Token: 0x06005977 RID: 22903 RVA: 0x000AA3E0 File Offset: 0x000A85E0
		[ProtoMember(8, IsRequired = false, Name = "goldMinimumRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldMinimumRewardCount
		{
			get
			{
				return this._goldMinimumRewardCount ?? 0U;
			}
			set
			{
				this._goldMinimumRewardCount = new uint?(value);
			}
		}

		// Token: 0x17001BEB RID: 7147
		// (get) Token: 0x06005978 RID: 22904 RVA: 0x000AA3F0 File Offset: 0x000A85F0
		// (set) Token: 0x06005979 RID: 22905 RVA: 0x000AA410 File Offset: 0x000A8610
		[XmlIgnore]
		[Browsable(false)]
		public bool goldMinimumRewardCountSpecified
		{
			get
			{
				return this._goldMinimumRewardCount != null;
			}
			set
			{
				bool flag = value == (this._goldMinimumRewardCount == null);
				if (flag)
				{
					this._goldMinimumRewardCount = (value ? new uint?(this.goldMinimumRewardCount) : null);
				}
			}
		}

		// Token: 0x0600597A RID: 22906 RVA: 0x000AA454 File Offset: 0x000A8654
		private bool ShouldSerializegoldMinimumRewardCount()
		{
			return this.goldMinimumRewardCountSpecified;
		}

		// Token: 0x0600597B RID: 22907 RVA: 0x000AA46C File Offset: 0x000A866C
		private void ResetgoldMinimumRewardCount()
		{
			this.goldMinimumRewardCountSpecified = false;
		}

		// Token: 0x17001BEC RID: 7148
		// (get) Token: 0x0600597C RID: 22908 RVA: 0x000AA478 File Offset: 0x000A8678
		// (set) Token: 0x0600597D RID: 22909 RVA: 0x000AA4A4 File Offset: 0x000A86A4
		[ProtoMember(9, IsRequired = false, Name = "clickday", DataFormat = DataFormat.TwosComplement)]
		public uint clickday
		{
			get
			{
				return this._clickday ?? 0U;
			}
			set
			{
				this._clickday = new uint?(value);
			}
		}

		// Token: 0x17001BED RID: 7149
		// (get) Token: 0x0600597E RID: 22910 RVA: 0x000AA4B4 File Offset: 0x000A86B4
		// (set) Token: 0x0600597F RID: 22911 RVA: 0x000AA4D4 File Offset: 0x000A86D4
		[XmlIgnore]
		[Browsable(false)]
		public bool clickdaySpecified
		{
			get
			{
				return this._clickday != null;
			}
			set
			{
				bool flag = value == (this._clickday == null);
				if (flag)
				{
					this._clickday = (value ? new uint?(this.clickday) : null);
				}
			}
		}

		// Token: 0x06005980 RID: 22912 RVA: 0x000AA518 File Offset: 0x000A8718
		private bool ShouldSerializeclickday()
		{
			return this.clickdaySpecified;
		}

		// Token: 0x06005981 RID: 22913 RVA: 0x000AA530 File Offset: 0x000A8730
		private void Resetclickday()
		{
			this.clickdaySpecified = false;
		}

		// Token: 0x17001BEE RID: 7150
		// (get) Token: 0x06005982 RID: 22914 RVA: 0x000AA53C File Offset: 0x000A873C
		// (set) Token: 0x06005983 RID: 22915 RVA: 0x000AA568 File Offset: 0x000A8768
		[ProtoMember(10, IsRequired = false, Name = "clickfreetime", DataFormat = DataFormat.TwosComplement)]
		public uint clickfreetime
		{
			get
			{
				return this._clickfreetime ?? 0U;
			}
			set
			{
				this._clickfreetime = new uint?(value);
			}
		}

		// Token: 0x17001BEF RID: 7151
		// (get) Token: 0x06005984 RID: 22916 RVA: 0x000AA578 File Offset: 0x000A8778
		// (set) Token: 0x06005985 RID: 22917 RVA: 0x000AA598 File Offset: 0x000A8798
		[XmlIgnore]
		[Browsable(false)]
		public bool clickfreetimeSpecified
		{
			get
			{
				return this._clickfreetime != null;
			}
			set
			{
				bool flag = value == (this._clickfreetime == null);
				if (flag)
				{
					this._clickfreetime = (value ? new uint?(this.clickfreetime) : null);
				}
			}
		}

		// Token: 0x06005986 RID: 22918 RVA: 0x000AA5DC File Offset: 0x000A87DC
		private bool ShouldSerializeclickfreetime()
		{
			return this.clickfreetimeSpecified;
		}

		// Token: 0x06005987 RID: 22919 RVA: 0x000AA5F4 File Offset: 0x000A87F4
		private void Resetclickfreetime()
		{
			this.clickfreetimeSpecified = false;
		}

		// Token: 0x17001BF0 RID: 7152
		// (get) Token: 0x06005988 RID: 22920 RVA: 0x000AA600 File Offset: 0x000A8800
		// (set) Token: 0x06005989 RID: 22921 RVA: 0x000AA62C File Offset: 0x000A882C
		[ProtoMember(11, IsRequired = false, Name = "clickfreecount", DataFormat = DataFormat.TwosComplement)]
		public uint clickfreecount
		{
			get
			{
				return this._clickfreecount ?? 0U;
			}
			set
			{
				this._clickfreecount = new uint?(value);
			}
		}

		// Token: 0x17001BF1 RID: 7153
		// (get) Token: 0x0600598A RID: 22922 RVA: 0x000AA63C File Offset: 0x000A883C
		// (set) Token: 0x0600598B RID: 22923 RVA: 0x000AA65C File Offset: 0x000A885C
		[XmlIgnore]
		[Browsable(false)]
		public bool clickfreecountSpecified
		{
			get
			{
				return this._clickfreecount != null;
			}
			set
			{
				bool flag = value == (this._clickfreecount == null);
				if (flag)
				{
					this._clickfreecount = (value ? new uint?(this.clickfreecount) : null);
				}
			}
		}

		// Token: 0x0600598C RID: 22924 RVA: 0x000AA6A0 File Offset: 0x000A88A0
		private bool ShouldSerializeclickfreecount()
		{
			return this.clickfreecountSpecified;
		}

		// Token: 0x0600598D RID: 22925 RVA: 0x000AA6B8 File Offset: 0x000A88B8
		private void Resetclickfreecount()
		{
			this.clickfreecountSpecified = false;
		}

		// Token: 0x17001BF2 RID: 7154
		// (get) Token: 0x0600598E RID: 22926 RVA: 0x000AA6C4 File Offset: 0x000A88C4
		// (set) Token: 0x0600598F RID: 22927 RVA: 0x000AA6F0 File Offset: 0x000A88F0
		[ProtoMember(12, IsRequired = false, Name = "clickcostcount", DataFormat = DataFormat.TwosComplement)]
		public uint clickcostcount
		{
			get
			{
				return this._clickcostcount ?? 0U;
			}
			set
			{
				this._clickcostcount = new uint?(value);
			}
		}

		// Token: 0x17001BF3 RID: 7155
		// (get) Token: 0x06005990 RID: 22928 RVA: 0x000AA700 File Offset: 0x000A8900
		// (set) Token: 0x06005991 RID: 22929 RVA: 0x000AA720 File Offset: 0x000A8920
		[XmlIgnore]
		[Browsable(false)]
		public bool clickcostcountSpecified
		{
			get
			{
				return this._clickcostcount != null;
			}
			set
			{
				bool flag = value == (this._clickcostcount == null);
				if (flag)
				{
					this._clickcostcount = (value ? new uint?(this.clickcostcount) : null);
				}
			}
		}

		// Token: 0x06005992 RID: 22930 RVA: 0x000AA764 File Offset: 0x000A8964
		private bool ShouldSerializeclickcostcount()
		{
			return this.clickcostcountSpecified;
		}

		// Token: 0x06005993 RID: 22931 RVA: 0x000AA77C File Offset: 0x000A897C
		private void Resetclickcostcount()
		{
			this.clickcostcountSpecified = false;
		}

		// Token: 0x17001BF4 RID: 7156
		// (get) Token: 0x06005994 RID: 22932 RVA: 0x000AA788 File Offset: 0x000A8988
		[ProtoMember(13, Name = "pandora", DataFormat = DataFormat.Default)]
		public List<PandoraDrop> pandora
		{
			get
			{
				return this._pandora;
			}
		}

		// Token: 0x17001BF5 RID: 7157
		// (get) Token: 0x06005995 RID: 22933 RVA: 0x000AA7A0 File Offset: 0x000A89A0
		// (set) Token: 0x06005996 RID: 22934 RVA: 0x000AA7CC File Offset: 0x000A89CC
		[ProtoMember(14, IsRequired = false, Name = "lastGiftUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastGiftUpdateTime
		{
			get
			{
				return this._lastGiftUpdateTime ?? 0U;
			}
			set
			{
				this._lastGiftUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001BF6 RID: 7158
		// (get) Token: 0x06005997 RID: 22935 RVA: 0x000AA7DC File Offset: 0x000A89DC
		// (set) Token: 0x06005998 RID: 22936 RVA: 0x000AA7FC File Offset: 0x000A89FC
		[XmlIgnore]
		[Browsable(false)]
		public bool lastGiftUpdateTimeSpecified
		{
			get
			{
				return this._lastGiftUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastGiftUpdateTime == null);
				if (flag)
				{
					this._lastGiftUpdateTime = (value ? new uint?(this.lastGiftUpdateTime) : null);
				}
			}
		}

		// Token: 0x06005999 RID: 22937 RVA: 0x000AA840 File Offset: 0x000A8A40
		private bool ShouldSerializelastGiftUpdateTime()
		{
			return this.lastGiftUpdateTimeSpecified;
		}

		// Token: 0x0600599A RID: 22938 RVA: 0x000AA858 File Offset: 0x000A8A58
		private void ResetlastGiftUpdateTime()
		{
			this.lastGiftUpdateTimeSpecified = false;
		}

		// Token: 0x17001BF7 RID: 7159
		// (get) Token: 0x0600599B RID: 22939 RVA: 0x000AA864 File Offset: 0x000A8A64
		// (set) Token: 0x0600599C RID: 22940 RVA: 0x000AA890 File Offset: 0x000A8A90
		[ProtoMember(15, IsRequired = false, Name = "shareGiftCount", DataFormat = DataFormat.TwosComplement)]
		public uint shareGiftCount
		{
			get
			{
				return this._shareGiftCount ?? 0U;
			}
			set
			{
				this._shareGiftCount = new uint?(value);
			}
		}

		// Token: 0x17001BF8 RID: 7160
		// (get) Token: 0x0600599D RID: 22941 RVA: 0x000AA8A0 File Offset: 0x000A8AA0
		// (set) Token: 0x0600599E RID: 22942 RVA: 0x000AA8C0 File Offset: 0x000A8AC0
		[XmlIgnore]
		[Browsable(false)]
		public bool shareGiftCountSpecified
		{
			get
			{
				return this._shareGiftCount != null;
			}
			set
			{
				bool flag = value == (this._shareGiftCount == null);
				if (flag)
				{
					this._shareGiftCount = (value ? new uint?(this.shareGiftCount) : null);
				}
			}
		}

		// Token: 0x0600599F RID: 22943 RVA: 0x000AA904 File Offset: 0x000A8B04
		private bool ShouldSerializeshareGiftCount()
		{
			return this.shareGiftCountSpecified;
		}

		// Token: 0x060059A0 RID: 22944 RVA: 0x000AA91C File Offset: 0x000A8B1C
		private void ResetshareGiftCount()
		{
			this.shareGiftCountSpecified = false;
		}

		// Token: 0x17001BF9 RID: 7161
		// (get) Token: 0x060059A1 RID: 22945 RVA: 0x000AA928 File Offset: 0x000A8B28
		// (set) Token: 0x060059A2 RID: 22946 RVA: 0x000AA954 File Offset: 0x000A8B54
		[ProtoMember(16, IsRequired = false, Name = "spriteMinGuarantee", DataFormat = DataFormat.TwosComplement)]
		public uint spriteMinGuarantee
		{
			get
			{
				return this._spriteMinGuarantee ?? 0U;
			}
			set
			{
				this._spriteMinGuarantee = new uint?(value);
			}
		}

		// Token: 0x17001BFA RID: 7162
		// (get) Token: 0x060059A3 RID: 22947 RVA: 0x000AA964 File Offset: 0x000A8B64
		// (set) Token: 0x060059A4 RID: 22948 RVA: 0x000AA984 File Offset: 0x000A8B84
		[XmlIgnore]
		[Browsable(false)]
		public bool spriteMinGuaranteeSpecified
		{
			get
			{
				return this._spriteMinGuarantee != null;
			}
			set
			{
				bool flag = value == (this._spriteMinGuarantee == null);
				if (flag)
				{
					this._spriteMinGuarantee = (value ? new uint?(this.spriteMinGuarantee) : null);
				}
			}
		}

		// Token: 0x060059A5 RID: 22949 RVA: 0x000AA9C8 File Offset: 0x000A8BC8
		private bool ShouldSerializespriteMinGuarantee()
		{
			return this.spriteMinGuaranteeSpecified;
		}

		// Token: 0x060059A6 RID: 22950 RVA: 0x000AA9E0 File Offset: 0x000A8BE0
		private void ResetspriteMinGuarantee()
		{
			this.spriteMinGuaranteeSpecified = false;
		}

		// Token: 0x17001BFB RID: 7163
		// (get) Token: 0x060059A7 RID: 22951 RVA: 0x000AA9EC File Offset: 0x000A8BEC
		// (set) Token: 0x060059A8 RID: 22952 RVA: 0x000AAA18 File Offset: 0x000A8C18
		[ProtoMember(17, IsRequired = false, Name = "spriteNextMinGuarantee", DataFormat = DataFormat.TwosComplement)]
		public uint spriteNextMinGuarantee
		{
			get
			{
				return this._spriteNextMinGuarantee ?? 0U;
			}
			set
			{
				this._spriteNextMinGuarantee = new uint?(value);
			}
		}

		// Token: 0x17001BFC RID: 7164
		// (get) Token: 0x060059A9 RID: 22953 RVA: 0x000AAA28 File Offset: 0x000A8C28
		// (set) Token: 0x060059AA RID: 22954 RVA: 0x000AAA48 File Offset: 0x000A8C48
		[XmlIgnore]
		[Browsable(false)]
		public bool spriteNextMinGuaranteeSpecified
		{
			get
			{
				return this._spriteNextMinGuarantee != null;
			}
			set
			{
				bool flag = value == (this._spriteNextMinGuarantee == null);
				if (flag)
				{
					this._spriteNextMinGuarantee = (value ? new uint?(this.spriteNextMinGuarantee) : null);
				}
			}
		}

		// Token: 0x060059AB RID: 22955 RVA: 0x000AAA8C File Offset: 0x000A8C8C
		private bool ShouldSerializespriteNextMinGuarantee()
		{
			return this.spriteNextMinGuaranteeSpecified;
		}

		// Token: 0x060059AC RID: 22956 RVA: 0x000AAAA4 File Offset: 0x000A8CA4
		private void ResetspriteNextMinGuarantee()
		{
			this.spriteNextMinGuaranteeSpecified = false;
		}

		// Token: 0x060059AD RID: 22957 RVA: 0x000AAAB0 File Offset: 0x000A8CB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015BD RID: 5565
		private uint? _lastDrawTime;

		// Token: 0x040015BE RID: 5566
		private uint? _OneDrawCount;

		// Token: 0x040015BF RID: 5567
		private uint? _MinimumRewardCount;

		// Token: 0x040015C0 RID: 5568
		private uint? _goldFreeDrawTime;

		// Token: 0x040015C1 RID: 5569
		private uint? _goldFreeDrawCount;

		// Token: 0x040015C2 RID: 5570
		private uint? _goldFreeDrawDay;

		// Token: 0x040015C3 RID: 5571
		private uint? _goldOneDrawCount;

		// Token: 0x040015C4 RID: 5572
		private uint? _goldMinimumRewardCount;

		// Token: 0x040015C5 RID: 5573
		private uint? _clickday;

		// Token: 0x040015C6 RID: 5574
		private uint? _clickfreetime;

		// Token: 0x040015C7 RID: 5575
		private uint? _clickfreecount;

		// Token: 0x040015C8 RID: 5576
		private uint? _clickcostcount;

		// Token: 0x040015C9 RID: 5577
		private readonly List<PandoraDrop> _pandora = new List<PandoraDrop>();

		// Token: 0x040015CA RID: 5578
		private uint? _lastGiftUpdateTime;

		// Token: 0x040015CB RID: 5579
		private uint? _shareGiftCount;

		// Token: 0x040015CC RID: 5580
		private uint? _spriteMinGuarantee;

		// Token: 0x040015CD RID: 5581
		private uint? _spriteNextMinGuarantee;

		// Token: 0x040015CE RID: 5582
		private IExtension extensionObject;
	}
}
