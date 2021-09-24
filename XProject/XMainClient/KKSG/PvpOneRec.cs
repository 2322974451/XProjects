using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpOneRec")]
	[Serializable]
	public class PvpOneRec : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "wincount", DataFormat = DataFormat.TwosComplement)]
		public int wincount
		{
			get
			{
				return this._wincount ?? 0;
			}
			set
			{
				this._wincount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wincountSpecified
		{
			get
			{
				return this._wincount != null;
			}
			set
			{
				bool flag = value == (this._wincount == null);
				if (flag)
				{
					this._wincount = (value ? new int?(this.wincount) : null);
				}
			}
		}

		private bool ShouldSerializewincount()
		{
			return this.wincountSpecified;
		}

		private void Resetwincount()
		{
			this.wincountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "losecount", DataFormat = DataFormat.TwosComplement)]
		public int losecount
		{
			get
			{
				return this._losecount ?? 0;
			}
			set
			{
				this._losecount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losecountSpecified
		{
			get
			{
				return this._losecount != null;
			}
			set
			{
				bool flag = value == (this._losecount == null);
				if (flag)
				{
					this._losecount = (value ? new int?(this.losecount) : null);
				}
			}
		}

		private bool ShouldSerializelosecount()
		{
			return this.losecountSpecified;
		}

		private void Resetlosecount()
		{
			this.losecountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "drawcount", DataFormat = DataFormat.TwosComplement)]
		public int drawcount
		{
			get
			{
				return this._drawcount ?? 0;
			}
			set
			{
				this._drawcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool drawcountSpecified
		{
			get
			{
				return this._drawcount != null;
			}
			set
			{
				bool flag = value == (this._drawcount == null);
				if (flag)
				{
					this._drawcount = (value ? new int?(this.drawcount) : null);
				}
			}
		}

		private bool ShouldSerializedrawcount()
		{
			return this.drawcountSpecified;
		}

		private void Resetdrawcount()
		{
			this.drawcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "mvpID", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpID
		{
			get
			{
				return this._mvpID ?? 0UL;
			}
			set
			{
				this._mvpID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpIDSpecified
		{
			get
			{
				return this._mvpID != null;
			}
			set
			{
				bool flag = value == (this._mvpID == null);
				if (flag)
				{
					this._mvpID = (value ? new ulong?(this.mvpID) : null);
				}
			}
		}

		private bool ShouldSerializemvpID()
		{
			return this.mvpIDSpecified;
		}

		private void ResetmvpID()
		{
			this.mvpIDSpecified = false;
		}

		[ProtoMember(5, Name = "myside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> myside
		{
			get
			{
				return this._myside;
			}
		}

		[ProtoMember(6, Name = "opside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> opside
		{
			get
			{
				return this._opside;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "military", DataFormat = DataFormat.TwosComplement)]
		public uint military
		{
			get
			{
				return this._military ?? 0U;
			}
			set
			{
				this._military = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool militarySpecified
		{
			get
			{
				return this._military != null;
			}
			set
			{
				bool flag = value == (this._military == null);
				if (flag)
				{
					this._military = (value ? new uint?(this.military) : null);
				}
			}
		}

		private bool ShouldSerializemilitary()
		{
			return this.militarySpecified;
		}

		private void Resetmilitary()
		{
			this.militarySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _wincount;

		private int? _losecount;

		private int? _drawcount;

		private ulong? _mvpID;

		private readonly List<PvpRoleBrief> _myside = new List<PvpRoleBrief>();

		private readonly List<PvpRoleBrief> _opside = new List<PvpRoleBrief>();

		private uint? _military;

		private IExtension extensionObject;
	}
}
