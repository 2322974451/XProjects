using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040E RID: 1038
	[ProtoContract(Name = "KMatchCommonArg")]
	[Serializable]
	public class KMatchCommonArg : IExtensible
	{
		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x0600373F RID: 14143 RVA: 0x00069CFC File Offset: 0x00067EFC
		// (set) Token: 0x06003740 RID: 14144 RVA: 0x00069D28 File Offset: 0x00067F28
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public KMatchType type
		{
			get
			{
				return this._type ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._type = new KMatchType?(value);
			}
		}

		// Token: 0x170010FD RID: 4349
		// (get) Token: 0x06003741 RID: 14145 RVA: 0x00069D38 File Offset: 0x00067F38
		// (set) Token: 0x06003742 RID: 14146 RVA: 0x00069D58 File Offset: 0x00067F58
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
					this._type = (value ? new KMatchType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003743 RID: 14147 RVA: 0x00069D9C File Offset: 0x00067F9C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003744 RID: 14148 RVA: 0x00069DB4 File Offset: 0x00067FB4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170010FE RID: 4350
		// (get) Token: 0x06003745 RID: 14149 RVA: 0x00069DC0 File Offset: 0x00067FC0
		// (set) Token: 0x06003746 RID: 14150 RVA: 0x00069DEC File Offset: 0x00067FEC
		[ProtoMember(2, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public KMatchOp op
		{
			get
			{
				return this._op ?? KMatchOp.KMATCH_OP_START;
			}
			set
			{
				this._op = new KMatchOp?(value);
			}
		}

		// Token: 0x170010FF RID: 4351
		// (get) Token: 0x06003747 RID: 14151 RVA: 0x00069DFC File Offset: 0x00067FFC
		// (set) Token: 0x06003748 RID: 14152 RVA: 0x00069E1C File Offset: 0x0006801C
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new KMatchOp?(this.op) : null);
				}
			}
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x00069E60 File Offset: 0x00068060
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x0600374A RID: 14154 RVA: 0x00069E78 File Offset: 0x00068078
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17001100 RID: 4352
		// (get) Token: 0x0600374B RID: 14155 RVA: 0x00069E84 File Offset: 0x00068084
		// (set) Token: 0x0600374C RID: 14156 RVA: 0x00069EB0 File Offset: 0x000680B0
		[ProtoMember(3, IsRequired = false, Name = "isteam", DataFormat = DataFormat.Default)]
		public bool isteam
		{
			get
			{
				return this._isteam ?? false;
			}
			set
			{
				this._isteam = new bool?(value);
			}
		}

		// Token: 0x17001101 RID: 4353
		// (get) Token: 0x0600374D RID: 14157 RVA: 0x00069EC0 File Offset: 0x000680C0
		// (set) Token: 0x0600374E RID: 14158 RVA: 0x00069EE0 File Offset: 0x000680E0
		[XmlIgnore]
		[Browsable(false)]
		public bool isteamSpecified
		{
			get
			{
				return this._isteam != null;
			}
			set
			{
				bool flag = value == (this._isteam == null);
				if (flag)
				{
					this._isteam = (value ? new bool?(this.isteam) : null);
				}
			}
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x00069F24 File Offset: 0x00068124
		private bool ShouldSerializeisteam()
		{
			return this.isteamSpecified;
		}

		// Token: 0x06003750 RID: 14160 RVA: 0x00069F3C File Offset: 0x0006813C
		private void Resetisteam()
		{
			this.isteamSpecified = false;
		}

		// Token: 0x06003751 RID: 14161 RVA: 0x00069F48 File Offset: 0x00068148
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DB2 RID: 3506
		private KMatchType? _type;

		// Token: 0x04000DB3 RID: 3507
		private KMatchOp? _op;

		// Token: 0x04000DB4 RID: 3508
		private bool? _isteam;

		// Token: 0x04000DB5 RID: 3509
		private IExtension extensionObject;
	}
}
