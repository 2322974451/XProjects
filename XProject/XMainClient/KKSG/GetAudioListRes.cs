using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014F RID: 335
	[ProtoContract(Name = "GetAudioListRes")]
	[Serializable]
	public class GetAudioListRes : IExtensible
	{
		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x000290E8 File Offset: 0x000272E8
		// (set) Token: 0x0600145E RID: 5214 RVA: 0x00029114 File Offset: 0x00027314
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

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x00029124 File Offset: 0x00027324
		// (set) Token: 0x06001460 RID: 5216 RVA: 0x00029144 File Offset: 0x00027344
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

		// Token: 0x06001461 RID: 5217 RVA: 0x00029188 File Offset: 0x00027388
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x000291A0 File Offset: 0x000273A0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06001463 RID: 5219 RVA: 0x000291AC File Offset: 0x000273AC
		[ProtoMember(2, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<AudioBrief> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x000291C4 File Offset: 0x000273C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000514 RID: 1300
		private ErrorCode? _result;

		// Token: 0x04000515 RID: 1301
		private readonly List<AudioBrief> _dataList = new List<AudioBrief>();

		// Token: 0x04000516 RID: 1302
		private IExtension extensionObject;
	}
}
