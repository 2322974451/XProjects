using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000115 RID: 277
	[ProtoContract(Name = "GetAchieveClassifyInfoRes")]
	[Serializable]
	public class GetAchieveClassifyInfoRes : IExtensible
	{
		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x0600116E RID: 4462 RVA: 0x00023928 File Offset: 0x00021B28
		// (set) Token: 0x0600116F RID: 4463 RVA: 0x00023954 File Offset: 0x00021B54
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

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06001170 RID: 4464 RVA: 0x00023964 File Offset: 0x00021B64
		// (set) Token: 0x06001171 RID: 4465 RVA: 0x00023984 File Offset: 0x00021B84
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

		// Token: 0x06001172 RID: 4466 RVA: 0x000239C8 File Offset: 0x00021BC8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x000239E0 File Offset: 0x00021BE0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001174 RID: 4468 RVA: 0x000239EC File Offset: 0x00021BEC
		[ProtoMember(2, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<StcAchieveInfo> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x00023A04 File Offset: 0x00021C04
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400045C RID: 1116
		private ErrorCode? _result;

		// Token: 0x0400045D RID: 1117
		private readonly List<StcAchieveInfo> _dataList = new List<StcAchieveInfo>();

		// Token: 0x0400045E RID: 1118
		private IExtension extensionObject;
	}
}
