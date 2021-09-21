using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B5 RID: 181
	[ProtoContract(Name = "StageCountResetRes")]
	[Serializable]
	public class StageCountResetRes : IExtensible
	{
		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x0001A0A0 File Offset: 0x000182A0
		// (set) Token: 0x06000C55 RID: 3157 RVA: 0x0001A0CC File Offset: 0x000182CC
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

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x0001A0DC File Offset: 0x000182DC
		// (set) Token: 0x06000C57 RID: 3159 RVA: 0x0001A0FC File Offset: 0x000182FC
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

		// Token: 0x06000C58 RID: 3160 RVA: 0x0001A140 File Offset: 0x00018340
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0001A158 File Offset: 0x00018358
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x0001A164 File Offset: 0x00018364
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400030E RID: 782
		private ErrorCode? _errorcode;

		// Token: 0x0400030F RID: 783
		private IExtension extensionObject;
	}
}
