using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class BlightDefensiveTower : Monster
{
	public int Tier
	{
		get
		{
			switch (Name)
			{
			case "Tower Foundation":
				return 0;
			case "Chilling Tower Mk III":
			case "Shock Nova Tower Mk III":
			case "Seismic Tower Mk III":
			case "Empowering Tower Mk III":
			case "Fireball Tower Mk III":
			case "Summoning Tower Mk III":
				return 3;
			case "Chilling Tower Mk II":
			case "Empowering Tower Mk II":
			case "Seismic Tower Mk II":
			case "Summoning Tower Mk II":
			case "Shock Nova Tower Mk II":
			case "Fireball Tower Mk II":
				return 2;
			case "Shock Nova Tower Mk I":
			case "Fireball Tower Mk I":
			case "Chilling Tower Mk I":
			case "Seismic Tower Mk I":
			case "Empowering Tower Mk I":
			case "Summoning Tower Mk I":
				return 1;
			default:
				return 0;
			case "Scout Tower":
			case "Freezebolt Tower":
			case "Sentinel Tower":
			case "Flamethrower Tower":
			case "Glacial Cage Tower":
			case "Meteor Tower":
			case "Imbuing Tower":
			case "Lightning Storm Tower":
			case "Stone Gaze Tower":
			case "Temporal Tower":
			case "Arc Tower":
			case "Smothering Tower":
				return 4;
			}
		}
	}

	public BlightTowerElement Ui
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (!(itemsOnGroundLabelElement == null))
			{
				Element label = itemsOnGroundLabelElement.Label;
				if (label == null)
				{
					return null;
				}
				return label.GetObjectAt<BlightTowerElement>(0);
			}
			return null;
		}
	}

	internal BlightDefensiveTower(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public bool Upgrade(string selectedId = "")
	{
		List<BlightTowerOption> menu = Ui.Menu;
		BlightTowerOption blightTowerOption = (string.IsNullOrEmpty(selectedId) ? menu.FirstOrDefault() : ((menu.Count > 1) ? Ui.Menu.FirstOrDefault((BlightTowerOption x) => x.Id == selectedId) : menu.FirstOrDefault()));
		if (!(blightTowerOption == null))
		{
			Vector2i elementClickLocation = blightTowerOption.ElementClickLocation;
			MouseManager.SetMousePosition(elementClickLocation, useRandomPos: false);
			Thread.Sleep(30);
			MouseManager.ClickLMB(elementClickLocation.X, elementClickLocation.Y);
			Thread.Sleep(30);
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Tower]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tTier: {Tier}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine($"\t[Upgrades]");
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine($"\t\tId: {item.Id}");
				stringBuilder.AppendLine($"\t\tName: {item.Name}");
				stringBuilder.AppendLine($"\t\tDescription: {item.Description}");
				stringBuilder.AppendLine($"\t\tIcon: {item.Icon}");
				stringBuilder.AppendLine($"\t\tCost: {item.Cost}");
				stringBuilder.AppendLine($"\t\tIsVisible: {item.IsVisible}");
				stringBuilder.AppendLine($"\t\tIsVisibleLocal: {item.IsVisibleLocal}");
			}
		}
		return stringBuilder.ToString();
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Tower]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tTier: {Tier}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine($"\t[Upgrades]");
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine($"\t\tId: {item.Id}");
				stringBuilder.AppendLine($"\t\tName: {item.Name}");
				stringBuilder.AppendLine($"\t\tDescription: {item.Description}");
				stringBuilder.AppendLine($"\t\tIcon: {item.Icon}");
				stringBuilder.AppendLine($"\t\tCost: {item.Cost}");
			}
		}
		return stringBuilder.ToString();
	}
}
