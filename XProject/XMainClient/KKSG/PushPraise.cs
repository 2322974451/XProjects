using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PushPraise")]
	[Serializable]
	public class PushPraise : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CommentType type
		{
			get
			{
				return this._type ?? CommentType.COMMENT_NEST;
			}
			set
			{
				this._type = new CommentType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new CommentType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "spriteid", DataFormat = DataFormat.TwosComplement)]
		public uint spriteid
		{
			get
			{
				return this._spriteid ?? 0U;
			}
			set
			{
				this._spriteid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool spriteidSpecified
		{
			get
			{
				return this._spriteid != null;
			}
			set
			{
				bool flag = value == (this._spriteid == null);
				if (flag)
				{
					this._spriteid = (value ? new uint?(this.spriteid) : null);
				}
			}
		}

		private bool ShouldSerializespriteid()
		{
			return this.spriteidSpecified;
		}

		private void Resetspriteid()
		{
			this.spriteidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CommentType? _type;

		private uint? _spriteid;

		private IExtension extensionObject;
	}
}
