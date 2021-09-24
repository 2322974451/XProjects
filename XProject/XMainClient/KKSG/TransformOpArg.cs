using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TransformOpArg")]
	[Serializable]
	public class TransformOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public int op
		{
			get
			{
				return this._op ?? 0;
			}
			set
			{
				this._op = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new int?(this.op) : null);
				}
			}
		}

		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		private void Resetop()
		{
			this.opSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.Default)]
		public string roleid
		{
			get
			{
				return this._roleid ?? "";
			}
			set
			{
				this._roleid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? this.roleid : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _op;

		private string _roleid;

		private uint? _itemid;

		private IExtension extensionObject;
	}
}
