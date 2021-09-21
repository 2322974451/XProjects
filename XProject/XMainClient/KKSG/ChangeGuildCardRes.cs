using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A0 RID: 160
	[ProtoContract(Name = "ChangeGuildCardRes")]
	[Serializable]
	public class ChangeGuildCardRes : IExtensible
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x00017B48 File Offset: 0x00015D48
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x00017B74 File Offset: 0x00015D74
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x00017B84 File Offset: 0x00015D84
		// (set) Token: 0x06000B10 RID: 2832 RVA: 0x00017BA4 File Offset: 0x00015DA4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00017BE8 File Offset: 0x00015DE8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00017C00 File Offset: 0x00015E00
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00017C0C File Offset: 0x00015E0C
		// (set) Token: 0x06000B14 RID: 2836 RVA: 0x00017C38 File Offset: 0x00015E38
		[ProtoMember(2, IsRequired = false, Name = "card", DataFormat = DataFormat.TwosComplement)]
		public uint card
		{
			get
			{
				return this._card ?? 0U;
			}
			set
			{
				this._card = new uint?(value);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00017C48 File Offset: 0x00015E48
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x00017C68 File Offset: 0x00015E68
		[XmlIgnore]
		[Browsable(false)]
		public bool cardSpecified
		{
			get
			{
				return this._card != null;
			}
			set
			{
				bool flag = value == (this._card == null);
				if (flag)
				{
					this._card = (value ? new uint?(this.card) : null);
				}
			}
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x00017CAC File Offset: 0x00015EAC
		private bool ShouldSerializecard()
		{
			return this.cardSpecified;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00017CC4 File Offset: 0x00015EC4
		private void Resetcard()
		{
			this.cardSpecified = false;
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00017CD0 File Offset: 0x00015ED0
		// (set) Token: 0x06000B1A RID: 2842 RVA: 0x00017CFC File Offset: 0x00015EFC
		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x00017D0C File Offset: 0x00015F0C
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x00017D2C File Offset: 0x00015F2C
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
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00017D70 File Offset: 0x00015F70
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00017D88 File Offset: 0x00015F88
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x00017D94 File Offset: 0x00015F94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002C6 RID: 710
		private ErrorCode? _errorcode;

		// Token: 0x040002C7 RID: 711
		private uint? _card;

		// Token: 0x040002C8 RID: 712
		private uint? _result;

		// Token: 0x040002C9 RID: 713
		private IExtension extensionObject;
	}
}
