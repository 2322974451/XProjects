using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000093 RID: 147
	[ProtoContract(Name = "ChangeGuildSettingRes")]
	[Serializable]
	public class ChangeGuildSettingRes : IExtensible
	{
		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00014988 File Offset: 0x00012B88
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x000149B4 File Offset: 0x00012BB4
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

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000149C4 File Offset: 0x00012BC4
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x000149E4 File Offset: 0x00012BE4
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

		// Token: 0x06000978 RID: 2424 RVA: 0x00014A28 File Offset: 0x00012C28
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00014A40 File Offset: 0x00012C40
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00014A4C File Offset: 0x00012C4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000275 RID: 629
		private ErrorCode? _result;

		// Token: 0x04000276 RID: 630
		private IExtension extensionObject;
	}
}
