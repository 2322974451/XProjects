using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActiveCookbookArg")]
	[Serializable]
	public class ActiveCookbookArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "cook_book_id", DataFormat = DataFormat.TwosComplement)]
		public uint cook_book_id
		{
			get
			{
				return this._cook_book_id ?? 0U;
			}
			set
			{
				this._cook_book_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cook_book_idSpecified
		{
			get
			{
				return this._cook_book_id != null;
			}
			set
			{
				bool flag = value == (this._cook_book_id == null);
				if (flag)
				{
					this._cook_book_id = (value ? new uint?(this.cook_book_id) : null);
				}
			}
		}

		private bool ShouldSerializecook_book_id()
		{
			return this.cook_book_idSpecified;
		}

		private void Resetcook_book_id()
		{
			this.cook_book_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _garden_id;

		private uint? _cook_book_id;

		private IExtension extensionObject;
	}
}
