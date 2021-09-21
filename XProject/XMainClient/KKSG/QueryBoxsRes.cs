using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000509 RID: 1289
	[ProtoContract(Name = "QueryBoxsRes")]
	[Serializable]
	public class QueryBoxsRes : IExtensible
	{
		// Token: 0x17001455 RID: 5205
		// (get) Token: 0x06004275 RID: 17013 RVA: 0x0007E7FC File Offset: 0x0007C9FC
		// (set) Token: 0x06004276 RID: 17014 RVA: 0x0007E828 File Offset: 0x0007CA28
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

		// Token: 0x17001456 RID: 5206
		// (get) Token: 0x06004277 RID: 17015 RVA: 0x0007E838 File Offset: 0x0007CA38
		// (set) Token: 0x06004278 RID: 17016 RVA: 0x0007E858 File Offset: 0x0007CA58
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

		// Token: 0x06004279 RID: 17017 RVA: 0x0007E89C File Offset: 0x0007CA9C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600427A RID: 17018 RVA: 0x0007E8B4 File Offset: 0x0007CAB4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001457 RID: 5207
		// (get) Token: 0x0600427B RID: 17019 RVA: 0x0007E8C0 File Offset: 0x0007CAC0
		// (set) Token: 0x0600427C RID: 17020 RVA: 0x0007E8EC File Offset: 0x0007CAEC
		[ProtoMember(2, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x17001458 RID: 5208
		// (get) Token: 0x0600427D RID: 17021 RVA: 0x0007E8FC File Offset: 0x0007CAFC
		// (set) Token: 0x0600427E RID: 17022 RVA: 0x0007E91C File Offset: 0x0007CB1C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x0600427F RID: 17023 RVA: 0x0007E960 File Offset: 0x0007CB60
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06004280 RID: 17024 RVA: 0x0007E978 File Offset: 0x0007CB78
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x17001459 RID: 5209
		// (get) Token: 0x06004281 RID: 17025 RVA: 0x0007E984 File Offset: 0x0007CB84
		[ProtoMember(3, Name = "boxinfos", DataFormat = DataFormat.Default)]
		public List<BoxInfos> boxinfos
		{
			get
			{
				return this._boxinfos;
			}
		}

		// Token: 0x06004282 RID: 17026 RVA: 0x0007E99C File Offset: 0x0007CB9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001093 RID: 4243
		private ErrorCode? _errorcode;

		// Token: 0x04001094 RID: 4244
		private uint? _timeleft;

		// Token: 0x04001095 RID: 4245
		private readonly List<BoxInfos> _boxinfos = new List<BoxInfos>();

		// Token: 0x04001096 RID: 4246
		private IExtension extensionObject;
	}
}
