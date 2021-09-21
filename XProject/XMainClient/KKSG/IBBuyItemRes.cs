using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F7 RID: 503
	[ProtoContract(Name = "IBBuyItemRes")]
	[Serializable]
	public class IBBuyItemRes : IExtensible
	{
		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x06001CA8 RID: 7336 RVA: 0x00038758 File Offset: 0x00036958
		// (set) Token: 0x06001CA9 RID: 7337 RVA: 0x00038784 File Offset: 0x00036984
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

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x06001CAA RID: 7338 RVA: 0x00038794 File Offset: 0x00036994
		// (set) Token: 0x06001CAB RID: 7339 RVA: 0x000387B4 File Offset: 0x000369B4
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

		// Token: 0x06001CAC RID: 7340 RVA: 0x000387F8 File Offset: 0x000369F8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x00038810 File Offset: 0x00036A10
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x0003881C File Offset: 0x00036A1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000721 RID: 1825
		private ErrorCode? _errorcode;

		// Token: 0x04000722 RID: 1826
		private IExtension extensionObject;
	}
}
