using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051A RID: 1306
	[ProtoContract(Name = "ChooseSpecialEffectsRes")]
	[Serializable]
	public class ChooseSpecialEffectsRes : IExtensible
	{
		// Token: 0x17001485 RID: 5253
		// (get) Token: 0x06004323 RID: 17187 RVA: 0x0007FBAC File Offset: 0x0007DDAC
		// (set) Token: 0x06004324 RID: 17188 RVA: 0x0007FBD8 File Offset: 0x0007DDD8
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

		// Token: 0x17001486 RID: 5254
		// (get) Token: 0x06004325 RID: 17189 RVA: 0x0007FBE8 File Offset: 0x0007DDE8
		// (set) Token: 0x06004326 RID: 17190 RVA: 0x0007FC08 File Offset: 0x0007DE08
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

		// Token: 0x06004327 RID: 17191 RVA: 0x0007FC4C File Offset: 0x0007DE4C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004328 RID: 17192 RVA: 0x0007FC64 File Offset: 0x0007DE64
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06004329 RID: 17193 RVA: 0x0007FC70 File Offset: 0x0007DE70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010BD RID: 4285
		private ErrorCode? _result;

		// Token: 0x040010BE RID: 4286
		private IExtension extensionObject;
	}
}
