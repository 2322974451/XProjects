using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatParamSpectate")]
	[Serializable]
	public class ChatParamSpectate : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "livetype", DataFormat = DataFormat.TwosComplement)]
		public uint livetype
		{
			get
			{
				return this._livetype ?? 0U;
			}
			set
			{
				this._livetype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool livetypeSpecified
		{
			get
			{
				return this._livetype != null;
			}
			set
			{
				bool flag = value == (this._livetype == null);
				if (flag)
				{
					this._livetype = (value ? new uint?(this.livetype) : null);
				}
			}
		}

		private bool ShouldSerializelivetype()
		{
			return this.livetypeSpecified;
		}

		private void Resetlivetype()
		{
			this.livetypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _liveid;

		private uint? _livetype;

		private IExtension extensionObject;
	}
}
