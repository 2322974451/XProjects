using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DA RID: 1498
	[ProtoContract(Name = "CustomBattleResult")]
	[Serializable]
	public class CustomBattleResult : IExtensible
	{
		// Token: 0x17001AB2 RID: 6834
		// (get) Token: 0x06005602 RID: 22018 RVA: 0x000A3B9C File Offset: 0x000A1D9C
		// (set) Token: 0x06005603 RID: 22019 RVA: 0x000A3BC8 File Offset: 0x000A1DC8
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
			}
		}

		// Token: 0x17001AB3 RID: 6835
		// (get) Token: 0x06005604 RID: 22020 RVA: 0x000A3BD8 File Offset: 0x000A1DD8
		// (set) Token: 0x06005605 RID: 22021 RVA: 0x000A3BF8 File Offset: 0x000A1DF8
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
					this._result = (value ? new PkResultType?(this.result) : null);
				}
			}
		}

		// Token: 0x06005606 RID: 22022 RVA: 0x000A3C3C File Offset: 0x000A1E3C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06005607 RID: 22023 RVA: 0x000A3C54 File Offset: 0x000A1E54
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001AB4 RID: 6836
		// (get) Token: 0x06005608 RID: 22024 RVA: 0x000A3C60 File Offset: 0x000A1E60
		// (set) Token: 0x06005609 RID: 22025 RVA: 0x000A3C8C File Offset: 0x000A1E8C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleType type
		{
			get
			{
				return this._type ?? CustomBattleType.CustomBattle_PK_Normal;
			}
			set
			{
				this._type = new CustomBattleType?(value);
			}
		}

		// Token: 0x17001AB5 RID: 6837
		// (get) Token: 0x0600560A RID: 22026 RVA: 0x000A3C9C File Offset: 0x000A1E9C
		// (set) Token: 0x0600560B RID: 22027 RVA: 0x000A3CBC File Offset: 0x000A1EBC
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
					this._type = (value ? new CustomBattleType?(this.type) : null);
				}
			}
		}

		// Token: 0x0600560C RID: 22028 RVA: 0x000A3D00 File Offset: 0x000A1F00
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600560D RID: 22029 RVA: 0x000A3D18 File Offset: 0x000A1F18
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001AB6 RID: 6838
		// (get) Token: 0x0600560E RID: 22030 RVA: 0x000A3D24 File Offset: 0x000A1F24
		// (set) Token: 0x0600560F RID: 22031 RVA: 0x000A3D50 File Offset: 0x000A1F50
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public int point
		{
			get
			{
				return this._point ?? 0;
			}
			set
			{
				this._point = new int?(value);
			}
		}

		// Token: 0x17001AB7 RID: 6839
		// (get) Token: 0x06005610 RID: 22032 RVA: 0x000A3D60 File Offset: 0x000A1F60
		// (set) Token: 0x06005611 RID: 22033 RVA: 0x000A3D80 File Offset: 0x000A1F80
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
					this._point = (value ? new int?(this.point) : null);
				}
			}
		}

		// Token: 0x06005612 RID: 22034 RVA: 0x000A3DC4 File Offset: 0x000A1FC4
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005613 RID: 22035 RVA: 0x000A3DDC File Offset: 0x000A1FDC
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001AB8 RID: 6840
		// (get) Token: 0x06005614 RID: 22036 RVA: 0x000A3DE8 File Offset: 0x000A1FE8
		// (set) Token: 0x06005615 RID: 22037 RVA: 0x000A3E14 File Offset: 0x000A2014
		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17001AB9 RID: 6841
		// (get) Token: 0x06005616 RID: 22038 RVA: 0x000A3E24 File Offset: 0x000A2024
		// (set) Token: 0x06005617 RID: 22039 RVA: 0x000A3E44 File Offset: 0x000A2044
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x06005618 RID: 22040 RVA: 0x000A3E88 File Offset: 0x000A2088
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06005619 RID: 22041 RVA: 0x000A3EA0 File Offset: 0x000A20A0
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001ABA RID: 6842
		// (get) Token: 0x0600561A RID: 22042 RVA: 0x000A3EAC File Offset: 0x000A20AC
		// (set) Token: 0x0600561B RID: 22043 RVA: 0x000A3ED8 File Offset: 0x000A20D8
		[ProtoMember(5, IsRequired = false, Name = "fightgroup", DataFormat = DataFormat.TwosComplement)]
		public uint fightgroup
		{
			get
			{
				return this._fightgroup ?? 0U;
			}
			set
			{
				this._fightgroup = new uint?(value);
			}
		}

		// Token: 0x17001ABB RID: 6843
		// (get) Token: 0x0600561C RID: 22044 RVA: 0x000A3EE8 File Offset: 0x000A20E8
		// (set) Token: 0x0600561D RID: 22045 RVA: 0x000A3F08 File Offset: 0x000A2108
		[XmlIgnore]
		[Browsable(false)]
		public bool fightgroupSpecified
		{
			get
			{
				return this._fightgroup != null;
			}
			set
			{
				bool flag = value == (this._fightgroup == null);
				if (flag)
				{
					this._fightgroup = (value ? new uint?(this.fightgroup) : null);
				}
			}
		}

		// Token: 0x0600561E RID: 22046 RVA: 0x000A3F4C File Offset: 0x000A214C
		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		// Token: 0x0600561F RID: 22047 RVA: 0x000A3F64 File Offset: 0x000A2164
		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

		// Token: 0x17001ABC RID: 6844
		// (get) Token: 0x06005620 RID: 22048 RVA: 0x000A3F70 File Offset: 0x000A2170
		// (set) Token: 0x06005621 RID: 22049 RVA: 0x000A3F9C File Offset: 0x000A219C
		[ProtoMember(6, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x17001ABD RID: 6845
		// (get) Token: 0x06005622 RID: 22050 RVA: 0x000A3FAC File Offset: 0x000A21AC
		// (set) Token: 0x06005623 RID: 22051 RVA: 0x000A3FCC File Offset: 0x000A21CC
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x06005624 RID: 22052 RVA: 0x000A4010 File Offset: 0x000A2210
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x06005625 RID: 22053 RVA: 0x000A4028 File Offset: 0x000A2228
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x06005626 RID: 22054 RVA: 0x000A4034 File Offset: 0x000A2234
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014F2 RID: 5362
		private PkResultType? _result;

		// Token: 0x040014F3 RID: 5363
		private CustomBattleType? _type;

		// Token: 0x040014F4 RID: 5364
		private int? _point;

		// Token: 0x040014F5 RID: 5365
		private int? _rank;

		// Token: 0x040014F6 RID: 5366
		private uint? _fightgroup;

		// Token: 0x040014F7 RID: 5367
		private bool? _ismvp;

		// Token: 0x040014F8 RID: 5368
		private IExtension extensionObject;
	}
}
