using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066E RID: 1646
	[ProtoContract(Name = "PlatformShareResult")]
	[Serializable]
	public class PlatformShareResult : IExtensible
	{
		// Token: 0x1700210A RID: 8458
		// (get) Token: 0x06006881 RID: 26753 RVA: 0x000C7BE8 File Offset: 0x000C5DE8
		// (set) Token: 0x06006882 RID: 26754 RVA: 0x000C7C14 File Offset: 0x000C5E14
		[ProtoMember(1, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		// Token: 0x1700210B RID: 8459
		// (get) Token: 0x06006883 RID: 26755 RVA: 0x000C7C24 File Offset: 0x000C5E24
		// (set) Token: 0x06006884 RID: 26756 RVA: 0x000C7C44 File Offset: 0x000C5E44
		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		// Token: 0x06006885 RID: 26757 RVA: 0x000C7C88 File Offset: 0x000C5E88
		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		// Token: 0x06006886 RID: 26758 RVA: 0x000C7CA0 File Offset: 0x000C5EA0
		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		// Token: 0x1700210C RID: 8460
		// (get) Token: 0x06006887 RID: 26759 RVA: 0x000C7CAC File Offset: 0x000C5EAC
		[ProtoMember(2, Name = "firstpass_share_list", DataFormat = DataFormat.Default)]
		public List<MapIntItem> firstpass_share_list
		{
			get
			{
				return this._firstpass_share_list;
			}
		}

		// Token: 0x1700210D RID: 8461
		// (get) Token: 0x06006888 RID: 26760 RVA: 0x000C7CC4 File Offset: 0x000C5EC4
		// (set) Token: 0x06006889 RID: 26761 RVA: 0x000C7CF0 File Offset: 0x000C5EF0
		[ProtoMember(3, IsRequired = false, Name = "weekly_share_number", DataFormat = DataFormat.TwosComplement)]
		public uint weekly_share_number
		{
			get
			{
				return this._weekly_share_number ?? 0U;
			}
			set
			{
				this._weekly_share_number = new uint?(value);
			}
		}

		// Token: 0x1700210E RID: 8462
		// (get) Token: 0x0600688A RID: 26762 RVA: 0x000C7D00 File Offset: 0x000C5F00
		// (set) Token: 0x0600688B RID: 26763 RVA: 0x000C7D20 File Offset: 0x000C5F20
		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_share_numberSpecified
		{
			get
			{
				return this._weekly_share_number != null;
			}
			set
			{
				bool flag = value == (this._weekly_share_number == null);
				if (flag)
				{
					this._weekly_share_number = (value ? new uint?(this.weekly_share_number) : null);
				}
			}
		}

		// Token: 0x0600688C RID: 26764 RVA: 0x000C7D64 File Offset: 0x000C5F64
		private bool ShouldSerializeweekly_share_number()
		{
			return this.weekly_share_numberSpecified;
		}

		// Token: 0x0600688D RID: 26765 RVA: 0x000C7D7C File Offset: 0x000C5F7C
		private void Resetweekly_share_number()
		{
			this.weekly_share_numberSpecified = false;
		}

		// Token: 0x1700210F RID: 8463
		// (get) Token: 0x0600688E RID: 26766 RVA: 0x000C7D88 File Offset: 0x000C5F88
		// (set) Token: 0x0600688F RID: 26767 RVA: 0x000C7DB4 File Offset: 0x000C5FB4
		[ProtoMember(4, IsRequired = false, Name = "weekly_award", DataFormat = DataFormat.Default)]
		public bool weekly_award
		{
			get
			{
				return this._weekly_award ?? false;
			}
			set
			{
				this._weekly_award = new bool?(value);
			}
		}

		// Token: 0x17002110 RID: 8464
		// (get) Token: 0x06006890 RID: 26768 RVA: 0x000C7DC4 File Offset: 0x000C5FC4
		// (set) Token: 0x06006891 RID: 26769 RVA: 0x000C7DE4 File Offset: 0x000C5FE4
		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_awardSpecified
		{
			get
			{
				return this._weekly_award != null;
			}
			set
			{
				bool flag = value == (this._weekly_award == null);
				if (flag)
				{
					this._weekly_award = (value ? new bool?(this.weekly_award) : null);
				}
			}
		}

		// Token: 0x06006892 RID: 26770 RVA: 0x000C7E28 File Offset: 0x000C6028
		private bool ShouldSerializeweekly_award()
		{
			return this.weekly_awardSpecified;
		}

		// Token: 0x06006893 RID: 26771 RVA: 0x000C7E40 File Offset: 0x000C6040
		private void Resetweekly_award()
		{
			this.weekly_awardSpecified = false;
		}

		// Token: 0x17002111 RID: 8465
		// (get) Token: 0x06006894 RID: 26772 RVA: 0x000C7E4C File Offset: 0x000C604C
		// (set) Token: 0x06006895 RID: 26773 RVA: 0x000C7E78 File Offset: 0x000C6078
		[ProtoMember(5, IsRequired = false, Name = "disappear_redpoint", DataFormat = DataFormat.Default)]
		public bool disappear_redpoint
		{
			get
			{
				return this._disappear_redpoint ?? false;
			}
			set
			{
				this._disappear_redpoint = new bool?(value);
			}
		}

		// Token: 0x17002112 RID: 8466
		// (get) Token: 0x06006896 RID: 26774 RVA: 0x000C7E88 File Offset: 0x000C6088
		// (set) Token: 0x06006897 RID: 26775 RVA: 0x000C7EA8 File Offset: 0x000C60A8
		[XmlIgnore]
		[Browsable(false)]
		public bool disappear_redpointSpecified
		{
			get
			{
				return this._disappear_redpoint != null;
			}
			set
			{
				bool flag = value == (this._disappear_redpoint == null);
				if (flag)
				{
					this._disappear_redpoint = (value ? new bool?(this.disappear_redpoint) : null);
				}
			}
		}

		// Token: 0x06006898 RID: 26776 RVA: 0x000C7EEC File Offset: 0x000C60EC
		private bool ShouldSerializedisappear_redpoint()
		{
			return this.disappear_redpointSpecified;
		}

		// Token: 0x06006899 RID: 26777 RVA: 0x000C7F04 File Offset: 0x000C6104
		private void Resetdisappear_redpoint()
		{
			this.disappear_redpointSpecified = false;
		}

		// Token: 0x17002113 RID: 8467
		// (get) Token: 0x0600689A RID: 26778 RVA: 0x000C7F10 File Offset: 0x000C6110
		[ProtoMember(6, Name = "have_notify_scene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> have_notify_scene
		{
			get
			{
				return this._have_notify_scene;
			}
		}

		// Token: 0x17002114 RID: 8468
		// (get) Token: 0x0600689B RID: 26779 RVA: 0x000C7F28 File Offset: 0x000C6128
		// (set) Token: 0x0600689C RID: 26780 RVA: 0x000C7F55 File Offset: 0x000C6155
		[ProtoMember(7, IsRequired = false, Name = "consume_dragoncoins_now", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_now
		{
			get
			{
				return this._consume_dragoncoins_now ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_now = new ulong?(value);
			}
		}

		// Token: 0x17002115 RID: 8469
		// (get) Token: 0x0600689D RID: 26781 RVA: 0x000C7F64 File Offset: 0x000C6164
		// (set) Token: 0x0600689E RID: 26782 RVA: 0x000C7F84 File Offset: 0x000C6184
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_nowSpecified
		{
			get
			{
				return this._consume_dragoncoins_now != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_now == null);
				if (flag)
				{
					this._consume_dragoncoins_now = (value ? new ulong?(this.consume_dragoncoins_now) : null);
				}
			}
		}

		// Token: 0x0600689F RID: 26783 RVA: 0x000C7FC8 File Offset: 0x000C61C8
		private bool ShouldSerializeconsume_dragoncoins_now()
		{
			return this.consume_dragoncoins_nowSpecified;
		}

		// Token: 0x060068A0 RID: 26784 RVA: 0x000C7FE0 File Offset: 0x000C61E0
		private void Resetconsume_dragoncoins_now()
		{
			this.consume_dragoncoins_nowSpecified = false;
		}

		// Token: 0x17002116 RID: 8470
		// (get) Token: 0x060068A1 RID: 26785 RVA: 0x000C7FEC File Offset: 0x000C61EC
		// (set) Token: 0x060068A2 RID: 26786 RVA: 0x000C8019 File Offset: 0x000C6219
		[ProtoMember(8, IsRequired = false, Name = "consume_dragoncoins_before_1", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_1
		{
			get
			{
				return this._consume_dragoncoins_before_1 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_1 = new ulong?(value);
			}
		}

		// Token: 0x17002117 RID: 8471
		// (get) Token: 0x060068A3 RID: 26787 RVA: 0x000C8028 File Offset: 0x000C6228
		// (set) Token: 0x060068A4 RID: 26788 RVA: 0x000C8048 File Offset: 0x000C6248
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_1Specified
		{
			get
			{
				return this._consume_dragoncoins_before_1 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_1 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_1 = (value ? new ulong?(this.consume_dragoncoins_before_1) : null);
				}
			}
		}

		// Token: 0x060068A5 RID: 26789 RVA: 0x000C808C File Offset: 0x000C628C
		private bool ShouldSerializeconsume_dragoncoins_before_1()
		{
			return this.consume_dragoncoins_before_1Specified;
		}

		// Token: 0x060068A6 RID: 26790 RVA: 0x000C80A4 File Offset: 0x000C62A4
		private void Resetconsume_dragoncoins_before_1()
		{
			this.consume_dragoncoins_before_1Specified = false;
		}

		// Token: 0x17002118 RID: 8472
		// (get) Token: 0x060068A7 RID: 26791 RVA: 0x000C80B0 File Offset: 0x000C62B0
		// (set) Token: 0x060068A8 RID: 26792 RVA: 0x000C80DD File Offset: 0x000C62DD
		[ProtoMember(9, IsRequired = false, Name = "consume_dragoncoins_before_2", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_2
		{
			get
			{
				return this._consume_dragoncoins_before_2 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_2 = new ulong?(value);
			}
		}

		// Token: 0x17002119 RID: 8473
		// (get) Token: 0x060068A9 RID: 26793 RVA: 0x000C80EC File Offset: 0x000C62EC
		// (set) Token: 0x060068AA RID: 26794 RVA: 0x000C810C File Offset: 0x000C630C
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_2Specified
		{
			get
			{
				return this._consume_dragoncoins_before_2 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_2 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_2 = (value ? new ulong?(this.consume_dragoncoins_before_2) : null);
				}
			}
		}

		// Token: 0x060068AB RID: 26795 RVA: 0x000C8150 File Offset: 0x000C6350
		private bool ShouldSerializeconsume_dragoncoins_before_2()
		{
			return this.consume_dragoncoins_before_2Specified;
		}

		// Token: 0x060068AC RID: 26796 RVA: 0x000C8168 File Offset: 0x000C6368
		private void Resetconsume_dragoncoins_before_2()
		{
			this.consume_dragoncoins_before_2Specified = false;
		}

		// Token: 0x1700211A RID: 8474
		// (get) Token: 0x060068AD RID: 26797 RVA: 0x000C8174 File Offset: 0x000C6374
		// (set) Token: 0x060068AE RID: 26798 RVA: 0x000C81A1 File Offset: 0x000C63A1
		[ProtoMember(10, IsRequired = false, Name = "consume_dragoncoins_before_3", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_3
		{
			get
			{
				return this._consume_dragoncoins_before_3 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_3 = new ulong?(value);
			}
		}

		// Token: 0x1700211B RID: 8475
		// (get) Token: 0x060068AF RID: 26799 RVA: 0x000C81B0 File Offset: 0x000C63B0
		// (set) Token: 0x060068B0 RID: 26800 RVA: 0x000C81D0 File Offset: 0x000C63D0
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_3Specified
		{
			get
			{
				return this._consume_dragoncoins_before_3 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_3 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_3 = (value ? new ulong?(this.consume_dragoncoins_before_3) : null);
				}
			}
		}

		// Token: 0x060068B1 RID: 26801 RVA: 0x000C8214 File Offset: 0x000C6414
		private bool ShouldSerializeconsume_dragoncoins_before_3()
		{
			return this.consume_dragoncoins_before_3Specified;
		}

		// Token: 0x060068B2 RID: 26802 RVA: 0x000C822C File Offset: 0x000C642C
		private void Resetconsume_dragoncoins_before_3()
		{
			this.consume_dragoncoins_before_3Specified = false;
		}

		// Token: 0x1700211C RID: 8476
		// (get) Token: 0x060068B3 RID: 26803 RVA: 0x000C8238 File Offset: 0x000C6438
		// (set) Token: 0x060068B4 RID: 26804 RVA: 0x000C8265 File Offset: 0x000C6465
		[ProtoMember(11, IsRequired = false, Name = "consume_dragoncoins_before_4", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_4
		{
			get
			{
				return this._consume_dragoncoins_before_4 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_4 = new ulong?(value);
			}
		}

		// Token: 0x1700211D RID: 8477
		// (get) Token: 0x060068B5 RID: 26805 RVA: 0x000C8274 File Offset: 0x000C6474
		// (set) Token: 0x060068B6 RID: 26806 RVA: 0x000C8294 File Offset: 0x000C6494
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_4Specified
		{
			get
			{
				return this._consume_dragoncoins_before_4 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_4 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_4 = (value ? new ulong?(this.consume_dragoncoins_before_4) : null);
				}
			}
		}

		// Token: 0x060068B7 RID: 26807 RVA: 0x000C82D8 File Offset: 0x000C64D8
		private bool ShouldSerializeconsume_dragoncoins_before_4()
		{
			return this.consume_dragoncoins_before_4Specified;
		}

		// Token: 0x060068B8 RID: 26808 RVA: 0x000C82F0 File Offset: 0x000C64F0
		private void Resetconsume_dragoncoins_before_4()
		{
			this.consume_dragoncoins_before_4Specified = false;
		}

		// Token: 0x1700211E RID: 8478
		// (get) Token: 0x060068B9 RID: 26809 RVA: 0x000C82FC File Offset: 0x000C64FC
		// (set) Token: 0x060068BA RID: 26810 RVA: 0x000C8329 File Offset: 0x000C6529
		[ProtoMember(12, IsRequired = false, Name = "consume_dragoncoins_before_5", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_5
		{
			get
			{
				return this._consume_dragoncoins_before_5 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_5 = new ulong?(value);
			}
		}

		// Token: 0x1700211F RID: 8479
		// (get) Token: 0x060068BB RID: 26811 RVA: 0x000C8338 File Offset: 0x000C6538
		// (set) Token: 0x060068BC RID: 26812 RVA: 0x000C8358 File Offset: 0x000C6558
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_5Specified
		{
			get
			{
				return this._consume_dragoncoins_before_5 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_5 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_5 = (value ? new ulong?(this.consume_dragoncoins_before_5) : null);
				}
			}
		}

		// Token: 0x060068BD RID: 26813 RVA: 0x000C839C File Offset: 0x000C659C
		private bool ShouldSerializeconsume_dragoncoins_before_5()
		{
			return this.consume_dragoncoins_before_5Specified;
		}

		// Token: 0x060068BE RID: 26814 RVA: 0x000C83B4 File Offset: 0x000C65B4
		private void Resetconsume_dragoncoins_before_5()
		{
			this.consume_dragoncoins_before_5Specified = false;
		}

		// Token: 0x17002120 RID: 8480
		// (get) Token: 0x060068BF RID: 26815 RVA: 0x000C83C0 File Offset: 0x000C65C0
		// (set) Token: 0x060068C0 RID: 26816 RVA: 0x000C83ED File Offset: 0x000C65ED
		[ProtoMember(13, IsRequired = false, Name = "consume_dragoncoins_before_6", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_6
		{
			get
			{
				return this._consume_dragoncoins_before_6 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_6 = new ulong?(value);
			}
		}

		// Token: 0x17002121 RID: 8481
		// (get) Token: 0x060068C1 RID: 26817 RVA: 0x000C83FC File Offset: 0x000C65FC
		// (set) Token: 0x060068C2 RID: 26818 RVA: 0x000C841C File Offset: 0x000C661C
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_6Specified
		{
			get
			{
				return this._consume_dragoncoins_before_6 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_6 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_6 = (value ? new ulong?(this.consume_dragoncoins_before_6) : null);
				}
			}
		}

		// Token: 0x060068C3 RID: 26819 RVA: 0x000C8460 File Offset: 0x000C6660
		private bool ShouldSerializeconsume_dragoncoins_before_6()
		{
			return this.consume_dragoncoins_before_6Specified;
		}

		// Token: 0x060068C4 RID: 26820 RVA: 0x000C8478 File Offset: 0x000C6678
		private void Resetconsume_dragoncoins_before_6()
		{
			this.consume_dragoncoins_before_6Specified = false;
		}

		// Token: 0x17002122 RID: 8482
		// (get) Token: 0x060068C5 RID: 26821 RVA: 0x000C8484 File Offset: 0x000C6684
		// (set) Token: 0x060068C6 RID: 26822 RVA: 0x000C84B1 File Offset: 0x000C66B1
		[ProtoMember(14, IsRequired = false, Name = "consume_dragoncoins_before_7", DataFormat = DataFormat.TwosComplement)]
		public ulong consume_dragoncoins_before_7
		{
			get
			{
				return this._consume_dragoncoins_before_7 ?? 0UL;
			}
			set
			{
				this._consume_dragoncoins_before_7 = new ulong?(value);
			}
		}

		// Token: 0x17002123 RID: 8483
		// (get) Token: 0x060068C7 RID: 26823 RVA: 0x000C84C0 File Offset: 0x000C66C0
		// (set) Token: 0x060068C8 RID: 26824 RVA: 0x000C84E0 File Offset: 0x000C66E0
		[XmlIgnore]
		[Browsable(false)]
		public bool consume_dragoncoins_before_7Specified
		{
			get
			{
				return this._consume_dragoncoins_before_7 != null;
			}
			set
			{
				bool flag = value == (this._consume_dragoncoins_before_7 == null);
				if (flag)
				{
					this._consume_dragoncoins_before_7 = (value ? new ulong?(this.consume_dragoncoins_before_7) : null);
				}
			}
		}

		// Token: 0x060068C9 RID: 26825 RVA: 0x000C8524 File Offset: 0x000C6724
		private bool ShouldSerializeconsume_dragoncoins_before_7()
		{
			return this.consume_dragoncoins_before_7Specified;
		}

		// Token: 0x060068CA RID: 26826 RVA: 0x000C853C File Offset: 0x000C673C
		private void Resetconsume_dragoncoins_before_7()
		{
			this.consume_dragoncoins_before_7Specified = false;
		}

		// Token: 0x17002124 RID: 8484
		// (get) Token: 0x060068CB RID: 26827 RVA: 0x000C8548 File Offset: 0x000C6748
		// (set) Token: 0x060068CC RID: 26828 RVA: 0x000C8574 File Offset: 0x000C6774
		[ProtoMember(15, IsRequired = false, Name = "last_update_consume", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_consume
		{
			get
			{
				return this._last_update_consume ?? 0U;
			}
			set
			{
				this._last_update_consume = new uint?(value);
			}
		}

		// Token: 0x17002125 RID: 8485
		// (get) Token: 0x060068CD RID: 26829 RVA: 0x000C8584 File Offset: 0x000C6784
		// (set) Token: 0x060068CE RID: 26830 RVA: 0x000C85A4 File Offset: 0x000C67A4
		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_consumeSpecified
		{
			get
			{
				return this._last_update_consume != null;
			}
			set
			{
				bool flag = value == (this._last_update_consume == null);
				if (flag)
				{
					this._last_update_consume = (value ? new uint?(this.last_update_consume) : null);
				}
			}
		}

		// Token: 0x060068CF RID: 26831 RVA: 0x000C85E8 File Offset: 0x000C67E8
		private bool ShouldSerializelast_update_consume()
		{
			return this.last_update_consumeSpecified;
		}

		// Token: 0x060068D0 RID: 26832 RVA: 0x000C8600 File Offset: 0x000C6800
		private void Resetlast_update_consume()
		{
			this.last_update_consumeSpecified = false;
		}

		// Token: 0x060068D1 RID: 26833 RVA: 0x000C860C File Offset: 0x000C680C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001939 RID: 6457
		private uint? _last_update_time;

		// Token: 0x0400193A RID: 6458
		private readonly List<MapIntItem> _firstpass_share_list = new List<MapIntItem>();

		// Token: 0x0400193B RID: 6459
		private uint? _weekly_share_number;

		// Token: 0x0400193C RID: 6460
		private bool? _weekly_award;

		// Token: 0x0400193D RID: 6461
		private bool? _disappear_redpoint;

		// Token: 0x0400193E RID: 6462
		private readonly List<uint> _have_notify_scene = new List<uint>();

		// Token: 0x0400193F RID: 6463
		private ulong? _consume_dragoncoins_now;

		// Token: 0x04001940 RID: 6464
		private ulong? _consume_dragoncoins_before_1;

		// Token: 0x04001941 RID: 6465
		private ulong? _consume_dragoncoins_before_2;

		// Token: 0x04001942 RID: 6466
		private ulong? _consume_dragoncoins_before_3;

		// Token: 0x04001943 RID: 6467
		private ulong? _consume_dragoncoins_before_4;

		// Token: 0x04001944 RID: 6468
		private ulong? _consume_dragoncoins_before_5;

		// Token: 0x04001945 RID: 6469
		private ulong? _consume_dragoncoins_before_6;

		// Token: 0x04001946 RID: 6470
		private ulong? _consume_dragoncoins_before_7;

		// Token: 0x04001947 RID: 6471
		private uint? _last_update_consume;

		// Token: 0x04001948 RID: 6472
		private IExtension extensionObject;
	}
}
