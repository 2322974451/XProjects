using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037B RID: 891
	[ProtoContract(Name = "LeaveLeagueTeamRes")]
	[Serializable]
	public class LeaveLeagueTeamRes : IExtensible
	{
		// Token: 0x17000F0B RID: 3851
		// (get) Token: 0x06003094 RID: 12436 RVA: 0x0005DB34 File Offset: 0x0005BD34
		// (set) Token: 0x06003095 RID: 12437 RVA: 0x0005DB60 File Offset: 0x0005BD60
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

		// Token: 0x17000F0C RID: 3852
		// (get) Token: 0x06003096 RID: 12438 RVA: 0x0005DB70 File Offset: 0x0005BD70
		// (set) Token: 0x06003097 RID: 12439 RVA: 0x0005DB90 File Offset: 0x0005BD90
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

		// Token: 0x06003098 RID: 12440 RVA: 0x0005DBD4 File Offset: 0x0005BDD4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x0005DBEC File Offset: 0x0005BDEC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x0005DBF8 File Offset: 0x0005BDF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C0D RID: 3085
		private ErrorCode? _result;

		// Token: 0x04000C0E RID: 3086
		private IExtension extensionObject;
	}
}
