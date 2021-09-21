using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011D RID: 285
	[ProtoContract(Name = "GetLevelSealInfoRes")]
	[Serializable]
	public class GetLevelSealInfoRes : IExtensible
	{
		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x00023FAC File Offset: 0x000221AC
		// (set) Token: 0x060011AA RID: 4522 RVA: 0x00023FD8 File Offset: 0x000221D8
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

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x00023FE8 File Offset: 0x000221E8
		// (set) Token: 0x060011AC RID: 4524 RVA: 0x00024008 File Offset: 0x00022208
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

		// Token: 0x060011AD RID: 4525 RVA: 0x0002404C File Offset: 0x0002224C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x00024064 File Offset: 0x00022264
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x00024070 File Offset: 0x00022270
		// (set) Token: 0x060011B0 RID: 4528 RVA: 0x00024088 File Offset: 0x00022288
		[ProtoMember(2, IsRequired = false, Name = "levelSealData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LevelSealInfo levelSealData
		{
			get
			{
				return this._levelSealData;
			}
			set
			{
				this._levelSealData = value;
			}
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x00024094 File Offset: 0x00022294
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400046C RID: 1132
		private ErrorCode? _errorcode;

		// Token: 0x0400046D RID: 1133
		private LevelSealInfo _levelSealData = null;

		// Token: 0x0400046E RID: 1134
		private IExtension extensionObject;
	}
}
