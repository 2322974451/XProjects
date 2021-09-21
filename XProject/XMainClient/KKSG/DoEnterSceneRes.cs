using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018B RID: 395
	[ProtoContract(Name = "DoEnterSceneRes")]
	[Serializable]
	public class DoEnterSceneRes : IExtensible
	{
		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x0002F720 File Offset: 0x0002D920
		// (set) Token: 0x060017C5 RID: 6085 RVA: 0x0002F74C File Offset: 0x0002D94C
		[ProtoMember(1, IsRequired = false, Name = "fightgroup", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x060017C6 RID: 6086 RVA: 0x0002F75C File Offset: 0x0002D95C
		// (set) Token: 0x060017C7 RID: 6087 RVA: 0x0002F77C File Offset: 0x0002D97C
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

		// Token: 0x060017C8 RID: 6088 RVA: 0x0002F7C0 File Offset: 0x0002D9C0
		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x0002F7D8 File Offset: 0x0002D9D8
		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x0002F7E4 File Offset: 0x0002D9E4
		// (set) Token: 0x060017CB RID: 6091 RVA: 0x0002F814 File Offset: 0x0002DA14
		[ProtoMember(2, IsRequired = false, Name = "face", DataFormat = DataFormat.FixedSize)]
		public float face
		{
			get
			{
				return this._face ?? 0f;
			}
			set
			{
				this._face = new float?(value);
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x0002F824 File Offset: 0x0002DA24
		// (set) Token: 0x060017CD RID: 6093 RVA: 0x0002F844 File Offset: 0x0002DA44
		[XmlIgnore]
		[Browsable(false)]
		public bool faceSpecified
		{
			get
			{
				return this._face != null;
			}
			set
			{
				bool flag = value == (this._face == null);
				if (flag)
				{
					this._face = (value ? new float?(this.face) : null);
				}
			}
		}

		// Token: 0x060017CE RID: 6094 RVA: 0x0002F888 File Offset: 0x0002DA88
		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		// Token: 0x060017CF RID: 6095 RVA: 0x0002F8A0 File Offset: 0x0002DAA0
		private void Resetface()
		{
			this.faceSpecified = false;
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x060017D0 RID: 6096 RVA: 0x0002F8AC File Offset: 0x0002DAAC
		// (set) Token: 0x060017D1 RID: 6097 RVA: 0x0002F8C4 File Offset: 0x0002DAC4
		[ProtoMember(3, IsRequired = false, Name = "pos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 pos
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x0002F8D0 File Offset: 0x0002DAD0
		[ProtoMember(4, Name = "otherunits", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> otherunits
		{
			get
			{
				return this._otherunits;
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x060017D3 RID: 6099 RVA: 0x0002F8E8 File Offset: 0x0002DAE8
		// (set) Token: 0x060017D4 RID: 6100 RVA: 0x0002F914 File Offset: 0x0002DB14
		[ProtoMember(5, IsRequired = false, Name = "iswatchend", DataFormat = DataFormat.Default)]
		public bool iswatchend
		{
			get
			{
				return this._iswatchend ?? false;
			}
			set
			{
				this._iswatchend = new bool?(value);
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x0002F924 File Offset: 0x0002DB24
		// (set) Token: 0x060017D6 RID: 6102 RVA: 0x0002F944 File Offset: 0x0002DB44
		[XmlIgnore]
		[Browsable(false)]
		public bool iswatchendSpecified
		{
			get
			{
				return this._iswatchend != null;
			}
			set
			{
				bool flag = value == (this._iswatchend == null);
				if (flag)
				{
					this._iswatchend = (value ? new bool?(this.iswatchend) : null);
				}
			}
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x0002F988 File Offset: 0x0002DB88
		private bool ShouldSerializeiswatchend()
		{
			return this.iswatchendSpecified;
		}

		// Token: 0x060017D8 RID: 6104 RVA: 0x0002F9A0 File Offset: 0x0002DBA0
		private void Resetiswatchend()
		{
			this.iswatchendSpecified = false;
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x0002F9AC File Offset: 0x0002DBAC
		// (set) Token: 0x060017DA RID: 6106 RVA: 0x0002F9D8 File Offset: 0x0002DBD8
		[ProtoMember(6, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x060017DB RID: 6107 RVA: 0x0002F9E8 File Offset: 0x0002DBE8
		// (set) Token: 0x060017DC RID: 6108 RVA: 0x0002FA08 File Offset: 0x0002DC08
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

		// Token: 0x060017DD RID: 6109 RVA: 0x0002FA4C File Offset: 0x0002DC4C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x0002FA64 File Offset: 0x0002DC64
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x060017DF RID: 6111 RVA: 0x0002FA70 File Offset: 0x0002DC70
		// (set) Token: 0x060017E0 RID: 6112 RVA: 0x0002FA88 File Offset: 0x0002DC88
		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookState state
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x060017E1 RID: 6113 RVA: 0x0002FA94 File Offset: 0x0002DC94
		// (set) Token: 0x060017E2 RID: 6114 RVA: 0x0002FAC0 File Offset: 0x0002DCC0
		[ProtoMember(8, IsRequired = false, Name = "is_cross", DataFormat = DataFormat.Default)]
		public bool is_cross
		{
			get
			{
				return this._is_cross ?? false;
			}
			set
			{
				this._is_cross = new bool?(value);
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x060017E3 RID: 6115 RVA: 0x0002FAD0 File Offset: 0x0002DCD0
		// (set) Token: 0x060017E4 RID: 6116 RVA: 0x0002FAF0 File Offset: 0x0002DCF0
		[XmlIgnore]
		[Browsable(false)]
		public bool is_crossSpecified
		{
			get
			{
				return this._is_cross != null;
			}
			set
			{
				bool flag = value == (this._is_cross == null);
				if (flag)
				{
					this._is_cross = (value ? new bool?(this.is_cross) : null);
				}
			}
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x0002FB34 File Offset: 0x0002DD34
		private bool ShouldSerializeis_cross()
		{
			return this.is_crossSpecified;
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x0002FB4C File Offset: 0x0002DD4C
		private void Resetis_cross()
		{
			this.is_crossSpecified = false;
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x0002FB58 File Offset: 0x0002DD58
		// (set) Token: 0x060017E8 RID: 6120 RVA: 0x0002FB79 File Offset: 0x0002DD79
		[ProtoMember(9, IsRequired = false, Name = "battlestamp", DataFormat = DataFormat.Default)]
		public string battlestamp
		{
			get
			{
				return this._battlestamp ?? "";
			}
			set
			{
				this._battlestamp = value;
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0002FB84 File Offset: 0x0002DD84
		// (set) Token: 0x060017EA RID: 6122 RVA: 0x0002FBA0 File Offset: 0x0002DDA0
		[XmlIgnore]
		[Browsable(false)]
		public bool battlestampSpecified
		{
			get
			{
				return this._battlestamp != null;
			}
			set
			{
				bool flag = value == (this._battlestamp == null);
				if (flag)
				{
					this._battlestamp = (value ? this.battlestamp : null);
				}
			}
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x0002FBD0 File Offset: 0x0002DDD0
		private bool ShouldSerializebattlestamp()
		{
			return this.battlestampSpecified;
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x0002FBE8 File Offset: 0x0002DDE8
		private void Resetbattlestamp()
		{
			this.battlestampSpecified = false;
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x060017ED RID: 6125 RVA: 0x0002FBF4 File Offset: 0x0002DDF4
		// (set) Token: 0x060017EE RID: 6126 RVA: 0x0002FC20 File Offset: 0x0002DE20
		[ProtoMember(10, IsRequired = false, Name = "specialstate", DataFormat = DataFormat.TwosComplement)]
		public uint specialstate
		{
			get
			{
				return this._specialstate ?? 0U;
			}
			set
			{
				this._specialstate = new uint?(value);
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x060017EF RID: 6127 RVA: 0x0002FC30 File Offset: 0x0002DE30
		// (set) Token: 0x060017F0 RID: 6128 RVA: 0x0002FC50 File Offset: 0x0002DE50
		[XmlIgnore]
		[Browsable(false)]
		public bool specialstateSpecified
		{
			get
			{
				return this._specialstate != null;
			}
			set
			{
				bool flag = value == (this._specialstate == null);
				if (flag)
				{
					this._specialstate = (value ? new uint?(this.specialstate) : null);
				}
			}
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x0002FC94 File Offset: 0x0002DE94
		private bool ShouldSerializespecialstate()
		{
			return this.specialstateSpecified;
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x0002FCAC File Offset: 0x0002DEAC
		private void Resetspecialstate()
		{
			this.specialstateSpecified = false;
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x060017F3 RID: 6131 RVA: 0x0002FCB8 File Offset: 0x0002DEB8
		// (set) Token: 0x060017F4 RID: 6132 RVA: 0x0002FCD0 File Offset: 0x0002DED0
		[ProtoMember(11, IsRequired = false, Name = "scenestate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SSceneState scenestate
		{
			get
			{
				return this._scenestate;
			}
			set
			{
				this._scenestate = value;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x060017F5 RID: 6133 RVA: 0x0002FCDC File Offset: 0x0002DEDC
		// (set) Token: 0x060017F6 RID: 6134 RVA: 0x0002FCF4 File Offset: 0x0002DEF4
		[ProtoMember(12, IsRequired = false, Name = "lrdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginReconnectEnterSceneData lrdata
		{
			get
			{
				return this._lrdata;
			}
			set
			{
				this._lrdata = value;
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x060017F7 RID: 6135 RVA: 0x0002FD00 File Offset: 0x0002DF00
		// (set) Token: 0x060017F8 RID: 6136 RVA: 0x0002FD30 File Offset: 0x0002DF30
		[ProtoMember(13, IsRequired = false, Name = "initface", DataFormat = DataFormat.FixedSize)]
		public float initface
		{
			get
			{
				return this._initface ?? 0f;
			}
			set
			{
				this._initface = new float?(value);
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x0002FD40 File Offset: 0x0002DF40
		// (set) Token: 0x060017FA RID: 6138 RVA: 0x0002FD60 File Offset: 0x0002DF60
		[XmlIgnore]
		[Browsable(false)]
		public bool initfaceSpecified
		{
			get
			{
				return this._initface != null;
			}
			set
			{
				bool flag = value == (this._initface == null);
				if (flag)
				{
					this._initface = (value ? new float?(this.initface) : null);
				}
			}
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0002FDA4 File Offset: 0x0002DFA4
		private bool ShouldSerializeinitface()
		{
			return this.initfaceSpecified;
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0002FDBC File Offset: 0x0002DFBC
		private void Resetinitface()
		{
			this.initfaceSpecified = false;
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x0002FDC8 File Offset: 0x0002DFC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005DF RID: 1503
		private uint? _fightgroup;

		// Token: 0x040005E0 RID: 1504
		private float? _face;

		// Token: 0x040005E1 RID: 1505
		private Vec3 _pos = null;

		// Token: 0x040005E2 RID: 1506
		private readonly List<UnitAppearance> _otherunits = new List<UnitAppearance>();

		// Token: 0x040005E3 RID: 1507
		private bool? _iswatchend;

		// Token: 0x040005E4 RID: 1508
		private ErrorCode? _errorcode;

		// Token: 0x040005E5 RID: 1509
		private OutLookState _state = null;

		// Token: 0x040005E6 RID: 1510
		private bool? _is_cross;

		// Token: 0x040005E7 RID: 1511
		private string _battlestamp;

		// Token: 0x040005E8 RID: 1512
		private uint? _specialstate;

		// Token: 0x040005E9 RID: 1513
		private SSceneState _scenestate = null;

		// Token: 0x040005EA RID: 1514
		private LoginReconnectEnterSceneData _lrdata = null;

		// Token: 0x040005EB RID: 1515
		private float? _initface;

		// Token: 0x040005EC RID: 1516
		private IExtension extensionObject;
	}
}
