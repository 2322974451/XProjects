using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A4 RID: 932
	[ProtoContract(Name = "JoinLeagueEleBattleRes")]
	[Serializable]
	public class JoinLeagueEleBattleRes : IExtensible
	{
		// Token: 0x17000F7B RID: 3963
		// (get) Token: 0x06003224 RID: 12836 RVA: 0x00060824 File Offset: 0x0005EA24
		// (set) Token: 0x06003225 RID: 12837 RVA: 0x00060850 File Offset: 0x0005EA50
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

		// Token: 0x17000F7C RID: 3964
		// (get) Token: 0x06003226 RID: 12838 RVA: 0x00060860 File Offset: 0x0005EA60
		// (set) Token: 0x06003227 RID: 12839 RVA: 0x00060880 File Offset: 0x0005EA80
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

		// Token: 0x06003228 RID: 12840 RVA: 0x000608C4 File Offset: 0x0005EAC4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003229 RID: 12841 RVA: 0x000608DC File Offset: 0x0005EADC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600322A RID: 12842 RVA: 0x000608E8 File Offset: 0x0005EAE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C75 RID: 3189
		private ErrorCode? _result;

		// Token: 0x04000C76 RID: 3190
		private IExtension extensionObject;
	}
}
