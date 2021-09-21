using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000120 RID: 288
	[ProtoContract(Name = "LevelSealOverExpRes")]
	[Serializable]
	public class LevelSealOverExpRes : IExtensible
	{
		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x060011E1 RID: 4577 RVA: 0x00024650 File Offset: 0x00022850
		// (set) Token: 0x060011E2 RID: 4578 RVA: 0x0002467C File Offset: 0x0002287C
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

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x060011E3 RID: 4579 RVA: 0x0002468C File Offset: 0x0002288C
		// (set) Token: 0x060011E4 RID: 4580 RVA: 0x000246AC File Offset: 0x000228AC
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

		// Token: 0x060011E5 RID: 4581 RVA: 0x000246F0 File Offset: 0x000228F0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x00024708 File Offset: 0x00022908
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x060011E7 RID: 4583 RVA: 0x00024714 File Offset: 0x00022914
		// (set) Token: 0x060011E8 RID: 4584 RVA: 0x00024740 File Offset: 0x00022940
		[ProtoMember(2, IsRequired = false, Name = "m_uStatus", DataFormat = DataFormat.TwosComplement)]
		public uint m_uStatus
		{
			get
			{
				return this._m_uStatus ?? 0U;
			}
			set
			{
				this._m_uStatus = new uint?(value);
			}
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x060011E9 RID: 4585 RVA: 0x00024750 File Offset: 0x00022950
		// (set) Token: 0x060011EA RID: 4586 RVA: 0x00024770 File Offset: 0x00022970
		[XmlIgnore]
		[Browsable(false)]
		public bool m_uStatusSpecified
		{
			get
			{
				return this._m_uStatus != null;
			}
			set
			{
				bool flag = value == (this._m_uStatus == null);
				if (flag)
				{
					this._m_uStatus = (value ? new uint?(this.m_uStatus) : null);
				}
			}
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x000247B4 File Offset: 0x000229B4
		private bool ShouldSerializem_uStatus()
		{
			return this.m_uStatusSpecified;
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x000247CC File Offset: 0x000229CC
		private void Resetm_uStatus()
		{
			this.m_uStatusSpecified = false;
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x000247D8 File Offset: 0x000229D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000478 RID: 1144
		private ErrorCode? _errorcode;

		// Token: 0x04000479 RID: 1145
		private uint? _m_uStatus;

		// Token: 0x0400047A RID: 1146
		private IExtension extensionObject;
	}
}
