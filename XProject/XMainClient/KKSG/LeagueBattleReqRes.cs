using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037D RID: 893
	[ProtoContract(Name = "LeagueBattleReqRes")]
	[Serializable]
	public class LeagueBattleReqRes : IExtensible
	{
		// Token: 0x17000F0F RID: 3855
		// (get) Token: 0x060030A4 RID: 12452 RVA: 0x0005DCFC File Offset: 0x0005BEFC
		// (set) Token: 0x060030A5 RID: 12453 RVA: 0x0005DD28 File Offset: 0x0005BF28
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

		// Token: 0x17000F10 RID: 3856
		// (get) Token: 0x060030A6 RID: 12454 RVA: 0x0005DD38 File Offset: 0x0005BF38
		// (set) Token: 0x060030A7 RID: 12455 RVA: 0x0005DD58 File Offset: 0x0005BF58
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

		// Token: 0x060030A8 RID: 12456 RVA: 0x0005DD9C File Offset: 0x0005BF9C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060030A9 RID: 12457 RVA: 0x0005DDB4 File Offset: 0x0005BFB4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060030AA RID: 12458 RVA: 0x0005DDC0 File Offset: 0x0005BFC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C11 RID: 3089
		private ErrorCode? _result;

		// Token: 0x04000C12 RID: 3090
		private IExtension extensionObject;
	}
}
