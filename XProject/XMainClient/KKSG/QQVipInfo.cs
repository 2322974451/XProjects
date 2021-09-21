using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065A RID: 1626
	[ProtoContract(Name = "QQVipInfo")]
	[Serializable]
	public class QQVipInfo : IExtensible
	{
		// Token: 0x17001FEE RID: 8174
		// (get) Token: 0x06006535 RID: 25909 RVA: 0x000C12E4 File Offset: 0x000BF4E4
		// (set) Token: 0x06006536 RID: 25910 RVA: 0x000C1310 File Offset: 0x000BF510
		[ProtoMember(1, IsRequired = false, Name = "is_vip", DataFormat = DataFormat.Default)]
		public bool is_vip
		{
			get
			{
				return this._is_vip ?? false;
			}
			set
			{
				this._is_vip = new bool?(value);
			}
		}

		// Token: 0x17001FEF RID: 8175
		// (get) Token: 0x06006537 RID: 25911 RVA: 0x000C1320 File Offset: 0x000BF520
		// (set) Token: 0x06006538 RID: 25912 RVA: 0x000C1340 File Offset: 0x000BF540
		[XmlIgnore]
		[Browsable(false)]
		public bool is_vipSpecified
		{
			get
			{
				return this._is_vip != null;
			}
			set
			{
				bool flag = value == (this._is_vip == null);
				if (flag)
				{
					this._is_vip = (value ? new bool?(this.is_vip) : null);
				}
			}
		}

		// Token: 0x06006539 RID: 25913 RVA: 0x000C1384 File Offset: 0x000BF584
		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		// Token: 0x0600653A RID: 25914 RVA: 0x000C139C File Offset: 0x000BF59C
		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		// Token: 0x17001FF0 RID: 8176
		// (get) Token: 0x0600653B RID: 25915 RVA: 0x000C13A8 File Offset: 0x000BF5A8
		// (set) Token: 0x0600653C RID: 25916 RVA: 0x000C13D4 File Offset: 0x000BF5D4
		[ProtoMember(2, IsRequired = false, Name = "is_svip", DataFormat = DataFormat.Default)]
		public bool is_svip
		{
			get
			{
				return this._is_svip ?? false;
			}
			set
			{
				this._is_svip = new bool?(value);
			}
		}

		// Token: 0x17001FF1 RID: 8177
		// (get) Token: 0x0600653D RID: 25917 RVA: 0x000C13E4 File Offset: 0x000BF5E4
		// (set) Token: 0x0600653E RID: 25918 RVA: 0x000C1404 File Offset: 0x000BF604
		[XmlIgnore]
		[Browsable(false)]
		public bool is_svipSpecified
		{
			get
			{
				return this._is_svip != null;
			}
			set
			{
				bool flag = value == (this._is_svip == null);
				if (flag)
				{
					this._is_svip = (value ? new bool?(this.is_svip) : null);
				}
			}
		}

		// Token: 0x0600653F RID: 25919 RVA: 0x000C1448 File Offset: 0x000BF648
		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		// Token: 0x06006540 RID: 25920 RVA: 0x000C1460 File Offset: 0x000BF660
		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		// Token: 0x17001FF2 RID: 8178
		// (get) Token: 0x06006541 RID: 25921 RVA: 0x000C146C File Offset: 0x000BF66C
		// (set) Token: 0x06006542 RID: 25922 RVA: 0x000C1498 File Offset: 0x000BF698
		[ProtoMember(3, IsRequired = false, Name = "is_year_vip", DataFormat = DataFormat.Default)]
		public bool is_year_vip
		{
			get
			{
				return this._is_year_vip ?? false;
			}
			set
			{
				this._is_year_vip = new bool?(value);
			}
		}

		// Token: 0x17001FF3 RID: 8179
		// (get) Token: 0x06006543 RID: 25923 RVA: 0x000C14A8 File Offset: 0x000BF6A8
		// (set) Token: 0x06006544 RID: 25924 RVA: 0x000C14C8 File Offset: 0x000BF6C8
		[XmlIgnore]
		[Browsable(false)]
		public bool is_year_vipSpecified
		{
			get
			{
				return this._is_year_vip != null;
			}
			set
			{
				bool flag = value == (this._is_year_vip == null);
				if (flag)
				{
					this._is_year_vip = (value ? new bool?(this.is_year_vip) : null);
				}
			}
		}

		// Token: 0x06006545 RID: 25925 RVA: 0x000C150C File Offset: 0x000BF70C
		private bool ShouldSerializeis_year_vip()
		{
			return this.is_year_vipSpecified;
		}

		// Token: 0x06006546 RID: 25926 RVA: 0x000C1524 File Offset: 0x000BF724
		private void Resetis_year_vip()
		{
			this.is_year_vipSpecified = false;
		}

		// Token: 0x17001FF4 RID: 8180
		// (get) Token: 0x06006547 RID: 25927 RVA: 0x000C1530 File Offset: 0x000BF730
		// (set) Token: 0x06006548 RID: 25928 RVA: 0x000C155C File Offset: 0x000BF75C
		[ProtoMember(4, IsRequired = false, Name = "qq_vip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip_start
		{
			get
			{
				return this._qq_vip_start ?? 0U;
			}
			set
			{
				this._qq_vip_start = new uint?(value);
			}
		}

		// Token: 0x17001FF5 RID: 8181
		// (get) Token: 0x06006549 RID: 25929 RVA: 0x000C156C File Offset: 0x000BF76C
		// (set) Token: 0x0600654A RID: 25930 RVA: 0x000C158C File Offset: 0x000BF78C
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vip_startSpecified
		{
			get
			{
				return this._qq_vip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_vip_start == null);
				if (flag)
				{
					this._qq_vip_start = (value ? new uint?(this.qq_vip_start) : null);
				}
			}
		}

		// Token: 0x0600654B RID: 25931 RVA: 0x000C15D0 File Offset: 0x000BF7D0
		private bool ShouldSerializeqq_vip_start()
		{
			return this.qq_vip_startSpecified;
		}

		// Token: 0x0600654C RID: 25932 RVA: 0x000C15E8 File Offset: 0x000BF7E8
		private void Resetqq_vip_start()
		{
			this.qq_vip_startSpecified = false;
		}

		// Token: 0x17001FF6 RID: 8182
		// (get) Token: 0x0600654D RID: 25933 RVA: 0x000C15F4 File Offset: 0x000BF7F4
		// (set) Token: 0x0600654E RID: 25934 RVA: 0x000C1620 File Offset: 0x000BF820
		[ProtoMember(5, IsRequired = false, Name = "qq_vip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip_end
		{
			get
			{
				return this._qq_vip_end ?? 0U;
			}
			set
			{
				this._qq_vip_end = new uint?(value);
			}
		}

		// Token: 0x17001FF7 RID: 8183
		// (get) Token: 0x0600654F RID: 25935 RVA: 0x000C1630 File Offset: 0x000BF830
		// (set) Token: 0x06006550 RID: 25936 RVA: 0x000C1650 File Offset: 0x000BF850
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vip_endSpecified
		{
			get
			{
				return this._qq_vip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_vip_end == null);
				if (flag)
				{
					this._qq_vip_end = (value ? new uint?(this.qq_vip_end) : null);
				}
			}
		}

		// Token: 0x06006551 RID: 25937 RVA: 0x000C1694 File Offset: 0x000BF894
		private bool ShouldSerializeqq_vip_end()
		{
			return this.qq_vip_endSpecified;
		}

		// Token: 0x06006552 RID: 25938 RVA: 0x000C16AC File Offset: 0x000BF8AC
		private void Resetqq_vip_end()
		{
			this.qq_vip_endSpecified = false;
		}

		// Token: 0x17001FF8 RID: 8184
		// (get) Token: 0x06006553 RID: 25939 RVA: 0x000C16B8 File Offset: 0x000BF8B8
		// (set) Token: 0x06006554 RID: 25940 RVA: 0x000C16E4 File Offset: 0x000BF8E4
		[ProtoMember(6, IsRequired = false, Name = "qq_svip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_svip_start
		{
			get
			{
				return this._qq_svip_start ?? 0U;
			}
			set
			{
				this._qq_svip_start = new uint?(value);
			}
		}

		// Token: 0x17001FF9 RID: 8185
		// (get) Token: 0x06006555 RID: 25941 RVA: 0x000C16F4 File Offset: 0x000BF8F4
		// (set) Token: 0x06006556 RID: 25942 RVA: 0x000C1714 File Offset: 0x000BF914
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_svip_startSpecified
		{
			get
			{
				return this._qq_svip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_svip_start == null);
				if (flag)
				{
					this._qq_svip_start = (value ? new uint?(this.qq_svip_start) : null);
				}
			}
		}

		// Token: 0x06006557 RID: 25943 RVA: 0x000C1758 File Offset: 0x000BF958
		private bool ShouldSerializeqq_svip_start()
		{
			return this.qq_svip_startSpecified;
		}

		// Token: 0x06006558 RID: 25944 RVA: 0x000C1770 File Offset: 0x000BF970
		private void Resetqq_svip_start()
		{
			this.qq_svip_startSpecified = false;
		}

		// Token: 0x17001FFA RID: 8186
		// (get) Token: 0x06006559 RID: 25945 RVA: 0x000C177C File Offset: 0x000BF97C
		// (set) Token: 0x0600655A RID: 25946 RVA: 0x000C17A8 File Offset: 0x000BF9A8
		[ProtoMember(7, IsRequired = false, Name = "qq_svip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_svip_end
		{
			get
			{
				return this._qq_svip_end ?? 0U;
			}
			set
			{
				this._qq_svip_end = new uint?(value);
			}
		}

		// Token: 0x17001FFB RID: 8187
		// (get) Token: 0x0600655B RID: 25947 RVA: 0x000C17B8 File Offset: 0x000BF9B8
		// (set) Token: 0x0600655C RID: 25948 RVA: 0x000C17D8 File Offset: 0x000BF9D8
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_svip_endSpecified
		{
			get
			{
				return this._qq_svip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_svip_end == null);
				if (flag)
				{
					this._qq_svip_end = (value ? new uint?(this.qq_svip_end) : null);
				}
			}
		}

		// Token: 0x0600655D RID: 25949 RVA: 0x000C181C File Offset: 0x000BFA1C
		private bool ShouldSerializeqq_svip_end()
		{
			return this.qq_svip_endSpecified;
		}

		// Token: 0x0600655E RID: 25950 RVA: 0x000C1834 File Offset: 0x000BFA34
		private void Resetqq_svip_end()
		{
			this.qq_svip_endSpecified = false;
		}

		// Token: 0x17001FFC RID: 8188
		// (get) Token: 0x0600655F RID: 25951 RVA: 0x000C1840 File Offset: 0x000BFA40
		// (set) Token: 0x06006560 RID: 25952 RVA: 0x000C186C File Offset: 0x000BFA6C
		[ProtoMember(8, IsRequired = false, Name = "qq_year_vip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_year_vip_start
		{
			get
			{
				return this._qq_year_vip_start ?? 0U;
			}
			set
			{
				this._qq_year_vip_start = new uint?(value);
			}
		}

		// Token: 0x17001FFD RID: 8189
		// (get) Token: 0x06006561 RID: 25953 RVA: 0x000C187C File Offset: 0x000BFA7C
		// (set) Token: 0x06006562 RID: 25954 RVA: 0x000C189C File Offset: 0x000BFA9C
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_year_vip_startSpecified
		{
			get
			{
				return this._qq_year_vip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_year_vip_start == null);
				if (flag)
				{
					this._qq_year_vip_start = (value ? new uint?(this.qq_year_vip_start) : null);
				}
			}
		}

		// Token: 0x06006563 RID: 25955 RVA: 0x000C18E0 File Offset: 0x000BFAE0
		private bool ShouldSerializeqq_year_vip_start()
		{
			return this.qq_year_vip_startSpecified;
		}

		// Token: 0x06006564 RID: 25956 RVA: 0x000C18F8 File Offset: 0x000BFAF8
		private void Resetqq_year_vip_start()
		{
			this.qq_year_vip_startSpecified = false;
		}

		// Token: 0x17001FFE RID: 8190
		// (get) Token: 0x06006565 RID: 25957 RVA: 0x000C1904 File Offset: 0x000BFB04
		// (set) Token: 0x06006566 RID: 25958 RVA: 0x000C1930 File Offset: 0x000BFB30
		[ProtoMember(9, IsRequired = false, Name = "qq_year_vip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_year_vip_end
		{
			get
			{
				return this._qq_year_vip_end ?? 0U;
			}
			set
			{
				this._qq_year_vip_end = new uint?(value);
			}
		}

		// Token: 0x17001FFF RID: 8191
		// (get) Token: 0x06006567 RID: 25959 RVA: 0x000C1940 File Offset: 0x000BFB40
		// (set) Token: 0x06006568 RID: 25960 RVA: 0x000C1960 File Offset: 0x000BFB60
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_year_vip_endSpecified
		{
			get
			{
				return this._qq_year_vip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_year_vip_end == null);
				if (flag)
				{
					this._qq_year_vip_end = (value ? new uint?(this.qq_year_vip_end) : null);
				}
			}
		}

		// Token: 0x06006569 RID: 25961 RVA: 0x000C19A4 File Offset: 0x000BFBA4
		private bool ShouldSerializeqq_year_vip_end()
		{
			return this.qq_year_vip_endSpecified;
		}

		// Token: 0x0600656A RID: 25962 RVA: 0x000C19BC File Offset: 0x000BFBBC
		private void Resetqq_year_vip_end()
		{
			this.qq_year_vip_endSpecified = false;
		}

		// Token: 0x17002000 RID: 8192
		// (get) Token: 0x0600656B RID: 25963 RVA: 0x000C19C8 File Offset: 0x000BFBC8
		// (set) Token: 0x0600656C RID: 25964 RVA: 0x000C19F4 File Offset: 0x000BFBF4
		[ProtoMember(10, IsRequired = false, Name = "vip_newbie_rewarded", DataFormat = DataFormat.Default)]
		public bool vip_newbie_rewarded
		{
			get
			{
				return this._vip_newbie_rewarded ?? false;
			}
			set
			{
				this._vip_newbie_rewarded = new bool?(value);
			}
		}

		// Token: 0x17002001 RID: 8193
		// (get) Token: 0x0600656D RID: 25965 RVA: 0x000C1A04 File Offset: 0x000BFC04
		// (set) Token: 0x0600656E RID: 25966 RVA: 0x000C1A24 File Offset: 0x000BFC24
		[XmlIgnore]
		[Browsable(false)]
		public bool vip_newbie_rewardedSpecified
		{
			get
			{
				return this._vip_newbie_rewarded != null;
			}
			set
			{
				bool flag = value == (this._vip_newbie_rewarded == null);
				if (flag)
				{
					this._vip_newbie_rewarded = (value ? new bool?(this.vip_newbie_rewarded) : null);
				}
			}
		}

		// Token: 0x0600656F RID: 25967 RVA: 0x000C1A68 File Offset: 0x000BFC68
		private bool ShouldSerializevip_newbie_rewarded()
		{
			return this.vip_newbie_rewardedSpecified;
		}

		// Token: 0x06006570 RID: 25968 RVA: 0x000C1A80 File Offset: 0x000BFC80
		private void Resetvip_newbie_rewarded()
		{
			this.vip_newbie_rewardedSpecified = false;
		}

		// Token: 0x17002002 RID: 8194
		// (get) Token: 0x06006571 RID: 25969 RVA: 0x000C1A8C File Offset: 0x000BFC8C
		// (set) Token: 0x06006572 RID: 25970 RVA: 0x000C1AB8 File Offset: 0x000BFCB8
		[ProtoMember(11, IsRequired = false, Name = "svip_newbie_rewarded", DataFormat = DataFormat.Default)]
		public bool svip_newbie_rewarded
		{
			get
			{
				return this._svip_newbie_rewarded ?? false;
			}
			set
			{
				this._svip_newbie_rewarded = new bool?(value);
			}
		}

		// Token: 0x17002003 RID: 8195
		// (get) Token: 0x06006573 RID: 25971 RVA: 0x000C1AC8 File Offset: 0x000BFCC8
		// (set) Token: 0x06006574 RID: 25972 RVA: 0x000C1AE8 File Offset: 0x000BFCE8
		[XmlIgnore]
		[Browsable(false)]
		public bool svip_newbie_rewardedSpecified
		{
			get
			{
				return this._svip_newbie_rewarded != null;
			}
			set
			{
				bool flag = value == (this._svip_newbie_rewarded == null);
				if (flag)
				{
					this._svip_newbie_rewarded = (value ? new bool?(this.svip_newbie_rewarded) : null);
				}
			}
		}

		// Token: 0x06006575 RID: 25973 RVA: 0x000C1B2C File Offset: 0x000BFD2C
		private bool ShouldSerializesvip_newbie_rewarded()
		{
			return this.svip_newbie_rewardedSpecified;
		}

		// Token: 0x06006576 RID: 25974 RVA: 0x000C1B44 File Offset: 0x000BFD44
		private void Resetsvip_newbie_rewarded()
		{
			this.svip_newbie_rewardedSpecified = false;
		}

		// Token: 0x17002004 RID: 8196
		// (get) Token: 0x06006577 RID: 25975 RVA: 0x000C1B50 File Offset: 0x000BFD50
		// (set) Token: 0x06006578 RID: 25976 RVA: 0x000C1B7C File Offset: 0x000BFD7C
		[ProtoMember(12, IsRequired = false, Name = "is_xinyue_vip", DataFormat = DataFormat.Default)]
		public bool is_xinyue_vip
		{
			get
			{
				return this._is_xinyue_vip ?? false;
			}
			set
			{
				this._is_xinyue_vip = new bool?(value);
			}
		}

		// Token: 0x17002005 RID: 8197
		// (get) Token: 0x06006579 RID: 25977 RVA: 0x000C1B8C File Offset: 0x000BFD8C
		// (set) Token: 0x0600657A RID: 25978 RVA: 0x000C1BAC File Offset: 0x000BFDAC
		[XmlIgnore]
		[Browsable(false)]
		public bool is_xinyue_vipSpecified
		{
			get
			{
				return this._is_xinyue_vip != null;
			}
			set
			{
				bool flag = value == (this._is_xinyue_vip == null);
				if (flag)
				{
					this._is_xinyue_vip = (value ? new bool?(this.is_xinyue_vip) : null);
				}
			}
		}

		// Token: 0x0600657B RID: 25979 RVA: 0x000C1BF0 File Offset: 0x000BFDF0
		private bool ShouldSerializeis_xinyue_vip()
		{
			return this.is_xinyue_vipSpecified;
		}

		// Token: 0x0600657C RID: 25980 RVA: 0x000C1C08 File Offset: 0x000BFE08
		private void Resetis_xinyue_vip()
		{
			this.is_xinyue_vipSpecified = false;
		}

		// Token: 0x0600657D RID: 25981 RVA: 0x000C1C14 File Offset: 0x000BFE14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400188A RID: 6282
		private bool? _is_vip;

		// Token: 0x0400188B RID: 6283
		private bool? _is_svip;

		// Token: 0x0400188C RID: 6284
		private bool? _is_year_vip;

		// Token: 0x0400188D RID: 6285
		private uint? _qq_vip_start;

		// Token: 0x0400188E RID: 6286
		private uint? _qq_vip_end;

		// Token: 0x0400188F RID: 6287
		private uint? _qq_svip_start;

		// Token: 0x04001890 RID: 6288
		private uint? _qq_svip_end;

		// Token: 0x04001891 RID: 6289
		private uint? _qq_year_vip_start;

		// Token: 0x04001892 RID: 6290
		private uint? _qq_year_vip_end;

		// Token: 0x04001893 RID: 6291
		private bool? _vip_newbie_rewarded;

		// Token: 0x04001894 RID: 6292
		private bool? _svip_newbie_rewarded;

		// Token: 0x04001895 RID: 6293
		private bool? _is_xinyue_vip;

		// Token: 0x04001896 RID: 6294
		private IExtension extensionObject;
	}
}
