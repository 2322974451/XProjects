using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000EC RID: 236
	[ProtoContract(Name = "UseSupplementRes")]
	[Serializable]
	public class UseSupplementRes : IExtensible
	{
		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x0001F22C File Offset: 0x0001D42C
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x0001F258 File Offset: 0x0001D458
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

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x0001F268 File Offset: 0x0001D468
		// (set) Token: 0x06000F16 RID: 3862 RVA: 0x0001F288 File Offset: 0x0001D488
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

		// Token: 0x06000F17 RID: 3863 RVA: 0x0001F2CC File Offset: 0x0001D4CC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003CA RID: 970
		private ErrorCode? _errorcode;

		// Token: 0x040003CB RID: 971
		private IExtension extensionObject;
	}
}
