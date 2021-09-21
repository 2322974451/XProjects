using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DE RID: 990
	[ProtoContract(Name = "CustomBattleOpRes")]
	[Serializable]
	public class CustomBattleOpRes : IExtensible
	{
		// Token: 0x17001035 RID: 4149
		// (get) Token: 0x060034AE RID: 13486 RVA: 0x00065024 File Offset: 0x00063224
		// (set) Token: 0x060034AF RID: 13487 RVA: 0x00065050 File Offset: 0x00063250
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

		// Token: 0x17001036 RID: 4150
		// (get) Token: 0x060034B0 RID: 13488 RVA: 0x00065060 File Offset: 0x00063260
		// (set) Token: 0x060034B1 RID: 13489 RVA: 0x00065080 File Offset: 0x00063280
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

		// Token: 0x060034B2 RID: 13490 RVA: 0x000650C4 File Offset: 0x000632C4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060034B3 RID: 13491 RVA: 0x000650DC File Offset: 0x000632DC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001037 RID: 4151
		// (get) Token: 0x060034B4 RID: 13492 RVA: 0x000650E8 File Offset: 0x000632E8
		// (set) Token: 0x060034B5 RID: 13493 RVA: 0x00065100 File Offset: 0x00063300
		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleClientInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x060034B6 RID: 13494 RVA: 0x0006510C File Offset: 0x0006330C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D14 RID: 3348
		private ErrorCode? _errorcode;

		// Token: 0x04000D15 RID: 3349
		private CustomBattleClientInfo _info = null;

		// Token: 0x04000D16 RID: 3350
		private IExtension extensionObject;
	}
}
