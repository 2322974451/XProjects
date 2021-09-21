using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000233 RID: 563
	[ProtoContract(Name = "GetTowerFirstPassRewardRes")]
	[Serializable]
	public class GetTowerFirstPassRewardRes : IExtensible
	{
		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x06001F57 RID: 8023 RVA: 0x0003D744 File Offset: 0x0003B944
		// (set) Token: 0x06001F58 RID: 8024 RVA: 0x0003D770 File Offset: 0x0003B970
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

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06001F59 RID: 8025 RVA: 0x0003D780 File Offset: 0x0003B980
		// (set) Token: 0x06001F5A RID: 8026 RVA: 0x0003D7A0 File Offset: 0x0003B9A0
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

		// Token: 0x06001F5B RID: 8027 RVA: 0x0003D7E4 File Offset: 0x0003B9E4
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x0003D7FC File Offset: 0x0003B9FC
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x0003D808 File Offset: 0x0003BA08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007D1 RID: 2001
		private ErrorCode? _error;

		// Token: 0x040007D2 RID: 2002
		private IExtension extensionObject;
	}
}
