using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A4 RID: 164
	[ProtoContract(Name = "ChangeGuildPositionRes")]
	[Serializable]
	public class ChangeGuildPositionRes : IExtensible
	{
		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00018124 File Offset: 0x00016324
		// (set) Token: 0x06000B40 RID: 2880 RVA: 0x00018150 File Offset: 0x00016350
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

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00018160 File Offset: 0x00016360
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x00018180 File Offset: 0x00016380
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

		// Token: 0x06000B43 RID: 2883 RVA: 0x000181C4 File Offset: 0x000163C4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x000181DC File Offset: 0x000163DC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x000181E8 File Offset: 0x000163E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002D1 RID: 721
		private ErrorCode? _result;

		// Token: 0x040002D2 RID: 722
		private IExtension extensionObject;
	}
}
