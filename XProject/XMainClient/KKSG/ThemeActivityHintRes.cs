using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049E RID: 1182
	[ProtoContract(Name = "ThemeActivityHintRes")]
	[Serializable]
	public class ThemeActivityHintRes : IExtensible
	{
		// Token: 0x170012DA RID: 4826
		// (get) Token: 0x06003D85 RID: 15749 RVA: 0x000756B4 File Offset: 0x000738B4
		// (set) Token: 0x06003D86 RID: 15750 RVA: 0x000756E0 File Offset: 0x000738E0
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

		// Token: 0x170012DB RID: 4827
		// (get) Token: 0x06003D87 RID: 15751 RVA: 0x000756F0 File Offset: 0x000738F0
		// (set) Token: 0x06003D88 RID: 15752 RVA: 0x00075710 File Offset: 0x00073910
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

		// Token: 0x06003D89 RID: 15753 RVA: 0x00075754 File Offset: 0x00073954
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003D8A RID: 15754 RVA: 0x0007576C File Offset: 0x0007396C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003D8B RID: 15755 RVA: 0x00075778 File Offset: 0x00073978
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F52 RID: 3922
		private ErrorCode? _result;

		// Token: 0x04000F53 RID: 3923
		private IExtension extensionObject;
	}
}
