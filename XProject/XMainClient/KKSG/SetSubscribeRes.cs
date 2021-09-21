using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000390 RID: 912
	[ProtoContract(Name = "SetSubscribeRes")]
	[Serializable]
	public class SetSubscribeRes : IExtensible
	{
		// Token: 0x17000F49 RID: 3913
		// (get) Token: 0x0600316C RID: 12652 RVA: 0x0005F34C File Offset: 0x0005D54C
		// (set) Token: 0x0600316D RID: 12653 RVA: 0x0005F378 File Offset: 0x0005D578
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

		// Token: 0x17000F4A RID: 3914
		// (get) Token: 0x0600316E RID: 12654 RVA: 0x0005F388 File Offset: 0x0005D588
		// (set) Token: 0x0600316F RID: 12655 RVA: 0x0005F3A8 File Offset: 0x0005D5A8
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

		// Token: 0x06003170 RID: 12656 RVA: 0x0005F3EC File Offset: 0x0005D5EC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x0005F404 File Offset: 0x0005D604
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x0005F410 File Offset: 0x0005D610
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C46 RID: 3142
		private ErrorCode? _result;

		// Token: 0x04000C47 RID: 3143
		private IExtension extensionObject;
	}
}
