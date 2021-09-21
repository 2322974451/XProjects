using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000068 RID: 104
	[ProtoContract(Name = "AddTempAttrRes")]
	[Serializable]
	public class AddTempAttrRes : IExtensible
	{
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x0000FF24 File Offset: 0x0000E124
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x0000FF50 File Offset: 0x0000E150
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

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0000FF60 File Offset: 0x0000E160
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x0000FF80 File Offset: 0x0000E180
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

		// Token: 0x060006F3 RID: 1779 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0000FFDC File Offset: 0x0000E1DC
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x0000FFE8 File Offset: 0x0000E1E8
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x00010014 File Offset: 0x0000E214
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00010024 File Offset: 0x0000E224
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00010044 File Offset: 0x0000E244
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00010088 File Offset: 0x0000E288
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x000100A0 File Offset: 0x0000E2A0
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x000100AC File Offset: 0x0000E2AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001C0 RID: 448
		private ErrorCode? _ErrorCode;

		// Token: 0x040001C1 RID: 449
		private uint? _count;

		// Token: 0x040001C2 RID: 450
		private IExtension extensionObject;
	}
}
