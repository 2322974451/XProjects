using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A9 RID: 681
	[ProtoContract(Name = "SendGuildBonusInSendListRes")]
	[Serializable]
	public class SendGuildBonusInSendListRes : IExtensible
	{
		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x060025F2 RID: 9714 RVA: 0x00049DD8 File Offset: 0x00047FD8
		// (set) Token: 0x060025F3 RID: 9715 RVA: 0x00049E04 File Offset: 0x00048004
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

		// Token: 0x17000BCD RID: 3021
		// (get) Token: 0x060025F4 RID: 9716 RVA: 0x00049E14 File Offset: 0x00048014
		// (set) Token: 0x060025F5 RID: 9717 RVA: 0x00049E34 File Offset: 0x00048034
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

		// Token: 0x060025F6 RID: 9718 RVA: 0x00049E78 File Offset: 0x00048078
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060025F7 RID: 9719 RVA: 0x00049E90 File Offset: 0x00048090
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x00049E9C File Offset: 0x0004809C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000968 RID: 2408
		private ErrorCode? _error;

		// Token: 0x04000969 RID: 2409
		private IExtension extensionObject;
	}
}
