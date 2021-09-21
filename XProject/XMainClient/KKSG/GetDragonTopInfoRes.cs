using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000162 RID: 354
	[ProtoContract(Name = "GetDragonTopInfoRes")]
	[Serializable]
	public class GetDragonTopInfoRes : IExtensible
	{
		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001579 RID: 5497 RVA: 0x0002B268 File Offset: 0x00029468
		// (set) Token: 0x0600157A RID: 5498 RVA: 0x0002B294 File Offset: 0x00029494
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

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x0600157B RID: 5499 RVA: 0x0002B2A4 File Offset: 0x000294A4
		// (set) Token: 0x0600157C RID: 5500 RVA: 0x0002B2C4 File Offset: 0x000294C4
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

		// Token: 0x0600157D RID: 5501 RVA: 0x0002B308 File Offset: 0x00029508
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x0002B320 File Offset: 0x00029520
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x0600157F RID: 5503 RVA: 0x0002B32C File Offset: 0x0002952C
		[ProtoMember(2, Name = "dragonInfo", DataFormat = DataFormat.Default)]
		public List<DragonInfo2Client> dragonInfo
		{
			get
			{
				return this._dragonInfo;
			}
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0002B344 File Offset: 0x00029544
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000555 RID: 1365
		private ErrorCode? _errorCode;

		// Token: 0x04000556 RID: 1366
		private readonly List<DragonInfo2Client> _dragonInfo = new List<DragonInfo2Client>();

		// Token: 0x04000557 RID: 1367
		private IExtension extensionObject;
	}
}
