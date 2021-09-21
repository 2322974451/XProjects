using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002ED RID: 749
	[ProtoContract(Name = "JoinLargeRoomRes")]
	[Serializable]
	public class JoinLargeRoomRes : IExtensible
	{
		// Token: 0x17000CD2 RID: 3282
		// (get) Token: 0x0600294B RID: 10571 RVA: 0x000502BC File Offset: 0x0004E4BC
		// (set) Token: 0x0600294C RID: 10572 RVA: 0x000502E8 File Offset: 0x0004E4E8
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

		// Token: 0x17000CD3 RID: 3283
		// (get) Token: 0x0600294D RID: 10573 RVA: 0x000502F8 File Offset: 0x0004E4F8
		// (set) Token: 0x0600294E RID: 10574 RVA: 0x00050318 File Offset: 0x0004E518
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

		// Token: 0x0600294F RID: 10575 RVA: 0x0005035C File Offset: 0x0004E55C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x00050374 File Offset: 0x0004E574
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000CD4 RID: 3284
		// (get) Token: 0x06002951 RID: 10577 RVA: 0x00050380 File Offset: 0x0004E580
		// (set) Token: 0x06002952 RID: 10578 RVA: 0x00050398 File Offset: 0x0004E598
		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public JoinLargeRoomReply data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x06002953 RID: 10579 RVA: 0x000503A4 File Offset: 0x0004E5A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A40 RID: 2624
		private ErrorCode? _error;

		// Token: 0x04000A41 RID: 2625
		private JoinLargeRoomReply _data = null;

		// Token: 0x04000A42 RID: 2626
		private IExtension extensionObject;
	}
}
