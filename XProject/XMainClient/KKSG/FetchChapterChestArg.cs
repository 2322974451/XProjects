using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchChapterChestArg")]
	[Serializable]
	public class FetchChapterChestArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "chapterID", DataFormat = DataFormat.TwosComplement)]
		public int chapterID
		{
			get
			{
				return this._chapterID ?? 0;
			}
			set
			{
				this._chapterID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chapterIDSpecified
		{
			get
			{
				return this._chapterID != null;
			}
			set
			{
				bool flag = value == (this._chapterID == null);
				if (flag)
				{
					this._chapterID = (value ? new int?(this.chapterID) : null);
				}
			}
		}

		private bool ShouldSerializechapterID()
		{
			return this.chapterIDSpecified;
		}

		private void ResetchapterID()
		{
			this.chapterIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "chestID", DataFormat = DataFormat.TwosComplement)]
		public int chestID
		{
			get
			{
				return this._chestID ?? 0;
			}
			set
			{
				this._chestID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chestIDSpecified
		{
			get
			{
				return this._chestID != null;
			}
			set
			{
				bool flag = value == (this._chestID == null);
				if (flag)
				{
					this._chestID = (value ? new int?(this.chestID) : null);
				}
			}
		}

		private bool ShouldSerializechestID()
		{
			return this.chestIDSpecified;
		}

		private void ResetchestID()
		{
			this.chestIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _chapterID;

		private int? _chestID;

		private IExtension extensionObject;
	}
}
