using System;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class AffinitieCheckbox : Element
{
	public LokiPoe.StashTabAffinitiesEnum AffinitieEnum
	{
		get
		{
			string text = base.Children[0].Text;
			if (!string.IsNullOrEmpty(text))
			{
				return text switch
				{
					"Currency" => LokiPoe.StashTabAffinitiesEnum.Corrency, 
					"Divination Card" => LokiPoe.StashTabAffinitiesEnum.DivinationCards, 
					"Delve" => LokiPoe.StashTabAffinitiesEnum.Delve, 
					"Map" => LokiPoe.StashTabAffinitiesEnum.Map, 
					"Blight" => LokiPoe.StashTabAffinitiesEnum.Blight, 
					"Flask" => LokiPoe.StashTabAffinitiesEnum.Flask, 
					"Unique" => LokiPoe.StashTabAffinitiesEnum.Unique, 
					"Metamorph" => LokiPoe.StashTabAffinitiesEnum.Metamorph, 
					"Fragment" => LokiPoe.StashTabAffinitiesEnum.Fragment, 
					"Gem" => LokiPoe.StashTabAffinitiesEnum.Gem, 
					"Delirium" => LokiPoe.StashTabAffinitiesEnum.Delirium, 
					"Essence" => LokiPoe.StashTabAffinitiesEnum.Essence, 
					_ => throw new ArgumentNullException("AffinitieEnum"), 
				};
			}
			throw new ArgumentNullException("AffinitieEnum");
		}
	}

	public bool IsSelected => base.M.ReadByte(base.Children[1].Address + PremiumStashSettingElement._checkBoxOffset) == 1;

	public void ClickCheckBox()
	{
		Vector2i pos = base.Children[1].CenterClickLocation();
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(10);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(10);
	}
}
