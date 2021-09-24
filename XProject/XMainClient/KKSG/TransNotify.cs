using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TransNotify")]
	[Serializable]
	public class TransNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "istrans", DataFormat = DataFormat.Default)]
		public bool istrans
		{
			get
			{
				return this._istrans ?? false;
			}
			set
			{
				this._istrans = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool istransSpecified
		{
			get
			{
				return this._istrans != null;
			}
			set
			{
				bool flag = value == (this._istrans == null);
				if (flag)
				{
					this._istrans = (value ? new bool?(this.istrans) : null);
				}
			}
		}

		private bool ShouldSerializeistrans()
		{
			return this.istransSpecified;
		}

		private void Resetistrans()
		{
			this.istransSpecified = false;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _istrans;

		private string _roleid;

		private IExtension extensionObject;
	}
}
