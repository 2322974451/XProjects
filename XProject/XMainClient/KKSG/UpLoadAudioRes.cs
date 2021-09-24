using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpLoadAudioRes")]
	[Serializable]
	public class UpLoadAudioRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "audiodownuid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiodownuid
		{
			get
			{
				return this._audiodownuid ?? 0UL;
			}
			set
			{
				this._audiodownuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audiodownuidSpecified
		{
			get
			{
				return this._audiodownuid != null;
			}
			set
			{
				bool flag = value == (this._audiodownuid == null);
				if (flag)
				{
					this._audiodownuid = (value ? new ulong?(this.audiodownuid) : null);
				}
			}
		}

		private bool ShouldSerializeaudiodownuid()
		{
			return this.audiodownuidSpecified;
		}

		private void Resetaudiodownuid()
		{
			this.audiodownuidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private ulong? _audiodownuid;

		private IExtension extensionObject;
	}
}
