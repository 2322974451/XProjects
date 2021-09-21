using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051D RID: 1309
	[ProtoContract(Name = "BackFlowActivityOperationArg")]
	[Serializable]
	public class BackFlowActivityOperationArg : IExtensible
	{
		// Token: 0x1700148B RID: 5259
		// (get) Token: 0x0600433B RID: 17211 RVA: 0x0007FE58 File Offset: 0x0007E058
		// (set) Token: 0x0600433C RID: 17212 RVA: 0x0007FE84 File Offset: 0x0007E084
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public BackFlowActOp type
		{
			get
			{
				return this._type ?? BackFlowActOp.BackFlowAct_TreasureData;
			}
			set
			{
				this._type = new BackFlowActOp?(value);
			}
		}

		// Token: 0x1700148C RID: 5260
		// (get) Token: 0x0600433D RID: 17213 RVA: 0x0007FE94 File Offset: 0x0007E094
		// (set) Token: 0x0600433E RID: 17214 RVA: 0x0007FEB4 File Offset: 0x0007E0B4
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
					this._type = (value ? new BackFlowActOp?(this.type) : null);
				}
			}
		}

		// Token: 0x0600433F RID: 17215 RVA: 0x0007FEF8 File Offset: 0x0007E0F8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004340 RID: 17216 RVA: 0x0007FF10 File Offset: 0x0007E110
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700148D RID: 5261
		// (get) Token: 0x06004341 RID: 17217 RVA: 0x0007FF1C File Offset: 0x0007E11C
		// (set) Token: 0x06004342 RID: 17218 RVA: 0x0007FF48 File Offset: 0x0007E148
		[ProtoMember(2, IsRequired = false, Name = "arg", DataFormat = DataFormat.TwosComplement)]
		public uint arg
		{
			get
			{
				return this._arg ?? 0U;
			}
			set
			{
				this._arg = new uint?(value);
			}
		}

		// Token: 0x1700148E RID: 5262
		// (get) Token: 0x06004343 RID: 17219 RVA: 0x0007FF58 File Offset: 0x0007E158
		// (set) Token: 0x06004344 RID: 17220 RVA: 0x0007FF78 File Offset: 0x0007E178
		[XmlIgnore]
		[Browsable(false)]
		public bool argSpecified
		{
			get
			{
				return this._arg != null;
			}
			set
			{
				bool flag = value == (this._arg == null);
				if (flag)
				{
					this._arg = (value ? new uint?(this.arg) : null);
				}
			}
		}

		// Token: 0x06004345 RID: 17221 RVA: 0x0007FFBC File Offset: 0x0007E1BC
		private bool ShouldSerializearg()
		{
			return this.argSpecified;
		}

		// Token: 0x06004346 RID: 17222 RVA: 0x0007FFD4 File Offset: 0x0007E1D4
		private void Resetarg()
		{
			this.argSpecified = false;
		}

		// Token: 0x06004347 RID: 17223 RVA: 0x0007FFE0 File Offset: 0x0007E1E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010C3 RID: 4291
		private BackFlowActOp? _type;

		// Token: 0x040010C4 RID: 4292
		private uint? _arg;

		// Token: 0x040010C5 RID: 4293
		private IExtension extensionObject;
	}
}
