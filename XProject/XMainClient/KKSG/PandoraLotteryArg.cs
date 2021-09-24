using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PandoraLotteryArg")]
	[Serializable]
	public class PandoraLotteryArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pandoraid", DataFormat = DataFormat.TwosComplement)]
		public uint pandoraid
		{
			get
			{
				return this._pandoraid ?? 0U;
			}
			set
			{
				this._pandoraid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pandoraidSpecified
		{
			get
			{
				return this._pandoraid != null;
			}
			set
			{
				bool flag = value == (this._pandoraid == null);
				if (flag)
				{
					this._pandoraid = (value ? new uint?(this.pandoraid) : null);
				}
			}
		}

		private bool ShouldSerializepandoraid()
		{
			return this.pandoraidSpecified;
		}

		private void Resetpandoraid()
		{
			this.pandoraidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isOneLottery", DataFormat = DataFormat.Default)]
		public bool isOneLottery
		{
			get
			{
				return this._isOneLottery ?? false;
			}
			set
			{
				this._isOneLottery = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isOneLotterySpecified
		{
			get
			{
				return this._isOneLottery != null;
			}
			set
			{
				bool flag = value == (this._isOneLottery == null);
				if (flag)
				{
					this._isOneLottery = (value ? new bool?(this.isOneLottery) : null);
				}
			}
		}

		private bool ShouldSerializeisOneLottery()
		{
			return this.isOneLotterySpecified;
		}

		private void ResetisOneLottery()
		{
			this.isOneLotterySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _pandoraid;

		private bool? _isOneLottery;

		private IExtension extensionObject;
	}
}
