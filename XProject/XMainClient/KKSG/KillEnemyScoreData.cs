using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KillEnemyScoreData")]
	[Serializable]
	public class KillEnemyScoreData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public int score
		{
			get
			{
				return this._score ?? 0;
			}
			set
			{
				this._score = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new int?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _score;

		private IExtension extensionObject;
	}
}
