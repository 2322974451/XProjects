using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B0 RID: 176
	[ProtoContract(Name = "GuildCheckinRes")]
	[Serializable]
	public class GuildCheckinRes : IExtensible
	{
		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00019B68 File Offset: 0x00017D68
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00019B94 File Offset: 0x00017D94
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

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00019BA4 File Offset: 0x00017DA4
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00019BC4 File Offset: 0x00017DC4
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

		// Token: 0x06000C2A RID: 3114 RVA: 0x00019C08 File Offset: 0x00017E08
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00019C20 File Offset: 0x00017E20
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00019C2C File Offset: 0x00017E2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000303 RID: 771
		private ErrorCode? _errorcode;

		// Token: 0x04000304 RID: 772
		private IExtension extensionObject;
	}
}
