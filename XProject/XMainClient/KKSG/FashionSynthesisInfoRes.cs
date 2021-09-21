using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050E RID: 1294
	[ProtoContract(Name = "FashionSynthesisInfoRes")]
	[Serializable]
	public class FashionSynthesisInfoRes : IExtensible
	{
		// Token: 0x17001462 RID: 5218
		// (get) Token: 0x060042A4 RID: 17060 RVA: 0x0007ED4C File Offset: 0x0007CF4C
		// (set) Token: 0x060042A5 RID: 17061 RVA: 0x0007ED78 File Offset: 0x0007CF78
		[ProtoMember(1, IsRequired = false, Name = "fashion_id", DataFormat = DataFormat.TwosComplement)]
		public uint fashion_id
		{
			get
			{
				return this._fashion_id ?? 0U;
			}
			set
			{
				this._fashion_id = new uint?(value);
			}
		}

		// Token: 0x17001463 RID: 5219
		// (get) Token: 0x060042A6 RID: 17062 RVA: 0x0007ED88 File Offset: 0x0007CF88
		// (set) Token: 0x060042A7 RID: 17063 RVA: 0x0007EDA8 File Offset: 0x0007CFA8
		[XmlIgnore]
		[Browsable(false)]
		public bool fashion_idSpecified
		{
			get
			{
				return this._fashion_id != null;
			}
			set
			{
				bool flag = value == (this._fashion_id == null);
				if (flag)
				{
					this._fashion_id = (value ? new uint?(this.fashion_id) : null);
				}
			}
		}

		// Token: 0x060042A8 RID: 17064 RVA: 0x0007EDEC File Offset: 0x0007CFEC
		private bool ShouldSerializefashion_id()
		{
			return this.fashion_idSpecified;
		}

		// Token: 0x060042A9 RID: 17065 RVA: 0x0007EE04 File Offset: 0x0007D004
		private void Resetfashion_id()
		{
			this.fashion_idSpecified = false;
		}

		// Token: 0x17001464 RID: 5220
		// (get) Token: 0x060042AA RID: 17066 RVA: 0x0007EE10 File Offset: 0x0007D010
		// (set) Token: 0x060042AB RID: 17067 RVA: 0x0007EE3C File Offset: 0x0007D03C
		[ProtoMember(2, IsRequired = false, Name = "add_succes_rate", DataFormat = DataFormat.TwosComplement)]
		public uint add_succes_rate
		{
			get
			{
				return this._add_succes_rate ?? 0U;
			}
			set
			{
				this._add_succes_rate = new uint?(value);
			}
		}

		// Token: 0x17001465 RID: 5221
		// (get) Token: 0x060042AC RID: 17068 RVA: 0x0007EE4C File Offset: 0x0007D04C
		// (set) Token: 0x060042AD RID: 17069 RVA: 0x0007EE6C File Offset: 0x0007D06C
		[XmlIgnore]
		[Browsable(false)]
		public bool add_succes_rateSpecified
		{
			get
			{
				return this._add_succes_rate != null;
			}
			set
			{
				bool flag = value == (this._add_succes_rate == null);
				if (flag)
				{
					this._add_succes_rate = (value ? new uint?(this.add_succes_rate) : null);
				}
			}
		}

		// Token: 0x060042AE RID: 17070 RVA: 0x0007EEB0 File Offset: 0x0007D0B0
		private bool ShouldSerializeadd_succes_rate()
		{
			return this.add_succes_rateSpecified;
		}

		// Token: 0x060042AF RID: 17071 RVA: 0x0007EEC8 File Offset: 0x0007D0C8
		private void Resetadd_succes_rate()
		{
			this.add_succes_rateSpecified = false;
		}

		// Token: 0x17001466 RID: 5222
		// (get) Token: 0x060042B0 RID: 17072 RVA: 0x0007EED4 File Offset: 0x0007D0D4
		// (set) Token: 0x060042B1 RID: 17073 RVA: 0x0007EF00 File Offset: 0x0007D100
		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001467 RID: 5223
		// (get) Token: 0x060042B2 RID: 17074 RVA: 0x0007EF10 File Offset: 0x0007D110
		// (set) Token: 0x060042B3 RID: 17075 RVA: 0x0007EF30 File Offset: 0x0007D130
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060042B4 RID: 17076 RVA: 0x0007EF74 File Offset: 0x0007D174
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060042B5 RID: 17077 RVA: 0x0007EF8C File Offset: 0x0007D18C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060042B6 RID: 17078 RVA: 0x0007EF98 File Offset: 0x0007D198
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400109F RID: 4255
		private uint? _fashion_id;

		// Token: 0x040010A0 RID: 4256
		private uint? _add_succes_rate;

		// Token: 0x040010A1 RID: 4257
		private ErrorCode? _result;

		// Token: 0x040010A2 RID: 4258
		private IExtension extensionObject;
	}
}
