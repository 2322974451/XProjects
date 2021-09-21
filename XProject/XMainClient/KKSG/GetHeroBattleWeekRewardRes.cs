using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036F RID: 879
	[ProtoContract(Name = "GetHeroBattleWeekRewardRes")]
	[Serializable]
	public class GetHeroBattleWeekRewardRes : IExtensible
	{
		// Token: 0x17000EC0 RID: 3776
		// (get) Token: 0x06002FA8 RID: 12200 RVA: 0x0005BEF4 File Offset: 0x0005A0F4
		// (set) Token: 0x06002FA9 RID: 12201 RVA: 0x0005BF20 File Offset: 0x0005A120
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

		// Token: 0x17000EC1 RID: 3777
		// (get) Token: 0x06002FAA RID: 12202 RVA: 0x0005BF30 File Offset: 0x0005A130
		// (set) Token: 0x06002FAB RID: 12203 RVA: 0x0005BF50 File Offset: 0x0005A150
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

		// Token: 0x06002FAC RID: 12204 RVA: 0x0005BF94 File Offset: 0x0005A194
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002FAD RID: 12205 RVA: 0x0005BFAC File Offset: 0x0005A1AC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000EC2 RID: 3778
		// (get) Token: 0x06002FAE RID: 12206 RVA: 0x0005BFB8 File Offset: 0x0005A1B8
		// (set) Token: 0x06002FAF RID: 12207 RVA: 0x0005BFE4 File Offset: 0x0005A1E4
		[ProtoMember(2, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		// Token: 0x17000EC3 RID: 3779
		// (get) Token: 0x06002FB0 RID: 12208 RVA: 0x0005BFF4 File Offset: 0x0005A1F4
		// (set) Token: 0x06002FB1 RID: 12209 RVA: 0x0005C014 File Offset: 0x0005A214
		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x0005C058 File Offset: 0x0005A258
		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		// Token: 0x06002FB3 RID: 12211 RVA: 0x0005C070 File Offset: 0x0005A270
		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		// Token: 0x17000EC4 RID: 3780
		// (get) Token: 0x06002FB4 RID: 12212 RVA: 0x0005C07C File Offset: 0x0005A27C
		// (set) Token: 0x06002FB5 RID: 12213 RVA: 0x0005C0A8 File Offset: 0x0005A2A8
		[ProtoMember(3, IsRequired = false, Name = "getnextweekprize", DataFormat = DataFormat.Default)]
		public bool getnextweekprize
		{
			get
			{
				return this._getnextweekprize ?? false;
			}
			set
			{
				this._getnextweekprize = new bool?(value);
			}
		}

		// Token: 0x17000EC5 RID: 3781
		// (get) Token: 0x06002FB6 RID: 12214 RVA: 0x0005C0B8 File Offset: 0x0005A2B8
		// (set) Token: 0x06002FB7 RID: 12215 RVA: 0x0005C0D8 File Offset: 0x0005A2D8
		[XmlIgnore]
		[Browsable(false)]
		public bool getnextweekprizeSpecified
		{
			get
			{
				return this._getnextweekprize != null;
			}
			set
			{
				bool flag = value == (this._getnextweekprize == null);
				if (flag)
				{
					this._getnextweekprize = (value ? new bool?(this.getnextweekprize) : null);
				}
			}
		}

		// Token: 0x06002FB8 RID: 12216 RVA: 0x0005C11C File Offset: 0x0005A31C
		private bool ShouldSerializegetnextweekprize()
		{
			return this.getnextweekprizeSpecified;
		}

		// Token: 0x06002FB9 RID: 12217 RVA: 0x0005C134 File Offset: 0x0005A334
		private void Resetgetnextweekprize()
		{
			this.getnextweekprizeSpecified = false;
		}

		// Token: 0x06002FBA RID: 12218 RVA: 0x0005C140 File Offset: 0x0005A340
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BD8 RID: 3032
		private ErrorCode? _errorcode;

		// Token: 0x04000BD9 RID: 3033
		private uint? _weekprize;

		// Token: 0x04000BDA RID: 3034
		private bool? _getnextweekprize;

		// Token: 0x04000BDB RID: 3035
		private IExtension extensionObject;
	}
}
