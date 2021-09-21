using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000030 RID: 48
	[ProtoContract(Name = "EnhanceItemRes")]
	[Serializable]
	public class EnhanceItemRes : IExtensible
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00008F78 File Offset: 0x00007178
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00008FA4 File Offset: 0x000071A4
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

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00008FB4 File Offset: 0x000071B4
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00008FD4 File Offset: 0x000071D4
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

		// Token: 0x06000349 RID: 841 RVA: 0x00009018 File Offset: 0x00007218
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009030 File Offset: 0x00007230
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000903C File Offset: 0x0000723C
		[ProtoMember(2, Name = "comagates", DataFormat = DataFormat.Default)]
		public List<ComAgate> comagates
		{
			get
			{
				return this._comagates;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00009054 File Offset: 0x00007254
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00009080 File Offset: 0x00007280
		[ProtoMember(3, IsRequired = false, Name = "isEnd", DataFormat = DataFormat.Default)]
		public bool isEnd
		{
			get
			{
				return this._isEnd ?? false;
			}
			set
			{
				this._isEnd = new bool?(value);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00009090 File Offset: 0x00007290
		// (set) Token: 0x0600034F RID: 847 RVA: 0x000090B0 File Offset: 0x000072B0
		[XmlIgnore]
		[Browsable(false)]
		public bool isEndSpecified
		{
			get
			{
				return this._isEnd != null;
			}
			set
			{
				bool flag = value == (this._isEnd == null);
				if (flag)
				{
					this._isEnd = (value ? new bool?(this.isEnd) : null);
				}
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000090F4 File Offset: 0x000072F4
		private bool ShouldSerializeisEnd()
		{
			return this.isEndSpecified;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000910C File Offset: 0x0000730C
		private void ResetisEnd()
		{
			this.isEndSpecified = false;
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00009118 File Offset: 0x00007318
		[ProtoMember(4, Name = "nextAttrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> nextAttrs
		{
			get
			{
				return this._nextAttrs;
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00009130 File Offset: 0x00007330
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000DC RID: 220
		private ErrorCode? _ErrorCode;

		// Token: 0x040000DD RID: 221
		private readonly List<ComAgate> _comagates = new List<ComAgate>();

		// Token: 0x040000DE RID: 222
		private bool? _isEnd;

		// Token: 0x040000DF RID: 223
		private readonly List<AttributeInfo> _nextAttrs = new List<AttributeInfo>();

		// Token: 0x040000E0 RID: 224
		private IExtension extensionObject;
	}
}
