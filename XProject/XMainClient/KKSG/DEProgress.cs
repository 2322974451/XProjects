using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DEProgress")]
	[Serializable]
	public class DEProgress : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bossavghppercent", DataFormat = DataFormat.TwosComplement)]
		public int bossavghppercent
		{
			get
			{
				return this._bossavghppercent ?? 0;
			}
			set
			{
				this._bossavghppercent = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bossavghppercentSpecified
		{
			get
			{
				return this._bossavghppercent != null;
			}
			set
			{
				bool flag = value == (this._bossavghppercent == null);
				if (flag)
				{
					this._bossavghppercent = (value ? new int?(this.bossavghppercent) : null);
				}
			}
		}

		private bool ShouldSerializebossavghppercent()
		{
			return this.bossavghppercentSpecified;
		}

		private void Resetbossavghppercent()
		{
			this.bossavghppercentSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public DEProgressState state
		{
			get
			{
				return this._state ?? DEProgressState.DEPS_FINISH;
			}
			set
			{
				this._state = new DEProgressState?(value);
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
					this._state = (value ? new DEProgressState?(this.state) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _sceneID;

		private int? _bossavghppercent;

		private DEProgressState? _state;

		private IExtension extensionObject;
	}
}
