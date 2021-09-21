using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050D RID: 1293
	[ProtoContract(Name = "FashionSynthesisInfoArg")]
	[Serializable]
	public class FashionSynthesisInfoArg : IExtensible
	{
		// Token: 0x17001460 RID: 5216
		// (get) Token: 0x0600429C RID: 17052 RVA: 0x0007EC68 File Offset: 0x0007CE68
		// (set) Token: 0x0600429D RID: 17053 RVA: 0x0007EC94 File Offset: 0x0007CE94
		[ProtoMember(1, IsRequired = false, Name = "fashion_id", DataFormat = DataFormat.TwosComplement)]
		public uint fashion_id
		{
			get
			{
				return this._fashion_id ?? 0U;
			}
			set
			{
				this._fashion_id = new uint?(value);
			}
		}

		// Token: 0x17001461 RID: 5217
		// (get) Token: 0x0600429E RID: 17054 RVA: 0x0007ECA4 File Offset: 0x0007CEA4
		// (set) Token: 0x0600429F RID: 17055 RVA: 0x0007ECC4 File Offset: 0x0007CEC4
		[XmlIgnore]
		[Browsable(false)]
		public bool fashion_idSpecified
		{
			get
			{
				return this._fashion_id != null;
			}
			set
			{
				bool flag = value == (this._fashion_id == null);
				if (flag)
				{
					this._fashion_id = (value ? new uint?(this.fashion_id) : null);
				}
			}
		}

		// Token: 0x060042A0 RID: 17056 RVA: 0x0007ED08 File Offset: 0x0007CF08
		private bool ShouldSerializefashion_id()
		{
			return this.fashion_idSpecified;
		}

		// Token: 0x060042A1 RID: 17057 RVA: 0x0007ED20 File Offset: 0x0007CF20
		private void Resetfashion_id()
		{
			this.fashion_idSpecified = false;
		}

		// Token: 0x060042A2 RID: 17058 RVA: 0x0007ED2C File Offset: 0x0007CF2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400109D RID: 4253
		private uint? _fashion_id;

		// Token: 0x0400109E RID: 4254
		private IExtension extensionObject;
	}
}
