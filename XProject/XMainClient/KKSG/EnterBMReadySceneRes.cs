using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043B RID: 1083
	[ProtoContract(Name = "EnterBMReadySceneRes")]
	[Serializable]
	public class EnterBMReadySceneRes : IExtensible
	{
		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x06003929 RID: 14633 RVA: 0x0006D5D0 File Offset: 0x0006B7D0
		// (set) Token: 0x0600392A RID: 14634 RVA: 0x0006D5FC File Offset: 0x0006B7FC
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

		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x0600392B RID: 14635 RVA: 0x0006D60C File Offset: 0x0006B80C
		// (set) Token: 0x0600392C RID: 14636 RVA: 0x0006D62C File Offset: 0x0006B82C
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

		// Token: 0x0600392D RID: 14637 RVA: 0x0006D670 File Offset: 0x0006B870
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600392E RID: 14638 RVA: 0x0006D688 File Offset: 0x0006B888
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x0600392F RID: 14639 RVA: 0x0006D694 File Offset: 0x0006B894
		// (set) Token: 0x06003930 RID: 14640 RVA: 0x0006D6C0 File Offset: 0x0006B8C0
		[ProtoMember(2, IsRequired = false, Name = "group", DataFormat = DataFormat.TwosComplement)]
		public uint group
		{
			get
			{
				return this._group ?? 0U;
			}
			set
			{
				this._group = new uint?(value);
			}
		}

		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x06003931 RID: 14641 RVA: 0x0006D6D0 File Offset: 0x0006B8D0
		// (set) Token: 0x06003932 RID: 14642 RVA: 0x0006D6F0 File Offset: 0x0006B8F0
		[XmlIgnore]
		[Browsable(false)]
		public bool groupSpecified
		{
			get
			{
				return this._group != null;
			}
			set
			{
				bool flag = value == (this._group == null);
				if (flag)
				{
					this._group = (value ? new uint?(this.group) : null);
				}
			}
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x0006D734 File Offset: 0x0006B934
		private bool ShouldSerializegroup()
		{
			return this.groupSpecified;
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x0006D74C File Offset: 0x0006B94C
		private void Resetgroup()
		{
			this.groupSpecified = false;
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x0006D758 File Offset: 0x0006B958
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E30 RID: 3632
		private ErrorCode? _error;

		// Token: 0x04000E31 RID: 3633
		private uint? _group;

		// Token: 0x04000E32 RID: 3634
		private IExtension extensionObject;
	}
}
