using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000294 RID: 660
	[ProtoContract(Name = "SendGift2PlatFriendRes")]
	[Serializable]
	public class SendGift2PlatFriendRes : IExtensible
	{
		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x060024EC RID: 9452 RVA: 0x00047F94 File Offset: 0x00046194
		// (set) Token: 0x060024ED RID: 9453 RVA: 0x00047FC0 File Offset: 0x000461C0
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

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x060024EE RID: 9454 RVA: 0x00047FD0 File Offset: 0x000461D0
		// (set) Token: 0x060024EF RID: 9455 RVA: 0x00047FF0 File Offset: 0x000461F0
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

		// Token: 0x060024F0 RID: 9456 RVA: 0x00048034 File Offset: 0x00046234
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x0004804C File Offset: 0x0004624C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x00048058 File Offset: 0x00046258
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000921 RID: 2337
		private ErrorCode? _error;

		// Token: 0x04000922 RID: 2338
		private IExtension extensionObject;
	}
}
