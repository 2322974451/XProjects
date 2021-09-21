using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000064 RID: 100
	[ProtoContract(Name = "BuyGoldAndFatigueRes")]
	[Serializable]
	public class BuyGoldAndFatigueRes : IExtensible
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000FA0C File Offset: 0x0000DC0C
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0000FA38 File Offset: 0x0000DC38
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

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000FA48 File Offset: 0x0000DC48
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0000FA68 File Offset: 0x0000DC68
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

		// Token: 0x060006C7 RID: 1735 RVA: 0x0000FAAC File Offset: 0x0000DCAC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0000FAC4 File Offset: 0x0000DCC4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0000FAD0 File Offset: 0x0000DCD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001B6 RID: 438
		private ErrorCode? _result;

		// Token: 0x040001B7 RID: 439
		private IExtension extensionObject;
	}
}
