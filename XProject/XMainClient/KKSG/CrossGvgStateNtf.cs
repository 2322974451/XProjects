using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000530 RID: 1328
	[ProtoContract(Name = "CrossGvgStateNtf")]
	[Serializable]
	public class CrossGvgStateNtf : IExtensible
	{
		// Token: 0x170014E3 RID: 5347
		// (get) Token: 0x0600444C RID: 17484 RVA: 0x00081EEC File Offset: 0x000800EC
		// (set) Token: 0x0600444D RID: 17485 RVA: 0x00081F18 File Offset: 0x00080118
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgTimeState state
		{
			get
			{
				return this._state ?? CrossGvgTimeState.CGVG_NotOpen;
			}
			set
			{
				this._state = new CrossGvgTimeState?(value);
			}
		}

		// Token: 0x170014E4 RID: 5348
		// (get) Token: 0x0600444E RID: 17486 RVA: 0x00081F28 File Offset: 0x00080128
		// (set) Token: 0x0600444F RID: 17487 RVA: 0x00081F48 File Offset: 0x00080148
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new CrossGvgTimeState?(this.state) : null);
				}
			}
		}

		// Token: 0x06004450 RID: 17488 RVA: 0x00081F8C File Offset: 0x0008018C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06004451 RID: 17489 RVA: 0x00081FA4 File Offset: 0x000801A4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06004452 RID: 17490 RVA: 0x00081FB0 File Offset: 0x000801B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400110A RID: 4362
		private CrossGvgTimeState? _state;

		// Token: 0x0400110B RID: 4363
		private IExtension extensionObject;
	}
}
