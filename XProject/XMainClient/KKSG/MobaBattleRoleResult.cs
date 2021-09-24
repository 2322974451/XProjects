using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleRoleResult")]
	[Serializable]
	public class MobaBattleRoleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isWin", DataFormat = DataFormat.Default)]
		public bool isWin
		{
			get
			{
				return this._isWin ?? false;
			}
			set
			{
				this._isWin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isWinSpecified
		{
			get
			{
				return this._isWin != null;
			}
			set
			{
				bool flag = value == (this._isWin == null);
				if (flag)
				{
					this._isWin = (value ? new bool?(this.isWin) : null);
				}
			}
		}

		private bool ShouldSerializeisWin()
		{
			return this.isWinSpecified;
		}

		private void ResetisWin()
		{
			this.isWinSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		[ProtoMember(5, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isWin;

		private uint? _heroid;

		private float? _kda;

		private bool? _isescape;

		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
