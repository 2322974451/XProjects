using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002C RID: 44
	[ProtoContract(Name = "QueryLotteryCDRes")]
	[Serializable]
	public class QueryLotteryCDRes : IExtensible
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000861C File Offset: 0x0000681C
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00008648 File Offset: 0x00006848
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00008658 File Offset: 0x00006858
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00008678 File Offset: 0x00006878
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000086BC File Offset: 0x000068BC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000086D4 File Offset: 0x000068D4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002FF RID: 767 RVA: 0x000086E0 File Offset: 0x000068E0
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0000870C File Offset: 0x0000690C
		[ProtoMember(2, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000871C File Offset: 0x0000691C
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0000873C File Offset: 0x0000693C
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00008780 File Offset: 0x00006980
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008798 File Offset: 0x00006998
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000305 RID: 773 RVA: 0x000087A4 File Offset: 0x000069A4
		// (set) Token: 0x06000306 RID: 774 RVA: 0x000087D0 File Offset: 0x000069D0
		[ProtoMember(3, IsRequired = false, Name = "goldbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint goldbuycount
		{
			get
			{
				return this._goldbuycount ?? 0U;
			}
			set
			{
				this._goldbuycount = new uint?(value);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000307 RID: 775 RVA: 0x000087E0 File Offset: 0x000069E0
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00008800 File Offset: 0x00006A00
		[XmlIgnore]
		[Browsable(false)]
		public bool goldbuycountSpecified
		{
			get
			{
				return this._goldbuycount != null;
			}
			set
			{
				bool flag = value == (this._goldbuycount == null);
				if (flag)
				{
					this._goldbuycount = (value ? new uint?(this.goldbuycount) : null);
				}
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00008844 File Offset: 0x00006A44
		private bool ShouldSerializegoldbuycount()
		{
			return this.goldbuycountSpecified;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000885C File Offset: 0x00006A5C
		private void Resetgoldbuycount()
		{
			this.goldbuycountSpecified = false;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00008868 File Offset: 0x00006A68
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00008894 File Offset: 0x00006A94
		[ProtoMember(4, IsRequired = false, Name = "goldbuycooldown", DataFormat = DataFormat.TwosComplement)]
		public uint goldbuycooldown
		{
			get
			{
				return this._goldbuycooldown ?? 0U;
			}
			set
			{
				this._goldbuycooldown = new uint?(value);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600030D RID: 781 RVA: 0x000088A4 File Offset: 0x00006AA4
		// (set) Token: 0x0600030E RID: 782 RVA: 0x000088C4 File Offset: 0x00006AC4
		[XmlIgnore]
		[Browsable(false)]
		public bool goldbuycooldownSpecified
		{
			get
			{
				return this._goldbuycooldown != null;
			}
			set
			{
				bool flag = value == (this._goldbuycooldown == null);
				if (flag)
				{
					this._goldbuycooldown = (value ? new uint?(this.goldbuycooldown) : null);
				}
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008908 File Offset: 0x00006B08
		private bool ShouldSerializegoldbuycooldown()
		{
			return this.goldbuycooldownSpecified;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00008920 File Offset: 0x00006B20
		private void Resetgoldbuycooldown()
		{
			this.goldbuycooldownSpecified = false;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000892C File Offset: 0x00006B2C
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00008958 File Offset: 0x00006B58
		[ProtoMember(5, IsRequired = false, Name = "goldbaodi", DataFormat = DataFormat.TwosComplement)]
		public uint goldbaodi
		{
			get
			{
				return this._goldbaodi ?? 0U;
			}
			set
			{
				this._goldbaodi = new uint?(value);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00008968 File Offset: 0x00006B68
		// (set) Token: 0x06000314 RID: 788 RVA: 0x00008988 File Offset: 0x00006B88
		[XmlIgnore]
		[Browsable(false)]
		public bool goldbaodiSpecified
		{
			get
			{
				return this._goldbaodi != null;
			}
			set
			{
				bool flag = value == (this._goldbaodi == null);
				if (flag)
				{
					this._goldbaodi = (value ? new uint?(this.goldbaodi) : null);
				}
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000089CC File Offset: 0x00006BCC
		private bool ShouldSerializegoldbaodi()
		{
			return this.goldbaodiSpecified;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000089E4 File Offset: 0x00006BE4
		private void Resetgoldbaodi()
		{
			this.goldbaodiSpecified = false;
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000089F0 File Offset: 0x00006BF0
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00008A1C File Offset: 0x00006C1C
		[ProtoMember(6, IsRequired = false, Name = "coinbaodi", DataFormat = DataFormat.TwosComplement)]
		public uint coinbaodi
		{
			get
			{
				return this._coinbaodi ?? 0U;
			}
			set
			{
				this._coinbaodi = new uint?(value);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00008A2C File Offset: 0x00006C2C
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00008A4C File Offset: 0x00006C4C
		[XmlIgnore]
		[Browsable(false)]
		public bool coinbaodiSpecified
		{
			get
			{
				return this._coinbaodi != null;
			}
			set
			{
				bool flag = value == (this._coinbaodi == null);
				if (flag)
				{
					this._coinbaodi = (value ? new uint?(this.coinbaodi) : null);
				}
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00008A90 File Offset: 0x00006C90
		private bool ShouldSerializecoinbaodi()
		{
			return this.coinbaodiSpecified;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00008AA8 File Offset: 0x00006CA8
		private void Resetcoinbaodi()
		{
			this.coinbaodiSpecified = false;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00008AB4 File Offset: 0x00006CB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000CB RID: 203
		private ErrorCode? _errorcode;

		// Token: 0x040000CC RID: 204
		private uint? _cooldown;

		// Token: 0x040000CD RID: 205
		private uint? _goldbuycount;

		// Token: 0x040000CE RID: 206
		private uint? _goldbuycooldown;

		// Token: 0x040000CF RID: 207
		private uint? _goldbaodi;

		// Token: 0x040000D0 RID: 208
		private uint? _coinbaodi;

		// Token: 0x040000D1 RID: 209
		private IExtension extensionObject;
	}
}
