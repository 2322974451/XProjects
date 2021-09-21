using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000149 RID: 329
	[ProtoContract(Name = "GetFlowerRewardRes")]
	[Serializable]
	public class GetFlowerRewardRes : IExtensible
	{
		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x0600142A RID: 5162 RVA: 0x00028AF8 File Offset: 0x00026CF8
		// (set) Token: 0x0600142B RID: 5163 RVA: 0x00028B24 File Offset: 0x00026D24
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x00028B34 File Offset: 0x00026D34
		// (set) Token: 0x0600142D RID: 5165 RVA: 0x00028B54 File Offset: 0x00026D54
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x00028B98 File Offset: 0x00026D98
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00028BB0 File Offset: 0x00026DB0
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x00028BBC File Offset: 0x00026DBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000505 RID: 1285
		private ErrorCode? _errorCode;

		// Token: 0x04000506 RID: 1286
		private IExtension extensionObject;
	}
}
