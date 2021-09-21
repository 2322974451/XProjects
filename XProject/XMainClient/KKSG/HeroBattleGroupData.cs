using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E4 RID: 1764
	[ProtoContract(Name = "HeroBattleGroupData")]
	[Serializable]
	public class HeroBattleGroupData : IExtensible
	{
		// Token: 0x1700254D RID: 9549
		// (get) Token: 0x060075CE RID: 30158 RVA: 0x000E1644 File Offset: 0x000DF844
		// (set) Token: 0x060075CF RID: 30159 RVA: 0x000E1670 File Offset: 0x000DF870
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x1700254E RID: 9550
		// (get) Token: 0x060075D0 RID: 30160 RVA: 0x000E1680 File Offset: 0x000DF880
		// (set) Token: 0x060075D1 RID: 30161 RVA: 0x000E16A0 File Offset: 0x000DF8A0
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x060075D2 RID: 30162 RVA: 0x000E16E4 File Offset: 0x000DF8E4
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x060075D3 RID: 30163 RVA: 0x000E16FC File Offset: 0x000DF8FC
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700254F RID: 9551
		// (get) Token: 0x060075D4 RID: 30164 RVA: 0x000E1708 File Offset: 0x000DF908
		// (set) Token: 0x060075D5 RID: 30165 RVA: 0x000E1734 File Offset: 0x000DF934
		[ProtoMember(2, IsRequired = false, Name = "headcount", DataFormat = DataFormat.TwosComplement)]
		public uint headcount
		{
			get
			{
				return this._headcount ?? 0U;
			}
			set
			{
				this._headcount = new uint?(value);
			}
		}

		// Token: 0x17002550 RID: 9552
		// (get) Token: 0x060075D6 RID: 30166 RVA: 0x000E1744 File Offset: 0x000DF944
		// (set) Token: 0x060075D7 RID: 30167 RVA: 0x000E1764 File Offset: 0x000DF964
		[XmlIgnore]
		[Browsable(false)]
		public bool headcountSpecified
		{
			get
			{
				return this._headcount != null;
			}
			set
			{
				bool flag = value == (this._headcount == null);
				if (flag)
				{
					this._headcount = (value ? new uint?(this.headcount) : null);
				}
			}
		}

		// Token: 0x060075D8 RID: 30168 RVA: 0x000E17A8 File Offset: 0x000DF9A8
		private bool ShouldSerializeheadcount()
		{
			return this.headcountSpecified;
		}

		// Token: 0x060075D9 RID: 30169 RVA: 0x000E17C0 File Offset: 0x000DF9C0
		private void Resetheadcount()
		{
			this.headcountSpecified = false;
		}

		// Token: 0x17002551 RID: 9553
		// (get) Token: 0x060075DA RID: 30170 RVA: 0x000E17CC File Offset: 0x000DF9CC
		// (set) Token: 0x060075DB RID: 30171 RVA: 0x000E17F8 File Offset: 0x000DF9F8
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17002552 RID: 9554
		// (get) Token: 0x060075DC RID: 30172 RVA: 0x000E1808 File Offset: 0x000DFA08
		// (set) Token: 0x060075DD RID: 30173 RVA: 0x000E1828 File Offset: 0x000DFA28
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x060075DE RID: 30174 RVA: 0x000E186C File Offset: 0x000DFA6C
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060075DF RID: 30175 RVA: 0x000E1884 File Offset: 0x000DFA84
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x060075E0 RID: 30176 RVA: 0x000E1890 File Offset: 0x000DFA90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BF1 RID: 7153
		private uint? _teamid;

		// Token: 0x04001BF2 RID: 7154
		private uint? _headcount;

		// Token: 0x04001BF3 RID: 7155
		private uint? _point;

		// Token: 0x04001BF4 RID: 7156
		private IExtension extensionObject;
	}
}
