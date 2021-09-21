using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042E RID: 1070
	[ProtoContract(Name = "DHRRes")]
	[Serializable]
	public class DHRRes : IExtensible
	{
		// Token: 0x17001169 RID: 4457
		// (get) Token: 0x060038AE RID: 14510 RVA: 0x0006C7D4 File Offset: 0x0006A9D4
		// (set) Token: 0x060038AF RID: 14511 RVA: 0x0006C800 File Offset: 0x0006AA00
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

		// Token: 0x1700116A RID: 4458
		// (get) Token: 0x060038B0 RID: 14512 RVA: 0x0006C810 File Offset: 0x0006AA10
		// (set) Token: 0x060038B1 RID: 14513 RVA: 0x0006C830 File Offset: 0x0006AA30
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

		// Token: 0x060038B2 RID: 14514 RVA: 0x0006C874 File Offset: 0x0006AA74
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x0006C88C File Offset: 0x0006AA8C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700116B RID: 4459
		// (get) Token: 0x060038B4 RID: 14516 RVA: 0x0006C898 File Offset: 0x0006AA98
		[ProtoMember(2, Name = "rewstate", DataFormat = DataFormat.Default)]
		public List<DHRewrad2State> rewstate
		{
			get
			{
				return this._rewstate;
			}
		}

		// Token: 0x1700116C RID: 4460
		// (get) Token: 0x060038B5 RID: 14517 RVA: 0x0006C8B0 File Offset: 0x0006AAB0
		// (set) Token: 0x060038B6 RID: 14518 RVA: 0x0006C8DC File Offset: 0x0006AADC
		[ProtoMember(3, IsRequired = false, Name = "helpcount", DataFormat = DataFormat.TwosComplement)]
		public uint helpcount
		{
			get
			{
				return this._helpcount ?? 0U;
			}
			set
			{
				this._helpcount = new uint?(value);
			}
		}

		// Token: 0x1700116D RID: 4461
		// (get) Token: 0x060038B7 RID: 14519 RVA: 0x0006C8EC File Offset: 0x0006AAEC
		// (set) Token: 0x060038B8 RID: 14520 RVA: 0x0006C90C File Offset: 0x0006AB0C
		[XmlIgnore]
		[Browsable(false)]
		public bool helpcountSpecified
		{
			get
			{
				return this._helpcount != null;
			}
			set
			{
				bool flag = value == (this._helpcount == null);
				if (flag)
				{
					this._helpcount = (value ? new uint?(this.helpcount) : null);
				}
			}
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x0006C950 File Offset: 0x0006AB50
		private bool ShouldSerializehelpcount()
		{
			return this.helpcountSpecified;
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x0006C968 File Offset: 0x0006AB68
		private void Resethelpcount()
		{
			this.helpcountSpecified = false;
		}

		// Token: 0x1700116E RID: 4462
		// (get) Token: 0x060038BB RID: 14523 RVA: 0x0006C974 File Offset: 0x0006AB74
		// (set) Token: 0x060038BC RID: 14524 RVA: 0x0006C9A0 File Offset: 0x0006ABA0
		[ProtoMember(4, IsRequired = false, Name = "wanthelp", DataFormat = DataFormat.Default)]
		public bool wanthelp
		{
			get
			{
				return this._wanthelp ?? false;
			}
			set
			{
				this._wanthelp = new bool?(value);
			}
		}

		// Token: 0x1700116F RID: 4463
		// (get) Token: 0x060038BD RID: 14525 RVA: 0x0006C9B0 File Offset: 0x0006ABB0
		// (set) Token: 0x060038BE RID: 14526 RVA: 0x0006C9D0 File Offset: 0x0006ABD0
		[XmlIgnore]
		[Browsable(false)]
		public bool wanthelpSpecified
		{
			get
			{
				return this._wanthelp != null;
			}
			set
			{
				bool flag = value == (this._wanthelp == null);
				if (flag)
				{
					this._wanthelp = (value ? new bool?(this.wanthelp) : null);
				}
			}
		}

		// Token: 0x060038BF RID: 14527 RVA: 0x0006CA14 File Offset: 0x0006AC14
		private bool ShouldSerializewanthelp()
		{
			return this.wanthelpSpecified;
		}

		// Token: 0x060038C0 RID: 14528 RVA: 0x0006CA2C File Offset: 0x0006AC2C
		private void Resetwanthelp()
		{
			this.wanthelpSpecified = false;
		}

		// Token: 0x060038C1 RID: 14529 RVA: 0x0006CA38 File Offset: 0x0006AC38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E0F RID: 3599
		private ErrorCode? _errorcode;

		// Token: 0x04000E10 RID: 3600
		private readonly List<DHRewrad2State> _rewstate = new List<DHRewrad2State>();

		// Token: 0x04000E11 RID: 3601
		private uint? _helpcount;

		// Token: 0x04000E12 RID: 3602
		private bool? _wanthelp;

		// Token: 0x04000E13 RID: 3603
		private IExtension extensionObject;
	}
}
