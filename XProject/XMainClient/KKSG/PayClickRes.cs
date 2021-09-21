using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C7 RID: 455
	[ProtoContract(Name = "PayClickRes")]
	[Serializable]
	public class PayClickRes : IExtensible
	{
		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06001AA3 RID: 6819 RVA: 0x00034BE8 File Offset: 0x00032DE8
		// (set) Token: 0x06001AA4 RID: 6820 RVA: 0x00034C14 File Offset: 0x00032E14
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06001AA5 RID: 6821 RVA: 0x00034C24 File Offset: 0x00032E24
		// (set) Token: 0x06001AA6 RID: 6822 RVA: 0x00034C44 File Offset: 0x00032E44
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x00034C88 File Offset: 0x00032E88
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x00034CA0 File Offset: 0x00032EA0
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06001AA9 RID: 6825 RVA: 0x00034CAC File Offset: 0x00032EAC
		// (set) Token: 0x06001AAA RID: 6826 RVA: 0x00034CD8 File Offset: 0x00032ED8
		[ProtoMember(2, IsRequired = false, Name = "payCardFirstClick", DataFormat = DataFormat.Default)]
		public bool payCardFirstClick
		{
			get
			{
				return this._payCardFirstClick ?? false;
			}
			set
			{
				this._payCardFirstClick = new bool?(value);
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06001AAB RID: 6827 RVA: 0x00034CE8 File Offset: 0x00032EE8
		// (set) Token: 0x06001AAC RID: 6828 RVA: 0x00034D08 File Offset: 0x00032F08
		[XmlIgnore]
		[Browsable(false)]
		public bool payCardFirstClickSpecified
		{
			get
			{
				return this._payCardFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payCardFirstClick == null);
				if (flag)
				{
					this._payCardFirstClick = (value ? new bool?(this.payCardFirstClick) : null);
				}
			}
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x00034D4C File Offset: 0x00032F4C
		private bool ShouldSerializepayCardFirstClick()
		{
			return this.payCardFirstClickSpecified;
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x00034D64 File Offset: 0x00032F64
		private void ResetpayCardFirstClick()
		{
			this.payCardFirstClickSpecified = false;
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06001AAF RID: 6831 RVA: 0x00034D70 File Offset: 0x00032F70
		// (set) Token: 0x06001AB0 RID: 6832 RVA: 0x00034D9C File Offset: 0x00032F9C
		[ProtoMember(3, IsRequired = false, Name = "payAileenFirstClick", DataFormat = DataFormat.Default)]
		public bool payAileenFirstClick
		{
			get
			{
				return this._payAileenFirstClick ?? false;
			}
			set
			{
				this._payAileenFirstClick = new bool?(value);
			}
		}

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06001AB1 RID: 6833 RVA: 0x00034DAC File Offset: 0x00032FAC
		// (set) Token: 0x06001AB2 RID: 6834 RVA: 0x00034DCC File Offset: 0x00032FCC
		[XmlIgnore]
		[Browsable(false)]
		public bool payAileenFirstClickSpecified
		{
			get
			{
				return this._payAileenFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payAileenFirstClick == null);
				if (flag)
				{
					this._payAileenFirstClick = (value ? new bool?(this.payAileenFirstClick) : null);
				}
			}
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x00034E10 File Offset: 0x00033010
		private bool ShouldSerializepayAileenFirstClick()
		{
			return this.payAileenFirstClickSpecified;
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x00034E28 File Offset: 0x00033028
		private void ResetpayAileenFirstClick()
		{
			this.payAileenFirstClickSpecified = false;
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06001AB5 RID: 6837 RVA: 0x00034E34 File Offset: 0x00033034
		// (set) Token: 0x06001AB6 RID: 6838 RVA: 0x00034E60 File Offset: 0x00033060
		[ProtoMember(4, IsRequired = false, Name = "payFirstAwardClick", DataFormat = DataFormat.Default)]
		public bool payFirstAwardClick
		{
			get
			{
				return this._payFirstAwardClick ?? false;
			}
			set
			{
				this._payFirstAwardClick = new bool?(value);
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06001AB7 RID: 6839 RVA: 0x00034E70 File Offset: 0x00033070
		// (set) Token: 0x06001AB8 RID: 6840 RVA: 0x00034E90 File Offset: 0x00033090
		[XmlIgnore]
		[Browsable(false)]
		public bool payFirstAwardClickSpecified
		{
			get
			{
				return this._payFirstAwardClick != null;
			}
			set
			{
				bool flag = value == (this._payFirstAwardClick == null);
				if (flag)
				{
					this._payFirstAwardClick = (value ? new bool?(this.payFirstAwardClick) : null);
				}
			}
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x00034ED4 File Offset: 0x000330D4
		private bool ShouldSerializepayFirstAwardClick()
		{
			return this.payFirstAwardClickSpecified;
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x00034EEC File Offset: 0x000330EC
		private void ResetpayFirstAwardClick()
		{
			this.payFirstAwardClickSpecified = false;
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06001ABB RID: 6843 RVA: 0x00034EF8 File Offset: 0x000330F8
		// (set) Token: 0x06001ABC RID: 6844 RVA: 0x00034F24 File Offset: 0x00033124
		[ProtoMember(5, IsRequired = false, Name = "growthFundClick", DataFormat = DataFormat.Default)]
		public bool growthFundClick
		{
			get
			{
				return this._growthFundClick ?? false;
			}
			set
			{
				this._growthFundClick = new bool?(value);
			}
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x06001ABD RID: 6845 RVA: 0x00034F34 File Offset: 0x00033134
		// (set) Token: 0x06001ABE RID: 6846 RVA: 0x00034F54 File Offset: 0x00033154
		[XmlIgnore]
		[Browsable(false)]
		public bool growthFundClickSpecified
		{
			get
			{
				return this._growthFundClick != null;
			}
			set
			{
				bool flag = value == (this._growthFundClick == null);
				if (flag)
				{
					this._growthFundClick = (value ? new bool?(this.growthFundClick) : null);
				}
			}
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x00034F98 File Offset: 0x00033198
		private bool ShouldSerializegrowthFundClick()
		{
			return this.growthFundClickSpecified;
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x00034FB0 File Offset: 0x000331B0
		private void ResetgrowthFundClick()
		{
			this.growthFundClickSpecified = false;
		}

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06001AC1 RID: 6849 RVA: 0x00034FBC File Offset: 0x000331BC
		[ProtoMember(6, Name = "info", DataFormat = DataFormat.Default)]
		public List<PayMember> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x00034FD4 File Offset: 0x000331D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006A0 RID: 1696
		private ErrorCode? _errcode;

		// Token: 0x040006A1 RID: 1697
		private bool? _payCardFirstClick;

		// Token: 0x040006A2 RID: 1698
		private bool? _payAileenFirstClick;

		// Token: 0x040006A3 RID: 1699
		private bool? _payFirstAwardClick;

		// Token: 0x040006A4 RID: 1700
		private bool? _growthFundClick;

		// Token: 0x040006A5 RID: 1701
		private readonly List<PayMember> _info = new List<PayMember>();

		// Token: 0x040006A6 RID: 1702
		private IExtension extensionObject;
	}
}
