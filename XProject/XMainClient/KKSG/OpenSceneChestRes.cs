using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BF RID: 191
	[ProtoContract(Name = "OpenSceneChestRes")]
	[Serializable]
	public class OpenSceneChestRes : IExtensible
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x0001AF10 File Offset: 0x00019110
		// (set) Token: 0x06000CD1 RID: 3281 RVA: 0x0001AF3C File Offset: 0x0001913C
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

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x0001AF4C File Offset: 0x0001914C
		// (set) Token: 0x06000CD3 RID: 3283 RVA: 0x0001AF6C File Offset: 0x0001916C
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

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0001AFB0 File Offset: 0x000191B0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0001AFC8 File Offset: 0x000191C8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0001AFD4 File Offset: 0x000191D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400032F RID: 815
		private ErrorCode? _result;

		// Token: 0x04000330 RID: 816
		private IExtension extensionObject;
	}
}
