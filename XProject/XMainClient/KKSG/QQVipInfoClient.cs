using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D0 RID: 1744
	[ProtoContract(Name = "QQVipInfoClient")]
	[Serializable]
	public class QQVipInfoClient : IExtensible
	{
		// Token: 0x1700249B RID: 9371
		// (get) Token: 0x060073A2 RID: 29602 RVA: 0x000DD3D0 File Offset: 0x000DB5D0
		// (set) Token: 0x060073A3 RID: 29603 RVA: 0x000DD3FC File Offset: 0x000DB5FC
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

		// Token: 0x1700249C RID: 9372
		// (get) Token: 0x060073A4 RID: 29604 RVA: 0x000DD40C File Offset: 0x000DB60C
		// (set) Token: 0x060073A5 RID: 29605 RVA: 0x000DD42C File Offset: 0x000DB62C
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

		// Token: 0x060073A6 RID: 29606 RVA: 0x000DD470 File Offset: 0x000DB670
		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		// Token: 0x060073A7 RID: 29607 RVA: 0x000DD488 File Offset: 0x000DB688
		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		// Token: 0x1700249D RID: 9373
		// (get) Token: 0x060073A8 RID: 29608 RVA: 0x000DD494 File Offset: 0x000DB694
		// (set) Token: 0x060073A9 RID: 29609 RVA: 0x000DD4C0 File Offset: 0x000DB6C0
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

		// Token: 0x1700249E RID: 9374
		// (get) Token: 0x060073AA RID: 29610 RVA: 0x000DD4D0 File Offset: 0x000DB6D0
		// (set) Token: 0x060073AB RID: 29611 RVA: 0x000DD4F0 File Offset: 0x000DB6F0
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

		// Token: 0x060073AC RID: 29612 RVA: 0x000DD534 File Offset: 0x000DB734
		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		// Token: 0x060073AD RID: 29613 RVA: 0x000DD54C File Offset: 0x000DB74C
		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		// Token: 0x1700249F RID: 9375
		// (get) Token: 0x060073AE RID: 29614 RVA: 0x000DD558 File Offset: 0x000DB758
		// (set) Token: 0x060073AF RID: 29615 RVA: 0x000DD584 File Offset: 0x000DB784
		[ProtoMember(3, IsRequired = false, Name = "qq_vip_end", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170024A0 RID: 9376
		// (get) Token: 0x060073B0 RID: 29616 RVA: 0x000DD594 File Offset: 0x000DB794
		// (set) Token: 0x060073B1 RID: 29617 RVA: 0x000DD5B4 File Offset: 0x000DB7B4
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

		// Token: 0x060073B2 RID: 29618 RVA: 0x000DD5F8 File Offset: 0x000DB7F8
		private bool ShouldSerializeqq_vip_end()
		{
			return this.qq_vip_endSpecified;
		}

		// Token: 0x060073B3 RID: 29619 RVA: 0x000DD610 File Offset: 0x000DB810
		private void Resetqq_vip_end()
		{
			this.qq_vip_endSpecified = false;
		}

		// Token: 0x170024A1 RID: 9377
		// (get) Token: 0x060073B4 RID: 29620 RVA: 0x000DD61C File Offset: 0x000DB81C
		// (set) Token: 0x060073B5 RID: 29621 RVA: 0x000DD648 File Offset: 0x000DB848
		[ProtoMember(4, IsRequired = false, Name = "qq_svip_end", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170024A2 RID: 9378
		// (get) Token: 0x060073B6 RID: 29622 RVA: 0x000DD658 File Offset: 0x000DB858
		// (set) Token: 0x060073B7 RID: 29623 RVA: 0x000DD678 File Offset: 0x000DB878
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

		// Token: 0x060073B8 RID: 29624 RVA: 0x000DD6BC File Offset: 0x000DB8BC
		private bool ShouldSerializeqq_svip_end()
		{
			return this.qq_svip_endSpecified;
		}

		// Token: 0x060073B9 RID: 29625 RVA: 0x000DD6D4 File Offset: 0x000DB8D4
		private void Resetqq_svip_end()
		{
			this.qq_svip_endSpecified = false;
		}

		// Token: 0x170024A3 RID: 9379
		// (get) Token: 0x060073BA RID: 29626 RVA: 0x000DD6E0 File Offset: 0x000DB8E0
		// (set) Token: 0x060073BB RID: 29627 RVA: 0x000DD70C File Offset: 0x000DB90C
		[ProtoMember(5, IsRequired = false, Name = "is_bigger_one_month", DataFormat = DataFormat.Default)]
		public bool is_bigger_one_month
		{
			get
			{
				return this._is_bigger_one_month ?? false;
			}
			set
			{
				this._is_bigger_one_month = new bool?(value);
			}
		}

		// Token: 0x170024A4 RID: 9380
		// (get) Token: 0x060073BC RID: 29628 RVA: 0x000DD71C File Offset: 0x000DB91C
		// (set) Token: 0x060073BD RID: 29629 RVA: 0x000DD73C File Offset: 0x000DB93C
		[XmlIgnore]
		[Browsable(false)]
		public bool is_bigger_one_monthSpecified
		{
			get
			{
				return this._is_bigger_one_month != null;
			}
			set
			{
				bool flag = value == (this._is_bigger_one_month == null);
				if (flag)
				{
					this._is_bigger_one_month = (value ? new bool?(this.is_bigger_one_month) : null);
				}
			}
		}

		// Token: 0x060073BE RID: 29630 RVA: 0x000DD780 File Offset: 0x000DB980
		private bool ShouldSerializeis_bigger_one_month()
		{
			return this.is_bigger_one_monthSpecified;
		}

		// Token: 0x060073BF RID: 29631 RVA: 0x000DD798 File Offset: 0x000DB998
		private void Resetis_bigger_one_month()
		{
			this.is_bigger_one_monthSpecified = false;
		}

		// Token: 0x060073C0 RID: 29632 RVA: 0x000DD7A4 File Offset: 0x000DB9A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B7E RID: 7038
		private bool? _is_vip;

		// Token: 0x04001B7F RID: 7039
		private bool? _is_svip;

		// Token: 0x04001B80 RID: 7040
		private uint? _qq_vip_end;

		// Token: 0x04001B81 RID: 7041
		private uint? _qq_svip_end;

		// Token: 0x04001B82 RID: 7042
		private bool? _is_bigger_one_month;

		// Token: 0x04001B83 RID: 7043
		private IExtension extensionObject;
	}
}
