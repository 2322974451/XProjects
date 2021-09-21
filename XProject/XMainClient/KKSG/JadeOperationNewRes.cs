using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054E RID: 1358
	[ProtoContract(Name = "JadeOperationNewRes")]
	[Serializable]
	public class JadeOperationNewRes : IExtensible
	{
		// Token: 0x1700153D RID: 5437
		// (get) Token: 0x06004582 RID: 17794 RVA: 0x00084208 File Offset: 0x00082408
		// (set) Token: 0x06004583 RID: 17795 RVA: 0x00084234 File Offset: 0x00082434
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700153E RID: 5438
		// (get) Token: 0x06004584 RID: 17796 RVA: 0x00084244 File Offset: 0x00082444
		// (set) Token: 0x06004585 RID: 17797 RVA: 0x00084264 File Offset: 0x00082464
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x06004586 RID: 17798 RVA: 0x000842A8 File Offset: 0x000824A8
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x06004587 RID: 17799 RVA: 0x000842C0 File Offset: 0x000824C0
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x1700153F RID: 5439
		// (get) Token: 0x06004588 RID: 17800 RVA: 0x000842CC File Offset: 0x000824CC
		// (set) Token: 0x06004589 RID: 17801 RVA: 0x000842F8 File Offset: 0x000824F8
		[ProtoMember(2, IsRequired = false, Name = "jadeSealID", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSealID
		{
			get
			{
				return this._jadeSealID ?? 0U;
			}
			set
			{
				this._jadeSealID = new uint?(value);
			}
		}

		// Token: 0x17001540 RID: 5440
		// (get) Token: 0x0600458A RID: 17802 RVA: 0x00084308 File Offset: 0x00082508
		// (set) Token: 0x0600458B RID: 17803 RVA: 0x00084328 File Offset: 0x00082528
		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSealIDSpecified
		{
			get
			{
				return this._jadeSealID != null;
			}
			set
			{
				bool flag = value == (this._jadeSealID == null);
				if (flag)
				{
					this._jadeSealID = (value ? new uint?(this.jadeSealID) : null);
				}
			}
		}

		// Token: 0x0600458C RID: 17804 RVA: 0x0008436C File Offset: 0x0008256C
		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		// Token: 0x0600458D RID: 17805 RVA: 0x00084384 File Offset: 0x00082584
		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		// Token: 0x0600458E RID: 17806 RVA: 0x00084390 File Offset: 0x00082590
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400115B RID: 4443
		private ErrorCode? _ErrorCode;

		// Token: 0x0400115C RID: 4444
		private uint? _jadeSealID;

		// Token: 0x0400115D RID: 4445
		private IExtension extensionObject;
	}
}
