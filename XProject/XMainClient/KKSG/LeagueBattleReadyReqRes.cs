using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000388 RID: 904
	[ProtoContract(Name = "LeagueBattleReadyReqRes")]
	[Serializable]
	public class LeagueBattleReadyReqRes : IExtensible
	{
		// Token: 0x17000F2D RID: 3885
		// (get) Token: 0x0600310C RID: 12556 RVA: 0x0005E850 File Offset: 0x0005CA50
		// (set) Token: 0x0600310D RID: 12557 RVA: 0x0005E87C File Offset: 0x0005CA7C
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

		// Token: 0x17000F2E RID: 3886
		// (get) Token: 0x0600310E RID: 12558 RVA: 0x0005E88C File Offset: 0x0005CA8C
		// (set) Token: 0x0600310F RID: 12559 RVA: 0x0005E8AC File Offset: 0x0005CAAC
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

		// Token: 0x06003110 RID: 12560 RVA: 0x0005E8F0 File Offset: 0x0005CAF0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003111 RID: 12561 RVA: 0x0005E908 File Offset: 0x0005CB08
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003112 RID: 12562 RVA: 0x0005E914 File Offset: 0x0005CB14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C2F RID: 3119
		private ErrorCode? _result;

		// Token: 0x04000C30 RID: 3120
		private IExtension extensionObject;
	}
}
