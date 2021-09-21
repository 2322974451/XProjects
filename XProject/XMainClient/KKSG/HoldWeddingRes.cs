using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046E RID: 1134
	[ProtoContract(Name = "HoldWeddingRes")]
	[Serializable]
	public class HoldWeddingRes : IExtensible
	{
		// Token: 0x17001229 RID: 4649
		// (get) Token: 0x06003B47 RID: 15175 RVA: 0x00071494 File Offset: 0x0006F694
		// (set) Token: 0x06003B48 RID: 15176 RVA: 0x000714C0 File Offset: 0x0006F6C0
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

		// Token: 0x1700122A RID: 4650
		// (get) Token: 0x06003B49 RID: 15177 RVA: 0x000714D0 File Offset: 0x0006F6D0
		// (set) Token: 0x06003B4A RID: 15178 RVA: 0x000714F0 File Offset: 0x0006F6F0
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

		// Token: 0x06003B4B RID: 15179 RVA: 0x00071534 File Offset: 0x0006F734
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003B4C RID: 15180 RVA: 0x0007154C File Offset: 0x0006F74C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700122B RID: 4651
		// (get) Token: 0x06003B4D RID: 15181 RVA: 0x00071558 File Offset: 0x0006F758
		// (set) Token: 0x06003B4E RID: 15182 RVA: 0x00071570 File Offset: 0x0006F770
		[ProtoMember(2, IsRequired = false, Name = "briedf", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingBrief briedf
		{
			get
			{
				return this._briedf;
			}
			set
			{
				this._briedf = value;
			}
		}

		// Token: 0x06003B4F RID: 15183 RVA: 0x0007157C File Offset: 0x0006F77C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EBA RID: 3770
		private ErrorCode? _result;

		// Token: 0x04000EBB RID: 3771
		private WeddingBrief _briedf = null;

		// Token: 0x04000EBC RID: 3772
		private IExtension extensionObject;
	}
}
