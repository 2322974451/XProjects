using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052D RID: 1325
	[ProtoContract(Name = "CampDuelActivityOperationRes")]
	[Serializable]
	public class CampDuelActivityOperationRes : IExtensible
	{
		// Token: 0x170014D0 RID: 5328
		// (get) Token: 0x06004416 RID: 17430 RVA: 0x00081878 File Offset: 0x0007FA78
		// (set) Token: 0x06004417 RID: 17431 RVA: 0x000818A4 File Offset: 0x0007FAA4
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

		// Token: 0x170014D1 RID: 5329
		// (get) Token: 0x06004418 RID: 17432 RVA: 0x000818B4 File Offset: 0x0007FAB4
		// (set) Token: 0x06004419 RID: 17433 RVA: 0x000818D4 File Offset: 0x0007FAD4
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

		// Token: 0x0600441A RID: 17434 RVA: 0x00081918 File Offset: 0x0007FB18
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600441B RID: 17435 RVA: 0x00081930 File Offset: 0x0007FB30
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170014D2 RID: 5330
		// (get) Token: 0x0600441C RID: 17436 RVA: 0x0008193C File Offset: 0x0007FB3C
		// (set) Token: 0x0600441D RID: 17437 RVA: 0x00081954 File Offset: 0x0007FB54
		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampDuelData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x170014D3 RID: 5331
		// (get) Token: 0x0600441E RID: 17438 RVA: 0x00081960 File Offset: 0x0007FB60
		// (set) Token: 0x0600441F RID: 17439 RVA: 0x0008198C File Offset: 0x0007FB8C
		[ProtoMember(3, IsRequired = false, Name = "precedeCampID", DataFormat = DataFormat.TwosComplement)]
		public uint precedeCampID
		{
			get
			{
				return this._precedeCampID ?? 0U;
			}
			set
			{
				this._precedeCampID = new uint?(value);
			}
		}

		// Token: 0x170014D4 RID: 5332
		// (get) Token: 0x06004420 RID: 17440 RVA: 0x0008199C File Offset: 0x0007FB9C
		// (set) Token: 0x06004421 RID: 17441 RVA: 0x000819BC File Offset: 0x0007FBBC
		[XmlIgnore]
		[Browsable(false)]
		public bool precedeCampIDSpecified
		{
			get
			{
				return this._precedeCampID != null;
			}
			set
			{
				bool flag = value == (this._precedeCampID == null);
				if (flag)
				{
					this._precedeCampID = (value ? new uint?(this.precedeCampID) : null);
				}
			}
		}

		// Token: 0x06004422 RID: 17442 RVA: 0x00081A00 File Offset: 0x0007FC00
		private bool ShouldSerializeprecedeCampID()
		{
			return this.precedeCampIDSpecified;
		}

		// Token: 0x06004423 RID: 17443 RVA: 0x00081A18 File Offset: 0x0007FC18
		private void ResetprecedeCampID()
		{
			this.precedeCampIDSpecified = false;
		}

		// Token: 0x170014D5 RID: 5333
		// (get) Token: 0x06004424 RID: 17444 RVA: 0x00081A24 File Offset: 0x0007FC24
		// (set) Token: 0x06004425 RID: 17445 RVA: 0x00081A50 File Offset: 0x0007FC50
		[ProtoMember(4, IsRequired = false, Name = "campDuelPoint1", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelPoint1
		{
			get
			{
				return this._campDuelPoint1 ?? 0U;
			}
			set
			{
				this._campDuelPoint1 = new uint?(value);
			}
		}

		// Token: 0x170014D6 RID: 5334
		// (get) Token: 0x06004426 RID: 17446 RVA: 0x00081A60 File Offset: 0x0007FC60
		// (set) Token: 0x06004427 RID: 17447 RVA: 0x00081A80 File Offset: 0x0007FC80
		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelPoint1Specified
		{
			get
			{
				return this._campDuelPoint1 != null;
			}
			set
			{
				bool flag = value == (this._campDuelPoint1 == null);
				if (flag)
				{
					this._campDuelPoint1 = (value ? new uint?(this.campDuelPoint1) : null);
				}
			}
		}

		// Token: 0x06004428 RID: 17448 RVA: 0x00081AC4 File Offset: 0x0007FCC4
		private bool ShouldSerializecampDuelPoint1()
		{
			return this.campDuelPoint1Specified;
		}

		// Token: 0x06004429 RID: 17449 RVA: 0x00081ADC File Offset: 0x0007FCDC
		private void ResetcampDuelPoint1()
		{
			this.campDuelPoint1Specified = false;
		}

		// Token: 0x170014D7 RID: 5335
		// (get) Token: 0x0600442A RID: 17450 RVA: 0x00081AE8 File Offset: 0x0007FCE8
		// (set) Token: 0x0600442B RID: 17451 RVA: 0x00081B14 File Offset: 0x0007FD14
		[ProtoMember(5, IsRequired = false, Name = "campDuelPoint2", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelPoint2
		{
			get
			{
				return this._campDuelPoint2 ?? 0U;
			}
			set
			{
				this._campDuelPoint2 = new uint?(value);
			}
		}

		// Token: 0x170014D8 RID: 5336
		// (get) Token: 0x0600442C RID: 17452 RVA: 0x00081B24 File Offset: 0x0007FD24
		// (set) Token: 0x0600442D RID: 17453 RVA: 0x00081B44 File Offset: 0x0007FD44
		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelPoint2Specified
		{
			get
			{
				return this._campDuelPoint2 != null;
			}
			set
			{
				bool flag = value == (this._campDuelPoint2 == null);
				if (flag)
				{
					this._campDuelPoint2 = (value ? new uint?(this.campDuelPoint2) : null);
				}
			}
		}

		// Token: 0x0600442E RID: 17454 RVA: 0x00081B88 File Offset: 0x0007FD88
		private bool ShouldSerializecampDuelPoint2()
		{
			return this.campDuelPoint2Specified;
		}

		// Token: 0x0600442F RID: 17455 RVA: 0x00081BA0 File Offset: 0x0007FDA0
		private void ResetcampDuelPoint2()
		{
			this.campDuelPoint2Specified = false;
		}

		// Token: 0x06004430 RID: 17456 RVA: 0x00081BAC File Offset: 0x0007FDAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010FB RID: 4347
		private ErrorCode? _errorcode;

		// Token: 0x040010FC RID: 4348
		private CampDuelData _data = null;

		// Token: 0x040010FD RID: 4349
		private uint? _precedeCampID;

		// Token: 0x040010FE RID: 4350
		private uint? _campDuelPoint1;

		// Token: 0x040010FF RID: 4351
		private uint? _campDuelPoint2;

		// Token: 0x04001100 RID: 4352
		private IExtension extensionObject;
	}
}
