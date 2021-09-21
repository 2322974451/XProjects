using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000387 RID: 903
	[ProtoContract(Name = "LeagueBattleReadyReqArg")]
	[Serializable]
	public class LeagueBattleReadyReqArg : IExtensible
	{
		// Token: 0x17000F2B RID: 3883
		// (get) Token: 0x06003104 RID: 12548 RVA: 0x0005E76C File Offset: 0x0005C96C
		// (set) Token: 0x06003105 RID: 12549 RVA: 0x0005E798 File Offset: 0x0005C998
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleReadyOper type
		{
			get
			{
				return this._type ?? LeagueBattleReadyOper.LBReady_Up;
			}
			set
			{
				this._type = new LeagueBattleReadyOper?(value);
			}
		}

		// Token: 0x17000F2C RID: 3884
		// (get) Token: 0x06003106 RID: 12550 RVA: 0x0005E7A8 File Offset: 0x0005C9A8
		// (set) Token: 0x06003107 RID: 12551 RVA: 0x0005E7C8 File Offset: 0x0005C9C8
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new LeagueBattleReadyOper?(this.type) : null);
				}
			}
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x0005E80C File Offset: 0x0005CA0C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x0005E824 File Offset: 0x0005CA24
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600310A RID: 12554 RVA: 0x0005E830 File Offset: 0x0005CA30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C2D RID: 3117
		private LeagueBattleReadyOper? _type;

		// Token: 0x04000C2E RID: 3118
		private IExtension extensionObject;
	}
}
