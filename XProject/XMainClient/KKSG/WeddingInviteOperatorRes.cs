using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047A RID: 1146
	[ProtoContract(Name = "WeddingInviteOperatorRes")]
	[Serializable]
	public class WeddingInviteOperatorRes : IExtensible
	{
		// Token: 0x17001260 RID: 4704
		// (get) Token: 0x06003BF0 RID: 15344 RVA: 0x00072878 File Offset: 0x00070A78
		// (set) Token: 0x06003BF1 RID: 15345 RVA: 0x000728A4 File Offset: 0x00070AA4
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

		// Token: 0x17001261 RID: 4705
		// (get) Token: 0x06003BF2 RID: 15346 RVA: 0x000728B4 File Offset: 0x00070AB4
		// (set) Token: 0x06003BF3 RID: 15347 RVA: 0x000728D4 File Offset: 0x00070AD4
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

		// Token: 0x06003BF4 RID: 15348 RVA: 0x00072918 File Offset: 0x00070B18
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003BF5 RID: 15349 RVA: 0x00072930 File Offset: 0x00070B30
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003BF6 RID: 15350 RVA: 0x0007293C File Offset: 0x00070B3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EE7 RID: 3815
		private ErrorCode? _result;

		// Token: 0x04000EE8 RID: 3816
		private IExtension extensionObject;
	}
}
