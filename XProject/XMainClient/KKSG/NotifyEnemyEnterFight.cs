using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyEnemyEnterFight")]
	[Serializable]
	public class NotifyEnemyEnterFight : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "enterfight", DataFormat = DataFormat.Default)]
		public bool enterfight
		{
			get
			{
				return this._enterfight ?? false;
			}
			set
			{
				this._enterfight = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enterfightSpecified
		{
			get
			{
				return this._enterfight != null;
			}
			set
			{
				bool flag = value == (this._enterfight == null);
				if (flag)
				{
					this._enterfight = (value ? new bool?(this.enterfight) : null);
				}
			}
		}

		private bool ShouldSerializeenterfight()
		{
			return this.enterfightSpecified;
		}

		private void Resetenterfight()
		{
			this.enterfightSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "enemyid", DataFormat = DataFormat.TwosComplement)]
		public ulong enemyid
		{
			get
			{
				return this._enemyid ?? 0UL;
			}
			set
			{
				this._enemyid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enemyidSpecified
		{
			get
			{
				return this._enemyid != null;
			}
			set
			{
				bool flag = value == (this._enemyid == null);
				if (flag)
				{
					this._enemyid = (value ? new ulong?(this.enemyid) : null);
				}
			}
		}

		private bool ShouldSerializeenemyid()
		{
			return this.enemyidSpecified;
		}

		private void Resetenemyid()
		{
			this.enemyidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _enterfight;

		private ulong? _enemyid;

		private IExtension extensionObject;
	}
}
