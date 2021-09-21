using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AD RID: 685
	[ProtoContract(Name = "UseGuildBuffRes")]
	[Serializable]
	public class UseGuildBuffRes : IExtensible
	{
		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x06002620 RID: 9760 RVA: 0x0004A340 File Offset: 0x00048540
		// (set) Token: 0x06002621 RID: 9761 RVA: 0x0004A36C File Offset: 0x0004856C
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

		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x06002622 RID: 9762 RVA: 0x0004A37C File Offset: 0x0004857C
		// (set) Token: 0x06002623 RID: 9763 RVA: 0x0004A39C File Offset: 0x0004859C
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

		// Token: 0x06002624 RID: 9764 RVA: 0x0004A3E0 File Offset: 0x000485E0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x0004A3F8 File Offset: 0x000485F8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000BDC RID: 3036
		// (get) Token: 0x06002626 RID: 9766 RVA: 0x0004A404 File Offset: 0x00048604
		// (set) Token: 0x06002627 RID: 9767 RVA: 0x0004A430 File Offset: 0x00048630
		[ProtoMember(2, IsRequired = false, Name = "cd", DataFormat = DataFormat.TwosComplement)]
		public uint cd
		{
			get
			{
				return this._cd ?? 0U;
			}
			set
			{
				this._cd = new uint?(value);
			}
		}

		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x06002628 RID: 9768 RVA: 0x0004A440 File Offset: 0x00048640
		// (set) Token: 0x06002629 RID: 9769 RVA: 0x0004A460 File Offset: 0x00048660
		[XmlIgnore]
		[Browsable(false)]
		public bool cdSpecified
		{
			get
			{
				return this._cd != null;
			}
			set
			{
				bool flag = value == (this._cd == null);
				if (flag)
				{
					this._cd = (value ? new uint?(this.cd) : null);
				}
			}
		}

		// Token: 0x0600262A RID: 9770 RVA: 0x0004A4A4 File Offset: 0x000486A4
		private bool ShouldSerializecd()
		{
			return this.cdSpecified;
		}

		// Token: 0x0600262B RID: 9771 RVA: 0x0004A4BC File Offset: 0x000486BC
		private void Resetcd()
		{
			this.cdSpecified = false;
		}

		// Token: 0x0600262C RID: 9772 RVA: 0x0004A4C8 File Offset: 0x000486C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000974 RID: 2420
		private ErrorCode? _error;

		// Token: 0x04000975 RID: 2421
		private uint? _cd;

		// Token: 0x04000976 RID: 2422
		private IExtension extensionObject;
	}
}
