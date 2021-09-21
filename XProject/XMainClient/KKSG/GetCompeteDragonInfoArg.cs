using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E6 RID: 1254
	[ProtoContract(Name = "GetCompeteDragonInfoArg")]
	[Serializable]
	public class GetCompeteDragonInfoArg : IExtensible
	{
		// Token: 0x170013D0 RID: 5072
		// (get) Token: 0x060040C0 RID: 16576 RVA: 0x0007B4A8 File Offset: 0x000796A8
		// (set) Token: 0x060040C1 RID: 16577 RVA: 0x0007B4D4 File Offset: 0x000796D4
		[ProtoMember(1, IsRequired = false, Name = "opArg", DataFormat = DataFormat.TwosComplement)]
		public CompeteDragonOpArg opArg
		{
			get
			{
				return this._opArg ?? CompeteDragonOpArg.CompeteDragon_GetInfo;
			}
			set
			{
				this._opArg = new CompeteDragonOpArg?(value);
			}
		}

		// Token: 0x170013D1 RID: 5073
		// (get) Token: 0x060040C2 RID: 16578 RVA: 0x0007B4E4 File Offset: 0x000796E4
		// (set) Token: 0x060040C3 RID: 16579 RVA: 0x0007B504 File Offset: 0x00079704
		[XmlIgnore]
		[Browsable(false)]
		public bool opArgSpecified
		{
			get
			{
				return this._opArg != null;
			}
			set
			{
				bool flag = value == (this._opArg == null);
				if (flag)
				{
					this._opArg = (value ? new CompeteDragonOpArg?(this.opArg) : null);
				}
			}
		}

		// Token: 0x060040C4 RID: 16580 RVA: 0x0007B548 File Offset: 0x00079748
		private bool ShouldSerializeopArg()
		{
			return this.opArgSpecified;
		}

		// Token: 0x060040C5 RID: 16581 RVA: 0x0007B560 File Offset: 0x00079760
		private void ResetopArg()
		{
			this.opArgSpecified = false;
		}

		// Token: 0x060040C6 RID: 16582 RVA: 0x0007B56C File Offset: 0x0007976C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001024 RID: 4132
		private CompeteDragonOpArg? _opArg;

		// Token: 0x04001025 RID: 4133
		private IExtension extensionObject;
	}
}
