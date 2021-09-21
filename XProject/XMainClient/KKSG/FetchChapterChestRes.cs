using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000087 RID: 135
	[ProtoContract(Name = "FetchChapterChestRes")]
	[Serializable]
	public class FetchChapterChestRes : IExtensible
	{
		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x000138E8 File Offset: 0x00011AE8
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x00013914 File Offset: 0x00011B14
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

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00013924 File Offset: 0x00011B24
		// (set) Token: 0x060008E7 RID: 2279 RVA: 0x00013944 File Offset: 0x00011B44
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

		// Token: 0x060008E8 RID: 2280 RVA: 0x00013988 File Offset: 0x00011B88
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x000139A0 File Offset: 0x00011BA0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000139AC File Offset: 0x00011BAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400024B RID: 587
		private ErrorCode? _result;

		// Token: 0x0400024C RID: 588
		private IExtension extensionObject;
	}
}
