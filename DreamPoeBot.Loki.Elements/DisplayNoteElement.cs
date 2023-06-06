using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class DisplayNoteElement : Element
{
	public Element TextLabel => base.Children[0].Children[0].Children[1].Children[1].Children[0];

	private Element ComboBoxElement => base.Children[0]?.Children[0]?.Children[1]?.Children[0];

	public Vector2i TextPos
	{
		get
		{
			Vector2i vector2i = LokiPoe.ElementClickLocation(TextLabel);
			int num = (int)((double)TextLabel.Width * 0.4 * (double)base.Scale);
			return new Vector2i(vector2i.X + num, vector2i.Y);
		}
	}

	public Element Confirm => base.Children[0].Children[0].Children[2];

	public Vector2i ConfirmPos => LokiPoe.ElementClickLocation(Confirm);

	public Element ComboboxButton => ComboBoxElement.Children[1];

	public Vector2i ComboboxButtonPos => LokiPoe.ElementClickLocation(ComboboxButton);

	public bool IsComboboxOpen => LokiPoe.Memory.ReadByte(ComboBoxElement.Address + 956L) == 1;

	public string ComboboxSelectedItem
	{
		get
		{
			byte b = LokiPoe.Memory.ReadByte(ComboBoxElement.Address + 948L);
			uint num = default(uint);
			while (true)
			{
				switch (b)
				{
				default:
				{
					int num2 = (int)((num * 1756087016) ^ 0x582299B2);
					while (true)
					{
						switch ((num = (uint)num2 ^ 0x8BDA3EF8u) % 8u)
						{
						case 2u:
							num2 = (int)((num * 211453031) ^ 0x1A69C666);
							continue;
						case 1u:
						case 7u:
							break;
						default:
							return "";
						case 5u:
							goto IL_008d;
						case 3u:
							goto IL_0093;
						case 6u:
							goto IL_0099;
						case 4u:
							goto end_IL_0070;
						}
						break;
					}
					continue;
				}
				case 0:
					goto IL_008d;
				case 1:
					goto IL_0093;
				case 2:
					goto IL_0099;
				case 3:
					break;
					IL_008d:
					return "Note";
					IL_0099:
					return "Exact Price";
					IL_0093:
					return "Negotiable Price";
					end_IL_0070:
					break;
				}
				break;
			}
			return "Do Not Index";
		}
	}
}
