using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000198 RID: 408
	[ProtoContract(Name = "ResetTowerRes")]
	[Serializable]
	public class ResetTowerRes : IExtensible
	{
		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06001882 RID: 6274 RVA: 0x00030D1C File Offset: 0x0002EF1C
		// (set) Token: 0x06001883 RID: 6275 RVA: 0x00030D48 File Offset: 0x0002EF48
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06001884 RID: 6276 RVA: 0x00030D58 File Offset: 0x0002EF58
		// (set) Token: 0x06001885 RID: 6277 RVA: 0x00030D78 File Offset: 0x0002EF78
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00030DBC File Offset: 0x0002EFBC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00030DD4 File Offset: 0x0002EFD4
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00030DE0 File Offset: 0x0002EFE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400060E RID: 1550
		private ErrorCode? _error;

		// Token: 0x0400060F RID: 1551
		private IExtension extensionObject;
	}
}
