using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DoEnterSceneRes")]
	[Serializable]
	public class DoEnterSceneRes : IExtensible
	{

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

		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

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

		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		private void Resetface()
		{
			this.faceSpecified = false;
		}

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

		[ProtoMember(4, Name = "otherunits", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> otherunits
		{
			get
			{
				return this._otherunits;
			}
		}

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

		private bool ShouldSerializeiswatchend()
		{
			return this.iswatchendSpecified;
		}

		private void Resetiswatchend()
		{
			this.iswatchendSpecified = false;
		}

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

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

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

		private bool ShouldSerializeis_cross()
		{
			return this.is_crossSpecified;
		}

		private void Resetis_cross()
		{
			this.is_crossSpecified = false;
		}

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

		private bool ShouldSerializebattlestamp()
		{
			return this.battlestampSpecified;
		}

		private void Resetbattlestamp()
		{
			this.battlestampSpecified = false;
		}

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

		private bool ShouldSerializespecialstate()
		{
			return this.specialstateSpecified;
		}

		private void Resetspecialstate()
		{
			this.specialstateSpecified = false;
		}

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

		private bool ShouldSerializeinitface()
		{
			return this.initfaceSpecified;
		}

		private void Resetinitface()
		{
			this.initfaceSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _fightgroup;

		private float? _face;

		private Vec3 _pos = null;

		private readonly List<UnitAppearance> _otherunits = new List<UnitAppearance>();

		private bool? _iswatchend;

		private ErrorCode? _errorcode;

		private OutLookState _state = null;

		private bool? _is_cross;

		private string _battlestamp;

		private uint? _specialstate;

		private SSceneState _scenestate = null;

		private LoginReconnectEnterSceneData _lrdata = null;

		private float? _initface;

		private IExtension extensionObject;
	}
}
