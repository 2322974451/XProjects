using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B1 RID: 1201
	[ProtoContract(Name = "ChangeDragonGuildSettingRes")]
	[Serializable]
	public class ChangeDragonGuildSettingRes : IExtensible
	{
		// Token: 0x17001333 RID: 4915
		// (get) Token: 0x06003EA4 RID: 16036 RVA: 0x000777D4 File Offset: 0x000759D4
		// (set) Token: 0x06003EA5 RID: 16037 RVA: 0x00077800 File Offset: 0x00075A00
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

		// Token: 0x17001334 RID: 4916
		// (get) Token: 0x06003EA6 RID: 16038 RVA: 0x00077810 File Offset: 0x00075A10
		// (set) Token: 0x06003EA7 RID: 16039 RVA: 0x00077830 File Offset: 0x00075A30
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

		// Token: 0x06003EA8 RID: 16040 RVA: 0x00077874 File Offset: 0x00075A74
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003EA9 RID: 16041 RVA: 0x0007788C File Offset: 0x00075A8C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003EAA RID: 16042 RVA: 0x00077898 File Offset: 0x00075A98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F97 RID: 3991
		private ErrorCode? _result;

		// Token: 0x04000F98 RID: 3992
		private IExtension extensionObject;
	}
}
