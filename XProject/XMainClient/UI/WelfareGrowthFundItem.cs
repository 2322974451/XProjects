using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class WelfareGrowthFundItem
	{

		public void Init(Transform tf)
		{
			this.m_transform = tf;
			this.m_getBtn = (tf.FindChild("Recharge").GetComponent("XUIButton") as IXUIButton);
			this.m_contentLabel = (tf.FindChild("Content").GetComponent("XUILabel") as IXUILabel);
			this.m_valueLabel = (tf.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_messageLabel = (tf.FindChild("Message").GetComponent("XUILabel") as IXUILabel);
			this.m_hasBuySprite = (tf.FindChild("HasBuy").GetComponent("XUISprite") as IXUISprite);
			this.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGetHandler));
		}

		private bool OnClickGetHandler(IXUIButton btn)
		{
			bool flag = this.m_type == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument.GetGrowthFundAward(this.m_type, this.m_key);
				result = true;
			}
			return result;
		}

		public void Set(int type, int key, int value)
		{
			this.m_type = type;
			this.m_key = key;
			this.m_value = value;
			this.m_valueLabel.SetText(this.m_value.ToString());
			bool flag = this.m_type == 0;
			if (flag)
			{
				this.m_contentLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_CONTENT"));
			}
			else
			{
				this.m_contentLabel.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("WELFARE_GROWTHFUND_CONTENT", this.m_type.ToString()), new object[]
				{
					this.m_key
				}));
			}
		}

		public void Refresh()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = !specificDocument.HasBuyGrowthFund;
			if (flag)
			{
				this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_ERROR"));
				this.m_getBtn.SetVisible(false);
				this.m_hasBuySprite.SetVisible(false);
			}
			else
			{
				bool flag2 = this.m_type == 0;
				if (flag2)
				{
					this.m_hasBuySprite.SetVisible(true);
					this.m_getBtn.SetVisible(false);
					this.m_messageLabel.SetText(string.Empty);
				}
				else
				{
					bool flag3 = specificDocument.HasGrowthFundGet(this.m_type, this.m_key);
					if (flag3)
					{
						this.m_hasBuySprite.SetVisible(true);
						this.m_messageLabel.SetText(string.Empty);
						this.m_getBtn.SetVisible(false);
					}
					else
					{
						this.m_hasBuySprite.SetVisible(false);
						bool flag4 = this.m_type == 1;
						if (flag4)
						{
							int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
							bool flag5 = level < this.m_key;
							if (flag5)
							{
								this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_MESSAGE1", new object[]
								{
									this.m_key - level
								}));
								this.m_getBtn.SetVisible(false);
							}
							else
							{
								this.m_messageLabel.SetText(string.Empty);
								this.m_getBtn.SetVisible(true);
							}
						}
						else
						{
							bool flag6 = this.m_type == 2;
							if (flag6)
							{
								int loginDayCount = specificDocument.LoginDayCount;
								bool flag7 = loginDayCount < this.m_key;
								if (flag7)
								{
									this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_MESSAGE2", new object[]
									{
										this.m_key - loginDayCount
									}));
									this.m_getBtn.SetVisible(false);
								}
								else
								{
									this.m_messageLabel.SetText(string.Empty);
									this.m_getBtn.SetVisible(true);
								}
							}
							else
							{
								this.m_messageLabel.SetText(string.Empty);
								this.m_getBtn.SetVisible(false);
							}
						}
					}
				}
			}
		}

		private Transform m_transform;

		private IXUIButton m_getBtn;

		private IXUILabel m_contentLabel;

		private IXUILabel m_valueLabel;

		private IXUILabel m_messageLabel;

		private IXUISprite m_hasBuySprite;

		private int m_type;

		private int m_key;

		private int m_value;
	}
}
