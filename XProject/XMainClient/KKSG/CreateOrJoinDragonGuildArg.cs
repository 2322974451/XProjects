using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CreateOrJoinDragonGuildArg")]
	[Serializable]
	public class CreateOrJoinDragonGuildArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "iscreate", DataFormat = DataFormat.Default)]
		public bool iscreate
		{
			get
			{
				return this._iscreate ?? false;
			}
			set
			{
				this._iscreate = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscreateSpecified
		{
			get
			{
				return this._iscreate != null;
			}
			set
			{
				bool flag = value == (this._iscreate == null);
				if (flag)
				{
					this._iscreate = (value ? new bool?(this.iscreate) : null);
				}
			}
		}

		private bool ShouldSerializeiscreate()
		{
			return this.iscreateSpecified;
		}

		private void Resetiscreate()
		{
			this.iscreateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dgname", DataFormat = DataFormat.Default)]
		public string dgname
		{
			get
			{
				return this._dgname ?? "";
			}
			set
			{
				this._dgname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dgnameSpecified
		{
			get
			{
				return this._dgname != null;
			}
			set
			{
				bool flag = value == (this._dgname == null);
				if (flag)
				{
					this._dgname = (value ? this.dgname : null);
				}
			}
		}

		private bool ShouldSerializedgname()
		{
			return this.dgnameSpecified;
		}

		private void Resetdgname()
		{
			this.dgnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _iscreate;

		private ulong? _dgid;

		private string _dgname;

		private IExtension extensionObject;
	}
}
