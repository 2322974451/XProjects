using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FD RID: 1277
	[ProtoContract(Name = "GetDailyTaskRefreshRecordRes")]
	[Serializable]
	public class GetDailyTaskRefreshRecordRes : IExtensible
	{
		// Token: 0x17001432 RID: 5170
		// (get) Token: 0x060041F9 RID: 16889 RVA: 0x0007D9B0 File Offset: 0x0007BBB0
		// (set) Token: 0x060041FA RID: 16890 RVA: 0x0007D9DC File Offset: 0x0007BBDC
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

		// Token: 0x17001433 RID: 5171
		// (get) Token: 0x060041FB RID: 16891 RVA: 0x0007D9EC File Offset: 0x0007BBEC
		// (set) Token: 0x060041FC RID: 16892 RVA: 0x0007DA0C File Offset: 0x0007BC0C
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

		// Token: 0x060041FD RID: 16893 RVA: 0x0007DA50 File Offset: 0x0007BC50
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060041FE RID: 16894 RVA: 0x0007DA68 File Offset: 0x0007BC68
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001434 RID: 5172
		// (get) Token: 0x060041FF RID: 16895 RVA: 0x0007DA74 File Offset: 0x0007BC74
		[ProtoMember(2, Name = "records", DataFormat = DataFormat.Default)]
		public List<DailyTaskRefreshInfo> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x06004200 RID: 16896 RVA: 0x0007DA8C File Offset: 0x0007BC8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001074 RID: 4212
		private ErrorCode? _result;

		// Token: 0x04001075 RID: 4213
		private readonly List<DailyTaskRefreshInfo> _records = new List<DailyTaskRefreshInfo>();

		// Token: 0x04001076 RID: 4214
		private IExtension extensionObject;
	}
}
