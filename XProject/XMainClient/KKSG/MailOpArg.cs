using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MailOpArg")]
	[Serializable]
	public class MailOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "optype", DataFormat = DataFormat.TwosComplement)]
		public uint optype
		{
			get
			{
				return this._optype ?? 0U;
			}
			set
			{
				this._optype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool optypeSpecified
		{
			get
			{
				return this._optype != null;
			}
			set
			{
				bool flag = value == (this._optype == null);
				if (flag)
				{
					this._optype = (value ? new uint?(this.optype) : null);
				}
			}
		}

		private bool ShouldSerializeoptype()
		{
			return this.optypeSpecified;
		}

		private void Resetoptype()
		{
			this.optypeSpecified = false;
		}

		[ProtoMember(2, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uid
		{
			get
			{
				return this._uid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _optype;

		private readonly List<ulong> _uid = new List<ulong>();

		private IExtension extensionObject;
	}
}
