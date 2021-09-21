using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D8 RID: 1496
	[ProtoContract(Name = "InvFightBattleResult")]
	[Serializable]
	public class InvFightBattleResult : IExtensible
	{
		// Token: 0x17001AA0 RID: 6816
		// (get) Token: 0x060055CC RID: 21964 RVA: 0x000A3510 File Offset: 0x000A1710
		// (set) Token: 0x060055CD RID: 21965 RVA: 0x000A353C File Offset: 0x000A173C
		[ProtoMember(1, IsRequired = false, Name = "resulttype", DataFormat = DataFormat.TwosComplement)]
		public PkResultType resulttype
		{
			get
			{
				return this._resulttype ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._resulttype = new PkResultType?(value);
			}
		}

		// Token: 0x17001AA1 RID: 6817
		// (get) Token: 0x060055CE RID: 21966 RVA: 0x000A354C File Offset: 0x000A174C
		// (set) Token: 0x060055CF RID: 21967 RVA: 0x000A356C File Offset: 0x000A176C
		[XmlIgnore]
		[Browsable(false)]
		public bool resulttypeSpecified
		{
			get
			{
				return this._resulttype != null;
			}
			set
			{
				bool flag = value == (this._resulttype == null);
				if (flag)
				{
					this._resulttype = (value ? new PkResultType?(this.resulttype) : null);
				}
			}
		}

		// Token: 0x060055D0 RID: 21968 RVA: 0x000A35B0 File Offset: 0x000A17B0
		private bool ShouldSerializeresulttype()
		{
			return this.resulttypeSpecified;
		}

		// Token: 0x060055D1 RID: 21969 RVA: 0x000A35C8 File Offset: 0x000A17C8
		private void Resetresulttype()
		{
			this.resulttypeSpecified = false;
		}

		// Token: 0x17001AA2 RID: 6818
		// (get) Token: 0x060055D2 RID: 21970 RVA: 0x000A35D4 File Offset: 0x000A17D4
		// (set) Token: 0x060055D3 RID: 21971 RVA: 0x000A35F5 File Offset: 0x000A17F5
		[ProtoMember(2, IsRequired = false, Name = "opname", DataFormat = DataFormat.Default)]
		public string opname
		{
			get
			{
				return this._opname ?? "";
			}
			set
			{
				this._opname = value;
			}
		}

		// Token: 0x17001AA3 RID: 6819
		// (get) Token: 0x060055D4 RID: 21972 RVA: 0x000A3600 File Offset: 0x000A1800
		// (set) Token: 0x060055D5 RID: 21973 RVA: 0x000A361C File Offset: 0x000A181C
		[XmlIgnore]
		[Browsable(false)]
		public bool opnameSpecified
		{
			get
			{
				return this._opname != null;
			}
			set
			{
				bool flag = value == (this._opname == null);
				if (flag)
				{
					this._opname = (value ? this.opname : null);
				}
			}
		}

		// Token: 0x060055D6 RID: 21974 RVA: 0x000A364C File Offset: 0x000A184C
		private bool ShouldSerializeopname()
		{
			return this.opnameSpecified;
		}

		// Token: 0x060055D7 RID: 21975 RVA: 0x000A3664 File Offset: 0x000A1864
		private void Resetopname()
		{
			this.opnameSpecified = false;
		}

		// Token: 0x060055D8 RID: 21976 RVA: 0x000A3670 File Offset: 0x000A1870
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014E6 RID: 5350
		private PkResultType? _resulttype;

		// Token: 0x040014E7 RID: 5351
		private string _opname;

		// Token: 0x040014E8 RID: 5352
		private IExtension extensionObject;
	}
}
