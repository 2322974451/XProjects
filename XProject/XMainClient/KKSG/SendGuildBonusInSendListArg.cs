using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A8 RID: 680
	[ProtoContract(Name = "SendGuildBonusInSendListArg")]
	[Serializable]
	public class SendGuildBonusInSendListArg : IExtensible
	{
		// Token: 0x17000BCA RID: 3018
		// (get) Token: 0x060025EA RID: 9706 RVA: 0x00049CF4 File Offset: 0x00047EF4
		// (set) Token: 0x060025EB RID: 9707 RVA: 0x00049D20 File Offset: 0x00047F20
		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		// Token: 0x17000BCB RID: 3019
		// (get) Token: 0x060025EC RID: 9708 RVA: 0x00049D30 File Offset: 0x00047F30
		// (set) Token: 0x060025ED RID: 9709 RVA: 0x00049D50 File Offset: 0x00047F50
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		// Token: 0x060025EE RID: 9710 RVA: 0x00049D94 File Offset: 0x00047F94
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x00049DAC File Offset: 0x00047FAC
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x060025F0 RID: 9712 RVA: 0x00049DB8 File Offset: 0x00047FB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000966 RID: 2406
		private uint? _bonusID;

		// Token: 0x04000967 RID: 2407
		private IExtension extensionObject;
	}
}
