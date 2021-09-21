using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003A RID: 58
	[ProtoContract(Name = "ReconnRes")]
	[Serializable]
	public class ReconnRes : IExtensible
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000A3D0 File Offset: 0x000085D0
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000A3FC File Offset: 0x000085FC
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

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000A40C File Offset: 0x0000860C
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x0000A42C File Offset: 0x0000862C
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

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000A470 File Offset: 0x00008670
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000A488 File Offset: 0x00008688
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000A494 File Offset: 0x00008694
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400010A RID: 266
		private ErrorCode? _result;

		// Token: 0x0400010B RID: 267
		private IExtension extensionObject;
	}
}
