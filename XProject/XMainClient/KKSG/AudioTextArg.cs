using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AudioTextArg")]
	[Serializable]
	public class AudioTextArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "file_id", DataFormat = DataFormat.Default)]
		public string file_id
		{
			get
			{
				return this._file_id ?? "";
			}
			set
			{
				this._file_id = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool file_idSpecified
		{
			get
			{
				return this._file_id != null;
			}
			set
			{
				bool flag = value == (this._file_id == null);
				if (flag)
				{
					this._file_id = (value ? this.file_id : null);
				}
			}
		}

		private bool ShouldSerializefile_id()
		{
			return this.file_idSpecified;
		}

		private void Resetfile_id()
		{
			this.file_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _file_id;

		private IExtension extensionObject;
	}
}
