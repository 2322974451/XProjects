using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E6 RID: 742
	[ProtoContract(Name = "QueryQQVipInfoRes")]
	[Serializable]
	public class QueryQQVipInfoRes : IExtensible
	{
		// Token: 0x17000CB1 RID: 3249
		// (get) Token: 0x060028DE RID: 10462 RVA: 0x0004F624 File Offset: 0x0004D824
		// (set) Token: 0x060028DF RID: 10463 RVA: 0x0004F650 File Offset: 0x0004D850
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

		// Token: 0x17000CB2 RID: 3250
		// (get) Token: 0x060028E0 RID: 10464 RVA: 0x0004F660 File Offset: 0x0004D860
		// (set) Token: 0x060028E1 RID: 10465 RVA: 0x0004F680 File Offset: 0x0004D880
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

		// Token: 0x060028E2 RID: 10466 RVA: 0x0004F6C4 File Offset: 0x0004D8C4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x0004F6DC File Offset: 0x0004D8DC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000CB3 RID: 3251
		// (get) Token: 0x060028E4 RID: 10468 RVA: 0x0004F6E8 File Offset: 0x0004D8E8
		// (set) Token: 0x060028E5 RID: 10469 RVA: 0x0004F700 File Offset: 0x0004D900
		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public QQVipInfoClient info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x060028E6 RID: 10470 RVA: 0x0004F70C File Offset: 0x0004D90C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A27 RID: 2599
		private ErrorCode? _result;

		// Token: 0x04000A28 RID: 2600
		private QQVipInfoClient _info = null;

		// Token: 0x04000A29 RID: 2601
		private IExtension extensionObject;
	}
}
