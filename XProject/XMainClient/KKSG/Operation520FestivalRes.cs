using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055D RID: 1373
	[ProtoContract(Name = "Operation520FestivalRes")]
	[Serializable]
	public class Operation520FestivalRes : IExtensible
	{
		// Token: 0x17001574 RID: 5492
		// (get) Token: 0x06004643 RID: 17987 RVA: 0x00085768 File Offset: 0x00083968
		// (set) Token: 0x06004644 RID: 17988 RVA: 0x00085794 File Offset: 0x00083994
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17001575 RID: 5493
		// (get) Token: 0x06004645 RID: 17989 RVA: 0x000857A4 File Offset: 0x000839A4
		// (set) Token: 0x06004646 RID: 17990 RVA: 0x000857C4 File Offset: 0x000839C4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06004647 RID: 17991 RVA: 0x00085808 File Offset: 0x00083A08
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004648 RID: 17992 RVA: 0x00085820 File Offset: 0x00083A20
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001576 RID: 5494
		// (get) Token: 0x06004649 RID: 17993 RVA: 0x0008582C File Offset: 0x00083A2C
		// (set) Token: 0x0600464A RID: 17994 RVA: 0x00085844 File Offset: 0x00083A44
		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Festival520Data data
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

		// Token: 0x17001577 RID: 5495
		// (get) Token: 0x0600464B RID: 17995 RVA: 0x00085850 File Offset: 0x00083A50
		// (set) Token: 0x0600464C RID: 17996 RVA: 0x0008587C File Offset: 0x00083A7C
		[ProtoMember(3, IsRequired = false, Name = "totalLoveValue", DataFormat = DataFormat.TwosComplement)]
		public uint totalLoveValue
		{
			get
			{
				return this._totalLoveValue ?? 0U;
			}
			set
			{
				this._totalLoveValue = new uint?(value);
			}
		}

		// Token: 0x17001578 RID: 5496
		// (get) Token: 0x0600464D RID: 17997 RVA: 0x0008588C File Offset: 0x00083A8C
		// (set) Token: 0x0600464E RID: 17998 RVA: 0x000858AC File Offset: 0x00083AAC
		[XmlIgnore]
		[Browsable(false)]
		public bool totalLoveValueSpecified
		{
			get
			{
				return this._totalLoveValue != null;
			}
			set
			{
				bool flag = value == (this._totalLoveValue == null);
				if (flag)
				{
					this._totalLoveValue = (value ? new uint?(this.totalLoveValue) : null);
				}
			}
		}

		// Token: 0x0600464F RID: 17999 RVA: 0x000858F0 File Offset: 0x00083AF0
		private bool ShouldSerializetotalLoveValue()
		{
			return this.totalLoveValueSpecified;
		}

		// Token: 0x06004650 RID: 18000 RVA: 0x00085908 File Offset: 0x00083B08
		private void ResettotalLoveValue()
		{
			this.totalLoveValueSpecified = false;
		}

		// Token: 0x06004651 RID: 18001 RVA: 0x00085914 File Offset: 0x00083B14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001186 RID: 4486
		private ErrorCode? _errorcode;

		// Token: 0x04001187 RID: 4487
		private Festival520Data _data = null;

		// Token: 0x04001188 RID: 4488
		private uint? _totalLoveValue;

		// Token: 0x04001189 RID: 4489
		private IExtension extensionObject;
	}
}
