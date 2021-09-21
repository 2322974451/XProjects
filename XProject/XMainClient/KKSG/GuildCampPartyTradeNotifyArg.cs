using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000400 RID: 1024
	[ProtoContract(Name = "GuildCampPartyTradeNotifyArg")]
	[Serializable]
	public class GuildCampPartyTradeNotifyArg : IExtensible
	{
		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x0600362D RID: 13869 RVA: 0x00067C74 File Offset: 0x00065E74
		// (set) Token: 0x0600362E RID: 13870 RVA: 0x00067CA0 File Offset: 0x00065EA0
		[ProtoMember(1, IsRequired = false, Name = "notify_type", DataFormat = DataFormat.TwosComplement)]
		public GuildCampPartyTradeType notify_type
		{
			get
			{
				return this._notify_type ?? GuildCampPartyTradeType.TRADE_INVITATION;
			}
			set
			{
				this._notify_type = new GuildCampPartyTradeType?(value);
			}
		}

		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x0600362F RID: 13871 RVA: 0x00067CB0 File Offset: 0x00065EB0
		// (set) Token: 0x06003630 RID: 13872 RVA: 0x00067CD0 File Offset: 0x00065ED0
		[XmlIgnore]
		[Browsable(false)]
		public bool notify_typeSpecified
		{
			get
			{
				return this._notify_type != null;
			}
			set
			{
				bool flag = value == (this._notify_type == null);
				if (flag)
				{
					this._notify_type = (value ? new GuildCampPartyTradeType?(this.notify_type) : null);
				}
			}
		}

		// Token: 0x06003631 RID: 13873 RVA: 0x00067D14 File Offset: 0x00065F14
		private bool ShouldSerializenotify_type()
		{
			return this.notify_typeSpecified;
		}

		// Token: 0x06003632 RID: 13874 RVA: 0x00067D2C File Offset: 0x00065F2C
		private void Resetnotify_type()
		{
			this.notify_typeSpecified = false;
		}

		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06003633 RID: 13875 RVA: 0x00067D38 File Offset: 0x00065F38
		// (set) Token: 0x06003634 RID: 13876 RVA: 0x00067D65 File Offset: 0x00065F65
		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0UL;
			}
			set
			{
				this._lauch_role_id = new ulong?(value);
			}
		}

		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06003635 RID: 13877 RVA: 0x00067D74 File Offset: 0x00065F74
		// (set) Token: 0x06003636 RID: 13878 RVA: 0x00067D94 File Offset: 0x00065F94
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new ulong?(this.lauch_role_id) : null);
				}
			}
		}

		// Token: 0x06003637 RID: 13879 RVA: 0x00067DD8 File Offset: 0x00065FD8
		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		// Token: 0x06003638 RID: 13880 RVA: 0x00067DF0 File Offset: 0x00065FF0
		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06003639 RID: 13881 RVA: 0x00067DFC File Offset: 0x00065FFC
		// (set) Token: 0x0600363A RID: 13882 RVA: 0x00067E28 File Offset: 0x00066028
		[ProtoMember(3, IsRequired = false, Name = "lauch_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_item_id
		{
			get
			{
				return this._lauch_item_id ?? 0U;
			}
			set
			{
				this._lauch_item_id = new uint?(value);
			}
		}

		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x0600363B RID: 13883 RVA: 0x00067E38 File Offset: 0x00066038
		// (set) Token: 0x0600363C RID: 13884 RVA: 0x00067E58 File Offset: 0x00066058
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_idSpecified
		{
			get
			{
				return this._lauch_item_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_id == null);
				if (flag)
				{
					this._lauch_item_id = (value ? new uint?(this.lauch_item_id) : null);
				}
			}
		}

		// Token: 0x0600363D RID: 13885 RVA: 0x00067E9C File Offset: 0x0006609C
		private bool ShouldSerializelauch_item_id()
		{
			return this.lauch_item_idSpecified;
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x00067EB4 File Offset: 0x000660B4
		private void Resetlauch_item_id()
		{
			this.lauch_item_idSpecified = false;
		}

		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x0600363F RID: 13887 RVA: 0x00067EC0 File Offset: 0x000660C0
		// (set) Token: 0x06003640 RID: 13888 RVA: 0x00067EED File Offset: 0x000660ED
		[ProtoMember(4, IsRequired = false, Name = "lauch_item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_item_uid
		{
			get
			{
				return this._lauch_item_uid ?? 0UL;
			}
			set
			{
				this._lauch_item_uid = new ulong?(value);
			}
		}

		// Token: 0x170010AF RID: 4271
		// (get) Token: 0x06003641 RID: 13889 RVA: 0x00067EFC File Offset: 0x000660FC
		// (set) Token: 0x06003642 RID: 13890 RVA: 0x00067F1C File Offset: 0x0006611C
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_uidSpecified
		{
			get
			{
				return this._lauch_item_uid != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_uid == null);
				if (flag)
				{
					this._lauch_item_uid = (value ? new ulong?(this.lauch_item_uid) : null);
				}
			}
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x00067F60 File Offset: 0x00066160
		private bool ShouldSerializelauch_item_uid()
		{
			return this.lauch_item_uidSpecified;
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x00067F78 File Offset: 0x00066178
		private void Resetlauch_item_uid()
		{
			this.lauch_item_uidSpecified = false;
		}

		// Token: 0x170010B0 RID: 4272
		// (get) Token: 0x06003645 RID: 13893 RVA: 0x00067F84 File Offset: 0x00066184
		// (set) Token: 0x06003646 RID: 13894 RVA: 0x00067FB0 File Offset: 0x000661B0
		[ProtoMember(5, IsRequired = false, Name = "lauch_confirm", DataFormat = DataFormat.Default)]
		public bool lauch_confirm
		{
			get
			{
				return this._lauch_confirm ?? false;
			}
			set
			{
				this._lauch_confirm = new bool?(value);
			}
		}

		// Token: 0x170010B1 RID: 4273
		// (get) Token: 0x06003647 RID: 13895 RVA: 0x00067FC0 File Offset: 0x000661C0
		// (set) Token: 0x06003648 RID: 13896 RVA: 0x00067FE0 File Offset: 0x000661E0
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_confirmSpecified
		{
			get
			{
				return this._lauch_confirm != null;
			}
			set
			{
				bool flag = value == (this._lauch_confirm == null);
				if (flag)
				{
					this._lauch_confirm = (value ? new bool?(this.lauch_confirm) : null);
				}
			}
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x00068024 File Offset: 0x00066224
		private bool ShouldSerializelauch_confirm()
		{
			return this.lauch_confirmSpecified;
		}

		// Token: 0x0600364A RID: 13898 RVA: 0x0006803C File Offset: 0x0006623C
		private void Resetlauch_confirm()
		{
			this.lauch_confirmSpecified = false;
		}

		// Token: 0x170010B2 RID: 4274
		// (get) Token: 0x0600364B RID: 13899 RVA: 0x00068048 File Offset: 0x00066248
		// (set) Token: 0x0600364C RID: 13900 RVA: 0x00068075 File Offset: 0x00066275
		[ProtoMember(6, IsRequired = false, Name = "target_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong target_role_id
		{
			get
			{
				return this._target_role_id ?? 0UL;
			}
			set
			{
				this._target_role_id = new ulong?(value);
			}
		}

		// Token: 0x170010B3 RID: 4275
		// (get) Token: 0x0600364D RID: 13901 RVA: 0x00068084 File Offset: 0x00066284
		// (set) Token: 0x0600364E RID: 13902 RVA: 0x000680A4 File Offset: 0x000662A4
		[XmlIgnore]
		[Browsable(false)]
		public bool target_role_idSpecified
		{
			get
			{
				return this._target_role_id != null;
			}
			set
			{
				bool flag = value == (this._target_role_id == null);
				if (flag)
				{
					this._target_role_id = (value ? new ulong?(this.target_role_id) : null);
				}
			}
		}

		// Token: 0x0600364F RID: 13903 RVA: 0x000680E8 File Offset: 0x000662E8
		private bool ShouldSerializetarget_role_id()
		{
			return this.target_role_idSpecified;
		}

		// Token: 0x06003650 RID: 13904 RVA: 0x00068100 File Offset: 0x00066300
		private void Resettarget_role_id()
		{
			this.target_role_idSpecified = false;
		}

		// Token: 0x170010B4 RID: 4276
		// (get) Token: 0x06003651 RID: 13905 RVA: 0x0006810C File Offset: 0x0006630C
		// (set) Token: 0x06003652 RID: 13906 RVA: 0x00068138 File Offset: 0x00066338
		[ProtoMember(7, IsRequired = false, Name = "target_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_item_id
		{
			get
			{
				return this._target_item_id ?? 0U;
			}
			set
			{
				this._target_item_id = new uint?(value);
			}
		}

		// Token: 0x170010B5 RID: 4277
		// (get) Token: 0x06003653 RID: 13907 RVA: 0x00068148 File Offset: 0x00066348
		// (set) Token: 0x06003654 RID: 13908 RVA: 0x00068168 File Offset: 0x00066368
		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_idSpecified
		{
			get
			{
				return this._target_item_id != null;
			}
			set
			{
				bool flag = value == (this._target_item_id == null);
				if (flag)
				{
					this._target_item_id = (value ? new uint?(this.target_item_id) : null);
				}
			}
		}

		// Token: 0x06003655 RID: 13909 RVA: 0x000681AC File Offset: 0x000663AC
		private bool ShouldSerializetarget_item_id()
		{
			return this.target_item_idSpecified;
		}

		// Token: 0x06003656 RID: 13910 RVA: 0x000681C4 File Offset: 0x000663C4
		private void Resettarget_item_id()
		{
			this.target_item_idSpecified = false;
		}

		// Token: 0x170010B6 RID: 4278
		// (get) Token: 0x06003657 RID: 13911 RVA: 0x000681D0 File Offset: 0x000663D0
		// (set) Token: 0x06003658 RID: 13912 RVA: 0x000681FD File Offset: 0x000663FD
		[ProtoMember(8, IsRequired = false, Name = "target_item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong target_item_uid
		{
			get
			{
				return this._target_item_uid ?? 0UL;
			}
			set
			{
				this._target_item_uid = new ulong?(value);
			}
		}

		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x06003659 RID: 13913 RVA: 0x0006820C File Offset: 0x0006640C
		// (set) Token: 0x0600365A RID: 13914 RVA: 0x0006822C File Offset: 0x0006642C
		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_uidSpecified
		{
			get
			{
				return this._target_item_uid != null;
			}
			set
			{
				bool flag = value == (this._target_item_uid == null);
				if (flag)
				{
					this._target_item_uid = (value ? new ulong?(this.target_item_uid) : null);
				}
			}
		}

		// Token: 0x0600365B RID: 13915 RVA: 0x00068270 File Offset: 0x00066470
		private bool ShouldSerializetarget_item_uid()
		{
			return this.target_item_uidSpecified;
		}

		// Token: 0x0600365C RID: 13916 RVA: 0x00068288 File Offset: 0x00066488
		private void Resettarget_item_uid()
		{
			this.target_item_uidSpecified = false;
		}

		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x0600365D RID: 13917 RVA: 0x00068294 File Offset: 0x00066494
		// (set) Token: 0x0600365E RID: 13918 RVA: 0x000682C0 File Offset: 0x000664C0
		[ProtoMember(9, IsRequired = false, Name = "target_confirm", DataFormat = DataFormat.Default)]
		public bool target_confirm
		{
			get
			{
				return this._target_confirm ?? false;
			}
			set
			{
				this._target_confirm = new bool?(value);
			}
		}

		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x0600365F RID: 13919 RVA: 0x000682D0 File Offset: 0x000664D0
		// (set) Token: 0x06003660 RID: 13920 RVA: 0x000682F0 File Offset: 0x000664F0
		[XmlIgnore]
		[Browsable(false)]
		public bool target_confirmSpecified
		{
			get
			{
				return this._target_confirm != null;
			}
			set
			{
				bool flag = value == (this._target_confirm == null);
				if (flag)
				{
					this._target_confirm = (value ? new bool?(this.target_confirm) : null);
				}
			}
		}

		// Token: 0x06003661 RID: 13921 RVA: 0x00068334 File Offset: 0x00066534
		private bool ShouldSerializetarget_confirm()
		{
			return this.target_confirmSpecified;
		}

		// Token: 0x06003662 RID: 13922 RVA: 0x0006834C File Offset: 0x0006654C
		private void Resettarget_confirm()
		{
			this.target_confirmSpecified = false;
		}

		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x06003663 RID: 13923 RVA: 0x00068358 File Offset: 0x00066558
		// (set) Token: 0x06003664 RID: 13924 RVA: 0x00068384 File Offset: 0x00066584
		[ProtoMember(10, IsRequired = false, Name = "lauch_count", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_count
		{
			get
			{
				return this._lauch_count ?? 0U;
			}
			set
			{
				this._lauch_count = new uint?(value);
			}
		}

		// Token: 0x170010BB RID: 4283
		// (get) Token: 0x06003665 RID: 13925 RVA: 0x00068394 File Offset: 0x00066594
		// (set) Token: 0x06003666 RID: 13926 RVA: 0x000683B4 File Offset: 0x000665B4
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_countSpecified
		{
			get
			{
				return this._lauch_count != null;
			}
			set
			{
				bool flag = value == (this._lauch_count == null);
				if (flag)
				{
					this._lauch_count = (value ? new uint?(this.lauch_count) : null);
				}
			}
		}

		// Token: 0x06003667 RID: 13927 RVA: 0x000683F8 File Offset: 0x000665F8
		private bool ShouldSerializelauch_count()
		{
			return this.lauch_countSpecified;
		}

		// Token: 0x06003668 RID: 13928 RVA: 0x00068410 File Offset: 0x00066610
		private void Resetlauch_count()
		{
			this.lauch_countSpecified = false;
		}

		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06003669 RID: 13929 RVA: 0x0006841C File Offset: 0x0006661C
		// (set) Token: 0x0600366A RID: 13930 RVA: 0x00068448 File Offset: 0x00066648
		[ProtoMember(11, IsRequired = false, Name = "open_trade", DataFormat = DataFormat.Default)]
		public bool open_trade
		{
			get
			{
				return this._open_trade ?? false;
			}
			set
			{
				this._open_trade = new bool?(value);
			}
		}

		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x0600366B RID: 13931 RVA: 0x00068458 File Offset: 0x00066658
		// (set) Token: 0x0600366C RID: 13932 RVA: 0x00068478 File Offset: 0x00066678
		[XmlIgnore]
		[Browsable(false)]
		public bool open_tradeSpecified
		{
			get
			{
				return this._open_trade != null;
			}
			set
			{
				bool flag = value == (this._open_trade == null);
				if (flag)
				{
					this._open_trade = (value ? new bool?(this.open_trade) : null);
				}
			}
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x000684BC File Offset: 0x000666BC
		private bool ShouldSerializeopen_trade()
		{
			return this.open_tradeSpecified;
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x000684D4 File Offset: 0x000666D4
		private void Resetopen_trade()
		{
			this.open_tradeSpecified = false;
		}

		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x0600366F RID: 13935 RVA: 0x000684E0 File Offset: 0x000666E0
		// (set) Token: 0x06003670 RID: 13936 RVA: 0x00068501 File Offset: 0x00066701
		[ProtoMember(12, IsRequired = false, Name = "lauch_name", DataFormat = DataFormat.Default)]
		public string lauch_name
		{
			get
			{
				return this._lauch_name ?? "";
			}
			set
			{
				this._lauch_name = value;
			}
		}

		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06003671 RID: 13937 RVA: 0x0006850C File Offset: 0x0006670C
		// (set) Token: 0x06003672 RID: 13938 RVA: 0x00068528 File Offset: 0x00066728
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_nameSpecified
		{
			get
			{
				return this._lauch_name != null;
			}
			set
			{
				bool flag = value == (this._lauch_name == null);
				if (flag)
				{
					this._lauch_name = (value ? this.lauch_name : null);
				}
			}
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x00068558 File Offset: 0x00066758
		private bool ShouldSerializelauch_name()
		{
			return this.lauch_nameSpecified;
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x00068570 File Offset: 0x00066770
		private void Resetlauch_name()
		{
			this.lauch_nameSpecified = false;
		}

		// Token: 0x170010C0 RID: 4288
		// (get) Token: 0x06003675 RID: 13941 RVA: 0x0006857C File Offset: 0x0006677C
		// (set) Token: 0x06003676 RID: 13942 RVA: 0x000685A8 File Offset: 0x000667A8
		[ProtoMember(13, IsRequired = false, Name = "lauch_profession", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_profession
		{
			get
			{
				return this._lauch_profession ?? 0U;
			}
			set
			{
				this._lauch_profession = new uint?(value);
			}
		}

		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06003677 RID: 13943 RVA: 0x000685B8 File Offset: 0x000667B8
		// (set) Token: 0x06003678 RID: 13944 RVA: 0x000685D8 File Offset: 0x000667D8
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_professionSpecified
		{
			get
			{
				return this._lauch_profession != null;
			}
			set
			{
				bool flag = value == (this._lauch_profession == null);
				if (flag)
				{
					this._lauch_profession = (value ? new uint?(this.lauch_profession) : null);
				}
			}
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x0006861C File Offset: 0x0006681C
		private bool ShouldSerializelauch_profession()
		{
			return this.lauch_professionSpecified;
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x00068634 File Offset: 0x00066834
		private void Resetlauch_profession()
		{
			this.lauch_professionSpecified = false;
		}

		// Token: 0x170010C2 RID: 4290
		// (get) Token: 0x0600367B RID: 13947 RVA: 0x00068640 File Offset: 0x00066840
		// (set) Token: 0x0600367C RID: 13948 RVA: 0x00068661 File Offset: 0x00066861
		[ProtoMember(14, IsRequired = false, Name = "target_name", DataFormat = DataFormat.Default)]
		public string target_name
		{
			get
			{
				return this._target_name ?? "";
			}
			set
			{
				this._target_name = value;
			}
		}

		// Token: 0x170010C3 RID: 4291
		// (get) Token: 0x0600367D RID: 13949 RVA: 0x0006866C File Offset: 0x0006686C
		// (set) Token: 0x0600367E RID: 13950 RVA: 0x00068688 File Offset: 0x00066888
		[XmlIgnore]
		[Browsable(false)]
		public bool target_nameSpecified
		{
			get
			{
				return this._target_name != null;
			}
			set
			{
				bool flag = value == (this._target_name == null);
				if (flag)
				{
					this._target_name = (value ? this.target_name : null);
				}
			}
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x000686B8 File Offset: 0x000668B8
		private bool ShouldSerializetarget_name()
		{
			return this.target_nameSpecified;
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x000686D0 File Offset: 0x000668D0
		private void Resettarget_name()
		{
			this.target_nameSpecified = false;
		}

		// Token: 0x170010C4 RID: 4292
		// (get) Token: 0x06003681 RID: 13953 RVA: 0x000686DC File Offset: 0x000668DC
		// (set) Token: 0x06003682 RID: 13954 RVA: 0x00068708 File Offset: 0x00066908
		[ProtoMember(15, IsRequired = false, Name = "target_profession", DataFormat = DataFormat.TwosComplement)]
		public uint target_profession
		{
			get
			{
				return this._target_profession ?? 0U;
			}
			set
			{
				this._target_profession = new uint?(value);
			}
		}

		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x06003683 RID: 13955 RVA: 0x00068718 File Offset: 0x00066918
		// (set) Token: 0x06003684 RID: 13956 RVA: 0x00068738 File Offset: 0x00066938
		[XmlIgnore]
		[Browsable(false)]
		public bool target_professionSpecified
		{
			get
			{
				return this._target_profession != null;
			}
			set
			{
				bool flag = value == (this._target_profession == null);
				if (flag)
				{
					this._target_profession = (value ? new uint?(this.target_profession) : null);
				}
			}
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x0006877C File Offset: 0x0006697C
		private bool ShouldSerializetarget_profession()
		{
			return this.target_professionSpecified;
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x00068794 File Offset: 0x00066994
		private void Resettarget_profession()
		{
			this.target_professionSpecified = false;
		}

		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x06003687 RID: 13959 RVA: 0x000687A0 File Offset: 0x000669A0
		// (set) Token: 0x06003688 RID: 13960 RVA: 0x000687B8 File Offset: 0x000669B8
		[ProtoMember(16, IsRequired = false, Name = "lauch_chat_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildCampChatInfo lauch_chat_info
		{
			get
			{
				return this._lauch_chat_info;
			}
			set
			{
				this._lauch_chat_info = value;
			}
		}

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06003689 RID: 13961 RVA: 0x000687C4 File Offset: 0x000669C4
		// (set) Token: 0x0600368A RID: 13962 RVA: 0x000687DC File Offset: 0x000669DC
		[ProtoMember(17, IsRequired = false, Name = "target_chat_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildCampChatInfo target_chat_info
		{
			get
			{
				return this._target_chat_info;
			}
			set
			{
				this._target_chat_info = value;
			}
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x000687E8 File Offset: 0x000669E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D78 RID: 3448
		private GuildCampPartyTradeType? _notify_type;

		// Token: 0x04000D79 RID: 3449
		private ulong? _lauch_role_id;

		// Token: 0x04000D7A RID: 3450
		private uint? _lauch_item_id;

		// Token: 0x04000D7B RID: 3451
		private ulong? _lauch_item_uid;

		// Token: 0x04000D7C RID: 3452
		private bool? _lauch_confirm;

		// Token: 0x04000D7D RID: 3453
		private ulong? _target_role_id;

		// Token: 0x04000D7E RID: 3454
		private uint? _target_item_id;

		// Token: 0x04000D7F RID: 3455
		private ulong? _target_item_uid;

		// Token: 0x04000D80 RID: 3456
		private bool? _target_confirm;

		// Token: 0x04000D81 RID: 3457
		private uint? _lauch_count;

		// Token: 0x04000D82 RID: 3458
		private bool? _open_trade;

		// Token: 0x04000D83 RID: 3459
		private string _lauch_name;

		// Token: 0x04000D84 RID: 3460
		private uint? _lauch_profession;

		// Token: 0x04000D85 RID: 3461
		private string _target_name;

		// Token: 0x04000D86 RID: 3462
		private uint? _target_profession;

		// Token: 0x04000D87 RID: 3463
		private GuildCampChatInfo _lauch_chat_info = null;

		// Token: 0x04000D88 RID: 3464
		private GuildCampChatInfo _target_chat_info = null;

		// Token: 0x04000D89 RID: 3465
		private IExtension extensionObject;
	}
}
