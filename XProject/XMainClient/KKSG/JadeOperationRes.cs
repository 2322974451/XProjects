using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000041 RID: 65
	[ProtoContract(Name = "JadeOperationRes")]
	[Serializable]
	public class JadeOperationRes : IExtensible
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x0000B378 File Offset: 0x00009578
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x0000B3A4 File Offset: 0x000095A4
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000B3B4 File Offset: 0x000095B4
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x0000B3D4 File Offset: 0x000095D4
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000B418 File Offset: 0x00009618
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000B430 File Offset: 0x00009630
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000B43C File Offset: 0x0000963C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000129 RID: 297
		private ErrorCode? _ErrorCode;

		// Token: 0x0400012A RID: 298
		private IExtension extensionObject;
	}
}
