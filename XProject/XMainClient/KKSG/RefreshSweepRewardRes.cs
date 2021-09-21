using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000225 RID: 549
	[ProtoContract(Name = "RefreshSweepRewardRes")]
	[Serializable]
	public class RefreshSweepRewardRes : IExtensible
	{
		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x0003C8A8 File Offset: 0x0003AAA8
		// (set) Token: 0x06001ED6 RID: 7894 RVA: 0x0003C8D4 File Offset: 0x0003AAD4
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

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06001ED7 RID: 7895 RVA: 0x0003C8E4 File Offset: 0x0003AAE4
		// (set) Token: 0x06001ED8 RID: 7896 RVA: 0x0003C904 File Offset: 0x0003AB04
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

		// Token: 0x06001ED9 RID: 7897 RVA: 0x0003C948 File Offset: 0x0003AB48
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x0003C960 File Offset: 0x0003AB60
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06001EDB RID: 7899 RVA: 0x0003C96C File Offset: 0x0003AB6C
		// (set) Token: 0x06001EDC RID: 7900 RVA: 0x0003C998 File Offset: 0x0003AB98
		[ProtoMember(2, IsRequired = false, Name = "refreshResult", DataFormat = DataFormat.TwosComplement)]
		public int refreshResult
		{
			get
			{
				return this._refreshResult ?? 0;
			}
			set
			{
				this._refreshResult = new int?(value);
			}
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06001EDD RID: 7901 RVA: 0x0003C9A8 File Offset: 0x0003ABA8
		// (set) Token: 0x06001EDE RID: 7902 RVA: 0x0003C9C8 File Offset: 0x0003ABC8
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshResultSpecified
		{
			get
			{
				return this._refreshResult != null;
			}
			set
			{
				bool flag = value == (this._refreshResult == null);
				if (flag)
				{
					this._refreshResult = (value ? new int?(this.refreshResult) : null);
				}
			}
		}

		// Token: 0x06001EDF RID: 7903 RVA: 0x0003CA0C File Offset: 0x0003AC0C
		private bool ShouldSerializerefreshResult()
		{
			return this.refreshResultSpecified;
		}

		// Token: 0x06001EE0 RID: 7904 RVA: 0x0003CA24 File Offset: 0x0003AC24
		private void ResetrefreshResult()
		{
			this.refreshResultSpecified = false;
		}

		// Token: 0x06001EE1 RID: 7905 RVA: 0x0003CA30 File Offset: 0x0003AC30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007B2 RID: 1970
		private ErrorCode? _error;

		// Token: 0x040007B3 RID: 1971
		private int? _refreshResult;

		// Token: 0x040007B4 RID: 1972
		private IExtension extensionObject;
	}
}
