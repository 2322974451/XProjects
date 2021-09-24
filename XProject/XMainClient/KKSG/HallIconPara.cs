using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HallIconPara")]
	[Serializable]
	public class HallIconPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public HallIconState state
		{
			get
			{
				return this._state ?? HallIconState.HICONS_BEGIN;
			}
			set
			{
				this._state = new HallIconState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new HallIconState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public int systemid
		{
			get
			{
				return this._systemid ?? 0;
			}
			set
			{
				this._systemid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new int?(this.systemid) : null);
				}
			}
		}

		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "liveInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LiveIconData liveInfo
		{
			get
			{
				return this._liveInfo;
			}
			set
			{
				this._liveInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private HallIconState? _state;

		private int? _systemid;

		private LiveIconData _liveInfo = null;

		private IExtension extensionObject;
	}
}
