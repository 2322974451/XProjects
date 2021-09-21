using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000107 RID: 263
	[ProtoContract(Name = "AutoFight")]
	[Serializable]
	public class AutoFight : IExtensible
	{
		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x00022528 File Offset: 0x00020728
		// (set) Token: 0x060010C3 RID: 4291 RVA: 0x00022554 File Offset: 0x00020754
		[ProtoMember(1, IsRequired = false, Name = "autof", DataFormat = DataFormat.Default)]
		public bool autof
		{
			get
			{
				return this._autof ?? false;
			}
			set
			{
				this._autof = new bool?(value);
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00022564 File Offset: 0x00020764
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00022584 File Offset: 0x00020784
		[XmlIgnore]
		[Browsable(false)]
		public bool autofSpecified
		{
			get
			{
				return this._autof != null;
			}
			set
			{
				bool flag = value == (this._autof == null);
				if (flag)
				{
					this._autof = (value ? new bool?(this.autof) : null);
				}
			}
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x000225C8 File Offset: 0x000207C8
		private bool ShouldSerializeautof()
		{
			return this.autofSpecified;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000225E0 File Offset: 0x000207E0
		private void Resetautof()
		{
			this.autofSpecified = false;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000225EC File Offset: 0x000207EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000431 RID: 1073
		private bool? _autof;

		// Token: 0x04000432 RID: 1074
		private IExtension extensionObject;
	}
}
