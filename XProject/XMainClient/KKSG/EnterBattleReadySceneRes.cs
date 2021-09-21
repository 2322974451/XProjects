using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AA RID: 1194
	[ProtoContract(Name = "EnterBattleReadySceneRes")]
	[Serializable]
	public class EnterBattleReadySceneRes : IExtensible
	{
		// Token: 0x170012FF RID: 4863
		// (get) Token: 0x06003E06 RID: 15878 RVA: 0x00076510 File Offset: 0x00074710
		// (set) Token: 0x06003E07 RID: 15879 RVA: 0x0007653C File Offset: 0x0007473C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17001300 RID: 4864
		// (get) Token: 0x06003E08 RID: 15880 RVA: 0x0007654C File Offset: 0x0007474C
		// (set) Token: 0x06003E09 RID: 15881 RVA: 0x0007656C File Offset: 0x0007476C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06003E0A RID: 15882 RVA: 0x000765B0 File Offset: 0x000747B0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06003E0B RID: 15883 RVA: 0x000765C8 File Offset: 0x000747C8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06003E0C RID: 15884 RVA: 0x000765D4 File Offset: 0x000747D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F73 RID: 3955
		private ErrorCode? _error;

		// Token: 0x04000F74 RID: 3956
		private IExtension extensionObject;
	}
}
