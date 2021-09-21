using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FF RID: 1023
	[ProtoContract(Name = "AbsEnterSceneRes")]
	[Serializable]
	public class AbsEnterSceneRes : IExtensible
	{
		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x06003625 RID: 13861 RVA: 0x00067B78 File Offset: 0x00065D78
		// (set) Token: 0x06003626 RID: 13862 RVA: 0x00067BA4 File Offset: 0x00065DA4
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x06003627 RID: 13863 RVA: 0x00067BB4 File Offset: 0x00065DB4
		// (set) Token: 0x06003628 RID: 13864 RVA: 0x00067BD4 File Offset: 0x00065DD4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x00067C18 File Offset: 0x00065E18
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600362A RID: 13866 RVA: 0x00067C30 File Offset: 0x00065E30
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x00067C3C File Offset: 0x00065E3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D76 RID: 3446
		private ErrorCode? _error;

		// Token: 0x04000D77 RID: 3447
		private IExtension extensionObject;
	}
}
