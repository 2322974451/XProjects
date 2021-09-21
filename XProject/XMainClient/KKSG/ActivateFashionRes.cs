using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003EA RID: 1002
	[ProtoContract(Name = "ActivateFashionRes")]
	[Serializable]
	public class ActivateFashionRes : IExtensible
	{
		// Token: 0x17001060 RID: 4192
		// (get) Token: 0x0600353D RID: 13629 RVA: 0x00066088 File Offset: 0x00064288
		// (set) Token: 0x0600353E RID: 13630 RVA: 0x000660B4 File Offset: 0x000642B4
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001061 RID: 4193
		// (get) Token: 0x0600353F RID: 13631 RVA: 0x000660C4 File Offset: 0x000642C4
		// (set) Token: 0x06003540 RID: 13632 RVA: 0x000660E4 File Offset: 0x000642E4
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003541 RID: 13633 RVA: 0x00066128 File Offset: 0x00064328
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003542 RID: 13634 RVA: 0x00066140 File Offset: 0x00064340
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001062 RID: 4194
		// (get) Token: 0x06003543 RID: 13635 RVA: 0x0006614C File Offset: 0x0006434C
		// (set) Token: 0x06003544 RID: 13636 RVA: 0x00066178 File Offset: 0x00064378
		[ProtoMember(2, IsRequired = false, Name = "active_count", DataFormat = DataFormat.TwosComplement)]
		public uint active_count
		{
			get
			{
				return this._active_count ?? 0U;
			}
			set
			{
				this._active_count = new uint?(value);
			}
		}

		// Token: 0x17001063 RID: 4195
		// (get) Token: 0x06003545 RID: 13637 RVA: 0x00066188 File Offset: 0x00064388
		// (set) Token: 0x06003546 RID: 13638 RVA: 0x000661A8 File Offset: 0x000643A8
		[XmlIgnore]
		[Browsable(false)]
		public bool active_countSpecified
		{
			get
			{
				return this._active_count != null;
			}
			set
			{
				bool flag = value == (this._active_count == null);
				if (flag)
				{
					this._active_count = (value ? new uint?(this.active_count) : null);
				}
			}
		}

		// Token: 0x06003547 RID: 13639 RVA: 0x000661EC File Offset: 0x000643EC
		private bool ShouldSerializeactive_count()
		{
			return this.active_countSpecified;
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x00066204 File Offset: 0x00064404
		private void Resetactive_count()
		{
			this.active_countSpecified = false;
		}

		// Token: 0x06003549 RID: 13641 RVA: 0x00066210 File Offset: 0x00064410
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D39 RID: 3385
		private ErrorCode? _result;

		// Token: 0x04000D3A RID: 3386
		private uint? _active_count;

		// Token: 0x04000D3B RID: 3387
		private IExtension extensionObject;
	}
}
