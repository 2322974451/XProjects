using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FE RID: 510
	[ProtoContract(Name = "breakAtlasRes")]
	[Serializable]
	public class breakAtlasRes : IExtensible
	{
		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06001CEF RID: 7407 RVA: 0x00038F98 File Offset: 0x00037198
		// (set) Token: 0x06001CF0 RID: 7408 RVA: 0x00038FC4 File Offset: 0x000371C4
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

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x06001CF1 RID: 7409 RVA: 0x00038FD4 File Offset: 0x000371D4
		// (set) Token: 0x06001CF2 RID: 7410 RVA: 0x00038FF4 File Offset: 0x000371F4
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

		// Token: 0x06001CF3 RID: 7411 RVA: 0x00039038 File Offset: 0x00037238
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x00039050 File Offset: 0x00037250
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x0003905C File Offset: 0x0003725C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000734 RID: 1844
		private ErrorCode? _errorcode;

		// Token: 0x04000735 RID: 1845
		private IExtension extensionObject;
	}
}
