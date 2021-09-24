using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ComAgate")]
	[Serializable]
	public class ComAgate : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "itemId", DataFormat = DataFormat.TwosComplement)]
		public uint itemId
		{
			get
			{
				return this._itemId ?? 0U;
			}
			set
			{
				this._itemId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemIdSpecified
		{
			get
			{
				return this._itemId != null;
			}
			set
			{
				bool flag = value == (this._itemId == null);
				if (flag)
				{
					this._itemId = (value ? new uint?(this.itemId) : null);
				}
			}
		}

		private bool ShouldSerializeitemId()
		{
			return this.itemIdSpecified;
		}

		private void ResetitemId()
		{
			this.itemIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "comNum", DataFormat = DataFormat.TwosComplement)]
		public uint comNum
		{
			get
			{
				return this._comNum ?? 0U;
			}
			set
			{
				this._comNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool comNumSpecified
		{
			get
			{
				return this._comNum != null;
			}
			set
			{
				bool flag = value == (this._comNum == null);
				if (flag)
				{
					this._comNum = (value ? new uint?(this.comNum) : null);
				}
			}
		}

		private bool ShouldSerializecomNum()
		{
			return this.comNumSpecified;
		}

		private void ResetcomNum()
		{
			this.comNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _itemId;

		private uint? _comNum;

		private IExtension extensionObject;
	}
}
