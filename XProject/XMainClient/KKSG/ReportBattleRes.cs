using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C4 RID: 196
	[ProtoContract(Name = "ReportBattleRes")]
	[Serializable]
	public class ReportBattleRes : IExtensible
	{
		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000D09 RID: 3337 RVA: 0x0001B56C File Offset: 0x0001976C
		// (set) Token: 0x06000D0A RID: 3338 RVA: 0x0001B598 File Offset: 0x00019798
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

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0001B5A8 File Offset: 0x000197A8
		// (set) Token: 0x06000D0C RID: 3340 RVA: 0x0001B5C8 File Offset: 0x000197C8
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

		// Token: 0x06000D0D RID: 3341 RVA: 0x0001B60C File Offset: 0x0001980C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0001B624 File Offset: 0x00019824
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0001B630 File Offset: 0x00019830
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000343 RID: 835
		private ErrorCode? _result;

		// Token: 0x04000344 RID: 836
		private IExtension extensionObject;
	}
}
