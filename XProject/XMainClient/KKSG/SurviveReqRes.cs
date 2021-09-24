using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SurviveReqRes")]
	[Serializable]
	public class SurviveReqRes : IExtensible
	{

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

		[ProtoMember(2, IsRequired = false, Name = "givereward", DataFormat = DataFormat.Default)]
		public bool givereward
		{
			get
			{
				return this._givereward ?? false;
			}
			set
			{
				this._givereward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool giverewardSpecified
		{
			get
			{
				return this._givereward != null;
			}
			set
			{
				bool flag = value == (this._givereward == null);
				if (flag)
				{
					this._givereward = (value ? new bool?(this.givereward) : null);
				}
			}
		}

		private bool ShouldSerializegivereward()
		{
			return this.giverewardSpecified;
		}

		private void Resetgivereward()
		{
			this.giverewardSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "curtopcount", DataFormat = DataFormat.TwosComplement)]
		public uint curtopcount
		{
			get
			{
				return this._curtopcount ?? 0U;
			}
			set
			{
				this._curtopcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curtopcountSpecified
		{
			get
			{
				return this._curtopcount != null;
			}
			set
			{
				bool flag = value == (this._curtopcount == null);
				if (flag)
				{
					this._curtopcount = (value ? new uint?(this.curtopcount) : null);
				}
			}
		}

		private bool ShouldSerializecurtopcount()
		{
			return this.curtopcountSpecified;
		}

		private void Resetcurtopcount()
		{
			this.curtopcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "needtopcount", DataFormat = DataFormat.TwosComplement)]
		public uint needtopcount
		{
			get
			{
				return this._needtopcount ?? 0U;
			}
			set
			{
				this._needtopcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needtopcountSpecified
		{
			get
			{
				return this._needtopcount != null;
			}
			set
			{
				bool flag = value == (this._needtopcount == null);
				if (flag)
				{
					this._needtopcount = (value ? new uint?(this.needtopcount) : null);
				}
			}
		}

		private bool ShouldSerializeneedtopcount()
		{
			return this.needtopcountSpecified;
		}

		private void Resetneedtopcount()
		{
			this.needtopcountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private bool? _givereward;

		private uint? _curtopcount;

		private uint? _needtopcount;

		private uint? _point;

		private IExtension extensionObject;
	}
}
