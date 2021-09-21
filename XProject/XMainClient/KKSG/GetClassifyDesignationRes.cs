using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000110 RID: 272
	[ProtoContract(Name = "GetClassifyDesignationRes")]
	[Serializable]
	public class GetClassifyDesignationRes : IExtensible
	{
		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x00023238 File Offset: 0x00021438
		// (set) Token: 0x06001133 RID: 4403 RVA: 0x00023264 File Offset: 0x00021464
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

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x00023274 File Offset: 0x00021474
		// (set) Token: 0x06001135 RID: 4405 RVA: 0x00023294 File Offset: 0x00021494
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

		// Token: 0x06001136 RID: 4406 RVA: 0x000232D8 File Offset: 0x000214D8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x000232F0 File Offset: 0x000214F0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x000232FC File Offset: 0x000214FC
		[ProtoMember(2, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<StcDesignationInfo> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00023314 File Offset: 0x00021514
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400044D RID: 1101
		private ErrorCode? _result;

		// Token: 0x0400044E RID: 1102
		private readonly List<StcDesignationInfo> _dataList = new List<StcDesignationInfo>();

		// Token: 0x0400044F RID: 1103
		private IExtension extensionObject;
	}
}
