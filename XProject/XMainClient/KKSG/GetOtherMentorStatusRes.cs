using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000309 RID: 777
	[ProtoContract(Name = "GetOtherMentorStatusRes")]
	[Serializable]
	public class GetOtherMentorStatusRes : IExtensible
	{
		// Token: 0x17000D2A RID: 3370
		// (get) Token: 0x06002A7D RID: 10877 RVA: 0x00052594 File Offset: 0x00050794
		// (set) Token: 0x06002A7E RID: 10878 RVA: 0x000525C0 File Offset: 0x000507C0
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

		// Token: 0x17000D2B RID: 3371
		// (get) Token: 0x06002A7F RID: 10879 RVA: 0x000525D0 File Offset: 0x000507D0
		// (set) Token: 0x06002A80 RID: 10880 RVA: 0x000525F0 File Offset: 0x000507F0
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

		// Token: 0x06002A81 RID: 10881 RVA: 0x00052634 File Offset: 0x00050834
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0005264C File Offset: 0x0005084C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D2C RID: 3372
		// (get) Token: 0x06002A83 RID: 10883 RVA: 0x00052658 File Offset: 0x00050858
		// (set) Token: 0x06002A84 RID: 10884 RVA: 0x00052684 File Offset: 0x00050884
		[ProtoMember(2, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public MentorApplyStatus status
		{
			get
			{
				return this._status ?? MentorApplyStatus.MentorApplyMaster;
			}
			set
			{
				this._status = new MentorApplyStatus?(value);
			}
		}

		// Token: 0x17000D2D RID: 3373
		// (get) Token: 0x06002A85 RID: 10885 RVA: 0x00052694 File Offset: 0x00050894
		// (set) Token: 0x06002A86 RID: 10886 RVA: 0x000526B4 File Offset: 0x000508B4
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new MentorApplyStatus?(this.status) : null);
				}
			}
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x000526F8 File Offset: 0x000508F8
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x00052710 File Offset: 0x00050910
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x06002A89 RID: 10889 RVA: 0x0005271C File Offset: 0x0005091C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A8C RID: 2700
		private ErrorCode? _error;

		// Token: 0x04000A8D RID: 2701
		private MentorApplyStatus? _status;

		// Token: 0x04000A8E RID: 2702
		private IExtension extensionObject;
	}
}
