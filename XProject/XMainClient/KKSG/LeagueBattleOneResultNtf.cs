using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleOneResultNtf")]
	[Serializable]
	public class LeagueBattleOneResultNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "winrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief winrole
		{
			get
			{
				return this._winrole;
			}
			set
			{
				this._winrole = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "loserole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief loserole
		{
			get
			{
				return this._loserole;
			}
			set
			{
				this._loserole = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "winhppercent", DataFormat = DataFormat.FixedSize)]
		public float winhppercent
		{
			get
			{
				return this._winhppercent ?? 0f;
			}
			set
			{
				this._winhppercent = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winhppercentSpecified
		{
			get
			{
				return this._winhppercent != null;
			}
			set
			{
				bool flag = value == (this._winhppercent == null);
				if (flag)
				{
					this._winhppercent = (value ? new float?(this.winhppercent) : null);
				}
			}
		}

		private bool ShouldSerializewinhppercent()
		{
			return this.winhppercentSpecified;
		}

		private void Resetwinhppercent()
		{
			this.winhppercentSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "losehppercent", DataFormat = DataFormat.FixedSize)]
		public float losehppercent
		{
			get
			{
				return this._losehppercent ?? 0f;
			}
			set
			{
				this._losehppercent = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losehppercentSpecified
		{
			get
			{
				return this._losehppercent != null;
			}
			set
			{
				bool flag = value == (this._losehppercent == null);
				if (flag)
				{
					this._losehppercent = (value ? new float?(this.losehppercent) : null);
				}
			}
		}

		private bool ShouldSerializelosehppercent()
		{
			return this.losehppercentSpecified;
		}

		private void Resetlosehppercent()
		{
			this.losehppercentSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LeagueBattleRoleBrief _winrole = null;

		private LeagueBattleRoleBrief _loserole = null;

		private float? _winhppercent;

		private float? _losehppercent;

		private IExtension extensionObject;
	}
}
