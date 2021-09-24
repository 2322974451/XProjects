using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AddLevelScriptExtString")]
	[Serializable]
	public class AddLevelScriptExtString : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "extString", DataFormat = DataFormat.Default)]
		public string extString
		{
			get
			{
				return this._extString ?? "";
			}
			set
			{
				this._extString = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extStringSpecified
		{
			get
			{
				return this._extString != null;
			}
			set
			{
				bool flag = value == (this._extString == null);
				if (flag)
				{
					this._extString = (value ? this.extString : null);
				}
			}
		}

		private bool ShouldSerializeextString()
		{
			return this.extStringSpecified;
		}

		private void ResetextString()
		{
			this.extStringSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sceneTempID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneTempID
		{
			get
			{
				return this._sceneTempID ?? 0U;
			}
			set
			{
				this._sceneTempID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneTempIDSpecified
		{
			get
			{
				return this._sceneTempID != null;
			}
			set
			{
				bool flag = value == (this._sceneTempID == null);
				if (flag)
				{
					this._sceneTempID = (value ? new uint?(this.sceneTempID) : null);
				}
			}
		}

		private bool ShouldSerializesceneTempID()
		{
			return this.sceneTempIDSpecified;
		}

		private void ResetsceneTempID()
		{
			this.sceneTempIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "waveID", DataFormat = DataFormat.TwosComplement)]
		public int waveID
		{
			get
			{
				return this._waveID ?? 0;
			}
			set
			{
				this._waveID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool waveIDSpecified
		{
			get
			{
				return this._waveID != null;
			}
			set
			{
				bool flag = value == (this._waveID == null);
				if (flag)
				{
					this._waveID = (value ? new int?(this.waveID) : null);
				}
			}
		}

		private bool ShouldSerializewaveID()
		{
			return this.waveIDSpecified;
		}

		private void ResetwaveID()
		{
			this.waveIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _extString;

		private uint? _sceneTempID;

		private int? _waveID;

		private IExtension extensionObject;
	}
}
