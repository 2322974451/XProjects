using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011A RID: 282
	[ProtoContract(Name = "GetAchieveRewardRes")]
	[Serializable]
	public class GetAchieveRewardRes : IExtensible
	{
		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06001197 RID: 4503 RVA: 0x00023DB4 File Offset: 0x00021FB4
		// (set) Token: 0x06001198 RID: 4504 RVA: 0x00023DE0 File Offset: 0x00021FE0
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

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001199 RID: 4505 RVA: 0x00023DF0 File Offset: 0x00021FF0
		// (set) Token: 0x0600119A RID: 4506 RVA: 0x00023E10 File Offset: 0x00022010
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

		// Token: 0x0600119B RID: 4507 RVA: 0x00023E54 File Offset: 0x00022054
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x00023E6C File Offset: 0x0002206C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x00023E78 File Offset: 0x00022078
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000467 RID: 1127
		private ErrorCode? _result;

		// Token: 0x04000468 RID: 1128
		private IExtension extensionObject;
	}
}
