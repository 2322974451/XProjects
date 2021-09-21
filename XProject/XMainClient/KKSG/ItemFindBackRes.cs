using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F3 RID: 499
	[ProtoContract(Name = "ItemFindBackRes")]
	[Serializable]
	public class ItemFindBackRes : IExtensible
	{
		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x06001C7C RID: 7292 RVA: 0x00038240 File Offset: 0x00036440
		// (set) Token: 0x06001C7D RID: 7293 RVA: 0x0003826C File Offset: 0x0003646C
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

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x06001C7E RID: 7294 RVA: 0x0003827C File Offset: 0x0003647C
		// (set) Token: 0x06001C7F RID: 7295 RVA: 0x0003829C File Offset: 0x0003649C
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

		// Token: 0x06001C80 RID: 7296 RVA: 0x000382E0 File Offset: 0x000364E0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x000382F8 File Offset: 0x000364F8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x00038304 File Offset: 0x00036504
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000717 RID: 1815
		private ErrorCode? _error;

		// Token: 0x04000718 RID: 1816
		private IExtension extensionObject;
	}
}
