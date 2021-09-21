using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000486 RID: 1158
	[ProtoContract(Name = "TactEnterSceneRes")]
	[Serializable]
	public class TactEnterSceneRes : IExtensible
	{
		// Token: 0x1700128F RID: 4751
		// (get) Token: 0x06003C84 RID: 15492 RVA: 0x00073974 File Offset: 0x00071B74
		// (set) Token: 0x06003C85 RID: 15493 RVA: 0x000739A0 File Offset: 0x00071BA0
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

		// Token: 0x17001290 RID: 4752
		// (get) Token: 0x06003C86 RID: 15494 RVA: 0x000739B0 File Offset: 0x00071BB0
		// (set) Token: 0x06003C87 RID: 15495 RVA: 0x000739D0 File Offset: 0x00071BD0
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

		// Token: 0x06003C88 RID: 15496 RVA: 0x00073A14 File Offset: 0x00071C14
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003C89 RID: 15497 RVA: 0x00073A2C File Offset: 0x00071C2C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003C8A RID: 15498 RVA: 0x00073A38 File Offset: 0x00071C38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F10 RID: 3856
		private ErrorCode? _result;

		// Token: 0x04000F11 RID: 3857
		private IExtension extensionObject;
	}
}
