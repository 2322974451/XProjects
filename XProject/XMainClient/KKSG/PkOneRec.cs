using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkOneRec")]
	[Serializable]
	public class PkOneRec : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public PkResultType ret
		{
			get
			{
				return this._ret ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._ret = new PkResultType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new PkResultType?(this.ret) : null);
				}
			}
		}

		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		private void Resetret()
		{
			this.retSpecified = false;
		}

		[ProtoMember(2, Name = "myside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> myside
		{
			get
			{
				return this._myside;
			}
		}

		[ProtoMember(3, Name = "opside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> opside
		{
			get
			{
				return this._opside;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "cpoint", DataFormat = DataFormat.TwosComplement)]
		public int cpoint
		{
			get
			{
				return this._cpoint ?? 0;
			}
			set
			{
				this._cpoint = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cpointSpecified
		{
			get
			{
				return this._cpoint != null;
			}
			set
			{
				bool flag = value == (this._cpoint == null);
				if (flag)
				{
					this._cpoint = (value ? new int?(this.cpoint) : null);
				}
			}
		}

		private bool ShouldSerializecpoint()
		{
			return this.cpointSpecified;
		}

		private void Resetcpoint()
		{
			this.cpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkResultType? _ret;

		private readonly List<PvpRoleBrief> _myside = new List<PvpRoleBrief>();

		private readonly List<PvpRoleBrief> _opside = new List<PvpRoleBrief>();

		private int? _cpoint;

		private IExtension extensionObject;
	}
}
