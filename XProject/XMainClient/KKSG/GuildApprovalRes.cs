using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008F RID: 143
	[ProtoContract(Name = "GuildApprovalRes")]
	[Serializable]
	public class GuildApprovalRes : IExtensible
	{
		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x000143D4 File Offset: 0x000125D4
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00014400 File Offset: 0x00012600
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

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00014410 File Offset: 0x00012610
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00014430 File Offset: 0x00012630
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

		// Token: 0x06000946 RID: 2374 RVA: 0x00014474 File Offset: 0x00012674
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0001448C File Offset: 0x0001268C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00014498 File Offset: 0x00012698
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400026A RID: 618
		private ErrorCode? _result;

		// Token: 0x0400026B RID: 619
		private IExtension extensionObject;
	}
}
