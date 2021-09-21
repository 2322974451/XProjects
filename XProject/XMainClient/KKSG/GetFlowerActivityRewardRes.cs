using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041F RID: 1055
	[ProtoContract(Name = "GetFlowerActivityRewardRes")]
	[Serializable]
	public class GetFlowerActivityRewardRes : IExtensible
	{
		// Token: 0x17001131 RID: 4401
		// (get) Token: 0x060037FA RID: 14330 RVA: 0x0006B29C File Offset: 0x0006949C
		// (set) Token: 0x060037FB RID: 14331 RVA: 0x0006B2C8 File Offset: 0x000694C8
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

		// Token: 0x17001132 RID: 4402
		// (get) Token: 0x060037FC RID: 14332 RVA: 0x0006B2D8 File Offset: 0x000694D8
		// (set) Token: 0x060037FD RID: 14333 RVA: 0x0006B2F8 File Offset: 0x000694F8
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

		// Token: 0x060037FE RID: 14334 RVA: 0x0006B33C File Offset: 0x0006953C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x0006B354 File Offset: 0x00069554
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x0006B360 File Offset: 0x00069560
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DDF RID: 3551
		private ErrorCode? _errorcode;

		// Token: 0x04000DE0 RID: 3552
		private IExtension extensionObject;
	}
}
